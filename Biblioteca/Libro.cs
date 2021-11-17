using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblioteca
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public string Paginas { get; set; }
        public string Edicion { get; set; }
        public string Editorial { get; set; }
        public string Lugar { get; set; }
        public string FechaE { get; set; }

       
    }
}
