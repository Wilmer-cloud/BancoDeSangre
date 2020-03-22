using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Donantes
{
    
   public class ClientesBL
    {
        Contexto _contexto;
        public BindingList<Cliente> ListaClientes { get; set; }
        public ClientesBL()
        {
            _contexto = new Contexto();
            ListaClientes = new BindingList<Cliente>();

        }

        public BindingList<Cliente> ObtenerClientes()
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
        public Res GuardarCliente(Cliente cliente)
        {
            var res = Validar(cliente);
            if (res.Exitoso == false)
            {
                return res; 
            }

            _contexto.SaveChanges();
          
            res.Exitoso = true; 
            return res;
        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            ListaClientes.Add(nuevoCliente);
        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes)
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

        private Res Validar(Cliente cliente)
        {
            var res = new Res();
            res.Exitoso = true;


            if (cliente == null)
            {
                res.Mensaje = "Agregar un Cliente Valido";
                res.Exitoso = false;

                return res;
            }

            if ( string.IsNullOrEmpty(cliente.Nombre) == true)

            {
                res.Mensaje = "Ingrese un nombre";
                res.Exitoso = false;
            }

    
            return res;

        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string  Nombre { get; set; }
        public string Identidad { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }

    public class Res
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }

    }
}
