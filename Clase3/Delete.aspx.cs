using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clase3
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                DropDownList1.Items.Clear();
                conexion.Open();
                llenarDropDown(conexion);
                conexion.Close();
            }
        }
        private void llenarDropDown(SqlConnection conexion)
        {
            
            string consultUsers = $"select id, username, password from usuarios";
            SqlCommand comando2 = new SqlCommand(consultUsers, conexion);
            SqlDataAdapter sda = new SqlDataAdapter(comando2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "username";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string id = DropDownList1.SelectedValue.ToString();
                string deleteUser = $"delete from Usuarios where id = {id}";
                SqlCommand comando = new SqlCommand(deleteUser, conexion);
                comando.ExecuteNonQuery();

                llenarDropDown(conexion);


                conexion.Close();
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(
                  this.GetType(),
                  "alert",
                  $"alert('Error: {ex.Message}');",
                  true);
            }
            
        }
    }
}