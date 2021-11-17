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

                string query =  @"INSERT INTO InfoLibro (Titulo, Autor, ISBN, Paginas, Edicion, Editorial, Lugar, Fecha_edicion) VALUES (@Titulo, @Autor, @ISBN, @Paginas, @Edicion, @Editorial, @Lugar, @Fecha_edicion)";


                SqlParameter titulo = new SqlParameter("@Titulo", libro.Titulo);
                SqlParameter autor = new SqlParameter("@Autor", libro.Autor);
                SqlParameter isbn = new SqlParameter("@Isbn", libro.ISBN);
                SqlParameter paginas = new SqlParameter("@Paginas", libro.Paginas);
                SqlParameter edicion = new SqlParameter("@Edicion", libro.Edicion);
                SqlParameter editorial = new SqlParameter("@Editorial", libro.Editorial);
                SqlParameter lugar = new SqlParameter("@Lugar", libro.Lugar);
                SqlParameter fecha = new SqlParameter("@Fecha_edicion", libro.FechaE);


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
            catch (Exception e)
            {
                throw;
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
                     string query = @"SELECT Titulo, Autor, ISBN, Paginas, Edicion, Editorial, Lugar, Fecha_edicion
                                   FROM InfoLibro";
                SqlCommand comando = new SqlCommand();
              

                comando.CommandText = query;
                comando.Connection = lb;


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                        libro.Add(new Libro
                    {
                       
                        Titulo = reader["Titulo"].ToString(),
                        Autor = reader["Autor"].ToString(),
                        ISBN = reader["ISBN"].ToString(),
                        Paginas = reader["Paginas"].ToString(),
                        Edicion = reader["Edicion"].ToString(),
                        Editorial = reader["Editorial"].ToString(),
                        Lugar = reader["Lugar"].ToString(),
                        FechaE = reader["Fecha_edicion"].ToString(),
                        });
                }
            }
            catch (Exception )
            {

                throw;
            }
            finally
            {
                lb.Close();
            }
            return libro;

        }
        public void ActualizarLibro(Libro libro)
        {
            try
            {
                
                lb.Open();
                string query = @"UPDATE  Contactos  SET Titulo=@Titulo, Autor=@Autor, ISBN=@ISBN, Paginas=@Paginas, Edicion=@Edicion, Editorial=@Editorial, Lugar=@Lugar, Fecha edicion=@Fecha edicion
                          WHERE Id=@Id";
                

                SqlParameter id = new SqlParameter("@Id", libro.Id);
                SqlParameter titulo = new SqlParameter("@Titulo", libro.Titulo);
                SqlParameter autor = new SqlParameter("@Autor", libro.Autor);
                SqlParameter isbn = new SqlParameter("@ISBN", libro.ISBN);
                SqlParameter paginas = new SqlParameter("@Paginas", libro.Paginas);
                SqlParameter edicion = new SqlParameter("@Edicion", libro.Edicion);
                SqlParameter editorial = new SqlParameter("@Editorial", libro.Editorial);
                SqlParameter lugar = new SqlParameter("@Lugar", libro.Lugar);
                SqlParameter fechae = new SqlParameter("@Fecha edicion", libro.FechaE);


                SqlCommand comando = new SqlCommand(query, lb);
                comando.Parameters.Add(id);
                comando.Parameters.Add(titulo);
                comando.Parameters.Add(autor);
                comando.Parameters.Add(isbn);
                comando.Parameters.Add(paginas);
                comando.Parameters.Add(edicion);
                comando.Parameters.Add(editorial);
                comando.Parameters.Add(lugar);
                comando.Parameters.Add(fechae);
                
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                lb.Close();
            }
        }
        public void BorrarLibro(int id)

        {
            try
            {
                lb.Open();
                string query = "DELETE FROM InfoLibro WHERE Id=@Id";
                
                SqlCommand comando = new SqlCommand(query, lb);
                comando.Parameters.Add(new SqlParameter("@Id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception )
            {

                throw;
            }
            finally
            {
                lb.Close();
            }

        }
    }
}
    

