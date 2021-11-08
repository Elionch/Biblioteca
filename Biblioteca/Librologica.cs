using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace Biblioteca
{
    class Librologica
    {
        private LibroDatos _librodatos;

        public Librologica() 
        {
            _librodatos = new LibroDatos();
        }
        public Libro GuardarLibro(Libro libro) {
            if (libro.Id == 0)
                _librodatos.InsertarLibro(libro);
            else
            {
                //_librodatos.UpdateLibro(libro);
            }
            return libro;
        }
        public List<Libro> GetLibro(string TextSearch = null)
        {
            return _librodatos.GetLibro(TextSearch);
        }
        public void BorrarLibro(int id)
        {

            //_librodatos.BorrarLibro(id);

        }
    }
        
 }
    

