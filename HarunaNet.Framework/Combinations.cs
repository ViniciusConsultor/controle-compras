using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Combinations defines a meta-collection, typically a list of lists, of all possible 
    /// subsets of a particular size from the set of values.  This list is enumerable and 
    /// allows the scanning of all possible combinations using a simple foreach() loop.
    /// </summary>
    /// <typeparam name="T">The type of the values within the list.</typeparam>
    public class Combinations<T> : IMetaCollection<T>
    {
        #region Constructors

        /// <summary>
        /// No default constructor, must provided a list of values and size.
        /// </summary>
        protected Combinations()
        {

        }

        /// <summary>
        /// Create a combination set from the provided list of values.
        /// The upper index is calculated as values.Count, the lower index is specified.
        /// Collection type defaults to MetaCollectionType.WithoutRepetition
        /// </summary>
        /// <param name="values">List of values to select combinations from.</param>
        /// <param name="lowerIndex">The size of each combination set to return.</param>
        public Combinations(IList<T> values, int lowerIndex)
        {
            Initialize(values, lowerIndex, GenerateOption.WithoutRepetition);
        }

        /// <summary>
        /// Create a combination set from the provided list of values.
        /// The upper index is calculated as values.Count, the lower index is specified.
        /// </summary>
        /// <param name="values">List of values to select combinations from.</param>
        /// <param name="lowerIndex">The size of each combination set to return.</param>
        /// <param name="type">The type of Combinations set to generate.</param>
        public Combinations(IList<T> values, int lowerIndex, GenerateOption type)
        {
            Initialize(values, lowerIndex, type);
        }

        #endregion

        #region IEnumerable Interface

        /// <summary>
        /// Gets an enumerator for collecting the list of combinations.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<IList<T>> GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Gets an enumerator for collecting the list of combinations.
        /// </summary>
        /// <returns>The enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        #endregion

        #region Enumerator Inner Class

        /// <summary>
        /// The enumerator that enumerates each meta-collection of the enclosing Combinations class.
        /// </summary>
        public class Enumerator : IEnumerator<IList<T>>
        {

            #region Constructors

            /// <summary>
            /// Construct a enumerator with the parent object.
            /// </summary>
            /// <param name="source">The source combinations object.</param>
            public Enumerator(Combinations<T> source)
            {
                myParent = source;
                myPermutationsEnumerator = (Permutations<bool>.Enumerator)myParent.myPermutations.GetEnumerator();
            }

            #endregion

            #region IEnumerator interface
            /// <summary>
            /// Resets the combinations enumerator to the first combination.  
            /// </summary>
            public void Reset()
            {
                myPermutationsEnumerator.Reset();
            }

            /// <summary>
            /// Advances to the next combination of items from the set.
            /// </summary>
            /// <returns>True if successfully moved to next combination, False if no more unique combinations exist.</returns>
            public bool MoveNext()
            {
                bool ret = myPermutationsEnumerator.MoveNext();
                myCurrentList = null;
                return ret;
            }

            /// <summary>
            /// The current combination
            /// </summary>
            public IList<T> Current
            {
                get
                {
                    ComputeCurrent();
                    return myCurrentList;
                }
            }

            /// <summary>
            /// The current combination
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    ComputeCurrent();
                    return myCurrentList;
                }
            }

            /// <summary>
            /// Cleans up non-managed resources, of which there are none used here.
            /// </summary>
            public void Dispose()
            {

            }

            #endregion


            /// <summary>
            /// ComputeCurrent() creates a list of original
            /// values from the bool permutation provided.  
            /// </summary>
            private void ComputeCurrent()
            {
                if (myCurrentList == null)
                {
                    myCurrentList = new List<T>();
                    int index = 0;
                    IList<bool> currentPermutation = (IList<bool>)myPermutationsEnumerator.Current;
                    for (int i = 0; i < currentPermutation.Count; ++i)
                    {
                        if (currentPermutation[i] == false)
                        {
                            myCurrentList.Add(myParent.myValues[index]);
                            if (myParent.Type == GenerateOption.WithoutRepetition)
                            {
                                ++index;
                            }
                        }
                        else
                        {
                            ++index;
                        }
                    }
                }
            }

            #region Data

            /// <summary>
            /// Parent object this is an enumerator for.
            /// </summary>
            private Combinations<T> myParent;

            /// <summary>
            /// The current list of values, this is lazy evaluated by the Current property.
            /// </summary>
            private List<T> myCurrentList;

            /// <summary>
            /// An enumertor of the parents list of lexicographic orderings.
            /// </summary>
            private Permutations<bool>.Enumerator myPermutationsEnumerator;

            #endregion
        }
        #endregion

        #region IMetaList Interface

        /// <summary>
        /// The number of unique combinations that are defined in this meta-collection.
        /// </summary>
        public long Count
        {
            get
            {
                return myPermutations.Count;
            }
        }

        /// <summary>
        /// The type of Combinations set that is generated.
        /// </summary>
        public GenerateOption Type
        {
            get
            {
                return myMetaCollectionType;
            }
        }

        /// <summary>
        /// The upper index of the meta-collection, equal to the number of items in the initial set.
        /// </summary>
        public int UpperIndex
        {
            get
            {
                return myValues.Count;
            }
        }

        /// <summary>
        /// The lower index of the meta-collection, equal to the number of items returned each iteration.
        /// </summary>
        public int LowerIndex
        {
            get
            {
                return myLowerIndex;
            }
        }

        #endregion

        #region Initialize

        /// <summary>
        /// Initialize the combinations by settings a copy of the values from the 
        /// </summary>
        /// <param name="values">List of values to select combinations from.</param>
        /// <param name="lowerIndex">The size of each combination set to return.</param>
        /// <param name="type">The type of Combinations set to generate.</param>
        private void Initialize(IList<T> values, int lowerIndex, GenerateOption type)
        {
            myMetaCollectionType = type;
            myLowerIndex = lowerIndex;
            myValues = new List<T>();
            myValues.AddRange(values);
            List<bool> myMap = new List<bool>();
            if (type == GenerateOption.WithoutRepetition)
            {
                for (int i = 0; i < myValues.Count; ++i)
                {
                    if (i >= myValues.Count - myLowerIndex)
                    {
                        myMap.Add(false);
                    }
                    else
                    {
                        myMap.Add(true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < values.Count - 1; ++i)
                {
                    myMap.Add(true);
                }
                for (int i = 0; i < myLowerIndex; ++i)
                {
                    myMap.Add(false);
                }
            }
            myPermutations = new Permutations<bool>(myMap);
        }

        #endregion

        #region Data

        /// <summary>
        /// Copy of values object is intialized with, required for enumerator reset.
        /// </summary>
        private List<T> myValues;

        /// <summary>
        /// Permutations object that handles permutations on booleans for combination inclusion.
        /// </summary>
        private Permutations<bool> myPermutations;

        /// <summary>
        /// The type of the combination collection.
        /// </summary>
        private GenerateOption myMetaCollectionType;

        /// <summary>
        /// The lower index defined in the constructor.
        /// </summary>
        private int myLowerIndex;

        #endregion
    }
}
