using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Proyecto_Progra_3
{
    public partial class Login : Form
    {
        Conexion con = new Conexion();
        public Login()
        {
            InitializeComponent();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void IngresoCompleto()
        {
            if (txtUsuario.Text =="")
            {
                MessageBox.Show("Debe ingresar un Usuario");
                txtUsuario.Focus();
            }
            else 
            {
                if (txtPass.Text == "")
            {
                MessageBox.Show("Debe ingresar una contraseña");
                txtPass.Focus();
            }
                 else
            {
                ingresar(txtUsuario.Text,txtPass.Text);
            }
            }
           
        }

        private void ingresar(string usuario,string pass)
        {
            
            string CadSql;

            CadSql = "SELECT nom_usuario,pass_usuario, id_tipo_usuario from usuarios where nom_usuario='"+usuario+"';";
           MySqlDataReader Rec = null;
            try
            {
                con.EjecutarConsulta(CadSql);
                while (con.Rec.Read())
                {
                    ClaseArchivador.username = con.Rec["nom_usuario"].ToString();
                    ClaseArchivador.password = con.Rec["pass_usuario"].ToString();
                   
                    ClaseArchivador.id_privilegio = Convert.ToInt32(Rec["id_tipo_usuario"]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.Rec != null)
                {
                    con.CerrarConexion();
                   con.Rec = null;
                }
            }
            if (txtUsuario.Text.Equals(ClaseArchivador.username) && txtPass.Text.Equals(ClaseArchivador.password))
            {
                frmMenuPrincipal frm = new frmMenuPrincipal();
                this.Hide();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña no valido");
            } 
            

        }

        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            IngresoCompleto();
        }

        

       
    }
}
