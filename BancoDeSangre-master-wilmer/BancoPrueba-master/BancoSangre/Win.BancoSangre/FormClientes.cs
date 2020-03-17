using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.BancoSangre
{
    public partial class FormClientes : Form
    {
        ClientesBL _clientes;


        public FormClientes()
        {
            InitializeComponent();

            _clientes = new ClientesBL();
            listaClientesBindingSource.DataSource = _clientes.ObtenerClientes();



        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }
        private void Eliminar(int id)
        {
            var res = _clientes.EliminarCliente(id);

            if (res == true)
            {
                listaClientesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eleminar el donante");
            }


        }
        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _clientes.CancelarCambios();
            DeshabilitarHabilitarBotones(true);


        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _clientes.AgregarCliente();
            listaClientesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);


        }
        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;

            toolStripButtonCancelar.Visible = !valor;

        }

        private void listaDonantesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaClientesBindingSource.EndEdit();
            var cliente = (Clientes)listaClientesBindingSource.Current;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            if (idTextBox.Text != "")
            {
                var res = MessageBox.Show("¿¡Desea eliminar el registro del donante!?", "ELIMINAR", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

      

        private void listaDonantesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            listaClientesBindingSource.EndEdit();
            var cliente = (Clientes)listaClientesBindingSource.Current;

            var res  = _clientes.GuardarCliente(cliente);


            if (res.Exitoso == true)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);

                MessageBox.Show("Donante guardado exitosamente");
            }
            else
            {
                MessageBox.Show(res.Mensaje);

            }
        }
    }
}
    
