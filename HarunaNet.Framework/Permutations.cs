using System;
using System.Collections;
using System.Collections.Generic;

namespace HarunaNet.Framework.Utils 
{
    /// <summary>
    /// Permutations defines a meta-collection, typically a list of lists, of all
    /// possible orderings of a set of values.  This list is enumerable and allows
    /// the scanning of all possible permutations using a simple foreach() loop.
    /// </summary>
    /// <typeparam name="T">The type of the values within the list.</typeparam>
    public class Permutations<T> : IMetaCollection<T> 
    {

        #region Constructors

        /// <summary>
        /// No default constructor, must at least provided a list of values.
        /// </summary>
        protected Permutations() 
        {
        }

        /// <summary>
        /// Create a permutation set from the provided list of values.  
        /// The values (T) must implement IComparable.  
        /// </summary>
        /// <param name="values">List of values to permute.</param>
        public Permutations(IList<T> values) 
        {
            Initialize(values, GenerateOption.WithoutRepetition, null);
        }

        /// <summary>
        /// Create a permutation set from the provided list of values.  
        /// If type is MetaCollectionType.WithholdRepetitionSets, then values (T) must implement IComparable.  
        /// If T does not implement IComparable use a constructor with an explict IComparer.
        /// </summary>
        /// <param name="values">List of values to permute.</param>
        /// <param name="type">The type of permutation set to calculate.</param>
        public Permutations(IList<T> values, GenerateOption type) 
        {
            Initialize(values, type, null);
        }

        /// <summary>
        /// Create a permutation set from the provided list of values.  
        /// The values will be compared using the supplied IComparer.
        /// The repetition type defaults to MetaCollectionType.WithholdRepetitionSets
        /// </summary>
        /// <param name="values">List of values to permute.</param>
        /// <param name="comparer">Comparer used for defining the lexigraphic order.</param>
        public Permutations(IList<T> values, IComparer<T> comparer) 
        {
            Initialize(values, GenerateOption.WithoutRepetition, comparer);
        }

        #endregion

        #region IEnumerable Interface

        /// <summary>
        /// Gets an enumerator for collecting the list of permutations.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public virtual IEnumerator GetEnumerator() 
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Gets an enumerator for collecting the list of permutations.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator<IList<T>> IEnumerable<IList<T>>.GetEnumerator() 
        {
            return new Enumerator(this);
        }

        #endregion

        #region Enumerator Inner-Class

        /// <summary>
        /// The enumerator that enumerates each meta-collection of the enclosing Permutations class.
        /// </summary>
        public class Enumerator : IEnumerator<IList<T>> 
        {
            
            #region Constructors

            /// <summary>
            /// Construct a enumerator with the parent object.
            /// </summary>
            /// <param name="source">The source Permutations object.</param>
            public Enumerator(Permutations<T> source) 
            {
                myParent = source;
                myLexicographicalOrders = new int[source.myLexicographicOrders.Length];
                source.myLexicographicOrders.CopyTo(myLexicographicalOrders, 0);
                Reset();
            }

            #endregion

            #region IEnumerator Interface

            /// <summary>
            /// Resets the permutations enumerator to the first permutation.  
            /// This will be the first lexicographically order permutation.
            /// </summary>
            public void Reset() 
            {
                myPosition = Position.BeforeFirst;
            }

            /// <summary>
            /// Advances to the next permutation.
            /// </summary>
            /// <returns>True if successfully moved to next permutation, False if no more permutations exist.</returns>
            public bool MoveNext() 
            {
                if(myPosition == Position.BeforeFirst) 
                {
                    myValues = new List<T>(myParent.myValues.Count);
                    myValues.AddRange(myParent.myValues);
                    Array.Sort(myLexicographicalOrders);
                    myPosition = Position.InSet;
                } 
                else if(myPosition == Position.InSet) 
                {
                    if(myValues.Count < 2) 
                    {
                        myPosition = Position.AfterLast;
                    }
                    else if(NextPermutation() == false) 
                    {
                        myPosition = Position.AfterLast;
                    }
                }
                return myPosition != Position.AfterLast;
            }

            /// <summary>
            /// The current permutation.
            /// </summary>
            public object Current 
            {
                get 
                {
                    if(myPosition == Position.InSet) 
                    {
                        return myValues;
                    }
                    else 
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            /// <summary>
            /// The current permutation.
            /// </summary>
            IList<T> IEnumerator<IList<T>>.Current 
            {
                get 
                {
                    if(myPosition == Position.InSet) 
                    {
                        return myValues;
                    }
                    else 
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            /// <summary>
            /// Cleans up non-managed resources, of which there are none used here.
            /// </summary>
            public virtual void Dispose() 
            {
          
            }

            #endregion

            #region Methods

            /// <summary>
            /// Calculates the next lexicographical permutation of the set.
            /// This is a permutation with repetition where values that compare as equal will not 
            /// swap positions to create a new permutation.
            /// </summary>
            /// <returns>True if a new permutation has been returned, false if not.</returns>
            private bool NextPermutation() 
            {
                int i = myLexicographicalOrders.Length - 1;
                while(myLexicographicalOrders[i - 1] >= myLexicographicalOrders[i]) 
                {
                    --i;
                    if(i == 0) 
                    {
                        return false;
                    }
                }
                int j = myLexicographicalOrders.Length;
                while(myLexicographicalOrders[j - 1] <= myLexicographicalOrders[i - 1]) 
                {
                    --j;
                }
                Swap(i - 1, j - 1);
                ++i;
                j = myLexicographicalOrders.Length;
                while(i < j) 
                {
                    Swap(i - 1, j - 1);
                    ++i;
                    --j;
                }
                return true;
            }

            /// <summary>
            /// Helper function for swapping two elements within the internal collection.
            /// This swaps both the lexicographical order and the values, maintaining the parallel array.
            /// </summary>
            private void Swap(int i, int j) 
            {
                myTemp = myValues[i];
                myValues[i] = myValues[j];
                myValues[j] = myTemp;
                myKviTemp = myLexicographicalOrders[i];
                myLexicographicalOrders[i] = myLexicographicalOrders[j];
                myLexicographicalOrders[j] = myKviTemp;
            }

            #endregion

            #region Data and Internal Members
            /// <summary>
            /// Single instance of swap variable for T, small performance improvement over declaring in Swap function scope.
            /// </summary>
            private T myTemp;

            /// <summary>
            /// Single instance of swap variable for int, small performance improvement over declaring in Swap function scope.
            /// </summary>
            private int myKviTemp;

            /// <summary>
            /// Flag indicating the position of the enumerator.
            /// </summary>
            private Position myPosition = Position.BeforeFirst;

            /// <summary>
            /// Parrellel array of integers that represent the location of items in the myValues array.
            /// This is generated at Initialization and is used as a performance speed up rather that
            /// comparing T each time, much faster to let the CLR optimize around integers.
            /// </summary>
            private int[] myLexicographicalOrders;

            /// <summary>
            /// The list of values that are current to the enumerator.
            /// </summary>
            private List<T> myValues;

            /// <summary>
            /// The set of permuations that this enumerator enumerates.
            /// </summary>
            private Permutations<T> myParent;

            /// <summary>
            /// Internal position type for tracking enumertor position.
            /// </summary>
            private enum Position 
            {
                BeforeFirst,
                InSet,
                AfterLast
            }

            #endregion

        }

        #endregion

        #region IMetaList Interface

        /// <summary>
        /// The count of all permutations that will be returned.
        /// </summary>
        public long Count 
        {
            get 
            {
                return myCount;
            }
        }

        /// <summary>
        /// The type of Permutations set that is generated.
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
        /// For Permutation, this is always equal to the UpperIndex.
        /// </summary>
        public int LowerIndex 
        {
            get 
            {
                return myValues.Count;
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Common intializer used by the multiple flavors of constructors.
        /// </summary>
        private void Initialize(IList<T> values, GenerateOption type, IComparer<T> comparer) 
        {
            myMetaCollectionType = type;
            myValues = new List<T>(values.Count);
            myValues.AddRange(values);
            myLexicographicOrders = new int[values.Count];
            if(type == GenerateOption.WithRepetition) 
            {
                for(int i = 0; i < myLexicographicOrders.Length; ++i) 
                {
                    myLexicographicOrders[i] = i;
                }
            }
            else 
            {
                if(comparer == null) 
                {
                    comparer = new SelfComparer<T>();
                }
                myValues.Sort(comparer);
                int j = 1;
                if(myLexicographicOrders.Length > 0) 
                {
                    myLexicographicOrders[0] = j;
                }
                for(int i = 1; i < myLexicographicOrders.Length; ++i) 
                {
                    if(comparer.Compare(myValues[i - 1], myValues[i]) != 0) 
                    {
                        ++j;
                    }
                    myLexicographicOrders[i] = j;
                }
            }
            myCount = GetCount();
        }

        /// <summary>
        /// Calculates the total number of permutations that will be returned.  
        /// As this can grow very large, extra effort is taken to avoid overflowing the accumulator.  
        /// </summary>
        /// <returns>The number of permutations.</returns>
        private long GetCount() 
        {
            int runCount = 1;
            List<int> divisors = new List<int>();
            List<int> numerators = new List<int>();
            for(int i = 1; i < myLexicographicOrders.Length; ++i) 
            {
                numerators.AddRange(SmallPrimeUtility.Factor(i + 1));
                if(myLexicographicOrders[i] == myLexicographicOrders[i - 1]) 
                {
                    ++runCount;
                }
                else 
                {
                    for(int f = 2; f <= runCount; ++f) 
                    {
                        divisors.AddRange(SmallPrimeUtility.Factor(f));
                    }
                    runCount = 1;
                }
            }
            for(int f = 2; f <= runCount; ++f) 
            {
                divisors.AddRange(SmallPrimeUtility.Factor(f));
            }
            return SmallPrimeUtility.EvaluatePrimeFactors(SmallPrimeUtility.DividePrimeFactors(numerators, divisors));
        }

        #endregion

        #region Data and Internal Members

        /// <summary>
        /// A list of T that represents the order of elements as originally provided, used for Reset.
        /// </summary>
        private List<T> myValues;

        /// <summary>
        /// Parrellel array of integers that represent the location of items in the myValues array.
        /// This is generated at Initialization and is used as a performance speed up rather that
        /// comparing T each time, much faster to let the CLR optimize around integers.
        /// </summary>
        private int[] myLexicographicOrders;
        
        /// <summary>
        /// Inner class that wraps an IComparer around a type T when it is IComparable
        /// </summary>
        private class SelfComparer<U> : IComparer<U> 
        {
            public int Compare(U x, U y) 
            {
                return ((IComparable<U>)x).CompareTo(y);
            }
        }

        /// <summary>
        /// The count of all permutations.  Calculated at Initialization and returned by Count property.
        /// </summary>
        private long myCount;

        /// <summary>
        /// The type of Permutations that this was intialized from.
        /// </summary>
        private GenerateOption myMetaCollectionType;

        #endregion

    }
}
