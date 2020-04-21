
$(document).ready(function () {
    $("#Body_inp_ID_Destino_ED").val("");
    $("#Body_slc_ID_Aerolinea_ED").val("0");
    $("#Body_inp_NombDestino_ED").val("");
    $("#Body_slc_ID_PaisSalida_ED").val("0");
    $("#Body_slc_ID_PaisLlegada_ED").val("0");
    $("#Body_slc_ID_Estado_ED").val("0");
 
 




    $("#inp_DESCRIP_AG").val("");
    $("#slc_IDESTAD_AG").val("0");



    //Se extrae el texto de lo campos Eliminar en el Modal
    $("#Body_inp_ID_Dest_Elim").val("");
    $("#Body_inp_Nomb_Dest_Elim").val("");


});

function EDITAR_DEST_MD(vIdDestino, vIdAerolinea, vNomDestino, vPaisSalida,
                        vPaisLlegada,vIdEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#Body_inp_ID_Destino_ED").val(vIdDestino);
    $("#Body_slc_ID_Aerolinea_ED").val(vIdAerolinea);
    $("#Body_inp_NombDestino_ED").val(vNomDestino);
    $("#Body_slc_ID_PaisSalida_ED").val(vPaisSalida);
    $("#Body_slc_ID_PaisLlegada_ED").val(vPaisLlegada);
    $("#Body_slc_ID_Estado_ED").val(vIdEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_DESTI_MD(vId_Destino, vNombDestino) {
    $("#Body_inp_ID_Dest_Elim").val(vId_Destino);
    $("#Body_inp_Nomb_Dest_Elim").val(vNombDestino);
    $("#ModalEliminar").modal();
}

function AGREGAR_DESTINOS_MD() {
    $("#ModalAgregar").modal();
}
