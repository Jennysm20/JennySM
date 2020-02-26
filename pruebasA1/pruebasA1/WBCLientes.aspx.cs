using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebasA1
{
    public partial class WBCLientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Listarclientes();


        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            Data.ClientesData client = new Data.ClientesData();
            DataTable clientInfoDT = client.SearchClient(txtNombre.Text);
            BindGridView(clientInfoDT);
        }

        private void BindGridView(DataTable clientInfoDT)
        {
            GridView1.DataSource = clientInfoDT;
            GridView1.DataBind();
        }

        protected void btninsertar_Click(object sender, EventArgs e)
        {


            Data.ClientesData client = new Data.ClientesData();

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtidentificacion.Text))
            {
                alerta.Visible = true;

            }
            else
            {               
                client.Insert("I", txtNombre.Text,134578, 12345, 0);
                Listarclientes();
            }
            

        }
       
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                
                    int index = int.Parse(e.CommandArgument.ToString());
                    int id = int.Parse(GridView1.DataKeys[index].Value.ToString());

                Data.ClientesData client = new Data.ClientesData();

                client.Delete("B", txtNombre.Text,1234, 12345, id);

                Listarclientes();

            }
            else
            {
               
               
                    int index = int.Parse(e.CommandArgument.ToString());
                    int id = int.Parse(GridView1.DataKeys[index].Value.ToString());
                    Data.ClientesData client = new Data.ClientesData();
                    Data.CLIENTES ClienteUpdated = new Data.CLIENTES();                   
                    ClienteUpdated.IDENTIFICACION = 13458;
                    ClienteUpdated.ID = id;                   
                    ClienteUpdated.TELEFONO = 34587;                   
                    ClienteUpdated.NOMBRE_COMPLETO = "Nombre actualizado";
                    client.UpdateClient(ClienteUpdated);


                    Listarclientes();

                


            }
        }

        public void Listarclientes()
        {
            List<Data.CLIENTES> Lista = new List<Data.CLIENTES>();
            Data.ClientesData client = new Data.ClientesData();


            Bussines.ClienteNegocio DataNegocio = new Bussines.ClienteNegocio();

            try
            {
                Lista = DataNegocio.ListaCliente();
            }
            catch (Exception)
            {

                throw;
            }

            GridView1.DataSource = Lista;
            GridView1.DataBind();
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;           
                      

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}