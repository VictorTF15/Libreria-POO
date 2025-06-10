using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{
    internal class ConexionBD
    {
        private string cadenaConexion ="Server=localhost;Database=Biblioteca;Trusted_Connection=True;";
        protected SqlConnection conexion;
        public void Abrir()
        {
            conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
        }
        public void Cerrar()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
