using ConsoleApp1.Datos.Utils;
using RepositoryExample.Data.Utils;
using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Datos
{
    public class Banco_ADO : IBanco
    {
        //CRUD entero
        //llamar metodo del helper para conectar la BD
        //mapear
        //
        private SqlConnection _connection;

        public Banco_ADO()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }


        public bool Delete(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@codigo", id));
            int rows = DataHelper.GetInstance().ExecuteSPDML("SP_REGISTRAR_BAJA_PRODUCTO", parameters);
            return rows == 1;
        }

        public List<Dominio.Product> GetAll()
        {
            List<Dominio.Product> lst = new List<Dominio.Product>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_RECUPERAR_PRODUCTOS", null);
            foreach (DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["codigo"]);
                string nombre = row["n_producto"].ToString();
                int stock = Convert.ToInt32(row["stock"]);
                bool activo = Convert.ToBoolean(row["esta_activo"]);

                Dominio.Product oProduct = new Dominio.Product()
                {
                    Codigo = id,
                    Nombre = nombre,
                    Stock = stock,
                    Activo = activo
                };
                lst.Add(oProduct);
            }
            return lst;
        }

        public Dominio.Product GetById(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@codigo", id));
            DataTable t = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_PRODUCTO_POR_CODIGO", parameters);

            if (t != null && t.Rows.Count == 1)
            {
                DataRow row = t.Rows[0];
                int codigo = Convert.ToInt32(row["codigo"]);
                string nombre = row["n_producto"].ToString();
                int stock = Convert.ToInt32(row["stock"]);
                bool activo = Convert.ToBoolean(row["esta_activo"]);

                Product oProduct = new Product()
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Stock = stock,
                    Activo = activo
                };
                return oProduct;

            }
            return null;
        }

        public bool Save(Dominio.Product oProduct)
        {
            bool result = true;
            string query = "SP_GUARDAR_PRODUCTO";

            try
            {
                if (oProduct != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", oProduct.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", oProduct.Nombre);
                    cmd.Parameters.AddWithValue("@stock", oProduct.Stock);
                    result = cmd.ExecuteNonQuery() == 1; //ExecuteNonQuery: cantidad de filas afectadas!
                }
            }
            catch (SqlException sqlEx)
            {
                result = false;
            }
            finally
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }
    }
}
