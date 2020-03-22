using BL.Donantes;
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
    public partial class FormDonantes : Form
    {
        DonantesBL _donantes;
        CategoriasBL _categorias;
        TiposBL _tipos;
        public FormDonantes()
        {
            InitializeComponent();

            _donantes = new DonantesBL();
            listaDonantesBindingSource.DataSource = _donantes.ObtenerDonantes();

            _categorias = new CategoriasBL();
            listaCategoriasBindingSource.DataSource = _categorias.ObtenerCategorias();

            _tipos = new TiposBL();
            listaTiposBindingSource.DataSource = _tipos.ObtenerTipos();

        }

        private void listaDonantesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaDonantesBindingSource.EndEdit();
            var donante = (Donante)listaDonantesBindingSource.Current;

            var resultado = _donantes.GuardarDonante(donante);

            if (resultado.Exitoso == true)
            {
                listaDonantesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);

                MessageBox.Show("Donante Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _donantes.AgregarDonante();
            listaDonantesBindingSource.MoveLast();

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

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea Eliminar este Donante?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
                
            }
        }

        private void Eliminar(int id)
        {
            
            var resultado = _donantes.EliminarDonante(id);

            if (resultado == true)
            {
                listaDonantesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrior un error al eliminaro un donante");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _donantes.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
            
        }

        private void FormDonantes_Load(object sender, EventArgs e)
        {

        }
    }
}
