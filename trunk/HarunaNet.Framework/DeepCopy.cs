using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Realiza uma cópia profunda do objeto, sem manter a referência antiga.
    /// </summary>
    /// <typeparam name="T">Tipo do objeto a ser copiado.</typeparam>
    public class DeepCopy<T>
    {
        /// <summary>
        /// Copia o objeto sem manter a referência antiga.
        /// </summary>
        /// <param name="source">Objeto a ser copiado.</param>
        /// <returns>Objeto copiado.</returns>
        public T Copy(T source)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, source);
            memoryStream.Position = 0;
            return (T)binaryFormatter.Deserialize(memoryStream);
        }
    }
}
