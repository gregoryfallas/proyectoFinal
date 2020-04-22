<%@ Page Title="Destinos" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="tbl_Destinos.aspx.cs" Inherits="Web_Consumo.tbl_Destinos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">




<header class="header-area">
    <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>
    
    <meta name="description" content=""/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- <link rel="manifest" href="site.webmanifest"> -->
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.png"/>
    <!-- Place favicon.ico in the root directory -->
    <!-- CSS here -->
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/owl.carousel.min.css"/>
    <link rel="stylesheet" href="css/magnific-popup.css"/>
    <link rel="stylesheet" href="css/font-awesome.min.css"/>
    <link rel="stylesheet" href="css/themify-icons.css"/>
    <link rel="stylesheet" href="css/nice-select.css"/>
    <link rel="stylesheet" href="css/flaticon.css"/>
    <link rel="stylesheet" href="css/gijgo.css"/>
    <link rel="stylesheet" href="css/animate.css"/>
    <link rel="stylesheet" href="css/slick.css"/>
    <link rel="stylesheet" href="css/slicknav.css"/>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css"/>
    <link rel="stylesheet" href="css/style.css"/>
    <!-- <link rel="stylesheet" href="css/responsive.css"> -->
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script type="text/javascript"
            src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.5.1.min.js"></script>

</header>


<div class="ContendorPrincipal">

    <div class="ContenedorSecundario">

        <div class="destination_details_info">
            <div class="container">
          
                
               <!-- Botonera -->  
                
                <div class="row justify-content-center">
                    <div class="col-lg-8 col-md-9">
                         <h2 class="tituloH">LISTA DE DESTINOS</h2>
                        <div class="row">                           
                            <div class="col-lg-8 col-md-8">
                                 <div class="row">
                                    <div class="col-lg-8 col-md-8">
                                         <input runat="server" id="inp_Filtrar" class="form-control" type="text" placeholder="FILTRAR DATOS"/>
                                    </div>
                                    <div class="col-lg-4 col-md-4">
                                          <asp:Button runat="server" Text="FILTRAR"  ID="btn_Filtrar" OnClick="btn_Filtrar_Click" class="btn btn-primary"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4">
                                <button type="button" class="btn btn-success float-right" onclick="AGREGAR_DESTINOS_MD()">AGREGAR ITEM</button>
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
                            <h4 class="modal-title">EDITAR DESTINOS</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

      
                          <!-- Modal body -->

                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>ID DESTINO</h4>
                                    <input runat="server" id="inp_ID_Destino_ED" class="form-control style_disabled" type="text" placeholder="ID_DESTINO"/>
                                </div>
                                <br />
                               <div class="input_field">
                                    <h4>ID_AEROLINEA</h4>
                                    <select runat="server" id="slc_ID_Aerolinea_ED" class="form-control" > </select>
                                </div>
                                <br />
                                 <div class="input_field">
                                    <h4>NOMBRE DESTINO</h4>
                                   <input runat="server" id="inp_NombDestino_ED" class="form-control" type="text" placeholder="NOMBRE DESTINO"/>
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>PAIS DE SALIDA</h4>
                                    <select runat="server" id="slc_ID_PaisSalida_ED" class="form-control" > </select>
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>PAIS DE LLEGADA</h4>
                                    <select runat="server" id="slc_ID_PaisLlegada_ED" class="form-control" > </select>
                                </div>
                                <br />
                                <div class="input_field">
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
                            <h4 class="modal-title">ELIMINAR DESTINOS</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->

                         <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>ESTA SEGURO DE ELIMINAR<br /> ESTE DESTINO?</h4>
                                    <div class="row">
                                        <div class="col-3">
                                            <input runat="server" id="inp_ID_Dest_Elim" class="form-control style_disabled" type="text"/>
                                        </div>
                                        <div class="col-4">
                                                <input runat="server" id="inp_Nomb_Dest_Elim" class="form-control style_disabled" type="text"/>
                                        </div>
                                    </div>    
                                </div>
                                <br />
                            </div>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">                  
                            <asp:Button runat="server" Text="Eliminar Registro"  ID="btn_EliminarRegist" OnClick="btn_EliminarRegist_Click" class="btn btn-primary"/>
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
                            <h4 class="modal-title">AGREGAR DESTINO NUEVO</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->

                            <!-- Modal body -->
                        <div class="modal-body">
                            <div>

                                <div class="input_field">
                                    <h4>ID_DESTINO</h4>
                                    <input runat="server" id="inp_IdDestino_AG" class="form-control" type="text" placeholder="ID_DESTINO"/>
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>ID_AEROLINEA</h4>
                                    <select runat="server" id="slc_ID_Aerolinea_AG" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
                                    </select>
                                    <br />
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>NOMBRE DESTINO</h4>
                                   <input runat="server" id="inp_NombreDestino_AG" class="form-control" type="text" placeholder="NOMBRE DESTINO"/>
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>PAIS SALIDA</h4>
                                   <select runat="server" id="slc_ID_PaisLlegada_AG" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
                                    </select> 
                                    <br />
                                </div>
                                <br />
                                <div class="input_field">
                                    <br />
                                    <h4>PAIS LLEGADA</h4>
                                   <select runat="server" id="slc_ID_PaisSalida_AG" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
                                    </select>        
                                    <br />
                                </div>
                                <br />
                                <div class="input_field">
                                    <br />
                                    <h4>ID ESTADO</h4>
                                    <select runat="server" id="slc_ID_Estado_AG" class="form-control" >
                                        <option value="0" selected disabled >SELECCIONAR</option>
                                    </select>
                                    <br />
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
    <script src="js/Tablas/TablaDestinos.js"></script>

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