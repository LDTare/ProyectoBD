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
    public partial class Clientes : Form
    {
        public Clientes()
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
            dataGridView1.DataSource = Logica.ListarClientes();
            dataGridView1.Refresh();

            comboBox2.DataSource = Logica.ListarClientes();
            comboBox2.DisplayMember = "ID_Cliente";
            comboBox2.ValueMember = "ID_Cliente";
            comboBox2.Refresh();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Apellido = textBox2.Text;
            string NIT = textBox3.Text;
            string Telefono = textBox4.Text;
            string Direccion = textBox5.Text;

            string status;

            status = Logica.InsertarCliente(Nombre,Apellido,NIT,Telefono,Direccion);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
            Actualizar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(comboBox2.SelectedValue);

            string Nombre = textBox1.Text;
            string Apellido = textBox2.Text;
            string NIT = textBox3.Text;
            string Telefono = textBox4.Text;
            string Direccion = textBox5.Text;

            string status;

            status = Logica.ActualizarCliente(Nombre,Apellido,NIT,Telefono,Direccion,code);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
            Actualizar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string status;
            int code = Convert.ToInt32(comboBox2.SelectedValue);
            status = Logica.DeleteCliente(code);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Actualizar();
        }
    }
}
