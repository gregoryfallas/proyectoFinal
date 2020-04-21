<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="TiposClientes.aspx.cs" Inherits="Web_Consumo.TiposClientes1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>Tipos de Clientes</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- <link rel="manifest" href="site.webmanifest"> -->
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.png">
    <!-- Place favicon.ico in the root directory -->

    <!-- CSS here -->
    <link href="css/MyStyles.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/magnific-popup.css">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link rel="stylesheet" href="css/themify-icons.css">
    <link rel="stylesheet" href="css/nice-select.css">
    <link rel="stylesheet" href="css/flaticon.css">
    <link rel="stylesheet" href="css/gijgo.css">
    <link rel="stylesheet" href="css/animate.css">
    <link rel="stylesheet" href="css/slick.css">
    <link rel="stylesheet" href="css/slicknav.css">
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css">
    <link rel="stylesheet" href="css/style.css">
    <!-- <link rel="stylesheet" href="css/responsive.css"> -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <!--Table tittle-start-->
    <div id="divTitle" runat="server">
        <b><h1 id="title" style=" text-align:center; padding:5px; background-color:midnightblue; color:white">TIPOS DE CLIENTES</h1></b>
    </div>
    <div id="divSubTitle" runat="server" style="padding:5px">
        <h2></h2>
    </div>
    <!--Table tittle-end-->
    <!--Main content-start-->
    <div class="row">
        <!-- Controls-start -->
        <div class="col-lg-5" style="padding:5px">
            <div id="divFiltro" style="padding:5px" class="row">
                <div class="col-8 text-right">
                    <p ><asp:Label ID="lblFiltro" runat="server" Text="FILTRO" CssClass="mylabel"></asp:Label></p>
                </div>
                <div class="col-4">
                    <p class="myparr_left"><asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox></p>
                </div>
            </div>
            <div id="divEliminar" style="padding:5px" class="row">
                <div class="col-8 text-right">
                </div>
                <div class="col-4">
                    <asp:Button ID="btnBuscar" CssClass="myactionButton" runat="server" Text="BUSCAR" OnClick="btnBuscar_Click" ToolTip="Buscar un tipo de Cliente" />
                    <asp:Button ID="bntEliminar" CssClass="myactionButton" runat="server" Text="ELIMINAR" OnClientClick="return confirm('¿Realmente desea eliminar el dato?')" OnClick="bntEliminar_Click" ToolTip="Eliminar un tipo de Cliente" />
                </div>
            </div>
            <div id="divCargar" style="padding:5px" class="row">
                <div class="col-8 text-right">
                </div>
                <div class="col-4">
                    <asp:Button ID="btnCargar" CssClass="myactionButton_lg" runat="server" Text="CARGAR ID DATA" OnClick="btnCargar_Click" ToolTip="Carga los valores de un ID de tipo de Cliente" />
                </div>
            </div><br />
            <div id="divID" style="padding:5px" class="row">
                <div class="col-8 text-right">
                    <p ><asp:Label ID="lblID" runat="server" Text="ID" CssClass="mylabel"></asp:Label></p>
                </div>
                <div class="col-4">
                    <p class="myparr_left"><asp:TextBox ID="txtID" runat="server"></asp:TextBox></p>
                </div>
            </div>
            <div id="divNombre" style="padding:5px" class="row">
                <div class="col-8 text-right">
                    <p ><asp:Label ID="lblTipo" runat="server" Text="Tipo" CssClass="mylabel"></asp:Label></p>
                </div>
                <div class="col-4">
                    <p class="myparr_left"><asp:TextBox ID="txtTipo" runat="server"></asp:TextBox></p>
                </div>
            </div>
            <div id="divDesc" style="padding:5px" class="row">
                <div class="col-8 text-right">
                    <p ><asp:Label ID="lblDesc" runat="server" Text="Descripción" CssClass="mylabel"></asp:Label></p>
                </div>
                <div class="col-4">
                    <p class="myparr_left"><asp:TextBox ID="txtDesc" runat="server"></asp:TextBox></p>
                </div>
            </div>
            <div id="divEstado" style="padding:5px" class="row">
                <div class="col-8 text-right">
                    <p ><asp:Label ID="lblEstado" runat="server" Text="Estado" CssClass="mylabel"></asp:Label></p>
                </div>
                <div class="col-4">
                    <p class="myparr_left"><asp:TextBox ID="txtEstado" runat="server"></asp:TextBox></p>
                </div>
            </div>
            <div id="divControles" style="padding:5px" class="row">
                <div class="col-8 text-right">                  
                </div>
                <div class="col-4">
                    <asp:Button ID="btnAgr" CssClass="myactionButton" runat="server" Text="AGREGAR" OnClientClick="return confirm('Confirme que desea agregar los nuevos datos')" OnClick="btnAgr_Click" ToolTip="Agregar tipo de Cliente" />
                    <asp:Button ID="btnMod" CssClass="myactionButton" runat="server" Text="MODIFICAR" OnClientClick="return confirm('¿Desea modificar el dato?')" OnClick="btnMod_Click" ToolTip="Modificar tipo de Cliente" />
                </div>
            </div>
        </div>
        <!-- Controls-end -->
        <!-- Table-start -->
        <div id="divTabla" class="col-lg-7" style="padding:5px">
            <asp:GridView ID="dgvTiposClientes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" HorizontalAlign="Center" BorderStyle="Groove">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>            
        </div>
        <!-- Table-end -->
    </div>
    <div id="div1" runat="server" style="padding:10px">
        <h2></h2>
    </div>
    <!--Main content-end-->



</asp:Content>
