using Proveedoresss.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proveedoresss.Models
{
    internal class ProveedoresModel
    {
        public int IDProveedores { get; set; }
        public string NombreEmpresa { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string DisplayName
        {
            get
            {
                return NombreEmpresa + " " + Direccion + " " + Telefono;
            }
        }
        private ConexionBDD conexionBDD = new ConexionBDD();

        SqlDataReader lector;
        List<ProveedoresModel> listaProveedores = new List<ProveedoresModel>();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public List<ProveedoresModel> Todos()
        {
            string cadena = "SELECT * FROM Proveedores";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexionBDD.AbrirConexion());
            DataTable data = new DataTable();
            adapter.Fill(data);
            foreach (DataRow fila in data.Rows)
            {
                ProveedoresModel proveedor = new ProveedoresModel
                {
                    IDProveedores = Convert.ToInt32(fila["IDProveedores"]),
                    NombreEmpresa = fila["Nombre"].ToString(),
                    Direccion = fila["Dirección"].ToString(),
                    Telefono = fila["Teléfono"].ToString(),

                };
                listaProveedores.Add(proveedor);
            }

            conexionBDD.CerrarConexion();
            return listaProveedores;
        }


        public void agregar()
        {
            cmd.Connection = conexionBDD.AbrirConexion();
            string cadena = "INSERT INTO Proveedores (NombreEmpresa, Dirección, Teléfono) VALUES (@Nombre, @Direccion, @Telefono)";
            using (SqlCommand cmd = new SqlCommand(cadena, conexionBDD.AbrirConexion()))
            {
                cmd.Parameters.AddWithValue("@Nombre", NombreEmpresa);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.ExecuteNonQuery();
                conexionBDD.CerrarConexion();
            }
        }




        public void Actualizar()
        {

            string cadena = "UPDATE Proveedores SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono WHERE IDProveedores = @IDProveedores";
            using (SqlCommand comando = new SqlCommand(cadena, conexionBDD.AbrirConexion()))
            {
                comando.Parameters.AddWithValue("@IDProveedor", IDProveedores);
                comando.Parameters.AddWithValue("@Nombre", NombreEmpresa);
                comando.Parameters.AddWithValue("@Direccion", Direccion);
                comando.Parameters.AddWithValue("@Telefono", Telefono);
                comando.ExecuteNonQuery();
                conexionBDD.CerrarConexion();
            }

        }

        public void Eliminar(int id)
        {
            string cadena = "DELETE FROM Proveedores WHERE IDProveedores = @IDProveedor";
            using (SqlCommand cmd = new SqlCommand(cadena, conexionBDD.AbrirConexion()))
            {
                cmd.Parameters.AddWithValue("@IDProveedor", id);
                cmd.ExecuteNonQuery();
                conexionBDD.CerrarConexion();
            }

        }
    }
}
