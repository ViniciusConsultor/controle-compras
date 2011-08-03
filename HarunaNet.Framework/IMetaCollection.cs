using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Interface para Permutation, Combination e outras classes que 
    /// apresentam uma collection de collections baseadas em uma collection de entrada
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IMetaCollection<T> : IEnumerable<IList<T>> 
    {
        /// <summary>
        /// A quantidade de itens na collection. 
        /// </summary>
        long Count 
        { 
            get; 
        }

        /// <summary>
        /// O tipo do meta-collection.
        /// </summary>
        GenerateOption Type 
        { 
            get; 
        }

        /// <summary>
        /// O maior índice do meta-collection.
        /// </summary>
        int UpperIndex 
        { 
            get; 
        }

        /// <summary>
        /// O menor índice do meta-collection.
        /// </summary>
        int LowerIndex 
        { 
            get; 
        }
    }

}
