$(document).ready(function () {
    $("#inp_IDAVION").val("");
    $("#inp_NOMAVION").val("");
    $("#inp_DESCAVION").val("");
    $("#slc_IDAerolinea").val("");
    $("#slc_IDtpAVION").val("");
    $("#slc_IDESTAD").val("");

    $("#inp_IDTIP_ELIM").val("");
    $("#inp_DESCR_ELIM").val("");

    $("#inp_IDAVION_AG").val("");
    $("#inp_NOMAVION_AG").val("");
    $("#inp_DESCAVION_AG").val("");
    $("#slc_IDAerolinea_AG").val("");
    $("#slc_IDtpAVION_AG").val("");
    $("#slc_IDESTAD_AG").val("0");
});

function EDITAR(vId, vDesc, vDescAv, vIdAero, vIdAv, vEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#inp_IDAVION").val(vId);
    $("#inp_NOMAVION").val(vDesc);
    $("#inp_DESCAVION").val(vDescAv);
    $("#slc_IDAerolinea").val(vIdAero);
    $("#slc_IDtpAVION").val(vIdAv);
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
