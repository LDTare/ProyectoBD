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
    public partial class Impresion : Form
    {
        public Impresion()
        {
            InitializeComponent();
        }

        ClassLogica Logica = new ClassLogica();

        public int codigo;

        private void Impresion_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Logica.ListarCodFactura(codigo);
            dataGridView1.Refresh();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.printDocument1.Print();
            this.Close();
        }
    }
}
