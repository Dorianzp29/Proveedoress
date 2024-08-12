using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proveedoresss.Controllers;
using Proveedoresss.Models;
namespace Proveedoresss
{
    public partial class Form1 : Form
    {
        ProveedoresController proveedorController = new ProveedoresController();
        string IDCliente;
        public Form1()
        {
            InitializeComponent();
        }

        
        
        
        public void cargarLista()
        {
            lstProveedor.DataSource = proveedorController.todos();
            lstProveedor.DisplayMember = "DisplayName";
            lstProveedor.ValueMember = "IDProveedor";
        }



        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            ProveedoresModel Proveedor = new ProveedoresModel
            {
                IDProveedores = Convert.ToInt32(lstProveedor.SelectedValue),
                NombreEmpresa = txt_NombreEmp.Text,
                Direccion = txt_Direcc.Text,
                Telefono = txt_Telef.Text,
                
            };

            ProveedoresController proveedorController = new ProveedoresController();
            try
            {
                proveedorController.agregar(Proveedor);
                MessageBox.Show("Proveedor agregado correctamente.");
                cargarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el proveedor: " + ex.Message);
            }
        }
    }
}
