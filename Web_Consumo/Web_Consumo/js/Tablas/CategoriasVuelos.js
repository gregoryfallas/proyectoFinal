$(document).ready(function () {
    $("#inp_CATVUELO").val("");
    $("#inp_DESCRIP").val("");
    $("#slc_IDESTAD").val("");

    $("#Body_inp_CATVUELO_ELIM").val("");
    $("#Body_inp_DESCR_ELIM").val("");

    $("#Body_inp_DESCRIP_AG").val("");
    $("#Body_slc_IDESTAD_AG").val("0");
});

function EDITAR(vId, vDesc, vEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#Body_inp_CATVUELO").val(vId);
    $("#Body_inp_DESCRIP").val(vDesc);
    $("#Body_slc_IDESTAD").val(vEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_MD(vId, vDesc) {
    $("#Body_inp_CATVUELO_ELIM").val(vId);
    $("#Body_inp_DESCR_ELIM").val(vDesc);
    $("#ModalEliminar").modal();
}

function AGREGAR_MD() {
    $("#ModalAgregar").modal();
}