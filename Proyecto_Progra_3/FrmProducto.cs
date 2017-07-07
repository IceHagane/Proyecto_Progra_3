using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Progra_3
{
    public partial class FrmProducto : Form
    {
        Conexion con = new Conexion();

        public FrmProducto()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            cboEntidad.SelectedIndex = -1;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            String CadSql;
            CadSql = "select nom_ent, id_ent from datos_entidades where id_tipo = 2 or id_tipo = 3";
            Subrrutinas.llenarCombobox(cboEntidad, CadSql, "nom_ent", "id_ent");
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void btnIngresar_MouseClick(object sender, MouseEventArgs e)
        {
            string nom;
            int prec, stock;
            nom = txtNombre.Text;
            prec = int.Parse(txtPrecio.Text);
            stock = int.Parse(txtStock.Text);

            string CadSql;
            CadSql = "insert into productos (nom_producto, precio_producto, stock_producto, id_ent) values ('" + nom + "'," + prec + "," +
            stock + "," + ClaseArchivador.id_ent + ");";

            try
            {
                if (con.EjecutarIUD(CadSql) > 0)
                {
                    MessageBox.Show("Producto Guardado", "Listo");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Producto NO Guardado", "ERROR");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void btnLimpiar_MouseClick(object sender, MouseEventArgs e)
        {
            limpiar();
        }

        private void cboEntidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String ID;
            ID = "Select id_ent from datos_entidades where nom_ent ='" + cboEntidad.SelectedItem.ToString() + "';";


            try
            {
                con.EjecutarConsulta(ID);
                while (con.Rec.Read())
                {
                    ClaseArchivador.id_ent = Convert.ToInt32(con.Rec["id_ent"]);
                }
            }
            catch (Exception ex)
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
        }


    }
}
