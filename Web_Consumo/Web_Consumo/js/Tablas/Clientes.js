$(document).ready(function () {
    $("#inp_Idcliente").val("");
    $("#inp_Cedula").val("");
    $("#inp_Nombre").val("");
    $("#inp_Apellidos").val("");
    $("#inp_Telefono").val("");
    $("#slc_IdTipoCliente").val("");
    $("#slc_Idestado").val("");

    $("#body_inp_Idcliente_ELIM").val("");
    $("#body_inp_Cedula_ELIM").val("");
    
    
    $("#body_inp_Idcliente_AG").val("");
    $("#body_inp_Cedula_AG").val("");
    $("#body_inp_Nombre_AG").val("");
    $("#body_inp_Apellidos_AG").val("");
    $("#body_inp_Telefono_AG").val("");
    $("#body_slc_IdTipoCliente_AG").val("");
    $("#slc_Idestado_AG").val("0");
});

function EDITAR(vId, vCd, vNom, vApe, vTel, vIdTipo, vEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#Body_inp_Idcliente").val(vId);
    $("#Body_inp_Cedula").val(vCd);
    $("#Body_inp_Nombre").val(vNom);
    $("#Body_inp_Apellidos").val(vApe);
    $("#Body_inp_Telefono").val(vTel);
    $("#Body_slc_IdTipoCliente").val(vIdTipo);
    $("#Body_slc_Idestado").val(vEstado);
    

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_MD(vId, vCd) {
    $("#Body_inp_Idcliente_ELIM").val(vId);
    $("#Body_inp_Cedula_ELIM").val(vCd);
    $("#ModalEliminar").modal();
}

function AGREGAR_MD() {
    $("#ModalAgregar").modal();
}