using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CapaDatos
{
    /// <summary>
    /// Genera códigos EAN-13 y los renderiza como Bitmap.
    /// No requiere librerías externas — usa System.Drawing puro.
    /// 
    /// Estructura EAN-13:
    ///   750  = prefijo México
    ///   XXXX = código interno del producto (4 dígitos)
    ///   XXXXX= número secuencial (5 dígitos)
    ///   X    = dígito verificador (calculado)
    /// </summary>
    public static class CodigoBarrasHelper
    {
        // ── Tablas de codificación EAN-13 ────────────────────────
        // L = paridad impar, G = paridad par, R = lado derecho
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

        // Tabla de paridad según primer dígito
        private static readonly string[] TablaParidad = {
            "LLLLLL","LLGLGG","LLGGLG","LLGGGL","LGLLGG",
            "LGGLLG","LGGGLL","LGLGLG","LGLGGL","LGGLGL"
        };

        // Guardas
        private const string GuardaNormal = "101";
        private const string GuardaCentral = "01010";

        // ════════════════════════════════════════════════════════
        //  GENERACIÓN DEL CÓDIGO
        // ════════════════════════════════════════════════════════

        /// <summary>
        /// Genera un código EAN-13 único para un producto.
        /// Formato: 750 + categoriaID(2) + productoID(5) + verificador(1)
        /// </summary>
        public static string GenerarEAN13(int productoID, int categoriaID)
        {
            // 750 = prefijo México
            // CategoriaID de 2 dígitos
            // ProductoID de 5 dígitos
            string base12 = $"750{categoriaID:D2}{productoID:D5}";

            // Aseguramos exactamente 12 dígitos
            if (base12.Length > 12)
                base12 = base12.Substring(base12.Length - 12, 12);
            base12 = base12.PadLeft(12, '0');

            int verificador = CalcularVerificador(base12);
            return base12 + verificador.ToString();
        }

        /// <summary>
        /// Genera un EAN-13 aleatorio con prefijo 750 (México).
        /// Útil cuando no se tiene el ID del producto aún.
        /// </summary>
        public static string GenerarEAN13Aleatorio()
        {
            var rnd = new Random();
            string base12 = "750" + rnd.Next(0, 999999999).ToString("D9");
            int verificador = CalcularVerificador(base12);
            return base12 + verificador.ToString();
        }

        /// <summary>Calcula el dígito verificador de un EAN-12.</summary>
        public static int CalcularVerificador(string ean12)
        {
            int suma = 0;
            for (int i = 0; i < 12; i++)
                suma += (ean12[i] - '0') * (i % 2 == 0 ? 1 : 3);
            int mod = suma % 10;
            return mod == 0 ? 0 : 10 - mod;
        }

        /// <summary>Valida que un string sea un EAN-13 correcto.</summary>
        public static bool EsEAN13Valido(string codigo)
        {
            if (codigo == null || codigo.Length != 13) return false;
            foreach (char c in codigo)
                if (!char.IsDigit(c)) return false;

            int verificador = CalcularVerificador(codigo.Substring(0, 12));
            return verificador == (codigo[12] - '0');
        }

        // ════════════════════════════════════════════════════════
        //  RENDERIZADO — genera Bitmap del código de barras
        // ════════════════════════════════════════════════════════

        /// <summary>
        /// Genera la imagen Bitmap del código EAN-13.
        /// </summary>
        /// <param name="ean13">Código de 13 dígitos.</param>
        /// <param name="anchoTotal">Ancho de la imagen en píxeles.</param>
        /// <param name="altoTotal">Alto de la imagen en píxeles.</param>
        public static Bitmap GenerarImagen(string ean13, int anchoTotal = 280, int altoTotal = 120)
        {
            if (!EsEAN13Valido(ean13))
                throw new ArgumentException($"El código '{ean13}' no es un EAN-13 válido.");

            // Construir la secuencia de bits
            string bits = ConstruirBits(ean13);

            var bmp = new Bitmap(anchoTotal, altoTotal, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int margenIzq = 14;
                int anchoBarra = Math.Max(1, (anchoTotal - margenIzq * 2) / bits.Length);
                int altoBarraNormal = altoTotal - 28;
                int altoBarraGuarda = altoTotal - 18;  // Guardas son más largas
                int yInicio = 4;

                // Determinar posiciones de guardas para barras largas
                int lenGuardaIzq = GuardaNormal.Length;                    // 0..2
                int lenIzq = lenGuardaIzq + 6 * 7;                   // 3..44
                int lenGuardaCen = GuardaCentral.Length;                   // 45..49
                int lenDer = lenGuardaCen + 6 * 7;                   // 50..91
                // int lenGuardaDer = GuardaNormal.Length;                  // 92..94

                using (var pincel = new SolidBrush(Color.Black))
                {
                    for (int i = 0; i < bits.Length; i++)
                    {
                        if (bits[i] == '1')
                        {
                            // Barras de guarda son más largas
                            bool esGuarda = i < lenGuardaIzq
                                         || (i >= lenIzq && i < lenIzq + lenGuardaCen)
                                         || i >= lenIzq + lenGuardaCen + lenDer;

                            int alto = esGuarda ? altoBarraGuarda : altoBarraNormal;
                            int x = margenIzq + i * anchoBarra;
                            g.FillRectangle(pincel, x, yInicio, anchoBarra, alto);
                        }
                    }
                }

                // Texto del código debajo
                using (var fuente = new Font("Courier New", 9F, FontStyle.Regular))
                using (var pincelTexto = new SolidBrush(Color.Black))
                {
                    // Primer dígito (a la izquierda de la guarda)
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

        // ════════════════════════════════════════════════════════
        //  PRIVADO — construcción de bits EAN-13
        // ════════════════════════════════════════════════════════
        private static string ConstruirBits(string ean13)
        {
            int primerDigito = ean13[0] - '0';
            string paridad = TablaParidad[primerDigito];

            var bits = new System.Text.StringBuilder();

            // Guarda izquierda
            bits.Append(GuardaNormal);

            // 6 dígitos izquierda
            for (int i = 0; i < 6; i++)
            {
                int d = ean13[i + 1] - '0';
                bits.Append(paridad[i] == 'L' ? CodigosL[d] : CodigosG[d]);
            }

            // Guarda central
            bits.Append(GuardaCentral);

            // 6 dígitos derecha
            for (int i = 0; i < 6; i++)
            {
                int d = ean13[i + 7] - '0';
                bits.Append(CodigosR[d]);
            }

            // Guarda derecha
            bits.Append(GuardaNormal);

            return bits.ToString();
        }
    }
}