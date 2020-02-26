using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Bussines
{
    public class ClienteNegocio
    {
        public List<Data.CLIENTES> ListaCliente()
        {
            Data.ClientesData Data = new Data.ClientesData();
            try
            {
                return Data.ListaClientes();
            }
            catch (Exception)
            {

                throw;
            }

        }
            

      
    }
}
