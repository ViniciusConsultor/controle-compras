using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Calsse para conversões customizadas.
    /// </summary>
    public sealed class Conversion
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public Conversion()
        {

        }

        #region Static members
        
        /// <summary>
        /// Serializa um objeto para transferencia entre páginas aspx.
        /// </summary>
        /// <param name="value">Objeto para tranferencia.</param>
        /// <returns>Objeto serializado.</returns>
        public static string SerializeObjectForHTMLTransfer(Object value)
        {
            return SerializeObjectForHTMLTransfer(value, false);
        }

        /// <summary>
        /// Serializa um objeto para transferencia entre páginas aspx.
        /// </summary>
        /// <param name="value">Objeto para tranferencia.</param>
        /// <param name="b64Result">Identifica se a resposta do método deve ser em base64 string ou não.</param>
        /// <returns>Objeto serializado.</returns>
        public static string SerializeObjectForHTMLTransfer(Object value, bool b64Result)
        {
            XmlSerializer xs = new XmlSerializer(value.GetType());
            MemoryStream ms = new MemoryStream();
            try
            {
                xs.Serialize(ms, value);
                ms.Seek(0, 0);

                if (!b64Result)
                {
                    return ReadString(ms);
                }
                else
                {
                    return ChangeSendChar(ToBase64String(ReadString(ms)));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (null != ms)
                {
                    ms.Close();
                }
            }

        }

        private static string ChangeSendChar(string value)
        {
            return value.Replace("+", "%").Replace("=", "|");
        }

        private static string ChangeReciveChar(string value)
        {
            return value.Replace("%", "+").Replace("|", "=");
        }

        /// <summary>
        /// Deserilaliza um objeto serializado para transferencia entre páginas aspx.
        /// </summary>
        /// <param name="value">Objeto serializado.</param>
        /// <param name="tipo">Tipo do objeto serializado.</param>
        /// <param name="b64Result">Indica se o valor serializado está ou não em base64.</param>
        /// <returns>Objeto deserializado.</returns>
        public static object DeserializeObjectFromHTMLTransfer(string value, Type tipo, bool b64Result)
        {
            if (null != value)
            {
                XmlSerializer xs = new XmlSerializer(tipo);
                value = ChangeReciveChar(value);
                string s = value;
                if (b64Result)
                {
                    s = FromBase64String(value);
                }

                MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.UTF8.GetBytes(s));
                try
                {
                    return xs.Deserialize(ms);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (null != ms)
                    {
                        ms.Close();
                    }
                }
            }
            return value;
        }

        private static string ReadString(MemoryStream stream)
        {
            byte[] buffer = stream.ToArray();
            return System.Text.UTF8Encoding.UTF8.GetString(buffer);
        }

        /// <summary>
        /// Converte uma string para base64 string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToBase64String(string s)
        {
            return Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(s));
        }

        /// <summary>
        /// Recupera uma string do base64 string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FromBase64String(string s)
        {
            return System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(s));
        }

        /// <summary>
        /// Gerador de parâmetros int para passagem de null quando vazio p/ Banco de dados.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object geraParametroInt(int valor)
        {
            return (valor > int.MinValue ? (object)valor : (object)DBNull.Value);
        }

        /// <summary>
        /// Gerador de parâmetros BigInt para passagem de null quando vazio p/ Banco de dados.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object geraParametroLong(long valor)
        {
            return (valor > long.MinValue ? (object)valor : (object)DBNull.Value);
        }

        /// <summary>
        /// Gerador de parâmetros Decimal para passagem de null quando vazio p/ Banco de dados.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object geraParametroDecimal(decimal valor)
        {
            return (valor > decimal.MinValue ? (object)valor : (object)DBNull.Value);
        }

        /// <summary>
        /// Gerador de parâmetros string para passagem de null quando vazio p/ Banco de dados.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object geraParametroString(string valor)
        {
            return (valor.Length > 0 ? (object)valor : (object)DBNull.Value);
        }

        /// <summary>
        /// Gerador de parâmetros DateTime para passagem de null quando vazio p/ Banco de dados.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object geraParametroDatetime(DateTime valor)
        {
            return (valor > DateTime.MinValue ? (object)valor : (object)DBNull.Value);
        }

        /// <summary>
        /// Preenchimento de campos int quando trazidos do banco de dados (se null preenche MinValue)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static int preencheCampoInt(object reader)
        {
            return (!Convert.IsDBNull(reader) ? Convert.ToInt32(reader) : int.MinValue);
        }

        /// <summary>
        /// Preenchimento de campos int16 quando trazidos do banco de dados (se null preenche MinValue)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Int16 preencheCampoInt16(object reader)
        {
            return (!Convert.IsDBNull(reader) ? Convert.ToInt16(reader) : Int16.MinValue);
        }

        /// <summary>
        /// Preenchimento de campos string quando trazidos do banco de dados (se null preenche Empty)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static string preencheCampoString(object reader)
        {
            return (!Convert.IsDBNull(reader) ? reader.ToString() : string.Empty);
        }

        /// <summary>
        /// Preenchimento de campos string quando trazidos do banco de dados (se null preenche Empty)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static char preencheCampoChar(object reader)
        {
            return (!Convert.IsDBNull(reader) ? Convert.ToChar(reader.ToString()) : char.MinValue);
        }

        /// <summary>
        /// Preenchimento de campos DateTime quando trazidos do banco de dados (se null preenche MinValue)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static DateTime preencheCampoDateTime(object reader)
        {
            return (!Convert.IsDBNull(reader) ? Convert.ToDateTime(reader) : DateTime.MinValue);
        }

        /// <summary>
        /// Preenchimento de campos decimal quando trazidos do banco de dados (se null preenche MinValue)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static decimal preencheCampoDecimal(object reader)
        {
            return (!Convert.IsDBNull(reader) ? Convert.ToDecimal(reader) : decimal.MinValue);
        }

        /// <summary>
        /// Preenchimento de campos Boolean quando trazidos do banco de dados (se null preenche false)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static bool preencheCampoBoolean(object reader)
        {
            return (!Convert.IsDBNull(reader) ? Convert.ToBoolean(reader) : false);
        }
        #endregion
    }
}
