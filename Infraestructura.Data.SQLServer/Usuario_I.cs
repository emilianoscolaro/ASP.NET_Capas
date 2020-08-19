using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SQLServer
{
    public class Usuario_I
    {
        SqlConnection conexion;
        SqlDataAdapter comando;
        SqlDataReader dr;
        SqlCommand cmd;
        String errores;

        Conection cn = new Conection();


        public IEnumerable<Usuario> LogInUsuario(string user,string pasword)
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                conexion = cn.conectar();
                cmd = new SqlCommand("Pr_Login", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50));
                cmd.Parameters["@usuario"].Direction = ParameterDirection.Input;
                cmd.Parameters["@usuario"].Value = user;

                cmd.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar, 50));
                cmd.Parameters["@clave"].Direction = ParameterDirection.Input;
                cmd.Parameters["@clave"].Value = pasword;

                dr = null;
                conexion.Open();

                dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     Usuario objeto = new Usuario();
                     objeto.Usuario_u = Convert.ToString(dr["Usuario_u"]);
                     objeto.Clave_u = Convert.ToString(dr["Clave_u"]);
                     objeto.NombreUsiario_u = Convert.ToString(dr["NombreUsiario_u"]);

                     lista.Add(objeto);
                 }
                
                dr.Close();

            }
            catch (Exception ex)
            {
                errores = ex.Message;
            }
            finally 
            {
                if(conexion.State == ConnectionState.Open) { conexion.Close(); }
                conexion.Dispose();
                cmd.Dispose();
            }
            return lista;

        }

    }
}
