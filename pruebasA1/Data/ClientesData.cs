using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.EntityClient;

namespace Data
{

   public class ClientesData
    {
        DataTable dataTable = new DataTable();
        public List<Data.CLIENTES> ListaClientes()
        {
            Prueba_JPEntities Con = new Prueba_JPEntities();
            try
            {
                var ListaClient = (from x in Con.CLIENTES select x).ToList();
                return ListaClient;
            }

            catch (Exception ex)
            {
                throw;
            }



        }

        public void UpdateClient(Data.CLIENTES Client)
        {
            Prueba_JPEntities Con = new Prueba_JPEntities();
            CLIENTES EntClientes = new CLIENTES();
            try
            {
                EntClientes = (from x in Con.CLIENTES where x.ID == Client.ID select x).FirstOrDefault();
                EntClientes.IDENTIFICACION = Client.IDENTIFICACION;
                EntClientes.TELEFONO = Client.TELEFONO;
                EntClientes.NOMBRE_COMPLETO = Client.NOMBRE_COMPLETO;
                Con.SaveChanges();
              
            }

            catch (Exception ex)
            {
                throw;
            }



        }

        public CLIENTES SearchClientEntity(string Nombre)
        {
            Prueba_JPEntities Con = new Prueba_JPEntities();
            CLIENTES EntClientes = new CLIENTES();
            try
            {
                EntClientes = (from x in Con.CLIENTES where x.NOMBRE_COMPLETO == Nombre select x).FirstOrDefault();
                return EntClientes;

            }

            catch (Exception ex)
            {
                throw;
            }



        }
        

        public void Insert( string Accion,string NOMBRE,int IDENTIFICACION,int Telefono,int Id)
        {
            try
            {
                string s = System.Configuration.ConfigurationManager.ConnectionStrings["ClientesEntities"].ConnectionString;
                System.Data.EntityClient.EntityConnectionStringBuilder e = new System.Data.EntityClient.EntityConnectionStringBuilder(s);
                string ProviderConnectionString = e.ProviderConnectionString;
                            
                SqlConnection con = new SqlConnection(ProviderConnectionString);

                SqlCommand cmd = new SqlCommand("STPR_CLIENTES_PRUEBA_MANTENIMIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ACCION", SqlDbType.VarChar).Value = "I";
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@IDENTIFICACION", SqlDbType.Int).Value = IDENTIFICACION;
                cmd.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = Telefono;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@P_Mensaje", SqlDbType.VarChar).Value = "I";

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();              
            }
            catch (Exception ex)
            {
                //MessageBox.Show(" Datos No Insertado" + ex.Message);
            }
        }

        public void Delete(string Accion, string NOMBRE, int IDENTIFICACION, int Telefono, int Id)
        {
            try
            {
                string s = System.Configuration.ConfigurationManager.ConnectionStrings["ClientesEntities"].ConnectionString;
                System.Data.EntityClient.EntityConnectionStringBuilder e = new System.Data.EntityClient.EntityConnectionStringBuilder(s);
                string ProviderConnectionString = e.ProviderConnectionString;                     

                SqlConnection con = new SqlConnection(ProviderConnectionString);

                SqlCommand cmd = new SqlCommand("STPR_CLIENTES_PRUEBA_MANTENIMIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ACCION", SqlDbType.VarChar).Value = Accion;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@IDENTIFICACION", SqlDbType.Int).Value = IDENTIFICACION;
                cmd.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = Telefono;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@P_Mensaje", SqlDbType.VarChar).Value = "I";

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(" Datos No Insertado" + ex.Message);
            }
        }

        public DataTable SearchClient(string NOMBRE)
        {
            DataTable clientInfoDT = new DataTable();
            clientInfoDT.Columns.Add("ID", typeof(string));
            clientInfoDT.Columns.Add("NOMBRE_COMPLETO", typeof(string));
            clientInfoDT.Columns.Add("IDENTIFICACION", typeof(string));
            clientInfoDT.Columns.Add("TELEFONO", typeof(string));
            try
            {
                string s = System.Configuration.ConfigurationManager.ConnectionStrings["ClientesEntities"].ConnectionString;
                System.Data.EntityClient.EntityConnectionStringBuilder e = new System.Data.EntityClient.EntityConnectionStringBuilder(s);
                string ProviderConnectionString = e.ProviderConnectionString;
                string ConnectionString = ConfigurationManager.ConnectionStrings["ClientesEntities"].ConnectionString;
                SqlConnection con = new SqlConnection(ProviderConnectionString);
                SqlDataReader reader;

                string query = @"SELECT * FROM [dbo].[udfProductInYear](@model_year);";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@model_year";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Value = NOMBRE;

                cmd.Parameters.Add(param1);

                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = clientInfoDT.NewRow();
                    row["ID"] = reader["ID"].ToString();
                    row["NOMBRE_COMPLETO"] = reader["NOMBRE_COMPLETO"].ToString();
                    row["IDENTIFICACION"] = reader["IDENTIFICACION"].ToString();
                    row["TELEFONO"] = reader["TELEFONO"].ToString();
                    clientInfoDT.Rows.Add(row);
                }
                con.Close();


            }
            catch (Exception ex)
            {

            }
            return clientInfoDT;
        }
    }
}
