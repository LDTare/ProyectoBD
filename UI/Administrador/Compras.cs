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
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }

        ClassLogica Logica = new ClassLogica();
        Ventas dest = new Ventas();
        Impresion orus = new Impresion();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public int cods()
        {
            Random rnd = new Random();
            int codigo = rnd.Next(1, 9999);
            return codigo;
        }

        public void codigo()
        {

        }

        public void Actualizar()
        {
            comboBox1.DataSource = Logica.ListarClientes();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "ID_Cliente";
            Refresh();

            comboBox2.DataSource = Logica.ListarTiposMetodos();
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Nombre";
            comboBox2.Refresh();


            listBox1.DataSource = Logica.ListarProductos();
            listBox1.DisplayMember = "Nombre";
            listBox1.ValueMember = "ID_Producto";

            
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            int serial = cods();

            if(Logica.ListarCodFactura(serial).Rows.Count > 0)
            {
                serial = cods();
            }
            else
            {
                Actualizar();
                Codigo.Text = Convert.ToString(serial);
                orus.codigo = serial;
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dest.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = Logica.ListarProductos();

            int Barra = Convert.ToInt32(Codigo.Text);

            int id = Convert.ToInt32(listBox1.SelectedValue);
            int cliente = Convert.ToInt32(comboBox1.SelectedValue);
            string metodo = comboBox2.Text;

            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.AllowDBNull = false;
            column.Caption = "Subtotal";
            column.ColumnName = "Subtotal";
            column.Expression = "Precio_Venta - (Precio_Venta*Descuento)";

            table.Columns.Add(column);

            double subtotales = Convert.ToDouble(table.Compute("SUM(Subtotal)", "Existencias > 0"));
            label6.Text = Convert.ToString(subtotales);

            double total = subtotales + (subtotales * 0.12);

            Total.Text = Convert.ToString(total);

            Logica.InsertarCompra(Barra,cliente,1,metodo,dateTimePicker1.Text,total);

            Logica.InsertarDetalle(id,Barra,subtotales);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            orus.Show();
        }
    }
}
