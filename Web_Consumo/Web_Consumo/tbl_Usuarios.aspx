<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="tbl_Usuarios.aspx.cs" Inherits="Web_Consumo.tbl_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/Tablas/General.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
       <div class="destination_details_info">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-8 col-md-9">
                         <h2 class="tituloH">USUARIOS</h2>
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
                            <h4 class="modal-title">USUARIO</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body" style="width:100%">
                            <div>
                                <div class="input_field">
                                    <h4>USERNAME</h4>
                                     <input runat="server" id="inp_USER_ED" class="form-control style_disabled" type="text" placeholder="USERNAME" maxlength="15">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>PASSWORD</h4>
                                    <input runat="server" id="inp_PASS_ED" class="form-control" type="text" placeholder="PASSWORD" maxlength="8">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>ID EMPLEADO</h4>
                                    <select runat="server" id="slc_IDEMPLE_ED" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
                                    </select>
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>ID ESTADO</h4>
                                    <select runat="server" id="slc_IDESTAD_ED" class="form-control" >
                                        <option value="0" selected disabled>SELECCIONAR</option>
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
                            <h4 class="modal-title">ELIMINAR USUARIO</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>DESEAS ELIMINAR ESTE USUARIO?</h4>
                                    <div class="row">
                                        <div class="col-12">
                                            <input runat="server" id="inp_USER_ELIM" class="form-control style_disabled" type="text">
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
                            <h4 class="modal-title">AGREGAR USUARIO</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div>
                                <div class="input_field">
                                    <h4>USERNAME</h4>
                                     <input runat="server" id="inp_USER_AG" class="form-control" type="text" placeholder="USERNAME" maxlength="15">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>PASSWORD</h4>
                                    <input runat="server" id="inp_PASS_AG" class="form-control" type="text" placeholder="PASSWORD" maxlength="8">
                                </div>
                                <br />
                                <div class="input_field">
                                    <h4>ID EMPLEADO</h4>
                                    <select runat="server" id="slc_IDEMPLE_AG" class="form-control" >
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
</asp:Content>
