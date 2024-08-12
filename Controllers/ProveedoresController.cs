using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Proveedoresss.Models;
namespace Proveedoresss.Controllers
{
    internal class ProveedoresController
    {
        private ProveedoresModel clientesProveedoresModel = new ProveedoresModel();

        public List<ProveedoresModel> todos()
        {
            List<ProveedoresModel> listaCliente = new List<ProveedoresModel>();
            listaCliente = clientesProveedoresModel.Todos();
            return listaCliente;
        }

        public void agregar(ProveedoresModel Cliente)
        {
            Cliente.agregar();
        }

        public void actualizar(ProveedoresModel Cliente)
        {
            Cliente.Actualizar();
        }

        public void eliminar(int id)
        {
            clientesProveedoresModel.Eliminar(id);
        }
    }
}
    

