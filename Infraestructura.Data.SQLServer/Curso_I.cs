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
    public class Curso_I
    {
        SqlConnection conexion;
        SqlDataAdapter comando;
        SqlDataReader dr;
        SqlCommand cmd;
        String errores;

        Conection cn = new Conection();


        public IEnumerable<Curso> ListaCurso()
        {
            List<Curso> lista = new List<Curso>();

            try
            {
                conexion = cn.conectar();
                cmd = new SqlCommand("ListarCurso", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = null;
                conexion.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Curso objeto = new Curso();
                    objeto.Id_cur = Convert.ToInt32(dr["Id_cur"]);
                    objeto.Nombre_c = Convert.ToString(dr["Nombre_c"]);
                    objeto.Correro_c = Convert.ToString(dr["Correro_c"]);
                    objeto.Credito_c = Convert.ToInt32(dr["Credito_c"]);

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
                if (conexion.State == ConnectionState.Open) { conexion.Close(); }
                conexion.Dispose();
                cmd.Dispose();
            }
            return lista;

        }


        public Boolean RegistrarCurso(Curso objeto)
        {
            try
            {
                conexion = cn.conectar();
                cmd = new SqlCommand("RegistrarCurso", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@nombreCurso", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@creditos", SqlDbType.Int));

                cmd.Parameters["@nombreCurso"].Direction = ParameterDirection.Input;
                cmd.Parameters["@email"].Direction = ParameterDirection.Input;
                cmd.Parameters["@creditos"].Direction = ParameterDirection.Input;

                cmd.Parameters["@nombreCurso"].Value = objeto.Nombre_c;
                cmd.Parameters["@email"].Value = objeto.Correro_c;
                cmd.Parameters["@creditos"].Value = objeto.Credito_c;

                conexion.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                errores = ex.Message;
                return false;
            }

            finally
            {
                if (conexion.State == ConnectionState.Open) { conexion.Close(); }
                conexion = null;
                cmd = null;
                cn = null; 
            }
        }



    }
}
