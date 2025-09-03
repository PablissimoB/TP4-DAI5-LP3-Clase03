using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clase3
{
    public partial class Read : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            string consultUsers = $@"select usuarios.id as idUsuario, username, password, idUsuarioTipo,  descripcion from usuarios
                inner join UsuarioTipos on Usuarios.idUsuarioTipo = UsuarioTipos.id";
            SqlCommand comando = new SqlCommand(consultUsers, conexion);
            SqlDataReader register = comando.ExecuteReader();


            //Label1.Text = "ID - Username  - Password  - TipoUsuario <br/>";
            TableHeaderRow header = new TableHeaderRow();
            header.Cells.Add(new TableHeaderCell { Text = "ID" });
            header.Cells.Add(new TableHeaderCell { Text = "Username" });
            header.Cells.Add(new TableHeaderCell { Text = "Password" });
            header.Cells.Add(new TableHeaderCell { Text = "Tipo Usuario" });
            tblUsuarios.Rows.Add(header);

            while (register.Read())
            {
                TableRow fila = new TableRow();

                fila.Cells.Add(new TableCell { Text = register["idUsuario"].ToString() });
                fila.Cells.Add(new TableCell { Text = register["username"].ToString() });
                fila.Cells.Add(new TableCell { Text = register["password"].ToString() });
                fila.Cells.Add(new TableCell { Text = $"{register["idUsuarioTipo"].ToString()}-{register["descripcion"].ToString()}" });

                tblUsuarios.Rows.Add(fila);
                //Label1.Text += register["idUsuario"].ToString() + " - "+ register["username"].ToString() + " - " + register["password"].ToString() + " - " + register["idUsuarioTipo"].ToString() + "<br/>";
            }
            //SqlDataAdapter sda = new SqlDataAdapter(comando);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Label1.Text += dr[0].ToString() + " - ";
            //    Label1.Text += dr[1].ToString() + " - ";
            //    Label1.Text += dr[2].ToString() + " - ";
            //    Label1.Text += dr[3].ToString() + " - " + dr[4].ToString() + "<br/>";
            //}
            conexion.Close();
        }
    }
}