using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Datos
{
    public interface IBanco
    {
        //metodos abstractos
        List<Dominio.Product> GetAll();
        Dominio.Product GetById(int id);
        bool Save(Dominio.Product oProduct);
        bool Delete(int id);

    }
}
