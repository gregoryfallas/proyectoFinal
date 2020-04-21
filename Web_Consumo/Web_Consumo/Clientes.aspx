<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Web_Consumo.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <link href="css/style.css" rel="stylesheet" />
    <script src="js/Tablas/Clientes.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    
        <div class="destination_details_info">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-8 col-md-9">
                         <h2 class="tituloH"> CLIENTES</h2>
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
                            <h4 class="modal-title">CLIENTES</h4>
                            <button  type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>ID CLIENTE</h4>
                                    <input runat="server" id="inp_Idcliente" class="form-control style_disabled" type="text" placeholder="ID CLIENTE">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>CEDULA</h4>
                                    <input runat="server" id="inp_Cedula" class="form-control" type="text" placeholder="CEDULA">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>NOMBRE</h4>
                                    <input pattern="[A-Za-z ]{1,85}" title="Solo debe ingresar letras" runat="server" id="inp_Nombre" class="form-control" type="text" placeholder="NOMBRE">
                                    
                                </div>
                                <div class="input_field">
                                    <h4>APELLIDOS</h4>
                                    <input pattern="[A-Za-z ]{1,85}" title="Solo debe ingresar letras" runat="server" id="inp_Apellidos" class="form-control" type="text" placeholder="APELLIDOs">
                                    
                                </div>
                                <div class="input_field">
                                    <h4>TELEFONO</h4>
                                    <input  runat="server" id="inp_Telefono" class="form-control" type="text" placeholder="TELEFONO">
                                   
                                </div>
                                <div class="input_field">
                                    <h4>ID TIPO CLIENTE</h4>
                                    <select runat="server" id="slc_IdTipoCliente" class="form-control" >
                                    </select>
                                </div>

                                <div class="input_field">
                                    <h4>ID ESTADO</h4>
                                    <select runat="server" id="slc_Idestado" class="form-control" >
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
                            <h4 class="modal-title">ELIMINAR CLIENTE</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>DESEAS ELIMINAR ESTE CLIENTE?</h4>
                                    <div class="row">
                                        <div class="col-3">
                                            <input runat="server" id="inp_Idcliente_ELIM" class="form-control style_disabled" type="text">
                                        </div>
                                        <div class="col-9">
                                            <input runat="server" id="inp_Cedula_ELIM" class="form-control style_disabled" type="text">
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
                            <h4 class="modal-title">AGREGAR CLIENTE</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>IDCLIENTE</h4>
                                    <input runat="server" id="inp_Idcliente_AG" class="form-control style" type="text" placeholder="ID CLIENTE">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>CEDULA</h4>
                                    <input runat="server" id="inp_Cedula_AG" class="form-control" type="text" placeholder="CEDULA">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>NOMBRE</h4>
                                    <input pattern="[A-Za-z ]{1,85}" title="Solo debe ingresar letras" runat="server" id="inp_Nombre_AG" class="form-control" type="text" placeholder="NOMBRE">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>APELLIDO</h4>
                                    <input pattern="[A-Za-z ]{1,85}" title="Solo debe ingresar letras" runat="server" id="inp_Apellidos_AG" class="form-control" type="text" placeholder="APELLIDOS">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>TELEFONO</h4>
                                    <input runat="server" id="inp_Telefono_AG" class="form-control" type="text" placeholder="TELEFONO">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>ID TIPO CLIENTE</h4>
                                    <select runat="server" id="slc_IdTipoCliente_AG" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
                                    </select>
                                <br />
                                <div class="input_field">
                                    <h4>ID ESTADO</h4>
                                    <select runat="server" id="slc_Idestado_AG" class="form-control" >
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
        </div>
</asp:Content>
