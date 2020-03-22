using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Donantes
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();

        }

        private void Login()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void donanteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            var formDonantes = new FormDonantes();
            formDonantes.MdiParent = this;
            formDonantes.Show();



        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();


        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formEliminarCliente = new FormEliminarCliente();
            formEliminarCliente.MdiParent = this;
            formEliminarCliente.Show();

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Login();

        }

        private void facturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }
    }
}
