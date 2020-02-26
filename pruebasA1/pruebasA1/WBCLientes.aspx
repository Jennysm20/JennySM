<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WBCLientes.aspx.cs" Inherits="pruebasA1.WBCLientes" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <<script src='http://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js' 
type='text/javascript'></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>  
 

   
</head>
<body>
    
     <asp:Panel ID="pnlampliacion" visible="true" runat="server" >
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            Formulario de Clientes
                        </h3>
                    </div>
    <form id="form1" runat="server">
        <div class="row">

            <div class="col-lg-2 col-md-6 col-xs-12">
                <label for="txtNombre">Nombre Completo:</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" ></asp:TextBox>
              
            </div>
            <div class="col-lg-2 col-md-6 col-xs-12">
                           <label for="txtidentificacion">Identificación:</label>
                <asp:TextBox ID="txtidentificacion" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
           <div class="col-lg-2 col-md-6 col-xs-12">
                           <label for="txttelefono">Teléfono:</label>
                <asp:TextBox ID="txttelefono" CssClass="form-control" runat="server" ></asp:TextBox>

            </div>

        </div>
        <br />
        <br />
        <div class="row">

             <div class="col-lg-2 col-md-6 col-xs-12">
                <asp:Button ID="btnshow" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnshow_Click" />

            </div>
            <div class="col-lg-2 col-md-6 col-xs-12">
                <asp:Button ID="btninsertar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btninsertar_Click" />

            </div>
            <div class="col-lg-2 col-md-6 col-xs-12" runat="server" id="alerta" visible="false"> 
                <div class="alert alert-danger alert-dismissible fade in">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Alerta!</strong> Debe ingresar los datos correspondientes
                </div>

            </div>
        </div>
        <br /><br />
        <div>
            <asp:GridView CssClass="table table-hover table-bordered" ID="GridView1" DataKeyNames="ID"
                runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                >
                <Columns>
                    <asp:buttonfield buttontype="Link" commandname="Editar" ControlStyle-CssClass="btn btn-primary" text="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>"/>
                    <asp:BoundField DataField="ID" HeaderText="IdPesca" Visible="false" />
                    <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="Nombre" />
                    <asp:BoundField DataField="IDENTIFICACION" HeaderText="Identificacion" />
                    <asp:BoundField DataField="TELEFONO" HeaderText="Telefono" />         
                    
                    <asp:buttonfield buttontype="Link" commandname="Eliminar" ControlStyle-CssClass="btn btn-danger" text="<i aria-hidden='true' class='glyphicon glyphicon-trash'></i>"/>  
                             
                </Columns>
            </asp:GridView>                   


            <div class="panel-body">

                <table style="width: 100%;">
                    <tr>
                        <td class="style10">&nbsp;
                        </td>
                        <td class="style9">&nbsp;
                        </td>
                        <td class="style7">&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
                    </div>
                    </asp:Panel>
    
</body>
</html>
