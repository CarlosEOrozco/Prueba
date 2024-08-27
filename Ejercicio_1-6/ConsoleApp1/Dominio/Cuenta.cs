using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    internal class Cuenta
    {
        public string Cbu { get; set; }
        public decimal Saldo { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public DateTime UltimoMovimiento { get; set; }

        public Cuenta(string cbu, decimal saldo, TipoCuenta tipoCuenta)
        {
            Cbu = cbu;
            Saldo = saldo;
            TipoCuenta = tipoCuenta;
            UltimoMovimiento = DateTime.Now;
        }
    }
}
