
$(document).ready(function () {
    $("#Body_inp_IDTIPOEMP").val("");
    $("#Body_inp_DESCRIP").val("");
    $("#Body_slc_IDESTAD").val("");

    $("#Body_inp_IDTIP_ELIM").val("");
    $("#Body_inp_DESCR_ELIM").val("");

    $("#Body_inp_DESCRIP_AG").val("");
    $("#Body_slc_IDESTAD_AG").val("0");


    $("#Body_inp_USER_ELIM").val("");
    $("#Body_slc_IDEMPLE_ED").val("0");
    $("#Body_slc_IDESTAD_ED").val("0");
});

function EDITAR(vId, vDesc, vEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#Body_inp_IDTIPOEMP").val(vId);
    $("#Body_inp_DESCRIP").val(vDesc);
    $("#Body_slc_IDESTAD").val(vEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_MD(vId, vDesc) {
    $("#Body_inp_IDTIP_ELIM").val(vId);
    $("#Body_inp_DESCR_ELIM").val(vDesc);
    $("#ModalEliminar").modal();
}

function AGREGAR_MD() {
    $("#ModalAgregar").modal();
}


function ELIMINAR_USER_MD(user) {
    $("#Body_inp_USER_ELIM").val(user);
    $("#ModalEliminar").modal();
}

function EDITAR_USER(user, pass, emp, est) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#Body_inp_USER_ED").val(user);
    $("#Body_inp_PASS_ED").val(pass);
    $("#Body_slc_IDEMPLE_ED").val(emp);
    $("#Body_slc_IDESTAD_ED").val(est);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}