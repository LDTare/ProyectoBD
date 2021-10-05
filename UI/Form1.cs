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

namespace UI
{
    public partial class Form1 : Form
    {

        ClassLogica Logica = new ClassLogica();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string User = textBox1.Text;
            string Pass = textBox2.Text;

            bool Logs = Logica.Login(User,Pass);
            int Clase = Logica.RolUser(User, Pass);
            string Rol = Logica.Rol(Clase);

            if(Logs == true)
            {
                MessageBox.Show(Rol + "Bienvenido: " + User,"Autenticacion de Usuarios", MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (Rol.Contains("Administrador"))
                {
                    Administrador.Menu AdminMenu = new Administrador.Menu();
                    AdminMenu.ShowDialog();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Datos incorrecots");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
