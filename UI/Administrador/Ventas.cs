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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        ClassLogica Logica = new ClassLogica();
        Menu dest = new Menu();

        private void actualizar()
        {
            dataGridView1.DataSource = Logica.ListarFactura();
            dataGridView1.Refresh();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dest.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Compras dots = new Compras();
            dots.Show();
            this.Hide();
        }
    }
}
