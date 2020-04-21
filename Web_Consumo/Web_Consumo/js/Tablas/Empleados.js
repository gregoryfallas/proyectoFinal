
$(document).ready(function () {
    $("#inp_ID_Empleado_ED").val("");
    $("#inp_Cedula_ED").val("");
    $("#inp_Nombre_ED").val("");
    $("#inp_Apellidos_ED").val("");
    $("#inp_Direccion_ED").val("");
    $("#inp_Edad_ED").val("");
    $("#inp_TelCasa_ED").val("");
    $("#inp_TelReferencia_ED").val("");
    $("#inp_Celular_ED").val("");
    $("#inp_Salario_ED").val("");
    $("#slc_ID_Tipo_Empleado_ED").val("0");
    $("#slc_ID_Aerolinea_ED").val("");
    $("#slc_ID_Estado_ED").val("");




    //Extraer texto de campos eliminar empleado
    $("#inp_ID_Empleado_Elim").val("");
    $("#inp_Nombre_Elim").val("");
    $("##inp_Apellidos_Elim").val("");
   

    $("#inp_DESCRIP_AG").val("");
    $("#slc_IDESTAD_AG").val("0");
});

function EDITAR_EMPLEADOS_MD(vIdEmp, vCedula, vNombre, vApellidos, vDireccion, vEdad,
    vTelCasa, vTelRefe, vCelular, vSalario, vIdTipoEmp, vIdAerolinea,
    vIdEstado)
{
    //ASIGNO LOS VALORES A LOS INPUT
    $("#inp_ID_Empleado_ED").val(vIdEmp);
    $("#inp_Cedula_ED").val(vCedula);
    $("#inp_Nombre_ED").val(vNombre);
    $("#inp_Apellidos_ED").val(vApellidos);
    $("#inp_Direccion_ED").val(vDireccion);
    $("#inp_Edad_ED").val(vEdad);
    $("#inp_TelCasa_ED").val(vTelCasa);
    $("#inp_TelReferencia_ED").val(vTelRefe);
    $("#inp_Celular_ED").val(vCelular);
    $("#inp_Salario_ED").val(vSalario);
    $("#slc_ID_Tipo_Empleado_ED").val(vIdTipoEmp);
    $("#slc_ID_Aerolinea_ED").val(vIdAerolinea);
    $("#slc_ID_Estado_ED").val(vIdEstado);

    //ABRIR EL MODAL
    $("#ModalEditar").modal();
}


function ELIMINAR_EMPLEADOS_MD(vIdEmp,vNombEmp,vApellido) {
    $("#inp_ID_Empleado_Elim").val(vIdEmp);
    $("#inp_Nombre_Elim").val(vNombEmp);
    $("#inp_Apellidos_Elim").val(vApellido);

    $("#ModalEliminar").modal();
}

function AGREGAR_EMPLEADOS_MD() {
    $("#ModalAgregar").modal();
}
