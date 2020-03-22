using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Donantes
{
    public class DonantesBL
    {
        Contexto _contexto;
       public BindingList<Donante> ListaDonantes { get; set; }
        public DonantesBL()
        {
            _contexto = new Contexto();
            ListaDonantes = new BindingList<Donante>();

        }

        public BindingList<Donante> ObtenerDonantes()
        {
            _contexto.Donantes.Load();
            ListaDonantes = _contexto.Donantes.Local.ToBindingList();

            return ListaDonantes;

        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarDonante(Donante donante)
        {
            var resultado = Validar(donante);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public  void AgregarDonante()
        {
            var nuevoDonante = new Donante();
            ListaDonantes.Add(nuevoDonante);
        }

        public bool EliminarDonante(int id)
        {
            foreach (var producto in ListaDonantes)
            {
                if (producto.Id == id)
                {
                    ListaDonantes.Remove(producto);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Donante donante)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (donante == null)
            {
                resultado.Mensaje = "Agregar un Donante Valido";
                resultado.Exitoso = false;

                return resultado;
            }

            if ( string.IsNullOrEmpty(donante.Nombre) == true)
            {
                resultado.Mensaje = "Ingreso un Nombre";
                resultado.Exitoso = false;
            }
            if (donante.Existencia < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayo que cero";
                resultado.Exitoso = false;
            }
            if (donante.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayo que cero";
                resultado.Exitoso = false;
            }

            if (donante.TipoId == 0)
            {
                resultado.Mensaje = "Seleccione una tipo";
                resultado.Exitoso = false;
            }

            if (donante.CategoriaId ==0)
            {
                resultado.Mensaje = "Seleccione una categoria";
                resultado.Exitoso = false;
            }

            return resultado;
        }
    }

    public class Donante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public bool Activo { get; set; }

        public Donante()
        {
            Activo = true;
        }
    }
    public  class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }

    }
}
