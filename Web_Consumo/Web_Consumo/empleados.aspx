﻿<%@ Page Title="Tabla_Empleados" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="empleados.aspx.cs" Inherits="Web_Consumo.empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">


<header>
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
</header>


<div class="ContenedorPrincipal">
    <!--[if lte IE 9]>
            <p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="https://browsehappy.com/">upgrade your browser</a> to improve your experience and security.</p>
        <![endif]-->
    <!-- header-start -->

     <div class="ContenedorSecundario">


        <div class="destination_details_info">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-8 col-md-9">
                         <h2 class="tituloH">LISTA EMPLEADOS</h2>
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
                                <button type="button" class="btn btn-success float-right" onclick="AGREGAR_EMPLEADOS_MD()">AGREGAR ITEM</button>
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
                            <h4 class="modal-title">EDITAR EMPLEADOS</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                                 <div>
                                <div class="input_field">
                                    <h4>ID EMPLEADO</h4>
                                    <input runat="server" id="inp_ID_Empleado_ED" class="form-control style_disabled" type="text" placeholder="ID_EMPLEADO">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>CEDULA</h4>
                                    <input runat="server" id="inp_Cedula_ED" class="form-control" type="text" placeholder="CEDULA">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>NOMBRE</h4>
                                   <input runat="server" id="inp_Nombre_ED" class="form-control" type="text" placeholder="NOMBRE">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>APELLIDOS</h4>
                                   <input runat="server" id="inp_Apellidos_ED" class="form-control" type="text" placeholder="APELLIDOS">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>DIRECCION</h4>
                                   <input runat="server" id="inp_Direccion_ED" class="form-control" type="text" placeholder="DIRECCION">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>EDAD</h4>
                                   <input runat="server" id="inp_Edad_ED" class="form-control" type="text" placeholder="EDAD">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>TEL CASA</h4>
                                   <input runat="server" id="inp_TelCasa_ED" class="form-control" type="text" placeholder="TELEFONO CASA">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>TEL REFERENCIA</h4>
                                   <input runat="server" id="inp_TelReferencia_ED" class="form-control" type="text" placeholder="TELEFONO DE REFERENCIA">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>CELULAR</h4>
                                   <input runat="server" id="inp_Celular_ED" class="form-control" type="text" placeholder="NUM CELULAR">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>SALARIO</h4>
                                   <input runat="server" id="inp_Salario_ED" class="form-control" type="text" placeholder="SALARIO">
                                </div>
                                <br />
                                <div class="input_field">
                                    <br />
                                    <h4>ID_TIPO_EMPLEADO</h4>
                                    <select runat="server" id="slc_ID_Tipo_Empleado_ED" class="form-control" > </select>
                                </div>
                                <br />
                                <div class="input_field">
                                    <br />
                                    <h4>ID_AEROLINEA</h4>
                                    <select runat="server" id="slc_ID_Aerolinea_ED" class="form-control" > </select>
                                </div>
                                <br />
                                <div class="input_field">
                                    <br />
                                    <h4>ID_ESTADO</h4>
                                    <select runat="server" id="slc_ID_Estado_ED" class="form-control" > </select>
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
                            <h4 class="modal-title">ELIMINAR EMPLEADO</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>DESEAS ELIMINAR ESTE EMPLEADO?</h4>
                                    <div class="row">
                                        <div class="col-3">
                                            <input runat="server" id="inp_ID_Empleado_Elim" class="form-control style_disabled" type="text">
                                        </div>
                                        <div class="col-9">
                                                <input runat="server" id="inp_Nombre_Elim" class="form-control style_disabled" type="text">
                                        </div>
                                        <div class="col-9">
                                                <input runat="server" id="inp_Apellidos_Elim" class="form-control style_disabled" type="text">
                                        </div>
                                    </div>    
                                </div>
                                <br />
                            </div>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">                  
                            <asp:Button runat="server" Text="Eliminar Registro"  ID="btn_Eliminar_Empleado" OnClick="btn_Eliminar_Click" class="btn btn-primary"/>
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
                            <h4 class="modal-title">AGREGAR TIPO EMPLEADO</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>ID EMPLEADO</h4>
                                    <input runat="server" id="inp_IdEmpleado_AG" class="form-control" type="text" placeholder="ID_EMPLEADO">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>CEDULA</h4>
                                    <input runat="server" id="inp_Cedula_AG" class="form-control" type="text" placeholder="CEDULA">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>NOMBRE</h4>
                                   <input runat="server" id="inp_Nombre_AG" class="form-control" type="text" placeholder="NOMBRE">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>APELLIDOS</h4>
                                   <input runat="server" id="inp_Apellidos_AG" class="form-control" type="text" placeholder="APELLIDOS">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>DIRECCION</h4>
                                   <input runat="server" id="inp_Direccion_AG" class="form-control" type="text" placeholder="DIRECCION">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>EDAD</h4>
                                   <input runat="server" id="inp_Edad_AG" class="form-control" type="text" placeholder="EDAD">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>TEL CASA</h4>
                                   <input runat="server" id="inp_TelCasa_AG" class="form-control" type="text" placeholder="TELEFONO CASA">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>TEL REFERENCIA</h4>
                                   <input runat="server" id="inp_TelRef_AG" class="form-control" type="text" placeholder="TELEFONO DE REFERENCIA">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>CELULAR</h4>
                                   <input runat="server" id="inp_Celular_AG" class="form-control" type="text" placeholder="NUM CELULAR">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>SALARIO</h4>
                                   <input runat="server" id="inp_Salario_AG" class="form-control" type="text" placeholder="SALARIO">
                                </div>
                                <br />
                                <div class="input_field">
                                    <br />
                                    <h4>ID_TIPO_EMPLEADO</h4>
                                    <select runat="server" id="slc_IdTipoEmpleado_AG" class="form-control" >
                                        <option value="0" selected disabled aria-autocomplete="none" >2</option>
                                    </select>
                                </div>
                                <br />
                                <div class="input_field">
                                    <br />
                                    <h4>ID_AEROLINEA</h4>
                                    <select runat="server" id="slc_IdAerolinea_AG" class="form-control" >
                                        <option value="0" selected disabled aria-autocomplete="none" >4</option>
                                    </select>
                                </div>
                                <br />
                                <div class="input_field">
                                    <br />
                                    <h4>ID ESTADO</h4>
                                    <select runat="server" id="slc_IdEstado_AG" class="form-control" >
                                        <option value="0" selected disabled aria-autocomplete="none" >A</option>
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

 
    </div>
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
    <script src="js/Tablas/Empleados.js"></script>
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



   </div>


</asp:Content>