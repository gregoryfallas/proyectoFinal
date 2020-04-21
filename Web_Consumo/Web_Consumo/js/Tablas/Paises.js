
$(document).ready(function () {
    $("#inp_IDPAIS").val("");
    $("#inp_NOMPAIS").val("");
    $("#inp_CODPAIS").val("");
    $("#inp_CODAREA").val("");
    $("#slc_IDESTAD").val("");

    $("#Body_inp_ELIMIDPAIS").val("");
    $("#Body_inp_ELIMNOMPAIS").val("");

    $("#Body_inp_AGNOMPAIS").val("");
    $("#Body_inp_AGCODPAIS").val("");
    $("#Body_inp_AGCODAREA").val("");
    $("#Body_slc_IDESTAD_AG").val("0");
});

function EDITAR(vId, vNOM, vCOD, vAREA, vEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#Body_inp_IDPAIS").val(vId);
    $("#Body_inp_NOMPAIS").val(vNOM);
    $("#Body_inp_CODPAIS").val(vCOD);
    $("#Body_inp_CODAREA").val(vAREA);
    $("#Body_slc_IDESTAD").val(vEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_MD(vID, vNOM) {
    $("#Body_inp_ELIMIDPAIS").val(vID);
    $("#Body_inp_ELIMNOMPAIS").val(vNOM);
    $("#ModalEliminar").modal();
}

function AGREGAR_MD() {
    $("#ModalAgregar").modal();
}
