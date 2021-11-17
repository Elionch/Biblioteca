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
    public partial class FormMain : Form
    {
        private Librologica _librologica;
        public FormMain()
        {
            InitializeComponent();
            _librologica = new Librologica();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
            CargarLibro();
            
        }

       

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormLibro formlibro = new FormLibro();
            formlibro.ShowDialog(this);
        }

        private void grLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)grLibros.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value.ToString() == "Editar")
            {

                FormLibro formlibro = new FormLibro();

                formlibro.CargarLibro(new Libro
                {
                    Id = int.Parse((grLibros.Rows[e.RowIndex].Cells[0]).Value.ToString()),
                    Titulo = grLibros.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Autor = grLibros.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    ISBN = grLibros.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Paginas = grLibros.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    Edicion = grLibros.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Editorial = grLibros.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Lugar = grLibros.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    FechaE = grLibros.Rows[e.RowIndex].Cells[4].Value.ToString(),
                });

                formlibro.ShowDialog(this);
            }

            else if (cell.Value.ToString() == "Eliminar")
            {
                BorrarLibro(int.Parse((grLibros.Rows[e.RowIndex].Cells[0]).Value.ToString()));
                CargarLibro();

            }
        }
        public void CargarLibro(String SearchText = null)
        {
            List<Libro> libro = _librologica.GetLibro(SearchText);
            grLibros.DataSource = libro;
        }
        private void BorrarLibro(int id)
        {
            _librologica.BorrarLibro(id);
        }
    }
}
