
$(document).ready(function () {
    $("#Body_inp_ID_Empleado_ED").val("");
    $("#Body_inp_Cedula_ED").val("");
    $("#Body_inp_Nombre_ED").val("");
    $("#Body_inp_Apellidos_ED").val("");
    $("#Body_inp_Direccion_ED").val("");
    $("#Body_inp_Edad_ED").val("");
    $("#Body_inp_TelCasa_ED").val("");
    $("#Body_inp_TelReferencia_ED").val("");
    $("#Body_inp_Celular_ED").val("");
    $("#Body_inp_Salario_ED").val("");
    $("#Body_slc_ID_Tipo_Empleado_ED").val("0");
    $("#Body_slc_ID_Aerolinea_ED").val("");
    $("#Body_slc_ID_Estado_ED").val("");




    //Extraer texto de campos eliminar empleado
    $("#Body_inp_ID_Empleado_Elim").val("");
    $("#Body_inp_Nombre_Elim").val("");
    $("#Body_inp_Apellidos_Elim").val("");
   

    $("#inp_DESCRIP_AG").val("");
    $("#slc_IDESTAD_AG").val("0");
});

function EDITAR_EMPLEADOS_MD(vIdEmp, vCedula, vNombre, vApellidos, vDireccion, vEdad,
    vTelCasa, vTelRefe, vCelular, vSalario, vIdTipoEmp, vIdAerolinea,
    vIdEstado)
{
    //ASIGNO LOS VALORES A LOS INPUT
    $("#Body_inp_ID_Empleado_ED").val(vIdEmp);
    $("#Body_inp_Cedula_ED").val(vCedula);
    $("#Body_inp_Nombre_ED").val(vNombre);
    $("#Body_inp_Apellidos_ED").val(vApellidos);
    $("#Body_inp_Direccion_ED").val(vDireccion);
    $("#Body_inp_Edad_ED").val(vEdad);
    $("#Body_inp_TelCasa_ED").val(vTelCasa);
    $("#Body_inp_TelReferencia_ED").val(vTelRefe);
    $("#Body_inp_Celular_ED").val(vCelular);
    $("#Body_inp_Salario_ED").val(vSalario);
    $("#Body_slc_ID_Tipo_Empleado_ED").val(vIdTipoEmp);
    $("#Body_slc_ID_Aerolinea_ED").val(vIdAerolinea);
    $("#Body_slc_ID_Estado_ED").val(vIdEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_EMPLEADOS_MD(vIdEmp,vNombEmp,vApellido) {
    $("#Body_inp_ID_Empleado_Elim").val(vIdEmp);
    $("#Body_inp_Nombre_Elim").val(vNombEmp);
    $("#Body_inp_Apellidos_Elim").val(vApellido);

    $("#ModalEliminar").modal();
}

function AGREGAR_EMPLEADOS_MD() {
    $("#ModalAgregar").modal();
}
