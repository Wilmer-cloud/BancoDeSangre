using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas.BL;

namespace Ventas.Win
{
    public partial class Form1 : Form
    {
        ProductoBL productosBL;
        public Form1()
        {
            InitializeComponent();

            productosBL = new ProductoBL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            dataGridView1.DataSource = productosBL.ListadeProductos;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox1.Text);
            var descripcion = textBox2.Text;

            productosBL.agregar(3, "Huawei P30");

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = productosBL.ListadeProductos;
                
        }
    }
}
