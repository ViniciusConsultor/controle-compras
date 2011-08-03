using System;
using System.Text.RegularExpressions;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Summary description for Valid.
    /// </summary>
    public class Valid
    {
        #region CPF(int intCPF)
        /// <summary>
        /// CPF
        /// </summary>
        /// <param name="intCPF"></param>
        /// <returns></returns>
        public static bool CPF(int intCPF)
        {
            return CPF(intCPF.ToString().Trim());
        }
        #endregion

        #region CPF(string strCPFUser)
        /// <summary>
        /// CPF
        /// </summary>
        /// <param name="strCPFUser"></param>
        /// <returns></returns>
        public static bool CPF(string strCPFUser)
        {
            if (strCPFUser.Trim() == string.Empty)
            {
                return false;
            }

            if (strCPFUser.Trim().Length > 11)
            {
                return false;
            }

            int intD1, intD2;
            int intSoma = 0;
            string strDigitado = "";
            string strCalculado = "";

            // Pega a string passada no parametro
            string strCPF = strCPFUser;

            // Pesos para calcular o primeiro digito
            int[] intArrPeso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] intArrPeso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] intDigitoCPF = new int[11];

            bool bRetorno = false;

            // Limpa a string
            strCPF = strCPF.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "");

            strCPF = strCPF.Trim().PadLeft(11, '0');

            // Caso coloque todos os numeros iguais
            switch (strCPF)
            {
                case "11111111111":
                    {
                        return false;
                    }
                case "00000000000":
                    {
                        return false;
                    }
                case "2222222222":
                    {
                        return false;
                    }
                case "33333333333":
                    {
                        return false;
                    }
                case "44444444444":
                    {
                        return false;
                    }
                case "55555555555":
                    {
                        return false;
                    }
                case "66666666666":
                    {
                        return false;
                    }
                case "77777777777":
                    {
                        return false;
                    }
                case "88888888888":
                    {
                        return false;
                    }
                case "99999999999":
                    {
                        return false;
                    }
            }

            try
            {
                // Quebra cada digito do strCPF
                intDigitoCPF[0] = Convert.ToInt32(strCPF.Substring(0, 1));
                intDigitoCPF[1] = Convert.ToInt32(strCPF.Substring(1, 1));
                intDigitoCPF[2] = Convert.ToInt32(strCPF.Substring(2, 1));
                intDigitoCPF[3] = Convert.ToInt32(strCPF.Substring(3, 1));
                intDigitoCPF[4] = Convert.ToInt32(strCPF.Substring(4, 1));
                intDigitoCPF[5] = Convert.ToInt32(strCPF.Substring(5, 1));
                intDigitoCPF[6] = Convert.ToInt32(strCPF.Substring(6, 1));
                intDigitoCPF[7] = Convert.ToInt32(strCPF.Substring(7, 1));
                intDigitoCPF[8] = Convert.ToInt32(strCPF.Substring(8, 1));
                intDigitoCPF[9] = Convert.ToInt32(strCPF.Substring(9, 1));
                intDigitoCPF[10] = Convert.ToInt32(strCPF.Substring(10, 1));
            }
            catch
            {
                return false;
            }


            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= intArrPeso1.GetUpperBound(0); i++)
            {
                intSoma += (intArrPeso1[i] * Convert.ToInt32(intDigitoCPF[i]));
            }

            // Pega o resto da divisao
            int intResto = intSoma % 11;

            if (intResto == 1 || intResto == 0)
            {
                intD1 = 0;
            }
            else
            {
                intD1 = 11 - intResto;
            }

            intSoma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= intArrPeso2.GetUpperBound(0); i++)
            {
                intSoma += (intArrPeso2[i] * Convert.ToInt32(intDigitoCPF[i]));
            }

            // Pega o resto da divisao
            intResto = intSoma % 11;

            if (intResto == 1 || intResto == 0)
            {
                intD2 = 0;
            }
            else
            {
                intD2 = 11 - intResto;
            }

            strCalculado = intD1.ToString() + intD2.ToString();
            strDigitado = intDigitoCPF[9].ToString() + intDigitoCPF[10].ToString();

            // Se os ultimos dois digitos strCalculados bater com
            // os dois ultimos digitos do strCPF entao é válido
            if (strCalculado == strDigitado)
            {
                bRetorno = true;
            }
            else
            {
                bRetorno = false;
            }

            return bRetorno;
        }
        #endregion

        #region CNPJ(int nRadical, int nFilial, int nDigito)
        /// <summary>
        /// CNPJ
        /// </summary>
        /// <param name="nRadical"></param>
        /// <param name="nFilial"></param>
        /// <param name="nDigito"></param>
        /// <returns></returns>
        public static bool CNPJ(int nRadical, int nFilial, int nDigito)
        {
            string sRadical, sFilial, sDigito;

            sRadical = nRadical.ToString().Trim().PadLeft(8, '0');
            sFilial = nFilial.ToString().Trim().PadLeft(4, '0');
            sDigito = nDigito.ToString().Trim().PadLeft(2, '0');

            return CNPJ(sRadical + sFilial + sDigito);
        }
        #endregion

        #region CNPJ(string strCnpjUser)
        /// <summary>
        /// CNPJ
        /// </summary>
        /// <param name="strCnpjUser"></param>
        /// <returns></returns>
        public static bool CNPJ(string strCnpjUser)
        {
            strCnpjUser = strCnpjUser.Trim().PadLeft(14, '0');

            if (Convert.ToInt64(strCnpjUser) == 0)
            {
                return false;
            }

            string strL, strINX, strDig;
            int intS1, intS2, intI, intD1, intD2, intV, intM1, intM2;

            strINX = strCnpjUser.Substring(12, 2);
            strCnpjUser = strCnpjUser.Substring(0, 12);
            intS1 = 0;
            intS2 = 0;
            intM2 = 2;

            for (intI = 11; intI >= 0; intI--)
            {
                strL = strCnpjUser.Substring(intI, 1);
                intV = Convert.ToInt16(strL);
                intM1 = intM2;
                intM2 = intM2 < 9 ? intM2 + 1 : 2;
                intS1 += intV * intM1;
                intS2 += intV * intM2;
            }

            intS1 %= 11;
            intD1 = intS1 < 2 ? 0 : 11 - intS1;
            intS2 = (intS2 + 2 * intD1) % 11;
            intD2 = intS2 < 2 ? 0 : 11 - intS2;
            strDig = intD1.ToString() + intD2.ToString();

            return (strINX == strDig);
        }
        #endregion

        #region CPFCNPJ(string strCPFCNPJ)
        /// <summary>
        /// CPFCNPJ
        /// </summary>
        /// <param name="strCPFCNPJ"></param>
        /// <returns></returns>
        public static bool CPFCNPJ(string strCPFCNPJ)
        {
            //Testa se CPF é válido
            if (CPF(strCPFCNPJ))
            {
                return true;
            }
            else
            {
                //Testa então se o CNPJ é válido
                if (CNPJ(strCPFCNPJ))
                {
                    return true;
                }
                else
                {
                    //CPF/CNPJ inválido
                    return false;
                }
            }
        }

        /// <summary>
        /// Formata o cpf.
        /// </summary>
        /// <param name="cpf">Cpf a ser formatado.</param>
        /// <returns>Cpf formatado.</returns>
        public static string CPFFormatado(string cpf)
        {
            StringBuilder sbCpf = new StringBuilder(string.Empty);

            if (cpf.Length >= 11)
            {
                sbCpf.Append(cpf.Substring(0, 3));
                sbCpf.Append(".");
                sbCpf.Append(cpf.Substring(3, 3));
                sbCpf.Append(".");
                sbCpf.Append(cpf.Substring(6, 3));
                sbCpf.Append("-");
                sbCpf.Append(cpf.Substring(9, 2));
            }

            return sbCpf.ToString();
        }
        #endregion

        #region Expressões Regulares
        #region Constantes
        /// <summary>
        /// Expressão regular de validação de e-mail
        /// </summary>
        private static string m_RegexEmail = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        /// <summary>
        /// Expressão regular de validação de URL
        /// </summary>
        private static string m_RegexURL = @"^((ht|f)tp(s?)\:\/\/|~/|/)?([\w]+:\w+@)?([a-zA-Z]{1}([\w\-]+\.)+([\w]{2,5}))(:[\d]{1,5})?((/?\w+/)+|/?)(\w+\.[\w]{3,4})?((\?\w+=\w+)?(&\w+=\w+)*)?";
        /// <summary>
        /// Expressão regular de validação de texto
        /// </summary>
        private static string m_RegexText = @"^[a-zA-Z ]+$";
        ///// <summary>
        ///// Expressão regular de validação de número
        ///// </summary>
        //private static string m_RegexNumber = @"^[0-9]+$";
        /// <summary>
        /// Expressão regular de validação de data
        /// </summary>
        private static string m_RegexDate = @"^(((0[1-9]|[12][0-9]|3[01])[/](0[13456789]|1[012]))|((0[1-9]|[12][0-9])/02))[/](19|20)\d\d$";
        /// <summary>
        /// Expressão regular de validação de decimais
        /// </summary>
        private static string m_RegexDecimal = @"^[-+]?[0-9]{1,3}((\.[0-9]{3}|[0-9]{3}){1,9})?(,[0-9]{1,})?$";
        /// <summary>
        /// Expressão regular de validação de alpha numericos
        /// </summary>
        private static string m_RegexAlphaNumeric = @"^[a-zA-Z0-9]+$";
        /// <summary>
        /// Expressão regular de validação de alpha com espaço e ponto
        /// </summary>
        private static string m_RegexAlphaSpacePoint = @"^[a-zA-Z .]+$";
        /// <summary>
        /// Expressão regular de validação de alpha numericos com espaço e ponto
        /// </summary>
        private static string m_RegexAlphaNumericSpacePoint = @"^[a-zA-Z0-9 .]+$";
        /// <summary>
        /// Expressão regular de validação de alpha numericos com espaço
        /// </summary>
        private static string m_RegexAlphaNumericSpace = @"^[a-zA-Z0-9 ]+$";
        /// <summary>
        /// Expressão regular de validação de alpha numericos com ponto
        /// </summary>
        private static string m_RegexAlphaNumericPoint = @"^[a-zA-Z0-9.]+$";
        /// <summary>
        /// Expressão regular de validação de CEP
        /// </summary>
        private static string m_RegexCep = @"^[0-9]+$";
        /// <summary>
        /// Expressão regular de validação de RG
        /// </summary>
        private static string m_RegexRg = @"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}-[0-9]$";
        /// <summary>
        /// Expressão regular de validação de CNPJ
        /// </summary>
        private static string m_RegexCnpj = @"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\\[0-9]{4}-[0-9]{2}|[0-9]{2}[0-9]{3}[0-9]{3}\\[0-9]{4}-[0-9]{2}|[0-9]{2}[0-9]{3}[0-9]{3}[0-9]{4}-[0-9]{2}|[0-9]{2}[0-9]{3}[0-9]{3}[0-9]{4}[0-9]{2}$";
        /// <summary>
        /// Expressão regular de validação de CPF
        /// </summary>
        private static string m_RegexCpf = @"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}|[0-9]{3}[0-9]{3}[0-9]{3}-[0-9]{2}|[0-9]{3}[0-9]{3}[0-9]{3}[0-9]{2}$";
        /// <summary>
        /// Expressão regular de validação de telefone
        /// </summary>
        private static string m_RegexTelefone = @"^([(][0-9]{3}[)])?[0-9]{4}|[0-9]{3}-?[0-9]{4}$";
        /// <summary>
        /// Expressão regular de validação de hora
        /// </summary>
        private static string m_RegexHora = @"^([0-9]|[01][0-9]|2[0-3])[:][0-5][0-9]$";
        #endregion

        #region Metodos de validação
        #region Alpha
        /// <summary>
        /// Verifica se a string é um texto válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só caracteres alpha false se não.</returns>
        public static bool IsText(string text)
        {
            return Regex.IsMatch(text, m_RegexText);
        }

        /// <summary>
        /// Verifica se a string é um texto alpha com espaços e ponto válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só caracteres alpha false se não.</returns>
        public static bool IsAlphaSpacePoint(string text)
        {
            return Regex.IsMatch(text, m_RegexAlphaSpacePoint);
        }

        #endregion

        #region AlphaNumeric
        /// <summary>
        /// Verifica se a string é um texto alpha numerico válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só caracteres alpha false se não.</returns>
        public static bool IsAlphaNumeric(string text)
        {
            return Regex.IsMatch(text, m_RegexAlphaNumeric);
        }

        /// <summary>
        /// Verifica se a string é um texto alpha numerico com espaços válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só caracteres alpha false se não.</returns>
        public static bool IsAlphaNumericSpace(string text)
        {
            return Regex.IsMatch(text, m_RegexAlphaNumericSpace);
        }

        /// <summary>
        /// Verifica se a string é um alpha numerico com ponto válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsAlphaNumericPoint(string text)
        {
            return Regex.IsMatch(text, m_RegexAlphaNumericPoint);
        }

        /// <summary>
        /// Verifica se a string é um texto alpha numerico com espaços e ponto válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só caracteres alpha false se não.</returns>
        public static bool IsAlphaNumericSpacePoint(string text)
        {
            return Regex.IsMatch(text, m_RegexAlphaNumericSpacePoint);
        }
        #endregion

        #region Numeric
        /// <summary>
        /// Verifica se a string é um numero válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsNumber(string text)
        {
            //return Regex.IsMatch(text, m_RegexNumber);
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotIntPattern.IsMatch(text) && objIntPattern.IsMatch(text);
        }

        /// <summary>
        /// Verifica se a string é um decimal válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsDecimal(string text)
        {
            return Regex.IsMatch(text, m_RegexDecimal);
        }
        #endregion

        #region Web
        /// <summary>
        /// Verifica se a string é um e-mail válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string for um e-mail e false se não for.</returns>
        public static bool IsEmail(string text)
        {
            return Regex.IsMatch(text, m_RegexEmail);
        }

        /// <summary>
        /// Verifica se a string é uma URL válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string for uma URL e false se não for.</returns>
        public static bool IsURL(string text)
        {
            return Regex.IsMatch(text, m_RegexURL);
        }
        #endregion

        #region Cultural
        /// <summary>
        /// Verifica se a string é um CEP válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsCep(string text)
        {
            return Regex.IsMatch(text, m_RegexCep);
        }

        /// <summary>
        /// Verifica se a string é um RG válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsRg(string text)
        {
            return Regex.IsMatch(text, m_RegexRg);
        }

        /// <summary>
        /// Verifica se a string é um CNPJ válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsCnpj(string text)
        {
            return Regex.IsMatch(text, m_RegexCnpj);
        }

        /// <summary>
        /// Verifica se a string é um CPF válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsCpf(string text)
        {
            return Regex.IsMatch(text, m_RegexCpf);
        }


        /// <summary>
        /// Verifica se a string é um telefone válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsTelefone(string text)
        {
            return Regex.IsMatch(text, m_RegexTelefone);
        }

        /// <summary>
        /// Verifica se a string é uma hora válida
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string possuir só números false se não.</returns>
        public static bool IsHora(string text)
        {
            return Regex.IsMatch(text, m_RegexHora);
        }

        /// <summary>
        /// Verifica se a string é um texto válido
        /// </summary>
        /// <param name="text">String a ser válidada</param>
        /// <returns>True se a string for uma data false se não.</returns>
        public static bool IsDate(string text)
        {
            return Regex.IsMatch(text, m_RegexDate);
        }
        #endregion

        #region Other
        /// <summary>
        /// Verifica se o e-mail passado pertence ao domínio passado.
        /// </summary>
        /// <param name="domain">String com o domínio a ser usado.</param>
        /// <param name="email">String com o e-mail a ser testado.</param>
        /// <returns>True caso seja da comgás, false se não for.</returns>
        public static bool IsEmailOwnerDomain(string domain, string email)
        {
            if (-1 != email.ToLower().IndexOf(domain, email.ToLower().IndexOf("@", 0)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Valida o tamanho total da string com o tamanho máximo permitido.
        /// </summary>
        /// <param name="text">Texto a ser validado.</param>
        /// <param name="length">Tamanho máximo a ser validado.</param>
        /// <returns>True ou False para validação.</returns>
        public static bool IsTextLength(string text, int length)
        {
            if (text.Length <= length)
                return true;
            return false;
        }
        #endregion
        #endregion

        #endregion
    }
}
