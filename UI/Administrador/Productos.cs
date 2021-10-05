using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL;

namespace UI.Administrador
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        ClassLogica Logica = new ClassLogica();
        Menu dest = new Menu();

        private void button1_Click(object sender, EventArgs e)
        {
            dest.Show();
            this.Close();
        }

        void Actualizar()
        {
            dataGridView1.DataSource = Logica.ListarEmpleados();
            dataGridView1.Refresh();

            comboBox2.DataSource = Logica.ListarEmpleados();
            comboBox2.DisplayMember = "ID_Empleado";
            comboBox2.ValueMember = "ID_Empleado";
            comboBox2.Refresh();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
