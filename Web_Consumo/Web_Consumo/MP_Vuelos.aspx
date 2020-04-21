<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="MP_Vuelos.aspx.cs" Inherits="Web_Consumo.MP_Vuelos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- <link rel="manifest" href="site.webmanifest"> -->
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.png">
    <!-- Place favicon.ico in the root directory -->
    <!-- CSS here -->
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
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script type="text/javascript"
            src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.5.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="destination_details_info">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-md-9">
                </div>
               <!-- <form id="form1" runat="server">-->
        <div>
              <asp:Label ID="lbl_filtar_Vuelos" runat="server" Text="ID del Vuelos : " CssClass="btGrisNegrita" Font-Bold="true"></asp:Label>
              <asp:TextBox ID="txt_filtroVuelos" runat="server" Width="477px"  CssClass="btGrisNegrita"></asp:TextBox>  <br><br />
              <asp:Button ID="btn_FiltrarVuelos" runat="server" Text="Buscar" class="boxed-btn4" OnClick="btn_FiltrarVuelos_Click"/><br><br />
               <div>
                   <asp:Label ID="lb_ID_Vuelos" runat="server" Text="ID Vuelos :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;
                   <asp:TextBox ID="txt_ID_Vuelos" runat="server" Width="180px" style="text-align:center" BorderStyle="Solid" CssClass="range" MaxLength="4" ></asp:TextBox>
                   <br />
                   <br />
                   <asp:Label ID="lb_ID_Destinos" runat="server" Text="ID Destinos :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_ID_Destinos" runat="server" Width="180px" style="text-align:center" BorderStyle="Solid" MaxLength="4"></asp:TextBox>
                   &nbsp;&nbsp;&nbsp;&nbsp;
                   <br />
                   <br />
                   <asp:Label ID="lb_ID_Aerolinea" runat="server" Text="ID Aerolinea :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:TextBox ID="txt_ID_Aerolinea" runat="server" Width="180px" style="text-align:center" BorderStyle="Solid" MaxLength="4"></asp:TextBox>
                   <br />
                   <br />
                   <asp:Label ID="lb_ID_Avion" runat="server" Text="ID Avion :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_ID_Avion" runat="server" Width="180px" style="text-align:center" BorderStyle="Solid" MaxLength="4"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<br />
                   <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Width="220px">
                       <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                       <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                       <OtherMonthDayStyle ForeColor="#999999" />
                       <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                       <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                       <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                       <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                       <WeekendDayStyle BackColor="#CCCCFF" />
                   </asp:Calendar>
                   <br />
                   <asp:Label ID="lb_FechaHoraSalida" runat="server" Text="Fecha-Hora de Salida :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_FechaHoraSalida" TextMode="Date" runat="server" Width="180px" style="text-align:center" BorderStyle="Solid" CssClass="datetimepicker"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="28px" ImageUrl="~/img/Calendario1.png" OnClick="ImageButton1_Click" Width="36px" />
                   &nbsp;&nbsp;
                   <br />
                   <br />
                   <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar2_SelectionChanged1" ShowGridLines="True" Width="220px">
                       <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                       <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                       <OtherMonthDayStyle ForeColor="#CC9966" />
                       <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                       <SelectorStyle BackColor="#FFCC66" />
                       <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                       <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                   </asp:Calendar>
                   <asp:Label ID="lb_FechaHoraLlegada" runat="server" Text="Fecha-Hora de Llegada :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
                   <asp:TextBox ID="txt_FechaHoraLlegada" TextMode="Date" runat="server" Width="180px" style="text-align:center" BorderStyle="Solid" CssClass="datetimepicker"></asp:TextBox>
                   <asp:ImageButton ID="ImageButton2" runat="server" Height="28px" ImageUrl="~/img/Calendario1.png" Width="36px" OnClick="ImageButton2_Click" />
                   <br />
                   <br />
                   <asp:Label ID="lb_ID_Estado" runat="server" Text="ID Estado :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_ID_Estado" runat="server" Width="180px" BorderStyle="Solid"></asp:TextBox>
                   &nbsp;<br />
                   <br />
                   <asp:Button ID="btn_Insertar" runat="server" Text="INSERTAR"  class="boxed-btn4" OnClick="btn_Insertar_Click"/> &nbsp;
                   <asp:Button ID="btn_Modificar" runat="server" Text="MODIFICAR"  class="boxed-btn4" OnClick="btn_Modificar_Click"/> &nbsp;
                   <asp:Button ID="btn_Eliminar" runat="server" Text="ELIMINAR"  class="boxed-btn4" OnClick="btn_Eliminar_Click"/>&nbsp;
                  
                   <br />
                   <br />
                   <asp:GridView ID="DGV_DATOSV" runat="server" CssClass="align-items-sm-center" style="text-align:center" BorderStyle="None" BackColor="White" BorderColor="#999999" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                       <AlternatingRowStyle BackColor="#DCDCDC" />
                       <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                       <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                       <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                       <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                       <SortedAscendingHeaderStyle BackColor="#0000A9" />
                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                       <SortedDescendingHeaderStyle BackColor="#000065" />
                   </asp:GridView>
                   <p></p>
               </div>        
        </div>
   <!-- </form>-->

            </div>
        </div>
    </div>

    <!-- The Modal -->
    <div class="modal fade" id="myModal">
        <div class="modal-dialog">
            Programacion
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Estados</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                   <!-- <form action="/" method="post">-->
                        <div>
                            <div class="input_field">
                                <h4>ID ESTADO</h4>
                                <input id="inputcolumn0" class="form-control" type="text" placeholder="ID ESTADO">
                            </div>
                            <br />
                            <div class="input_field">
                                <h4>DESCRIPCION</h4>
                                <input id="inputcolumn1" class="form-control" type="text" placeholder="DESCRIPCION">
                            </div>
                            <br />
                        </div>
                  <!--  </form>-->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
