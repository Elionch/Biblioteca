using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblioteca
{
    class LibroDatos
    {
        SqlConnection lb = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Libro;Data Source=DESKTOP-2TO5G68\\SQLEXPRESS");
        public void InsertarLibro(Libro libro)
        {
            try
            {
                lb.Open();

                string query =  @"INSERT INTO Libro (Titulo, Autor, ISBN, Paginas, Edicion, Editorial, Lugar, Fecha edicion) VALUES (@Titulo, @Autor, @ISBN, @Paginas, @Edicion, @Editorial, @Lugar, @Fecha edicion)";


                SqlParameter titulo = new SqlParameter("@Titulo", libro.Titulo);
                SqlParameter autor = new SqlParameter("@Autor", libro.Autor);
                SqlParameter isbn = new SqlParameter("@Isbn", libro.ISBN);
                SqlParameter paginas = new SqlParameter("@Paginas", libro.Paginas);
                SqlParameter edicion = new SqlParameter("@Edicion", libro.Edicion);
                SqlParameter editorial = new SqlParameter("@Editorial", libro.Editorial);
                SqlParameter lugar = new SqlParameter("@Lugar", libro.Lugar);
                SqlParameter fecha = new SqlParameter("@Fecha edicion", libro.FechaE);


                SqlCommand comando = new SqlCommand(query, lb);
                comando.Parameters.Add(titulo);
                comando.Parameters.Add(autor);
                comando.Parameters.Add(isbn);
                comando.Parameters.Add(paginas);
                comando.Parameters.Add(edicion);
                comando.Parameters.Add(editorial);
                comando.Parameters.Add(lugar);
                comando.Parameters.Add(fecha);

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                
            }
            finally
            {
                lb.Close();
            }
            
        }
        public List<Libro> GetLibro(string search = null)
        {
            List<Libro> libro = new List<Libro>();
            
            try
            {
                lb.Open();
                     string query = @"SELECT Titulo, Autor, ISBN, Paginas, Edicion, Editorial, Lugar, Fecha edicion
                                   FROM Libro";
                SqlCommand comando = new SqlCommand();
              

                comando.CommandText = query;
                comando.Connection = lb;


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                        libro.Add(new Libro
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Titulo = reader["Titulo"].ToString(),
                        Autor = reader["Autor"].ToString(),
                        ISBN = int.Parse(reader["ISBN"].ToString()),
                        Paginas = int.Parse(reader["Paginas"].ToString()),
                        Edicion = int.Parse(reader["Edicion"].ToString()),
                        Editorial = reader["Editorial"].ToString(),
                        Lugar = reader["Lugar"].ToString(),
                        FechaE = reader["Fecha edicion"].ToString(),
                        });
                }
            }
            catch (Exception)
            {

                
            }
            finally
            {
                lb.Close();
            }
            return libro;

        }
    }
}
