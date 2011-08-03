using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Classe de formata��o
    /// </summary>
    public class Format
    {
        #region CPF
        /// <summary>
        /// CPF
        /// </summary>
        /// <param name="sCPF"></param>
        /// <returns></returns>
        public static string CPF(string sCPF)
        {
            if (sCPF.Trim() == "")
            {
                return "";
            }

            // Garante que a string n�o tem formata��o
            sCPF = CPF(sCPF, true);

            // Completa com zeros � esquerda
            sCPF = sCPF.PadLeft(11, '0');

            return sCPF.Substring(0, 3) + "." +
                sCPF.Substring(3, 3) + "." +
                sCPF.Substring(6, 3) + "-" +
                sCPF.Substring(9);
        }
        /// <summary>
        /// CPF
        /// </summary>
        /// <param name="iCPF"></param>
        /// <returns></returns>
        public static string CPF(int iCPF)
        {
            return CPF(iCPF.ToString().Trim());
        }
        /// <summary>
        /// CPF
        /// </summary>
        /// <param name="sCPF"></param>
        /// <param name="Retira_Sinais"></param>
        /// <returns></returns>
        public static string CPF(string sCPF, bool Retira_Sinais)
        {
            sCPF = sCPF.Replace(".", "");
            sCPF = sCPF.Replace("-", "");

            return sCPF;
        }

        #endregion

        #region CNPJ
        /// <summary>
        /// Remove o formato de um CNPJ.
        /// </summary>
        /// <param name="value">CNPJ formatado (xx.xxx.xxx/xxxx-xx).</param>
        /// <returns>CNPJ sem formato, apenas com os n�meros.</returns>
        public static string RemoveFormatCNPJ(string value)
        {
            return Regex.Replace(value, @"\.|\-|\/", "");
        }
        /// <summary>
        /// Formata o CNPJ totalizando 14 digitos (0�s a esquerda) e sem tra�os/pontos .
        /// </summary>
        /// <param name="sCNPJ"></param>
        /// <returns></returns>
        public static string FormatCNPJ(string sCNPJ)
        {
            // Garante que est� sem formata��o
            sCNPJ = CNPJ(sCNPJ, true);

            // 14 cararacteres
            return sCNPJ.PadLeft(14, '0');
        }
        /// <summary>
        /// Formata o CNPJ com pontos, barras e tra�o.
        /// </summary>
        /// <param name="sCNPJ"></param>
        /// <returns></returns>
        public static string CNPJ(string sCNPJ)
        {
            // Garante que est� sem formata��o
            sCNPJ = CNPJ(sCNPJ, true);

            // 14 cararacteres
            sCNPJ = sCNPJ.PadLeft(14, '0');

            sCNPJ = sCNPJ.Substring(0, 2) + "."
                + sCNPJ.Substring(2, 3) + "."
                + sCNPJ.Substring(5, 3) + "/"
                + sCNPJ.Substring(8, 4) + "-"
                + sCNPJ.Substring(12, 2);

            return sCNPJ;
        }
        /// <summary>
        /// Formata o CNPJ com pontos, barras e tra�o.
        /// </summary>
        /// <param name="nRadical"></param>
        /// <param name="nFilial"></param>
        /// <param name="nDigito"></param>
        /// <returns></returns>
        public static string CNPJ(int nRadical, int nFilial, int nDigito)
        {
            string sRadical, sFilial, sDigito;

            sRadical = nRadical.ToString().Trim().PadLeft(8, '0');
            sFilial = nFilial.ToString().Trim().PadLeft(4, '0');
            sDigito = nDigito.ToString().Trim().PadLeft(2, '0');

            return FormatCNPJ(sRadical + sFilial + sDigito);
        }
        /// <summary>
        /// Formata o CNPJ com pontos, barras e tra�o.
        /// </summary>
        /// <param name="sCNPJ"></param>
        /// <param name="Retira_Sinais"></param>
        /// <returns></returns>
        public static string CNPJ(string sCNPJ, bool Retira_Sinais)
        {
            sCNPJ = sCNPJ.Replace(".", "");
            sCNPJ = sCNPJ.Replace("/", "");
            sCNPJ = sCNPJ.Replace("-", "");

            return sCNPJ;
        }

        #endregion

        #region Datas
        /// <summary>
        /// Data
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static DateTime Data(string strData)
        {
            int nDia, nMes, nAno;
            string[] vs = strData.Split('/');
            nDia = int.Parse("0" + vs[0]);
            nMes = int.Parse("0" + vs[1]);
            nAno = int.Parse("0" + vs[2]);
            return new DateTime(nAno, nMes, nDia);
        }
        /// <summary>
        /// FormataData
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static String FormataData(string strData)
        {
            String retorno = "";
            if (strData.Length >= 5)
            {
                int nDia, nMes, nAno;
                string[] data = strData.Split(' '); // retira tudo ap�s os espa�os
                string[] vs = data[0].Split('/');
                nDia = int.Parse("0" + vs[0]);
                nMes = int.Parse("0" + vs[1]);
                nAno = int.Parse("0" + vs[2]);
                retorno = new DateTime(nAno, nMes, nDia).ToString("dd/MM/yyyy");
            }
            return retorno;
        }

        #endregion

        #region M�s por extenso
        /// <summary>
        /// aMes
        /// </summary>
        /// <param name="dData"></param>
        /// <returns></returns>
        public static string aMes(DateTime dData)
        {
            // Retorna o nome do m�s inteiro
            return aMes(dData.Month, 0);
        }
        /// <summary>
        /// aMes
        /// </summary>
        /// <param name="dData"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string aMes(DateTime dData, int nLength)
        {
            return aMes(dData.Month, nLength);
        }
        /// <summary>
        /// aMes
        /// </summary>
        /// <param name="nMes"></param>
        /// <returns></returns>
        public static string aMes(int nMes)
        {
            // Retorna o nome do m�s inteiro
            return aMes(nMes, 0);
        }
        /// <summary>
        /// aMes
        /// </summary>
        /// <param name="nMes"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string aMes(int nMes, int nLength)
        {

            if (nMes < 0 || nMes > 12)
            {
                return "M�s Inv�lido";
            }

            string[] aMeses = new string[13];
            aMeses[1] = "Janeiro";
            aMeses[2] = "Fevereiro";
            aMeses[3] = "Mar�o";
            aMeses[4] = "Abril";
            aMeses[5] = "Maio";
            aMeses[6] = "Junho";
            aMeses[7] = "Julho";
            aMeses[8] = "Agosto";
            aMeses[9] = "Setembro";
            aMeses[10] = "Outubro";
            aMeses[11] = "Novembro";
            aMeses[12] = "Dezembro";
            aMeses[0] = "Dezembro";

            if (nLength > 0)
            {
                return aMeses[nMes].Substring(0, nLength);
            }
            else
            {
                return aMeses[nMes];
            }

        }

        #endregion

        #region Semana por extenso
        /// <summary>
        /// aSemana
        /// </summary>
        /// <param name="dData"></param>
        /// <returns></returns>
        public static string aSemana(DateTime dData)
        {
            return aSemana(dData.DayOfWeek, 0);
        }
        /// <summary>
        /// aSemana
        /// </summary>
        /// <param name="dData"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string aSemana(DateTime dData, int nLength)
        {
            return aSemana(dData.DayOfWeek, nLength);
        }
        /// <summary>
        /// aSemana
        /// </summary>
        /// <param name="nDia"></param>
        /// <returns></returns>
        public static string aSemana(DayOfWeek nDia)
        {
            return aSemana((int)nDia, 0);
        }
        /// <summary>
        /// aSemana
        /// </summary>
        /// <param name="nDia"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string aSemana(DayOfWeek nDia, int nLength)
        {
            return aSemana((int)nDia, nLength);
        }
        /// <summary>
        /// aSemana
        /// </summary>
        /// <param name="nDia"></param>
        /// <returns></returns>
        public static string aSemana(int nDia)
        {
            return aSemana(nDia, 0);
        }
        /// <summary>
        /// aSemana
        /// </summary>
        /// <param name="nDia"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string aSemana(int nDia, int nLength)
        {

            if (nDia < 0 || nDia > 6)
            {
                return "Dia Inv�lido";
            }

            string[] aDias = new string[7];
            aDias[0] = "Domingo";
            aDias[1] = "Segunda";
            aDias[2] = "Ter�a";
            aDias[3] = "Quarta";
            aDias[4] = "Quinta";
            aDias[5] = "Sexta";
            aDias[6] = "S�bado";


            if (nLength > 0)
            {
                return aDias[nDia].Substring(0, nLength);
            }
            else
            {
                return aDias[nDia];
            }

        }

        #endregion

        #region Transforma��o de strings
        /// <summary>
        /// Proper
        /// </summary>
        /// <param name="cString"></param>
        /// <returns></returns>
        public static string Proper(string cString)
        {
            if (cString == "")
            {
                return cString;
            }

            cString = cString + " ";
            string[] aWords = cString.Split(' ');
            cString = "";
            foreach (string cWord in aWords)
            {
                if (cWord.Length == 1)
                {
                    cString += " " + cWord.Substring(0).ToLower();
                }
                else if (cWord.Length > 1)
                {
                    cString += " " + cWord.Substring(0, 1).ToUpper() + cWord.Substring(1).ToLower();
                }
            }

            return cString.Trim();
        }
        /// <summary>
        /// ProperFrase
        /// </summary>
        /// <param name="cFrase"></param>
        /// <returns></returns>
        public static string ProperFrase(string cFrase)
        {
            cFrase = Proper(cFrase);
            cFrase = cFrase.Replace(" De ", " de ");
            cFrase = cFrase.Replace(" Do ", " do ");
            cFrase = cFrase.Replace(" Dos ", " dos ");
            cFrase = cFrase.Replace(" Da ", " da ");
            cFrase = cFrase.Replace(" Das ", " das ");
            cFrase = cFrase.Replace(" Do ", " do ");
            cFrase = cFrase.Replace(" E ", " e ");
            cFrase = cFrase.Replace("A/c ", "a/c ");
            cFrase = cFrase.Replace(" Com ", " com ");

            return cFrase;
        }
        /// <summary>
        /// RemoveAcentos
        /// </summary>
        /// <param name="cString"></param>
        /// <returns></returns>
        public static string RemoveAcentos(string cString)
        {
            cString = cString.Replace("�", "a");
            cString = cString.Replace("�", "a");
            cString = cString.Replace("�", "a");
            cString = cString.Replace("�", "a");
            cString = cString.Replace("�", "a");
            cString = cString.Replace("�", "a");

            cString = cString.Replace("�", "e");
            cString = cString.Replace("�", "e");
            cString = cString.Replace("�", "e");
            cString = cString.Replace("�", "e");

            cString = cString.Replace("�", "i");
            cString = cString.Replace("�", "i");
            cString = cString.Replace("�", "i");
            cString = cString.Replace("�", "i");

            cString = cString.Replace("�", "o");
            cString = cString.Replace("�", "o");
            cString = cString.Replace("�", "o");
            cString = cString.Replace("�", "o");
            cString = cString.Replace("�", "o");

            cString = cString.Replace("�", "u");
            cString = cString.Replace("�", "u");
            cString = cString.Replace("�", "u");
            cString = cString.Replace("�", "u");

            cString = cString.Replace("�", "A");
            cString = cString.Replace("�", "A");
            cString = cString.Replace("�", "A");
            cString = cString.Replace("�", "A");
            cString = cString.Replace("�", "A");
            cString = cString.Replace("�", "A");

            cString = cString.Replace("�", "E");
            cString = cString.Replace("�", "E");
            cString = cString.Replace("�", "E");
            cString = cString.Replace("�", "E");

            cString = cString.Replace("�", "I");
            cString = cString.Replace("�", "I");
            cString = cString.Replace("�", "I");
            cString = cString.Replace("�", "I");

            cString = cString.Replace("�", "O");
            cString = cString.Replace("�", "O");
            cString = cString.Replace("�", "O");
            cString = cString.Replace("�", "O");
            cString = cString.Replace("�", "O");

            cString = cString.Replace("�", "U");
            cString = cString.Replace("�", "U");
            cString = cString.Replace("�", "U");
            cString = cString.Replace("�", "U");

            cString = cString.Replace("�", "c");
            cString = cString.Replace("�", "C");

            cString = cString.Replace("�", "n");
            cString = cString.Replace("�", "N");

            return cString;
        }

        #endregion

        #region File Name

        // Adiciona barra no path, se necess�rio
        /// <summary>
        /// ADDBS
        /// </summary>
        /// <param name="cPath"></param>
        /// <returns></returns>
        public static string ADDBS(string cPath)
        {
            cPath = cPath.Trim();
            if (cPath.Substring(cPath.Length - 1) != @"\")
            {
                cPath = cPath.PadRight(cPath.Length + 1, '\\');
            }

            return cPath;
        }
        // Retorna apenas o nome do arquivo
        /// <summary>
        /// JustFName
        /// </summary>
        /// <param name="cFile"></param>
        /// <returns></returns>
        public static string JustFName(string cFile)
        {
            cFile = cFile.Trim();
            return cFile.Substring(cFile.LastIndexOf('\\') + 1);
        }

        // Retorna apenas o drive
        /// <summary>
        /// JustDrive
        /// </summary>
        /// <param name="cFile"></param>
        /// <returns></returns>
        public static string JustDrive(string cFile)
        {
            cFile = cFile.Trim();
            if (cFile.IndexOf(":") == -1)
            {
                return "";
            }
            else
            {
                return cFile.Substring(0, cFile.IndexOf(':') + 1);
            }
        }

        // Retorna o path
        /// <summary>
        /// Retorna o path
        /// </summary>
        /// <param name="cFile"></param>
        /// <returns></returns>
        public static string JustPath(string cFile)
        {
            cFile = cFile.Trim();
            return cFile.Replace(cFile.Substring(cFile.LastIndexOf('\\') + 1), "");
        }

        // Retorna o nome do arquivo sem a extens�o
        /// <summary>
        ///  Retorna o nome do arquivo sem a extens�o
        /// </summary>
        /// <param name="cFile"></param>
        /// <returns></returns>
        public static string JustStem(string cFile)
        {
            cFile = cFile.Trim();
            return JustFName(cFile).Replace("." + JustExt(cFile), "");
        }

        // Retorna a extens�o do arquivo
        /// <summary>
        /// Retorna a extens�o do arquivo
        /// </summary>
        /// <param name="cFile"></param>
        /// <returns></returns>
        public static string JustExt(string cFile)
        {
            cFile = cFile.Trim();
            return cFile.Substring(cFile.LastIndexOf('.') + 1);
        }

        // Troca o path do arquivo
        /// <summary>
        /// Troca o path do arquivo
        /// </summary>
        /// <param name="cFile"></param>
        /// <param name="cPath"></param>
        /// <returns></returns>
        public static string ForcePath(string cFile, string cPath)
        {
            cPath = ADDBS(cPath);
            cFile = cFile.Trim();
            return cPath + JustFName(cFile);
        }
        #endregion

        #region CEP/Telefone
        /// <summary>
        /// Formata o n�mero do telefone informado.
        /// </summary>
        /// <param name="ddi">DDI.</param>
        /// <param name="ddd">DDD></param>
        /// <param name="phone">Telefone.</param>
        /// <returns>N�mero do telefone formatado.</returns>
        public static string FormatPhone(string ddi, string ddd, string phone)
        {
            string phoneComplete = string.Empty;
            if (!string.IsNullOrEmpty(ddi))
                phoneComplete = string.Concat("+", ddi);
            if (!string.IsNullOrEmpty(ddd))
                phoneComplete = string.Concat(phoneComplete.Trim(), " ", "(", ddd, ")");
            if (!string.IsNullOrEmpty(phone))
                if (phone.Length == 8)
                    phoneComplete = string.Concat(phoneComplete.Trim(), " ", phone.Substring(0, 4), "-", phone.Substring(4, 4));
                else
                    phoneComplete = string.Concat(phoneComplete.Trim(), " ", phone);
            return phoneComplete.Trim();
        }

        /// <summary>
        /// Formata o n�mero do telefone informado.
        /// </summary>
        /// <param name="ddd">DDD.</param>
        /// <param name="phone">Telefone.</param>
        /// <returns>N�mero do telefone formatado.</returns>
        public static string FormatPhone(string ddd, string phone)
        {
            return FormatPhone(string.Empty, ddd, phone);
        }

        /// <summary>
        /// Formata o n�mero do telefone informado.
        /// </summary>
        /// <param name="phone">Telefone.</param>
        /// <returns>N�mero do telefone formatado.</returns>
        public static string FormatPhone(string phone)
        {
            return FormatPhone(string.Empty, string.Empty, phone);
        }

        /// <summary>
        /// Formata o cep.
        /// </summary>
        /// <param name="cep">CEP.</param>
        /// <returns>CEP formatado.</returns>
        public static string FormatCEP(string cep)
        {
            if (!string.IsNullOrEmpty(cep))
                if (cep.Trim().Length == 8)
                    return string.Concat(cep.Trim().Substring(0, 5), "-", cep.Trim().Substring(5, 3));
            return cep.Trim();
        }
        #endregion
    }
}
