using BL.BancoSangre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.BancoSangre
{
    public partial class FormAgregar : Form
    {
        DonantesBL _donantes;

        public FormAgregar()
        {
            InitializeComponent();

            _donantes = new DonantesBL();
            listaDonantesBindingSource.DataSource = _donantes.ObtenerDonantes();

        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {

        }

        private void listaDonantesBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void listaDonantesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
