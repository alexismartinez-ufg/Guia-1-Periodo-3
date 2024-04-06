using Ejercicio_1.Models;
using System;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Datos : Form
    {
        public int? id;
        public Persona personas;
        public Datos(int? _id = null)
        {
            InitializeComponent();
            this.id = _id;
            if (id != null)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            using (BDD_UFGEntities db = new BDD_UFGEntities())
            {
                personas = db.Persona.Find(id);
                tbxId.Text = personas.Id.ToString();
                tbxNombre.Text = personas.Nombre;
                tbxCorreo.Text = personas.Correo;
                tbxFechaNacimiento.Value = personas.FechaNacimiento.Value;
            }
        }

        private void btnAccionDatos_Click(object sender, EventArgs e)
        {
            using (BDD_UFGEntities db = new BDD_UFGEntities())
            {
                if(id == null)
                {
                    personas = new Persona();
                }

                personas.Nombre = tbxNombre.Text;
                personas.Correo = tbxCorreo.Text;
                personas.FechaNacimiento = tbxFechaNacimiento.Value;

                if (id == null)
                    db.Persona.Add(personas);
                else
                    db.Entry(personas).State = System.Data.Entity.EntityState.Modified;
                
                db.SaveChanges();

                this.Close();
            }
        }
    }
}
