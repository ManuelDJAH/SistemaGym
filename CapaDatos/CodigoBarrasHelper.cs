using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CapaDatos
{
    public static class CodigoBarrasHelper
    {
        private static readonly string[] CodigosL = {
            "0001101","0011001","0010011","0111101","0100011",
            "0110001","0101111","0111011","0110111","0001011"
        };
        private static readonly string[] CodigosG = {
            "0100111","0110011","0011011","0100001","0011101",
            "0111001","0000101","0010001","0001001","0010111"
        };
        private static readonly string[] CodigosR = {
            "1110010","1100110","1101100","1000010","1011100",
            "1001110","1010000","1000100","1001000","1110100"
        };


        private static readonly string[] TablaParidad = {
            "LLLLLL","LLGLGG","LLGGLG","LLGGGL","LGLLGG",
            "LGGLLG","LGGGLL","LGLGLG","LGLGGL","LGGLGL"
        };

        private const string GuardaNormal = "101";
        private const string GuardaCentral = "01010";

        public static string GenerarEAN13(int productoID, int categoriaID)
        {

            string base12 = $"750{categoriaID:D2}{productoID:D5}";

            if (base12.Length > 12)
                base12 = base12.Substring(base12.Length - 12, 12);
            base12 = base12.PadLeft(12, '0');

            int verificador = CalcularVerificador(base12);
            return base12 + verificador.ToString();
        }


        public static string GenerarEAN13Aleatorio()
        {
            var rnd = new Random();
            string base12 = "750" + rnd.Next(0, 999999999).ToString("D9");
            int verificador = CalcularVerificador(base12);
            return base12 + verificador.ToString();
        }

        public static int CalcularVerificador(string ean12)
        {
            int suma = 0;
            for (int i = 0; i < 12; i++)
                suma += (ean12[i] - '0') * (i % 2 == 0 ? 1 : 3);
            int mod = suma % 10;
            return mod == 0 ? 0 : 10 - mod;
        }

        public static bool EsEAN13Valido(string codigo)
        {
            if (codigo == null || codigo.Length != 13) return false;
            foreach (char c in codigo)
                if (!char.IsDigit(c)) return false;

            int verificador = CalcularVerificador(codigo.Substring(0, 12));
            return verificador == (codigo[12] - '0');
        }

        public static Bitmap GenerarImagen(string ean13, int anchoTotal = 280, int altoTotal = 120)
        {
            if (!EsEAN13Valido(ean13))
                throw new ArgumentException($"El código '{ean13}' no es un EAN-13 válido.");

            string bits = ConstruirBits(ean13);

            var bmp = new Bitmap(anchoTotal, altoTotal, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int margenIzq = 14;
                int anchoBarra = Math.Max(1, (anchoTotal - margenIzq * 2) / bits.Length);
                int altoBarraNormal = altoTotal - 28;
                int altoBarraGuarda = altoTotal - 18; 
                int yInicio = 4;

                int lenGuardaIzq = GuardaNormal.Length;
                int lenIzq = lenGuardaIzq + 6 * 7;
                int lenGuardaCen = GuardaCentral.Length;
                int lenDer = lenGuardaCen + 6 * 7; 

                using (var pincel = new SolidBrush(Color.Black))
                {
                    for (int i = 0; i < bits.Length; i++)
                    {
                        if (bits[i] == '1')
                        {

                            bool esGuarda = i < lenGuardaIzq
                                         || (i >= lenIzq && i < lenIzq + lenGuardaCen)
                                         || i >= lenIzq + lenGuardaCen + lenDer;

                            int alto = esGuarda ? altoBarraGuarda : altoBarraNormal;
                            int x = margenIzq + i * anchoBarra;
                            g.FillRectangle(pincel, x, yInicio, anchoBarra, alto);
                        }
                    }
                }

                using (var fuente = new Font("Courier New", 9F, FontStyle.Regular))
                using (var pincelTexto = new SolidBrush(Color.Black))
                {
                    string d1 = ean13[0].ToString();
                    string izq = ean13.Substring(1, 6);
                    string der = ean13.Substring(7, 6);

                    float yTexto = altoBarraNormal + 6;
                    float xIzqTexto = margenIzq + (float)(lenGuardaIzq * anchoBarra);
                    float xDerTexto = margenIzq + (float)((lenGuardaIzq + 6 * 7 + lenGuardaCen) * anchoBarra);

                    g.DrawString(d1, fuente, pincelTexto, 2, yTexto);
                    g.DrawString(izq, fuente, pincelTexto, xIzqTexto, yTexto);
                    g.DrawString(der, fuente, pincelTexto, xDerTexto, yTexto);
                }
            }

            return bmp;
        }

        private static string ConstruirBits(string ean13)
        {
            int primerDigito = ean13[0] - '0';
            string paridad = TablaParidad[primerDigito];

            var bits = new System.Text.StringBuilder();

            bits.Append(GuardaNormal);

            for (int i = 0; i < 6; i++)
            {
                int d = ean13[i + 1] - '0';
                bits.Append(paridad[i] == 'L' ? CodigosL[d] : CodigosG[d]);
            }

            bits.Append(GuardaCentral);

            for (int i = 0; i < 6; i++)
            {
                int d = ean13[i + 7] - '0';
                bits.Append(CodigosR[d]);
            }

            bits.Append(GuardaNormal);

            return bits.ToString();
        }
    }
}