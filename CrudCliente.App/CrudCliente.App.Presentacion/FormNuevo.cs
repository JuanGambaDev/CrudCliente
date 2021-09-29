using CrudCliente.App.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudCliente.App.Presentacion
{
    public partial class FormNuevo : Form
    {
        private int? Id;
        public FormNuevo(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
                LoadData();
        }

        private void LoadData() 
        {
            ClienteDB oClienteDb = new ClienteDB();
            Cliente oCliente = oClienteDb.Get((int)Id);
            textNombres.Text = oCliente.Nombres;
            textApellidos.Text = oCliente.Apellidos;
            textDireccion.Text = oCliente.Direccion;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ClienteDB oClienteDb = new ClienteDB();
            try 
            {
                if (Id == null)
                    oClienteDb.Add(textNombres.Text, textApellidos.Text, textDireccion.Text);
                else
                    oClienteDb.Update(textNombres.Text, textApellidos.Text, textDireccion.Text, (int)Id);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al guardar." + ex.Message);
            }
        }
    }
}
