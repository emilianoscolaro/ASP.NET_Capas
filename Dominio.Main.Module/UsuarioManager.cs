using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Core.Entities;
using Infraestructura.Data.SQLServer;

namespace Dominio.Main.Module
{
    public class UsuarioManager
    {
        Usuario_I usi = new Usuario_I();

        public IEnumerable<Usuario>LoginUsuario(string usr,string pass)
        {
            return usi.LogInUsuario(usr, pass);
        }


    }
}
