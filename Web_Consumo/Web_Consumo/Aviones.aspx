<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aviones.aspx.cs" Inherits="Web_Consumo.Aviones" %>

<!DOCTYPE html>

<html class="no-js" lang="zxx">

<head>
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>Travelo</title>
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

</head>

<body>
    <!--[if lte IE 9]>
            <p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="https://browsehappy.com/">upgrade your browser</a> to improve your experience and security.</p>
        <![endif]-->
    <form id="MyForm" method="post" runat="server">
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
                                                <li><a class="" href="travel_destination.html">Vuelos</a></li>
                                                <li>
                                                    <a href="#">Tablas <i class="ti-angle-down"></i></a>
                                                    <ul class="submenu">
                                                        <li><a href="destination_details.html">Empleados</a></li>
                                                        <li><a href="elements.html">Clientes</a></li>
                                                        <li><a href="TiposEmpleados.aspx">Tipos Empleados</a></li>
                                                    </ul>
                                                </li>
                                                <li>
                                                    <a href="#">blog <i class="ti-angle-down"></i></a>
                                                    <ul class="submenu">
                                                        <li><a href="blog.html">blog</a></li>
                                                        <li><a href="single-blog.html">single-blog</a></li>
                                                    </ul>
                                                </li>
                                                <li><a href="contact.html">Contact</a></li>
                                            </ul>
                                        </nav>
                                    </div>
                                </div>
                                <div class="col-xl-4 col-lg-4 d-none d-lg-block">
                                    <div class="social_wrap d-flex align-items-center justify-content-end">
                                        <div class="main-menu  d-none d-lg-block">
                                            <input type="text" name="search" placeholder="Search..">
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

        <div class="destination_details_info">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-8 col-md-9">
                         <h2 class="tituloH">AVIONES</h2>
                        <div class="row">                           
                            <div class="col-lg-8 col-md-8">
                                 <div class="row">
                                    <div class="col-lg-8 col-md-8">
                                         <input runat="server" id="inp_Filtrar" class="form-control" type="text" placeholder="FILTRAR DATOS">
                                    </div>
                                    <div class="col-lg-4 col-md-4">
                                          <asp:Button runat="server" Text="FILTRAR"  ID="btn_Filtrar" OnClick="btn_Filtrar_Click" class="btn btn-primary"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4">
                                <button type="button" class="btn btn-success float-right" onclick="AGREGAR_MD()">AGREGAR ITEM</button>
                            </div>
                        </div>
                        <br />
                        <asp:Label ID="labelTable" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>

                
        <!-- MODAL PARA EDITAR DATOS-->
        <div class="modal fade" id="ModalEditar">
            <div class="modal-dialog">
                <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">TIPOS AVIONES</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>ID AVION</h4>
                                    <input runat="server" id="inp_IDAVION" class="form-control" type="text" placeholder="ID AVION">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>NOMBRE DEL AVION</h4>
                                    <input runat="server" id="inp_NOMAVION" class="form-control" type="text" placeholder="NOMBRE O MODELO AVION">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>DESCRIPCION DEL AVION</h4>
                                    <input runat="server" id="inp_DESCAVION" class="form-control" type="text" placeholder="DESCRIPCIOIN DEL AVION">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>ID AEROLINEA</h4>
                                    <select runat="server" id="slc_IDAerolinea" class="form-control" >
                                    </select>
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>TIPO DE AVION</h4>
                                       <select runat="server" id="slc_IDtpAVION" class="form-control" >
                                       </select>
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>ID ESTADO</h4>
                                    <select runat="server" id="slc_IDESTAD" class="form-control" >
                                    </select>
                                </div>
                            </div>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">                  
                            <asp:Button runat="server" Text="Guardar Cambios"  ID="btn_Editar" OnClick="btn_Editar_Click" class="btn btn-primary"/>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                </div>
            </div>
        </div>

        <!-- MODAL PARA ELIMINAR DATOS-->
        <div class="modal fade" id="ModalEliminar">
            <div class="modal-dialog">
                <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">ELIMINAR AEROLINEA</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>DESEAS ELIMINAR LA AEROLINEA?</h4>
                                    <div class="row">
                                        <div class="col-3">
                                            <input runat="server" id="inp_IDTIP_ELIM" class="form-control style_disabled" type="text">
                                        </div>
                                        <div class="col-9">
                                                <input runat="server" id="inp_DESCR_ELIM" class="form-control style_disabled" type="text">
                                        </div>
                                    </div>    
                                </div>
                                <br />
                            </div>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">                  
                            <asp:Button runat="server" Text="Eliminar Registro"  ID="btn_EliminarRegist" OnClick="btn_Eliminar_Click" class="btn btn-primary"/>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                </div>
            </div>
        </div>

        <!-- MODAL PARA AGREGAR DATOS-->
        <div class="modal fade" id="ModalAgregar">
            <div class="modal-dialog">
                <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">AGREGAR NUEVA AEROLINEA</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>ID AVION</h4>
                                    <input runat="server" id="inp_IDAVION_AG" class="form-control" type="text" placeholder="ID AVION">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>NOMBRE AVION</h4>
                                    <input runat="server" id="inp_NOMAVION_AG" class="form-control" type="text" placeholder="NOMBRE AVION">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>DESCRIPCION DEL AVION</h4>
                                    <input runat="server" id="inp_DESCAVION_AG" class="form-control" type="text" placeholder="DESCRIPCION DEL AVION">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>ID AEROLINEA</h4>
                                    <select runat="server" id="slc_IDAerolinea_AG" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
                                    </select>
                                </div>
                                 <br />
                                  <div class="input_field">
                                    <h4>ID TIPO AVION</h4>
                                    <select runat="server" id="slc_IDtpAVION_AG" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
                                    </select>
                                </div>
                                 <br />
                                <div class="input_field">
                                    <h4>ID ESTADO</h4>
                                    <select runat="server" id="slc_IDESTAD_AG" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">                  
                            <asp:Button runat="server" Text="Agregar Item"  ID="btn_Agregar" OnClick="btn_Agregar_Click" class="btn btn-primary"/>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                </div>
            </div>
        </div>
        
                
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

        <!-- Modal -->
        <div class="modal fade custom_search_pop" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="serch_form">
                        <input type="text" placeholder="Search">
                        <button type="submit">search</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- link that opens popup -->
    </form>
    <!--
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
        <script src="https://static.codepen.io/assets/common/stopExecutionOnTimeout-de7e2ef6bfefd24b79a3f68b414b87b8db5b08439cac3f1012092b2290c719cd.js"></script>

        <script src=" https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"> </script> -->
    <!-- JS here -->
    <script src="js/vendor/modernizr-3.5.0.min.js"></script>
    <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/isotope.pkgd.min.js"></script>
    <script src="js/ajax-form.js"></script>
    <script src="js/waypoints.min.js"></script>
    <script src="js/jquery.counterup.min.js"></script>
    <script src="js/imagesloaded.pkgd.min.js"></script>
    <script src="js/scrollIt.js"></script>
    <script src="js/jquery.scrollUp.min.js"></script>
    <script src="js/wow.min.js"></script>
    <script src="js/nice-select.min.js"></script>
    <script src="js/jquery.slicknav.min.js"></script>
    <script src="js/jquery.magnific-popup.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/gijgo.min.js"></script>
    <script src="js/slick.min.js"></script>
    <script src="js/Tablas/Aviones.js"></script>

    <!--contact js-->
    <script src="js/contact.js"></script>
    <script src="js/jquery.ajaxchimp.min.js"></script>
    <script src="js/jquery.form.js"></script>
    <script src="js/jquery.validate.min.js"></script>
    <script src="js/mail-script.js"></script>
    
    <script src="js/main.js"></script>
    <script src="js/custom.js"></script>
    
    <script>

        $('#datepicker').datepicker({
            iconsLibrary: 'fontawesome',
            icons: {
                rightIcon: '<span class="fa fa-caret-down"></span>'
            }
        });
    </script>
</body>

</html>
