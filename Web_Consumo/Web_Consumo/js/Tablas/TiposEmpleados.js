$(document).ready(function () {
    $("#inp_IDTIPOEMP").val("");
    $("#inp_DESCRIP").val("");
    $("#slc_IDESTAD").val("");

    $("#inp_IDTIP_ELIM").val("");
    $("#inp_DESCR_ELIM").val("");

    $("#inp_DESCRIP_AG").val("");
    $("#slc_IDESTAD_AG").val("0");
});

function EDITAR(vId, vDesc, vEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#inp_IDTIPOEMP").val(vId);
    $("#inp_DESCRIP").val(vDesc);
    $("#slc_IDESTAD").val(vEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_MD(vId, vDesc) {
    $("#inp_IDTIP_ELIM").val(vId);
    $("#inp_DESCR_ELIM").val(vDesc);
    $("#ModalEliminar").modal();
}

function AGREGAR_MD() {
    $("#ModalAgregar").modal();
}