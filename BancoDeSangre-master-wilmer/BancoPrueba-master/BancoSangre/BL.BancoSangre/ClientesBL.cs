using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BancoSangre
{
    public class ClientesBL
    {
        Contexto _contexto;
        public BindingList<Clientes> ListaClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListaClientes = new BindingList<Clientes>();

        }

        public BindingList<Clientes> ObtenerClientes()
        {
            _contexto.Clientes.Load();
            ListaClientes = _contexto.Clientes.Local.ToBindingList();

            return ListaClientes;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }
        

        public Res GuardarCliente(Clientes cliente)

        {
            var res = Validar(cliente);
            if (res.Exitoso==false)
            {
                return res;
           
            }
            _contexto.SaveChanges();
            res.Exitoso = true;

            return res;

        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Clientes();
            ListaClientes.Add(nuevoCliente);
        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes.ToList())
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Res Validar(Clientes cliente)
        {
            var res = new Res();
            res.Exitoso = true;

            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                res.Mensaje = "Ingrese el Nombre del Cliente";
                res.Exitoso = false;
            }

            return res;
        }

    }

    public class Clientes


    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
    }
   

    public class Res

    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
