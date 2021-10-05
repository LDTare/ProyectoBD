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
    public partial class Empleados : Form
    {
        public Empleados()
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

        private void Empleados_Load(object sender, EventArgs e)
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
            string Usuario = textBox3.Text;
            string Password = textBox4.Text;

            string Rol = comboBox1.SelectedItem.ToString();

            int asignacion = 0;

            switch (Rol)
            {
                case "Administrador": {asignacion = 1; break; }
                case "Bodeguero": { asignacion = 2; break; }
                case "Cajero": { asignacion = 3; break; }
                case "Gerente": { asignacion = 4; break; }
                default: { break; }
            }

            string status;

            status = Logica.NuevoEmpleado(Nombre,Apellido,Usuario,Password,asignacion);
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Apellido = textBox2.Text;
            string Usuario = textBox3.Text;
            string Password = textBox4.Text;

            string Rol = comboBox1.SelectedItem.ToString();

            int code = Convert.ToInt32(comboBox2.SelectedValue);

            int asignacion = 0;

            switch (Rol)
            {
                case "Administrador": { asignacion = 1; break; }
                case "Bodeguero": { asignacion = 2; break; }
                case "Cajero": { asignacion = 3; break; }
                case "Gerente": { asignacion = 4; break; }
                default: { break; }
            }

            string status;

            status = Logica.ActualizarEmpleado(Nombre, Apellido, Usuario, Password,asignacion,code) ;
            MessageBox.Show(status, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            textBox1.Focus();
        }
    }
}
