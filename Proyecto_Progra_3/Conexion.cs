using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Proyecto_Progra_3
{
    class Conexion
    {
        public static MySqlConnection Conex = new MySqlConnection("Server=localhost;Database=bd_prodgex;Uid=root;Pwd=''");
        public MySqlCommand Comando = new MySqlCommand("", Conex);
        public MySqlDataReader Rec;

        public void AbrirConexion()
        {
            if (Conex.State == ConnectionState.Closed)
            {
                Conex.Open();
            }
        }

        public void CerrarConexion()
        {
            if (Conex.State == ConnectionState.Open)
            {
                Conex.Close();
            }
        }

        public int EjecutarIUD(String CadSql)
        {
            int fila = 0;//cantidad de filas afectadas por la ejecucion del query
            try
            {
                AbrirConexion();
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = CadSql;
                fila = Comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                CerrarConexion();
            }
            return fila;
        }

        public MySqlDataReader EjecutarConsulta(string CadSql)
        {
            try
            {
                AbrirConexion();
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = CadSql;
                Rec = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                Rec = null;
                MessageBox.Show(ex.Message);
            }
            return (Rec);
        }
    }
}
