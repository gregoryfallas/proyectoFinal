
$(document).ready(function () {
    $("#inp_ID_Destino_ED").val("");
    $("#slc_ID_Aerolinea_ED").val("0");
    $("#inp_NombDestino_ED").val("");
    $("#slc_ID_PaisSalida_ED").val("0");
    $("#slc_ID_PaisLlegada_ED").val("0");
    $("#slc_ID_Estado_ED").val("0");
 
 




    $("#inp_DESCRIP_AG").val("");
    $("#slc_IDESTAD_AG").val("0");



    //Se extrae el texto de lo campos Eliminar en el Modal
    $("#inp_ID_Dest_Elim").val("");
    $("#inp_Nomb_Dest_Elim").val("");


});

function EDITAR_DEST_MD(vIdDestino, vIdAerolinea, vNomDestino, vPaisSalida,
                        vPaisLlegada,vIdEstado) {
    //ASIGNO LOS VALORES A LOS INPUT
    $("#inp_ID_Destino_ED").val(vIdDestino);
    $("#slc_ID_Aerolinea_ED").val(vIdAerolinea);
    $("#inp_NombDestino_ED").val(vNomDestino);
    $("#slc_ID_PaisSalida_ED").val(vPaisSalida);
    $("#slc_ID_PaisLlegada_ED").val(vPaisLlegada);
    $("#slc_ID_Estado_ED").val(vIdEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_DESTI_MD(vId_Destino, vNombDestino) {
    $("#inp_ID_Dest_Elim").val(vId_Destino);
    $("#inp_Nomb_Dest_Elim").val(vNombDestino);
    $("#ModalEliminar").modal();
}

function AGREGAR_DESTINOS_MD() {
    $("#ModalAgregar").modal();
}
