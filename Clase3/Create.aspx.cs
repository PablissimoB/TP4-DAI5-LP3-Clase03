using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clase3
{
    public partial class Create : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }
        private void CargarCategorias()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            const string sql = @"SELECT id, descripcion FROM UsuarioTipos ORDER BY descripcion";
            using (var cn = new SqlConnection(cadenaConexion))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    DropDownList1.DataSource = rd;
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataTextField = "descripcion";
                    DropDownList1.DataBind();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text != "" && TextBox2.Text != "" && DropDownList1.SelectedValue != "")
            {
                string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                string addUser = $"insert into usuarios(username, password, idUsuarioTipo) values ('{TextBox1.Text}','{TextBox2.Text}',{DropDownList1.SelectedValue})";
                SqlCommand comando = new SqlCommand (addUser, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alert('Complete los datos necesarios para el registro');", true);
            }
        }
    }
}