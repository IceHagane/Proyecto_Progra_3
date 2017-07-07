using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_Progra_3
{
    class Subrrutinas
    {
        public static void llenarCombobox(ComboBox Cbo, string CadSql, string CampoVer, string CampoValor)
        {
            MySqlDataAdapter DA = new MySqlDataAdapter(CadSql, Conexion.Conex);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            Cbo.DataSource = DS.Tables[0];
            Cbo.DisplayMember = CampoVer;
            Cbo.ValueMember = CampoValor;
            Cbo.SelectedIndex = -1;
        }
    }
}
