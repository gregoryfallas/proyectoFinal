using System;
using System.Data;
using DAL.Catalogo_DAL;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Consumo.WCF_BD;

namespace Web_Consumo
{
    public partial class empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarDatos('L');
            CargarSelecEstados();
            CargarSelectIdAerolinea();
            CargarSelectTipoEmpleado();

        }



        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();
            if (obj_Usuario != null)
            {
                Cls_Empleados_DAL objDal = new Cls_Empleados_DAL();

                objDal.SIdEmpleado = inp_ID_Empleado_ED.Value.ToString();
                objDal.SCedula = inp_Cedula_ED.Value.ToString();
                objDal.SNombre = inp_Nombre_ED.Value.ToString();
                objDal.SApellidos = inp_Apellidos_ED.Value.ToString();
                objDal.SDireccion = inp_Direccion_ED.Value.ToString();
                objDal.IEdad = Convert.ToInt32(inp_Edad_ED.Value.ToString());
                objDal.STelefonoCasa = inp_TelCasa_ED.Value.ToString();
                objDal.STelefonoReferencia = inp_TelReferencia_ED.Value.ToString();
                objDal.SCelular = inp_Celular_ED.Value.ToString();
                objDal.DSalario = Convert.ToDecimal(inp_Salario_ED.Value.ToString());
                objDal.IIdTipoEmpleado = Convert.ToInt32(slc_ID_Tipo_Empleado_ED.Value.ToString());
                objDal.IIdAerolinea = Convert.ToInt32(slc_ID_Aerolinea_ED.Value.ToString());
                objDal.CIdEstado = Convert.ToChar(slc_ID_Estado_ED.Value.ToString());

                if (objDal.SIdEmpleado != "" && objDal.SCedula != "" && objDal.SNombre != ""
                      && objDal.SApellidos != "" && objDal.SDireccion != "" && objDal.IEdad != 0
                      && objDal.STelefonoCasa != "" && objDal.STelefonoReferencia != "" && objDal.SCelular != ""
                      && objDal.DSalario != 0 && objDal.IIdTipoEmpleado != 0 && objDal.IIdAerolinea != 0
                      && objDal.CIdEstado != '0')
                {
                    BDClient listarDatos = new BDClient();
                    String sMensajeError = "";
                    DataTable parametros = listarDatos.CrearDTParametros();
                    DataTable ObjListar = new DataTable();

                    parametros.Rows.Add("@IdEmpleado", "1", objDal.SIdEmpleado);
                    parametros.Rows.Add("@Cedula", "1", objDal.SCedula);
                    parametros.Rows.Add("@Nombre", "1", objDal.SNombre);
                    parametros.Rows.Add("@Apellidos", "1", objDal.SApellidos);
                    parametros.Rows.Add("@Direccion", "1", objDal.SDireccion);
                    parametros.Rows.Add("@Edad", "2", objDal.IEdad);
                    parametros.Rows.Add("@Telefono_Casa", "1", objDal.STelefonoCasa);
                    parametros.Rows.Add("@Telefono_Referencia", "1", objDal.STelefonoReferencia);
                    parametros.Rows.Add("@Celular", "1", objDal.SCelular);
                    parametros.Rows.Add("@Salario", "4", objDal.DSalario);
                    parametros.Rows.Add("@IdTipoEmpleado", "2", objDal.IIdTipoEmpleado);
                    parametros.Rows.Add("@idAerolinea", "2", objDal.IIdAerolinea);
                    parametros.Rows.Add("@IdEstado", "3", objDal.CIdEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_Empleados",false, parametros, ref sMensajeError);

                    if (sMensajeError != string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL MODIFICAR EL ITEM [" + objDal.SNombre + "], ERROR: [" + sMensajeError + "]');", true);
                    }
                    else
                    {
                        CargarDatos('L');
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('SE MODIFICO CORRECTAMENTE');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('PARA MODIFICAR UN ITEM SE DEBEN LLENAR TODOS LOS CAMPOS');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
            }

            
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();

            if (obj_Usuario != null)
            {
                if (obj_Usuario.iTipoUsuario == 8)
                {
                    string sIdEmpleado = inp_ID_Empleado_Elim.Value.ToString();
                    string sNombre = inp_Nombre_Elim.Value.ToString();
                    string sApellido = inp_Apellidos_Elim.ToString();

                    if (sIdEmpleado != "" && sNombre != "" && sApellido != "")
                    {

                        BDClient listarDatos = new BDClient();
                        String sMensajeError = "";
                        DataTable parametros = new DataTable();
                        DataTable ObjListar = new DataTable();

                        parametros = listarDatos.CrearDTParametros();
                        parametros.Rows.Add("@IdEmpleado", "1", sIdEmpleado);

                        listarDatos.Ins_Mod_Eli_Datos("SP_Borrar_Empleados", false, parametros, ref sMensajeError);

                        if (sMensajeError != string.Empty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL ELIMINAR EL ITEM [" + sNombre + "], ERROR: [" + sMensajeError + "]');", true);
                        }
                        else
                        {
                            CargarDatos('L');
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('SE ELIMINO CORRECTAMENTE');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL LEER LO VALORES, FAVOR INTENTARLO NUEVAMENTE');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El usuario logueado no tiene permisos de Administrador');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
            }


            

        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();

            if (obj_Usuario != null)
            {
                Cls_Empleados_DAL objDal = new Cls_Empleados_DAL();
         

                string SIdEmpleado = inp_IdEmpleado_AG.Value.ToString();
                string SCedula = inp_Cedula_AG.Value.ToString();
                string SNombre = inp_Nombre_AG.Value.ToString();
                string SApellidos = inp_Apellidos_AG.Value.ToString();
                string SDireccion = inp_Direccion_AG.Value.ToString();
                int IEdad = Convert.ToInt32(inp_Edad_AG.Value.ToString());
                string STelefonoCasa = inp_TelCasa_AG.Value.ToString();
                string STelefonoReferencia = inp_TelRef_AG.Value.ToString();
                string SCelular = inp_Celular_AG.Value.ToString();
                decimal DSalario = Convert.ToDecimal(inp_Salario_AG.Value.ToString());
                int IIdTipoEmpleado = Convert.ToInt32(slc_IdTipoEmpleado_AG.Value.ToString());
                int IIdAerolinea = Convert.ToInt32(slc_IdAerolinea_AG.Value.ToString());
                char CIdEstado = Convert.ToChar(slc_IdEstado_AG.Value.ToString());

                if (SIdEmpleado != "" && SCedula != "" && SNombre != "" 
                    && SApellidos != "" && SDireccion != "" && IEdad != 0
                    && STelefonoCasa != "" && STelefonoReferencia != "" && SCelular != ""
                    && DSalario != 0 && IIdTipoEmpleado != 0 && IIdAerolinea != 0
                    && CIdEstado != '0')
                {

                    BDClient listarDatos = new BDClient();
                    String sMensajeError = "";
                    DataTable parametros = listarDatos.CrearDTParametros();
              

                    parametros.Rows.Add("@IdEmpleado", "1", SIdEmpleado);
                    parametros.Rows.Add("@Cedula", "1", SCedula);
                    parametros.Rows.Add("@Nombre", "1", SNombre);
                    parametros.Rows.Add("@Apellidos", "1", SApellidos);
                    parametros.Rows.Add("@Direccion", "1",SDireccion);
                    parametros.Rows.Add("@Edad", "2",IEdad);
                    parametros.Rows.Add("@Telefono_Casa", "1",STelefonoCasa);
                    parametros.Rows.Add("@Telefono_Referencia", "1", STelefonoReferencia);
                    parametros.Rows.Add("@Celular", "1", SCelular);
                    parametros.Rows.Add("@Salario", "4", DSalario);
                    parametros.Rows.Add("@IdTipoEmpleado", "2", IIdTipoEmpleado);
                    parametros.Rows.Add("@idAerolinea", "2", IIdAerolinea);
                    parametros.Rows.Add("@IdEstado", "3",CIdEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_Empleados", false, parametros, ref sMensajeError);

                    if (sMensajeError != string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL AGREGAR EL ITEM [" + objDal.SNombre + "], ERROR: [" + sMensajeError + "]');", true);
                    }
                    else
                    {
                        CargarDatos('L');
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('SE AGREGO CORRECTAMENTE');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('PARA AGREGAR UN ITEM SE DEBEN LLENAR TODOS LOS CAMPOS');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
            }


            

        }

        protected void btn_Filtrar_Click(object sender, EventArgs e)
        {
            string sFiltrar = inp_Filtrar.Value.ToString();

            if (sFiltrar == "")
            {
                CargarDatos('L');
            }
            else
            {
                CargarDatos('F');
            }
        }



        private void CargarDatos(char tipo)
        {
            //Declaracion de objetos
            BDClient listarDatos = new BDClient();
            String sMensajeError = "";
            DataTable parametros = new DataTable();
            DataTable ObjListar = new DataTable();

            if (tipo == 'F')
            {
                ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();

                if (obj_Usuario != null)
                {
                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@filtro", "1", inp_Filtrar.Value.ToString());

                    ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Empleados", parametros, ref sMensajeError);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
                }
            }
            else
            {
                parametros = null;
                ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Empleados", parametros, ref sMensajeError);
            }

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS, ERROR: [" + sMensajeError + "]');", true);
            }
            else
            {

                //Formateo de Tabla

                #region Metodo para formatear tabla

                StringBuilder sb = new StringBuilder();

                sb.Append("<table class=\"table table-striped\">");
                sb.Append("<thead>");
                sb.Append("<tr>");
                foreach (DataColumn column in ObjListar.Columns)
                {
                    sb.Append("<th>" + column.ColumnName.ToString().ToUpper() + "</th>");
                }
                sb.Append("<th>EDITAR</th>");
                sb.Append("<th>ELIMINAR</th>");
                sb.Append("</tr></thead>");
                sb.Append("<tbody>");

                byte count = 0;
                foreach (DataRow row in ObjListar.Rows)
                {
                    sb.Append("<tr id=\"row" + count + "\">");

                    foreach (DataColumn column in ObjListar.Columns)
                    {
                        sb.Append("<td>" + row[column.ColumnName].ToString() + "</td>");
                    }
                    sb.Append("<td>");
                    sb.Append("<button type=\"button\" class=\"btn btn-primary\" onclick=\"EDITAR_EMPLEADOS_MD('" + row.ItemArray[0] + "','" + row.ItemArray[1] + "','" + row.ItemArray[2] + "','" + row.ItemArray[3] + "','" + row.ItemArray[4] + "'," + row.ItemArray[5] + ",'" + row.ItemArray[6] + "','" + row.ItemArray[7] + "','" + row.ItemArray[8] + "'," + row.ItemArray[9] + "," + row.ItemArray[10] + "," + row.ItemArray[11] + ",'" + row.ItemArray[12] + "')\" >");
                    sb.Append("<i class=\"fas fa-edit\"> </i></button>");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("<button type=\"button\" class=\"btn btn-danger\" onclick=\"ELIMINAR_EMPLEADOS_MD('" + row.ItemArray[0] + "','" + row.ItemArray[2] + "','" + row.ItemArray[3] + "')\" >");
                    sb.Append("<i class=\"fas fa-trash\"> </i></button>");
                    sb.Append("</td>");

                    sb.Append("</tr>");
                    count++;
                }
                sb.Append("</tbody>");
                sb.Append("</table>");

                labelTable.Text = sb.ToString();
                #endregion




            }




            

        }

        private void CargarSelecEstados()
        {

            BDClient listarDatos = new BDClient();
            String sMensajeError = "";

            DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Estados", null, ref sMensajeError);

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DE LOS SELECTS');", true);
            }
            else
            {
                foreach (DataRow row in ObjListar.Rows)
                {
                    //AGREGAMOS LA LISTA DE DATOS AL SELECT, EL PRIMER PARAMETRO ES EL TEXTO Y EL SEGUNDO ES EL VALUE
                    slc_ID_Estado_ED.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_IdEstado_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }



        }

        private void CargarSelectTipoEmpleado()
        {

            BDClient listarDatos = new BDClient();
            String sMensajeError = "";

            DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_TiposEmpleados", null, ref sMensajeError);

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DE LOS SELECTS');", true);
            }
            else
            {
                foreach (DataRow row in ObjListar.Rows)
                {
                    //AGREGAMOS LA LISTA DE DATOS AL SELECT, EL PRIMER PARAMETRO ES EL TEXTO Y EL SEGUNDO ES EL VALUE
                    slc_ID_Tipo_Empleado_ED.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_IdTipoEmpleado_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }



        }


        private void CargarSelectIdAerolinea()
        {
            BDClient listarDatos = new BDClient();
            String sMensajeError = "";

            DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Aerolineas", null, ref sMensajeError);

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DE LOS SELECTS');", true);
            }
            else
            {
                foreach (DataRow row in ObjListar.Rows)
                {
                    //AGREGAMOS LA LISTA DE DATOS AL SELECT, EL PRIMER PARAMETRO ES EL TEXTO Y EL SEGUNDO ES EL VALUE
                    slc_ID_Aerolinea_ED.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_IdAerolinea_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }



        }

    


    }

}