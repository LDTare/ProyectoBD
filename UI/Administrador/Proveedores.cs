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
    public partial class Proveedores : Form
    {
        public Proveedores()
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
            dataGridView1.DataSource = Logica.ListarProveedores();
            dataGridView1.Refresh();

            comboBox2.DataSource = Logica.ListarProveedores();
            comboBox2.DisplayMember = "ID_Proveedor";
            comboBox2.ValueMember = "ID_Proveedor";
            comboBox2.Refresh();
        }

        private void Proveedores_Load(object sender, EventArgs e)
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
            string Direccion = textBox2.Text;


            string status;

            status = Logica.InsertarProveedor(Nombre, Direccion);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
            Actualizar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Direccion = textBox2.Text;

            int code = Convert.ToInt32(comboBox2.SelectedValue);

            string status;

            status = Logica.ActualizarProveeodr(Nombre, Direccion, code);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
            Actualizar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string status;
            int code = Convert.ToInt32(comboBox2.SelectedValue);
            status = Logica.DeleteProveedor(code);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Actualizar();
        }
    }
}
