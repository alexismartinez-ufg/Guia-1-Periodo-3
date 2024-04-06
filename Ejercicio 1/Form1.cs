using System.Linq;
using System.Windows.Forms;
using Ejercicio_1.Models;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Regrescar();
        }

        private int? ObtenerId()
        {
            try
            {
                return int.Parse(dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
         }

        private void Regrescar()
        {
            using (BDD_UFGEntities db = new BDD_UFGEntities())
            {
                var lista = db.Persona.ToList();

                dgvDatos.DataSource = lista;
            }
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            Datos datos = new Datos();

            datos.ShowDialog();

            Regrescar();
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            int? id = ObtenerId();

            if (id != null)
            {
                Datos frmtabla = new Datos(id);
                frmtabla.ShowDialog();
            }

            Regrescar();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            int? id = ObtenerId();

            if (id != null)
            {
                using (BDD_UFGEntities db = new BDD_UFGEntities())
                {
                    var persona = db.Persona.Find(id);

                    db.Persona.Remove(persona);

                    db.SaveChanges();
                }
            }

            Regrescar();
        }
    }
}
