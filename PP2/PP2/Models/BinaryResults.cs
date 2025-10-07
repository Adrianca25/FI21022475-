using System;
using System.Linq;
using System.Text;

namespace PP2Web.Models
{
    // Contiene siempre los valores binarios (como strings) y provee utilidades
    public class BinaryResults
    {
        // Binary strings (los originales y los resultados)
        public string A { get; set; }           // original (sin rellenar)
        public string B { get; set; }           // original (sin rellenar)
        public string BinA8 { get; set; }       // A rellenado a 8 bits
        public string BinB8 { get; set; }       // B rellenado a 8 bits
        public string And { get; set; }         // resultado binario (sin ceros a la izquierda, mínimo "0")
        public string Or { get; set; }
        public string Xor { get; set; }
        public string Sum { get; set; }         // suma (binario)
        public string Mul { get; set; }         // multiplicación (binario)

        // Para mostrar en la tabla: conversiones. Cada método recibe un binario (string) y devuelve (Bin8, Oct, Dec, Hex)
        public static (string binTrimmed, string oct, string dec, string hex) ToAllBases(string bin)
        {
            // Acepta binario como string (por ejemplo "00001010" o "1010").
            // Para binario en tabla se mostrará la versión sin ceros a la izquierda excepto en columna "Bin" donde
            // para a y b queremos mostrar 8-bit.
            // Aquí devolvemos la representación binaria (sin ceros a la izquierda salvo si es "0"), y las demás bases.
            string trimmed = TrimLeadingZeros(bin);
            int decValue = Convert.ToInt32(trimmed, 2);
            string oct = Convert.ToString(decValue, 8);
            string hex = Convert.ToString(decValue, 16).ToUpper();
            return (trimmed, oct, decValue.ToString(), hex);
        }

        public static string TrimLeadingZeros(string bin)
        {
            if (string.IsNullOrEmpty(bin)) return "0";
            var t = bin.TrimStart('0');
            return string.IsNullOrEmpty(t) ? "0" : t;
        }

        // Rellena a 8 bits por la izquierda
        public static string PadTo8(string bin)
        {
            if (bin == null) return "00000000";
            return bin.PadLeft(8, '0');
        }

        // Operaciones binarias bit a bit sobre strings (ambos deben tener la misma longitud)
        public static string BinaryAnd(string x, string y)
        {
            return BinaryBitwise(x, y, (cx, cy) => (cx == '1' && cy == '1') ? '1' : '0');
        }
        public static string BinaryOr(string x, string y)
        {
            return BinaryBitwise(x, y, (cx, cy) => (cx == '1' || cy == '1') ? '1' : '0');
        }
        public static string BinaryXor(string x, string y)
        {
            return BinaryBitwise(x, y, (cx, cy) => (cx != cy) ? '1' : '0');
        }

        private static string BinaryBitwise(string x, string y, Func<char, char, char> op)
        {
            // Espera x,y de la misma longitud
            if (x == null) x = "";
            if (y == null) y = "";
            var sb = new StringBuilder();
            int len = Math.Max(x.Length, y.Length);
            // Asegurar que ambos tengan la misma longitud rellenando a la izquierda con ceros
            x = x.PadLeft(len, '0');
            y = y.PadLeft(len, '0');
            for (int i = 0; i < len; i++)
            {
                sb.Append(op(x[i], y[i]));
            }
            // Devolver el string resultante (no lo recortamos aquí; se recorta al mostrar)
            return sb.ToString();
        }

        // Suma y multiplicación: usar conversiones integradas y luego volver a binario
        public static string BinarySum(string aBin, string bBin)
        {
            int a = Convert.ToInt32(TrimLeadingZeros(aBin), 2);
            int b = Convert.ToInt32(TrimLeadingZeros(bBin), 2);
            int s = a + b;
            return Convert.ToString(s, 2); // sin ceros a la izquierda
        }
        public static string BinaryMul(string aBin, string bBin)
        {
            int a = Convert.ToInt32(TrimLeadingZeros(aBin), 2);
            int b = Convert.ToInt32(TrimLeadingZeros(bBin), 2);
            int m = a * b;
            return Convert.ToString(m, 2);
        }
    }
}
