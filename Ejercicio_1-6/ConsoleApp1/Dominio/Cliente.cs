using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    internal class Cliente
    {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Dni { get; set; }
            public List<Cuenta> Cuentas { get; set; }

            public Cliente(string nombre, string apellido, string dni)
            {
                Nombre = nombre;
                Apellido = apellido;
                Dni = dni;
                Cuentas = new List<Cuenta>();
            }

            public void AgregarCuenta(Cuenta cuenta)
            {
                Cuentas.Add(cuenta);
            }

    }
}
