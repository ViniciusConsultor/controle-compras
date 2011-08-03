using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Indicates whether a Permutation or Combination meta-collections
    /// generate repetition sets.  
    /// </summary>
    public enum GenerateOption 
    {
        /// <summary>
        /// Do not generate additional sets, typical implementation.
        /// </summary>
        WithoutRepetition,
        /// <summary>
        /// Generate additional sets even if repetition is required.
        /// </summary>
        WithRepetition
    }
}
