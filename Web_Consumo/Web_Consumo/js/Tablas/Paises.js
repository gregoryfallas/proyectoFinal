
$(document).ready(function () {
    $("#inp_IDPAIS").val("");
    $("#inp_NOMPAIS").val("");
    $("#inp_CODPAIS").val("");
    $("#inp_CODAREA").val("");
    $("#slc_IDESTAD").val("");

    $("#inp_ELIMIDPAIS").val("");
    $("#inp_ELIMNOMPAIS").val("");

    $("#inp_AGNOMPAIS").val("");
    $("#inp_AGCODPAIS").val("");
    $("#inp_AGCODAREA").val("");
    $("#slc_IDESTAD_AG").val("0");
});

function EDITAR(vId, vNOM, vCOD, vAREA, vEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#inp_IDPAIS").val(vId);
    $("#inp_NOMPAIS").val(vNOM);
    $("#inp_CODPAIS").val(vCOD);
    $("#inp_CODAREA").val(vAREA);
    $("#slc_IDESTAD").val(vEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_MD(vID, vNOM) {
    $("#inp_ELIMIDPAIS").val(vID);
    $("#inp_ELIMNOMPAIS").val(vNOM);
    $("#ModalEliminar").modal();
}

function AGREGAR_MD() {
    $("#ModalAgregar").modal();
}
