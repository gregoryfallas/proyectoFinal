
$(document).ready(function () {
    $("#inp_IDTIPOEMP").val("");
    $("#inp_DESCRIP").val("");
    $("#slc_IDESTAD").val("");

    $("#inp_IDTIP_ELIM").val("");
    $("#inp_DESCR_ELIM").val("");

    $("#inp_DESCRIP_AG").val("");
    $("#slc_IDESTAD_AG").val("0");


    $("#inp_USER_ELIM").val("");
    $("#slc_IDEMPLE_ED").val("0");
    $("#slc_IDESTAD_ED").val("0");
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


function ELIMINAR_USER_MD(user) {
    $("#inp_USER_ELIM").val(user);
    $("#ModalEliminar").modal();
}

function EDITAR_USER(user, pass, emp, est) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#inp_USER_ED").val(user);
    $("#inp_PASS_ED").val(pass);
    $("#slc_IDEMPLE_ED").val(emp);
    $("#slc_IDESTAD_ED").val(est);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}