using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void gestorDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes c = new FormClientes();
            c.ShowDialog();
        }

        private void formConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultasCliente f = new FormConsultasCliente();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void formBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacora b = new FormBitacora();
            b.ShowDialog();
        }
    }
}
