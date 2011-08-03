using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Classe tempor·ria, para caso as funÁÛes em Consts.* necessitem de banco de dados.
    /// Como Consts somente deve possuir classes e mÈtodos est·ticos, ela n„o pode herdar da classe
    /// Conexao, que possui os objetos de manipulaÁ„o de banco de dados.
    /// </summary>
    internal class Temp 
    {
    }
    
    
    /// <summary>
    /// Classe de constantes.
    /// </summary>
    public partial class Consts
    {
        /// <summary>
        /// Classe com funÁıes de uso geral
        /// </summary>
        public class Funcoes
        {
            
            /// <summary>
            /// Retorrna o nome da p·gina indicada pela URL, sem o path e sem a extens„o
            /// </summary>
            /// <param name="url">URL da p·gina</param>
            /// <returns>Nome do formul·rio</returns>
            public static string FormName(string url)
            {
                string NomeCompleto = url.Split('/')[url.Split('/').Length - 1];
                return NomeCompleto.Substring(0, NomeCompleto.IndexOf('.')).ToUpper();
            }

            /// <summary>
            /// Converte uma data para data por extenso
            /// </summary>
            /// <param name="dt">Data natural</param>
            /// <returns>Data por extenso</returns>
            public static string DataPorExtenso(DateTime dt)
            {
                return String.Format("{0:dddd, d' de 'MMMM' de 'yyyy}", dt);
            }

            /// <summary>
            /// Remove acentos de uma string
            /// </summary>
            /// <param name="texto">String de origem a ser removido os acentos</param>
            /// <returns>String com os acentos removidos</returns>
            public static string tira_acentos(string texto)
            {
                string ComAcentos = "ƒ≈¡¬¿√‰·‚‡„… À»ÈÍÎËÕŒœÃÌÓÔÏ÷”‘“’ˆÛÙÚı‹⁄€¸˙˚˘«Á";
                string SemAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";
                for (int i = 0; i < ComAcentos.Length; i++)
                {
                    texto = texto.Replace(ComAcentos[i].ToString(), SemAcentos[i].ToString());
                }
                return texto;
            }

            /// <summary>
            /// Escreve um dia da semana por extenso
            /// </summary>
            /// <param name="dt">Data</param>
            /// <returns>Dia da semana por extenso</returns>
            public static string DiaDaSemanaPorExtenso(DateTime dt)
            {
                string DiaSemana = "";
                switch (dt.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        {
                            DiaSemana = "Sexta-Feira";
                            break;
                        }
                    case DayOfWeek.Monday:
                        {
                            DiaSemana = "Segunda-Feira";
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            DiaSemana = "S·bado";
                            break;
                        }
                    case DayOfWeek.Sunday:
                        {
                            DiaSemana = "Domingo";
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            DiaSemana = "Quinta-feira";
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            DiaSemana = "TerÁa-feira";
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            DiaSemana = "Quarta-Feira";
                            break;
                        }
                }
                return DiaSemana;
            }

            /// <summary>
            /// Verifica se um CPF È v·lido
            /// </summary>
            /// <param name="pCPF">CPF a ser validado</param>
            /// <returns>True se o CPF for v·lido, false se n„o v·lido</returns>
            public static bool ValidarCPF(string pCPF)
            {
                //Remove a m·scara, se houver
                bool st = false;
                pCPF = pCPF.Replace("/", "").Replace(".", "").Replace("-","").Replace(" ","");
                try
                {
                    long pCPFi = long.Parse(pCPF);
                    pCPF = pCPFi.ToString().PadLeft(11,'0');
                }
                catch
                {
                    return false;
                }
                if (pCPF.Length != 11)
                {
                    return false;
                }
                else
                {
                    string DV = pCPF.Substring(9, 2);
                    int cDV1 = 0;
                    int cDV2 = 0;
                    
                    //C·lculo do 1∫ DV
                    int soma = 0;
                    int mult = 10;
                    for(int i = 0; i < 9; i++)
                    {
                        soma += Int32.Parse(pCPF[i].ToString()) * mult;
                        mult--;
                    }
                    if (((soma % 11) == 0) || ((soma % 11) == 1))
                    {
                        cDV1 = 0;
                    }
                    else
                    {
                        cDV1 = 11 - (soma % 11);
                    }

                    //C·lculo do 2∫ DV
                    soma = 0;
                    mult = 11;
                    for (int i = 0; i < 10; i++)
                    {
                        soma += Int32.Parse(pCPF[i].ToString()) * mult;
                        mult--;
                    }
                    if (((soma % 11) == 0) || ((soma % 11) == 1))
                    {
                        cDV2 = 0;
                    }
                    else
                    {
                        cDV2 = 11 - (soma % 11);
                    }
                    st = DV.Equals(cDV1.ToString() + cDV2.ToString());
                }
                return st;
            }

            /// <summary>
            /// Verifica se um CNPJ È v·lido
            /// </summary>
            /// <param name="cnpj">CNPJ a ser validado</param>
            /// <returns>True se o CNPJ for v·lido, false se n„o v·lido</returns>
            public static bool ValidarCNPJ(string cnpj)
            {
                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                if (cnpj.Length != 14)
                {
                    return false;
                }
                else
                {
                    int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                    int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                    int soma;
                    int resto;
                    string digito;
                    string tempCnpj;

                    if (cnpj.Length != 14)
                        return false;

                    tempCnpj = cnpj.Substring(0, 12);

                    soma = 0;
                    for (int i = 0; i < 12; i++)
                        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

                    resto = (soma % 11);
                    if (resto < 2)
                        resto = 0;
                    else
                        resto = 11 - resto;

                    digito = resto.ToString();

                    tempCnpj = tempCnpj + digito;
                    soma = 0;
                    for (int i = 0; i < 13; i++)
                        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

                    resto = (soma % 11);
                    if (resto < 2)
                        resto = 0;
                    else
                        resto = 11 - resto;

                    digito = digito + resto.ToString();

                    return cnpj.EndsWith(digito);
                }
            }

            /// <summary>
            /// Converte string vazia em um objeto DBNull
            /// </summary>
            /// <param name="s">String a ser convertida</param>
            /// <returns>s, se s for diferente de vazio, ou DBNull, caso s seja vazia</returns>
            public static object ValueOrDBNull(object s)
            {
                return ((s.ToString().Equals("") || (s == null)) ? (object)DBNull.Value : s.ToString());
            }
            
            /// <summary>
            /// Converte zero em um objeto do tipo DBNull
            /// </summary>
            /// <param name="i">Inteiro a ser convertido</param>
            /// <returns>i, se i for diferente de zero; DBNull, se i for igual a zero</returns>
            public static object ZeroOrDBNull(int i)
            {
                return ((i == 0) ? (object)DBNull.Value : i);
            }

            /// <summary>
            /// Converte zero em um objeto do tipo DBNull
            /// </summary>
            /// <param name="i">Inteiro a ser convertido</param>
            /// <returns>i, se i for diferente de zero; DBNull, se i for igual a zero</returns>
            public static object ZeroOrDBNull(Double i)
            {
                return ((i == 0) ? (object)DBNull.Value : i);
            }
            
            /// <summary>
            /// Converte um objeto em string; nulo corresponde a string vazia
            /// </summary>
            /// <param name="o">Objeto a ser convertido</param>
            /// <returns>String correspondente ao objeto; se ele for nulo, È uma string vazia</returns>
            public static string NullOrString(object o)
            {
                return ((o == null) || (o.ToString().Equals(""))) ? "" : o.ToString();
            }

            /// <summary>
            /// Converte um objeto em Char; nulo corresponde ao caracter NULL
            /// </summary>
            /// <param name="o">Objeto a ser convertido</param>
            /// <returns>Caracter correspondente ao objeto; se ele for nulo, È um caracter vazio</returns>
            public static char NullOrChar(object o)
            {
                return ((o == null) || (o.ToString().Equals(""))) ? '\0' : o.ToString()[0];
            }

            /// <summary>
            /// Converte um objeto em inteiro de 32 bits; nulo correspondente a zero
            /// </summary>
            /// <param name="o">Objeto a ser convertido</param>
            /// <returns>Inteiro correspondente ao objeto; se ele for nulo, È zero</returns>
            public static int NullOrInt(object o)
            {
                return ((o == null) || (o.ToString().Equals(""))) ? 0 : Int32.Parse(o.ToString());
            }

            /// <summary>
            /// Converte um objeto em inteiro longo; nulo correspondente a zero
            /// </summary>
            /// <param name="o">Objeto a ser convertido</param>
            /// <returns>Inteiro longo correspondente ao objeto; se ele for nulo, È igual a zero</returns>
            public static long NullOrLong(object o)
            {
                return ((o == null) || (o.ToString().Equals(""))) ? 0 : long.Parse(o.ToString());
            }

            /// <summary>
            /// Converte um objeto em Double; nulo correspondente a zero
            /// </summary>
            /// <param name="o">Objeto a ser convertido</param>
            /// <returns>Double correspondente ao objeto; se ele for nulo, È igual a zero</returns>
            public static double NullOrFloat(object o)
            {
                return ((o == null) || (o.ToString().Equals(""))) ? 0 : Double.Parse(o.ToString());
            }

            /// <summary>
            /// Converte um objeto em string com formataÁ„o DD/MM/AAAA; nulo corresponde a string vazia.
            /// Usar com objetos do tipo DateTime
            /// </summary>
            /// <param name="o">Objeto a ser convertido</param>
            /// <returns>String formatada correspondente ao objeto; se ele for nulo, È igual a string vazia</returns>
            public static string NullOrDateFmt(object o)
            {
                return ((o == null) || (o.ToString().Equals(""))) ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Parse(o.ToString()));
            }

            /// <summary>
            /// Converte um objeto em string com formataÁ„o HH:MM (24 horas); nulo corresponde a string vazia;
            /// Utilizar com objetos do tipo DateTime
            /// </summary>
            /// <param name="o">Objeto a ser convertido</param>
            /// <returns>String correspondente ao objeto; se ele for nulo, È igual a string vazia</returns>
            public static string NullOrTimeFmt(object o)
            {
                return ((o == null) || (o.ToString().Equals(""))) ? "" : String.Format("{0:HH:mm}", DateTime.Parse(o.ToString()));
            }

            /// <summary>
            /// Substitui caracteres que possam conflitar com os caracteres de controle em instruÁıes
            /// JavaScript, como aspa simples, retorno de carro e quebra de linha.
            /// </summary>
            /// <param name="str">String a ser tratada</param>
            /// <returns>String com caracteres aspa simples, retorno de carro e quebra de linha substituÌdos.</returns>
            public static string Replacer4js(string str)
            {
                string retorno = str;
                retorno = retorno.Replace("'", "");
                retorno = retorno.Replace("\n", "\\n");
                retorno = retorno.Replace("\r", "\\r");
                return retorno;
            }

            ///// <summary>
            ///// Cria um dataset preenchido para prototipar grids sem depender de banco de dados.
            ///// </summary>
            ///// <param name="qtdLinhas">Quantidade de linhas a serem geradas</param>
            ///// <param name="qtdColunas">Quantidade de colunas a serem geradas</param>
            ///// <returns>Datatable preenchido com valores arbitr·rios, para prototipar grids</returns>
            ///// <remarks>Os nomes das colunas ser„o criados com os nomes COLUNA1,COLUNA2, COLUNA"n", onde "n" È a quantidade de colunas informada em qrdColunas</remarks>
            //public static DataTable DataSetPrototipo(int qtdLinhas, int qtdColunas)
            //{
            //    DataTable dt = new DataTable();
            //    object[] novalinha = new object[qtdColunas];
            //    for (int i = 0; i < qtdColunas; i++)
            //    {
            //        novalinha[i] = "nononono";
            //        dt.Columns.Add(new DataColumn("COLUNA" + i.ToString()));
            //    }
            //    for (int j = 0; j < qtdLinhas; j++)
            //    {
            //        dt.Rows.Add(novalinha);
            //    }
            //    return dt;
            //}

            /// <summary>
            /// Verifica se um objeto È do tipo Double
            /// </summary>
            /// <param name="o">Objeto a ser verificado</param>
            /// <returns>True em caso afirmativo, False em caso negativo</returns>
            public static bool IsDouble(object o)
            {
                return (o is Double);
            }

            /// <summary>
            /// Converte um "null" de object para nulo de Banco de Dados
            /// </summary>
            /// <param name="o">Objeto a ser convertido</param>
            /// <returns>O prÛprio objeto, caso ele n„o esteja nulo e DBNull caso o objeto esteja nulo</returns>
            public static object NullToDBNull(object o)
            {
                return (o != null) ? o : DBNull.Value;
            }

            public static bool CompararIgualdadeByteArray(byte[] a1, byte[] a2)
            {
                bool r = true;
                for (int i = 0; i < a1.Length; i++)
                {
                    if (a2[i] != a1[i])
                    {
                        r = false;
                        break;
                    }
                }
                return r;
            }

        }
    }
}
