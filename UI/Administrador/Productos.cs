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
            dataGridView1.DataSource = Logica.ListarProductos();
            dataGridView1.Refresh();

            comboBox1.DataSource = Logica.ListarTiposProd();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "ID_TipoProducto";

            comboBox2.DataSource = Logica.ListarProductos();
            comboBox2.DisplayMember = "ID_Producto";
            comboBox2.ValueMember = "ID_Producto";
            comboBox2.Refresh();

            comboBox3.DataSource = Logica.ListarProveedores();
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "ID_Proveedor";
            comboBox3.Refresh();
        }

        private void Productos_Load(object sender, EventArgs e)
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
            string Descripcion = textBox2.Text;
            float Precio_Venta = float.Parse(textBox3.Text);
            float Precio_Compra = float.Parse(textBox4.Text);
            int Existencias = int.Parse(textBox5.Text);
            int MinEx = int.Parse(textBox6.Text);
            float descuento = float.Parse(textBox7.Text);

            int code1 = Convert.ToInt32(comboBox1.SelectedValue);
            int code2 = Convert.ToInt32(comboBox3.SelectedValue);

            string status;

            status = Logica.InsertarProducto(Nombre,Descripcion,Precio_Venta,Precio_Compra,Existencias,MinEx,descuento,code1,code2);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
            Actualizar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(comboBox2.SelectedValue);

            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            float Precio_Venta = float.Parse(textBox3.Text);
            float Precio_Compra = float.Parse(textBox4.Text);
            int Existencias = int.Parse(textBox5.Text);
            int MinEx = int.Parse(textBox6.Text);
            float descuento = float.Parse(textBox7.Text);

            int code1 = Convert.ToInt32(comboBox1.SelectedValue);
            int code2 = Convert.ToInt32(comboBox3.SelectedValue);

            string status;

            status = Logica.ActualizarProducto(Nombre, Descripcion, Precio_Venta, Precio_Compra, Existencias, MinEx, descuento, code1, code2,code);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
            Actualizar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string status;
            int code = Convert.ToInt32(comboBox2.SelectedValue);
            status = Logica.DeleteProducto(code);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Actualizar();
        }

    }
}
