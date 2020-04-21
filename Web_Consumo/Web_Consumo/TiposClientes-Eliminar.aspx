<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiposClientes.aspx.cs" Inherits="Web_Consumo.TiposClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
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
</head>
<body>

    <!-- header-start -->
    <header>
        <div class="header-area ">
            <div id="sticky-header" class="main-header-area">
                <div class="container-fluid">
                    <div class="header_bottom_border">
                        <div class="row align-items-center">
                            <div class="col-xl-2 col-lg-2">
                                <div class="logo">
                                    <a href="index.html">
                                        <img src="img/logo.png" alt="">
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-6 col-lg-6">
                                <div class="main-menu  d-none d-lg-block">
                                    <nav>
                                        <ul id="navigation">
                                            <li><a class="active" href="index.aspx">home</a></li>
                                            <li><a href="about.html">About</a></li>
                                            <li><a class="" href="travel_destination.html">Vuelos</a></l/li>
                                            <li><a href="#">Usuarios <i class="ti-angle-down"></i></a>
                                                <ul class="submenu">
                                                        <li><a href="empleados.aspx">Empleados</a></li>
                                                        <li><a href="elements.html">Clientes</a></li>
                                                </ul>
                                            </li>
                                            <li><a href="#">blog <i class="ti-angle-down"></i></a>
                                                <ul class="submenu">
                                                    <li><a href="blog.html">blog</a></li>
                                                    <li><a href="single-blog.html">single-blog</a></li>
                                                </ul>
                                            </li>
                                            <li><a href="contact.html">Contact</a></li>
                                            <li><a href="#">Administrador <i class="ti-angle-down"></i></a>
                                                <ul class="submenu">
                                                        <li><a href="TiposAviones.aspx">Tipos de Aviones</a></li>
                                                        <li><a href="TiposClientes.aspx">Tipos de Clientes</a></li>                                                        
                                                </ul>
                                            </li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                            <div class="col-xl-4 col-lg-4 d-none d-lg-block">
                                <div class="social_wrap d-flex align-items-center justify-content-end">
                                    <div  class="main-menu  d-none d-lg-block">
                                        <a class="active" href="index.html">Iniciar Sesion</a>
                                    </div>
                                </div>
                            </div>
                            <div class="seach_icon">
                                <a data-toggle="modal" data-target="#exampleModalCenter" href="#">
                                    <i class="fa fa-search"></i>
                                </a>
                            </div>
                            <div class="col-12">
                                <div class="mobile_menu d-block d-lg-none"></div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </header>
    <!-- header-end -->

    <!-- Page content-start -->
    <form id="frmData" runat="server">
        <div id="divTitle" runat="server">
            <b><h1 id="title" style=" text-align:center; padding:5px; background-color:midnightblue; color:white">TIPOS DE CLIENTES</h1></b>
        </div>
        <div id="divSubTitle" runat="server" style="padding:5px">
            <h2></h2>
        </div>
        <div class="row">
            <!-- Controls-start -->
            <div class="col-lg-4" style="padding:5px">
                <div id="divFiltro" style="padding:5px" class="row">
                    <div class="col-6">
                        <p class="myparr_right"><asp:Label ID="lblFiltro" runat="server" Text="FILTRO" CssClass="mylabel"></asp:Label></p>
                    </div>
                    <div class="col-6">
                        <p class="myparr_left"><asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox></p>
                    </div>
                </div>
                <div id="divEliminar" style="padding:5px" class="row">
                    <div class="col-6">
                    </div>
                    <div class="col-6">
                        <asp:Button ID="btnBuscar" CssClass="myactionButton" runat="server" Text="BUSCAR" OnClick="btnBuscar_Click" ToolTip="Buscar un tipo de Cliente" />
                        <asp:Button ID="bntEliminar" CssClass="myactionButton" runat="server" Text="ELIMINAR" OnClick="bntEliminar_Click" ToolTip="Eliminar un tipo de Cliente" />
                    </div>
                </div>
                <div id="divCargar" style="padding:5px" class="row">
                    <div class="col-6">
                    </div>
                    <div class="col-6">
                        <asp:Button ID="btnCargar" CssClass="myactionButton_lg" runat="server" Text="CARGAR ID DATA" OnClick="btnCargar_Click"  ToolTip="Carga los valores de un ID de tipo de Cliente" />
                    </div>
                </div><br />
                <div id="divID" style="padding:5px" class="row">
                    <div class="col-6">
                        <p class="myparr_right"><asp:Label ID="lblID" runat="server" Text="ID" CssClass="mylabel"></asp:Label></p>
                    </div>
                    <div class="col-6">
                        <p class="myparr_left"><asp:TextBox ID="txtID" runat="server"></asp:TextBox></p>
                    </div>
                </div>
                <div id="divNombre" style="padding:5px" class="row">
                    <div class="col-6">
                        <p class="myparr_right"><asp:Label ID="lblTipo" runat="server" Text="Tipo" CssClass="mylabel"></asp:Label></p>
                    </div>
                    <div class="col-6">
                        <p class="myparr_left"><asp:TextBox ID="txtTipo" runat="server"></asp:TextBox></p>
                    </div>
                </div>
                <div id="divDesc" style="padding:5px" class="row">
                    <div class="col-6">
                        <p class="myparr_right"><asp:Label ID="lblDesc" runat="server" Text="Descripción" CssClass="mylabel"></asp:Label></p>
                    </div>
                    <div class="col-6">
                        <p class="myparr_left"><asp:TextBox ID="txtDesc" runat="server"></asp:TextBox></p>
                    </div>
                </div>
                <div id="divEstado" style="padding:5px" class="row">
                    <div class="col-6">
                        <p class="myparr_right"><asp:Label ID="lblEstado" runat="server" Text="Estado" CssClass="mylabel"></asp:Label></p>
                    </div>
                    <div class="col-6">
                        <p class="myparr_left"><asp:TextBox ID="txtEstado" runat="server"></asp:TextBox></p>
                    </div>
                </div>
                <div id="divControles" style="padding:5px" class="row">
                    <div class="col-6">                  
                    </div>
                    <div class="col-6">
                        <asp:Button ID="btnAgr" CssClass="myactionButton" runat="server" Text="AGREGAR" OnClick="btnAgr_Click" ToolTip="Agregar tipo de Cliente" />
                        <asp:Button ID="btnMod" CssClass="myactionButton" runat="server" Text="MODIFICAR" OnClick="btnMod_Click" ToolTip="Modificar tipo de Cliente" />
                    </div>
                </div>
            </div>
            <!-- Controls-end -->
            <!-- Table-start -->
            <div id="divTabla" class="col-lg-8" style="padding:5px">
                <asp:GridView ID="dgvTiposClientes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" HorizontalAlign="Left" BorderStyle="Groove">
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
    </form>
    <!-- Page content-end -->

    <!-- footer-start -->
    <footer class="footer">
        <div class="footer_top">
            <div class="copy-right_text">
                <div class="container">
                    <div class="footer_border"></div>
                    <div class="row">
                        <div class="col-xl-12">
                            <p class="copy_right text-center">
                                <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                                Copyright &copy;
                                <script>document.write(new Date().getFullYear());</script> All rights reserved | This template is made with <i class="fa fa-heart-o" aria-hidden="true"></i> by <a href="https://colorlib.com" target="_blank">Colorlib</a>
                                <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>
    <!-- header-end -->
</body>
</html>
