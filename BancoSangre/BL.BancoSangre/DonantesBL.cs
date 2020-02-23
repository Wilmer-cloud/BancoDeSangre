using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BancoSangre
{
    public class DonantesBL
    {
        public BindingList<Donantes> ListaDonantes { get; set; }

        public DonantesBL()
        {
            ListaDonantes = new BindingList<Donantes>();

            var donate1 = new Donantes();
            donate1.Id = 1;
            donate1.Identidad = "0501-1995-10498";
            donate1.Nombre = "Jose";
            donate1.Fecha = "14/02/2020";  
            donate1.Telefono = "3353-6009";
            donate1.Direccion = "33 Calle 27 Ave";

            ListaDonantes.Add(donate1);

            var donate2 = new Donantes();
            donate2.Id = 2;
            donate2.Identidad = "0501-1986-25633";
            donate2.Nombre = "Carlos";
            donate2.Fecha = "14/02/2020";
            donate2.Telefono = "2552-0000";
            donate2.Direccion = "33 Calle 27 Ave";

            ListaDonantes.Add(donate2);

            var donate3 = new Donantes();
            donate3.Id = 3;
            donate3.Identidad = "0501-1963-05966";
            donate3.Nombre = "Roberto";
            donate3.Fecha = "14/02/2020";
            donate3.Telefono = "3259-7941";
            donate3.Direccion = "33 Calle 27 Ave";

            ListaDonantes.Add(donate3);
        }

        public BindingList<Donantes> ObtenerDonantes()
        {
            return ListaDonantes;
        }
        
 

    }

    public class Donantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identidad { get; set; }
        public string Fecha { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
