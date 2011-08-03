using System;
using System.Collections;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    ///Classe para escrever por extenso os valores em Real (em C# - suporta até R$ 9.999.999.999,99)
    ///Rotina Criada para ler um número e transformá-lo em extenso
    ///Limite máximo de 9 Bilhões (9.999.999.999,99)
    ///Não aceita números negativos
    /// </summary>
    public sealed class NumeroPorExtenso
    {
        private ArrayList numeroLista;

        private Int32 num;

        private TipoNumero tipo;

        //array de 2 linhas e 14 colunas[2][14]
        private static readonly String[,] qualificadores = new String[,] {
																			 //				{"milésimo de real","milésimos de real"},//[0][0] e [0][1]
				{"centavo", "centavos"},//[1][0] e [1][1]
				{"", ""},//[2][0],[2][1]
				{"mil", "mil"},
				{"milhão", "milhões"},
				{"bilhão", "bilhões"},
				{"trilhão", "trilhões"},
				{"quatrilhão", "quatrilhões"},
				{"quintilhão", "quintilhões"},
				{"sextilhão", "sextilhões"},
				{"setilhão", "setilhões"},
				{"octilhão","octilhões"},
				{"nonilhão","nonilhões"},
				{"decilhão","decilhões"}
																		 };

        private static readonly String[,] numeros = new String[,] {
				{
						"zero", "um", "dois", "três", "quatro",
					"cinco", "seis", "sete", "oito", "nove",
					"dez","onze", "doze", "treze", "quatorze",
					"quinze", "dezesseis", "dezessete", "dezoito", "dezenove"},
				{
						"vinte", "trinta", "quarenta", "cinqüenta", "sessenta",
					"setenta", "oitenta", "noventa",null,null,null,null,null,null,null,null,null,null,null,null},
				{
						"cem", "cento",
					"duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos",
					"setecentos", "oitocentos", "novecentos",null,null,null,null,null,null,null,null,null,null}															  };

        public TipoNumero Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public NumeroPorExtenso()
        {
            numeroLista = new ArrayList();
            tipo = TipoNumero.Moeda;
        }

        /// <summary>
        /// Passagem do número para Extenso partindo de um decimal
        /// </summary>
        /// <param name="dec"></param>
        public NumeroPorExtenso(Decimal dec)
        {
            numeroLista = new ArrayList();
            SetNumero(dec);
            tipo = TipoNumero.Moeda;
        }

        /// <summary>
        /// Seta Numero (Decimal)
        /// </summary>
        /// <param name="dec"></param>
        public void SetNumero(Decimal dec)
        {
            numeroLista.Clear();

            //if (tipo == TipoNumero.Percentual && dec > 0 && dec < 1)
            //    numeroLista.Add(0);

            dec = Decimal.Round(dec, 2);
            dec = dec * 100;
            num = Convert.ToInt32(dec);
            
            if (num == 0)
            {
                numeroLista.Add(0);
                numeroLista.Add(0);
            }
            else
            {
                AddRemainder(100);

                while (num != 0)
                {
                    AddRemainder(1000);
                }
            }            
        }

        private void AddRemainder(Int32 divisor)
        {
            Int32 div = num / divisor;
            Int32 mod = num % divisor;

            Int32[] newNum = new Int32[] { div, mod };

            numeroLista.Add(mod);

            num = div;
        }

        private bool TemMaisGrupos(Int32 ps)
        {
            while (ps > 0)
            {
                if ((Int32)numeroLista[ps] != 00 && !TemMaisGrupos(ps - 1))
                    return true;
                ps--;
            }
            return true;
        }

        private bool EhPrimeiroGrupoUm()
        {
            if ((Int32)numeroLista[numeroLista.Count - 1] == 1)
                return true;
            else
                return false;
        }

        private bool EhUltimoGrupo(Int32 ps)
        {
            return ((ps > 0) && ((Int32)numeroLista[ps] != 0) || !TemMaisGrupos(ps - 1));
        }

        private bool EhGrupoZero(Int32 ps)
        {
            if (ps <= 0 || ps >= numeroLista.Count)
                return true;
            return ((Int32)numeroLista[ps] == 0);
        }

        private bool EhUnicoGrupo()
        {
            if (numeroLista.Count <= 3)
                return false;

            if (!EhGrupoZero(1) && !EhGrupoZero(2))
                return false;

            bool hasOne = false;

            for (Int32 i = 3; i < numeroLista.Count; i++)
            {
                if ((Int32)numeroLista[i] != 0)
                {
                    if (hasOne)
                        return false;
                    hasOne = true;
                }
            }
            return true;
        }

        private String NumToString(Int32 numero, Int32 escala)
        {
            Int32 unidade = (numero % 10);
            Int32 dezena = (numero % 100);
            Int32 centena = (numero / 100);

            StringBuilder buf = new StringBuilder();

            if (numero != 0)
            {
                if (centena != 0)
                {
                    if (dezena == 0 && centena == 1)
                    {
                        buf.Append(numeros[2, 0]);
                    }
                    else
                    {
                        buf.Append(numeros[2, centena]);
                    }
                }

                if (buf.Length > 0 && dezena != 0)
                {
                    buf.Append(" e ");
                }

                if (dezena > 19)
                {
                    dezena = dezena / 10;
                    buf.Append(numeros[1, dezena - 2]);
                    if (unidade != 0)
                    {
                        buf.Append(" e ");
                        buf.Append(numeros[0, unidade]);
                    }
                }
                else if (centena == 0 || dezena != 0)
                {
                    buf.Append(numeros[0, dezena]);
                }

                buf.Append(" ");

                if (numero == 1)
                {
                    if (escala != 0 || (escala == 0 && tipo == TipoNumero.Moeda))
                        buf.Append(qualificadores[escala, 0]);
                    if (escala == 0 && tipo == TipoNumero.Percentual)
                        buf.Append("centésimo");
                }
                else
                {
                    if (escala != 0 || (escala == 0 && tipo == TipoNumero.Moeda))
                        buf.Append(qualificadores[escala, 1]);
                    if (escala == 0 && tipo == TipoNumero.Percentual)
                        buf.Append("centésimos");
                }
                
            }
            else if (numeroLista.Count == 2 && numero == 0)
            {
                buf = new StringBuilder();
                buf.Append("zero");
            }

            return buf.ToString();
        }

        /// <summary>
        /// Transforma número em string por extenso
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            StringBuilder buf = new StringBuilder();

            //Int32 numero = (Int32)numeroLista[0];
            Int32 count;
            for (count = numeroLista.Count - 1; count > 0; count--)
            {
                if (buf.Length > 0 && !EhGrupoZero(count))
                {
                    buf.Append(" e ");
                }
                buf.Append(NumToString((Int32)numeroLista[count], count));
            }

            if (buf.Length > 0)
            {

                while (buf.ToString().EndsWith(" "))
                    buf.Length = buf.Length - 1;

                if (EhUnicoGrupo())
                {
                    buf.Append(" de ");
                }

                if (EhPrimeiroGrupoUm())
                {
                    buf.Insert(0, "h");
                }
                
                if (numeroLista.Count == 2 && (Int32)numeroLista[1] == 1)
                {
                    if (tipo == TipoNumero.Moeda)
                        buf.Append(" real");
                    else if (tipo == TipoNumero.Percentual)
                        buf.Append(" inteiro");
                }
                else if (numeroLista.Count > 2 ||
                    (numeroLista.Count == 2 && (Int32)numeroLista[1] > 0))
                {
                    if (tipo == TipoNumero.Moeda)
                        buf.Append(" reais");
                    else if (tipo == TipoNumero.Percentual)
                        buf.Append(" inteiros");
                }

                if ((Int32)numeroLista[0] != 0)
                {                    
                    buf.Append(" e ");
                }
            }

            if ((Int32)numeroLista[0] != 0)
            {
                buf.Append(NumToString((Int32)numeroLista[0], 0));
            }

            if (tipo == TipoNumero.Percentual)
            {
                if ((numeroLista.Count == 2 && (Int32)numeroLista[1] > 0) ||
                    (numeroLista.Count == 1 && (Int32)numeroLista[0] > 0) ||
                    numeroLista.Count > 2)
                {
                    if (buf.ToString().EndsWith(" "))
                        buf.Append("por cento");
                    else
                        buf.Append(" por cento");
                }                
            }

            return buf.ToString();
        }
    }

    public enum TipoNumero
    {
        Moeda = 0,
        Percentual,
        Numerico
    }
}
