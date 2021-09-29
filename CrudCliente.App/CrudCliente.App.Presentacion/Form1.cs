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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh() 
        {
            ClienteDB oClienteDB = new ClienteDB();
            dataGridView1.DataSource = oClienteDB.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNuevo FormIngresar = new FormNuevo();
            FormIngresar.ShowDialog();
            Refresh();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                FormNuevo FormEditar = new FormNuevo(Id);
                FormEditar.ShowDialog();
                Refresh();
            }
        }

        #region HELPER
        private int? GetId() 
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            try
            {
                if (Id != null)
                {
                    ClienteDB oClienteDB = new ClienteDB();
                    oClienteDB.Delete((int)Id);
                    Refresh();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Ocurrio un error al eliminar. " + ex.Message);
            }
        }
    }
}
