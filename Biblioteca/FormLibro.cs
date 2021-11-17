using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Biblioteca
{
    public partial class FormLibro : Form
    {
        private Librologica _librologica;

        private Libro _libro;
        public FormLibro()
        {
            InitializeComponent();
            _librologica = new Librologica();
        }

        private void FormLibro_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarLibro();
            this.Close();
            ((FormMain)this.Owner).CargarLibro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GuardarLibro()
        {
            Libro libro = new Libro();
            
            libro.Titulo = bxTitulo.Text;
            libro.Autor = bxAutor.Text;
            libro.ISBN = bxISBN.Text;
            libro.Paginas = bxPaginas.Text;
            libro.Edicion = bxEdicion.Text;
            libro.Editorial = bxEditorial.Text;
            libro.Lugar = bxLugar.Text;
            libro.FechaE = bxFecha.Text;

            libro.Id = libro != null ? libro.Id : 0;
            _librologica.GuardarLibro(libro);
        }
        public void CargarLibro(Libro libro)
        {
            _libro = libro;
            if (libro != null)
            {
                ClearForm();
                bxTitulo.Text = libro.Titulo;
                bxAutor.Text = libro.Autor;
                bxISBN.Text = libro.ISBN;
                bxPaginas.Text = libro.Paginas;
                bxEdicion.Text = libro.Edicion;
                bxEditorial.Text = libro.Editorial;
                bxLugar.Text = libro.Lugar;
                bxFecha.Text = libro.FechaE;
            }

        }
        private void ClearForm()
        {
            bxTitulo.Text = string.Empty;
            bxAutor.Text = string.Empty;
            bxISBN.Text = string.Empty;
            bxPaginas.Text = string.Empty;
            bxEdicion.Text = string.Empty;
            bxEditorial.Text = string.Empty;
            bxLugar.Text = string.Empty;
            bxFecha.Text = string.Empty;
        }

    }
}
    

