using System;

namespace CapaDeDatos
{
    public class TipoDato
    {
        public System.Nullable<int> Entero { get; set; }
        public System.String Texto { get; set; }
        public System.Nullable<DateTime> FechaYHora { get; set; }
        public System.Nullable<decimal> Decimal { get; set; }
        public System.Nullable<Boolean> Boleano { get; set; }
        public System.Char Caracter { get; set; }
        public byte[] Imagen { get; set; }
        public System.Nullable<long> EnteroLargo { get; set; }
        public byte[] Archivo { get; set; }

    }
}
