using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class ProductService
    {
        //clase intermediario, get all, save, delete
        private Datos.IBanco _repositorio;

        public ProductService()
        {
            _repositorio = new Datos.Banco_ADO();
        }

        public List<Dominio.Product> GetProducts()
        {
            return _repositorio.GetAll();
        }

        public Dominio.Product GetProductByCodigo(int cod)
        {
            return _repositorio.GetById(cod);
        }

        public bool SaveProduct(Dominio.Product oProduct)
        {
            return _repositorio.Save(oProduct);
        }
        public bool DeleteProduct(int cod)
        {
            return _repositorio.Delete(cod);
        }
    }
}
