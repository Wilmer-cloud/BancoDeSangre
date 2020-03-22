using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Donantes
{
   public class DatosdeInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)

        {
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";

            contexto.Usuario.Add(usuarioAdmin);

            var tipo1 = new Tipo();
             tipo1.Nombre = "O-";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Nombre = "O+";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Nombre = "A-";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Nombre = "A-";
            contexto.Tipos.Add(tipo4);

            var tipo5 = new Tipo();
            tipo5.Nombre = "B-";
            contexto.Tipos.Add(tipo5);

            var tipo6 = new Tipo();
            tipo6.Nombre = "B+";
            contexto.Tipos.Add(tipo6);

            var tipo7 = new Tipo();
            tipo7.Nombre = "AB-";
            contexto.Tipos.Add(tipo7);

            var tipo8 = new Tipo();
            tipo8.Nombre = "AB+";
            contexto.Tipos.Add(tipo8);

            var categoria1 = new Categoria();
            categoria1.Nombre = "Prime Vez";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Nombre = "Recurrente";
            contexto.Categorias.Add(categoria2);

            base.Seed(contexto);


        }
    }
}
