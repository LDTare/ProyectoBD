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
    public partial class MetodoPago : Form
    {
        public MetodoPago()
        {
            InitializeComponent();
        }

        ClassLogica Logica = new ClassLogica();
        Menu dest = new Menu();

        public void actualizar()
        {
            dateTimePicker1.Value = DateTime.Now;

            comboBox1.DataSource = Logica.ListarClientes();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "ID_Cliente";
            Refresh();

            comboBox2.DataSource = Logica.ListarTiposMetodos();
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "ID_TipoMetodo";
            comboBox2.Refresh();

            dataGridView1.DataSource = Logica.ListarMetodosPago();
            dataGridView1.Refresh();

            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void MetodoPago_Load(object sender, EventArgs e)
        {
            actualizar();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cliente = Convert.ToInt32(comboBox1.SelectedValue);
            int metodo = Convert.ToInt32( comboBox2.SelectedValue);

            Logica.InsertarMetodo(cliente,metodo,dateTimePicker1.Text,textBox1.Text);
            actualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dest.Show();
            this.Close();
        }
    }
}
