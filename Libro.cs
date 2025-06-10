using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{
    internal class Libro : ConexionBD
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Año { get; set; }
        public void Insertar()
        {
            Abrir();
            string query = "INSERT INTO Libros (Titulo, Autor, Año) VALUES (@Titulo, @Autor, @Año)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@Titulo", Titulo);
            cmd.Parameters.AddWithValue("@Autor", Autor);
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.ExecuteNonQuery();
            Cerrar();
        }


        public void Eliminar(int id)
        {
            Abrir();
            string query = "DELETE FROM Libros WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Cerrar();
        }
        public List<Libro> ObtenerTodos()
        {
            List<Libro> lista = new List<Libro>();
            Abrir();
            string query = "SELECT * FROM Libros";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Libro
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Titulo = reader["Titulo"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Año = Convert.ToInt32(reader["Año"])
                });
            }
            reader.Close();
            Cerrar();
            return lista;
        }
    }
}
