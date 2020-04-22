using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Consumo.WCF_BD;

namespace Web_Consumo
{
    public partial class Vuelos : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                RecargarPagina('L');
                LlenarSelectEstado();
                LlenarSelectAerolinea();
                LlenarSelectAvion();
                LlenarSelectDestino();
            }

            protected void btn_Editar_Click(object sender, EventArgs e)
            {
                ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();

                if (obj_Usuario != null)
                {
                    string sIdVuelo = inp_IDVUELO.Value.ToString();
                    string sIdDestin = slc_IDDESTIN.Value.ToString();
                    int iIdAerol = Convert.ToInt32(slc_IDAEROL.Value.ToString());
                    string sIdAvion = slc_IDAVION.Value.ToString();
                    DateTime dSalida = Convert.ToDateTime(inp_SALIDA.ToString());
                    DateTime dLlegada = Convert.ToDateTime(inp_LLEGADA.Value.ToString());
                    char cEstado = Convert.ToChar(slc_IDESTAD.Value.ToString());

                if (sIdVuelo != "" && sIdDestin != "" && iIdAerol != '0' && sIdAvion != "" &&
                    dSalida != null && dLlegada != null && cEstado != '0')
                    {

                        BDClient listarDatos = new BDClient();
                        String sMensajeError = "";
                        DataTable parametros = new DataTable();
                        DataTable ObjListar = new DataTable();

                        parametros = listarDatos.CrearDTParametros();
                        parametros.Rows.Add("@IdVuelo", "1", sIdVuelo);
                        parametros.Rows.Add("@IdDestino", "1", sIdDestin);
                        parametros.Rows.Add("@IdAerolinea", "2", iIdAerol);
                        parametros.Rows.Add("@IdAvion", "1", sIdAvion);
                        parametros.Rows.Add("@FechaHoraSalida", "5", dSalida);
                        parametros.Rows.Add("@FechaHoraLlegada", "5", dLlegada);
                        parametros.Rows.Add("@IdEstado", "3", cEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_Vuelos", false, parametros, ref sMensajeError);

                        if (sMensajeError != string.Empty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL MODIFICAR EL ITEM [" + sIdVuelo + "], ERROR: [" + sMensajeError + "]');", true);
                        }
                        else
                        {
                            RecargarPagina('L');
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
                        string sIdVuelo = inp_IDTIP_ELIM.Value.ToString();

                        if (sIdVuelo != "")
                        {

                            BDClient listarDatos = new BDClient();
                            String sMensajeError = "";
                            DataTable parametros = new DataTable();
                            DataTable ObjListar = new DataTable();

                            parametros = listarDatos.CrearDTParametros();
                            parametros.Rows.Add("@IdVuelo", "1", sIdVuelo);

                            listarDatos.Ins_Mod_Eli_Datos("SP_Borrar_Vuelos", false, parametros, ref sMensajeError);

                            if (sMensajeError != string.Empty)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL ELIMINAR EL ITEM [" + sIdVuelo + "], ERROR: [" + sMensajeError + "]');", true);
                            }
                            else
                            {
                                RecargarPagina('L');
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

            protected void btn_Filtrar_Click(object sender, EventArgs e)
            {
                string sFiltrar = inp_Filtrar.Value.ToString();

                if (sFiltrar == "")
                {
                    RecargarPagina('L');
                }
                else
                {
                    RecargarPagina('F');
                }
            }

            protected void btn_Agregar_Click(object sender, EventArgs e)
            {
                ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();

                if (obj_Usuario != null)
                {
                    string sIdVuelo = inp_IDVUELO_AG.Value.ToString();
                    string sIdDestin = slc_IDDESTIN_AG.Value.ToString();
                    int iIdAerol = Convert.ToInt32(slc_IDAEROL_AG.Value.ToString());
                    string sIdAvion = slc_IDAVION_AG.Value.ToString();
                    DateTime dSalida = Convert.ToDateTime(inp_SALIDA_AG.Value.ToString());
                    DateTime dLlegada = Convert.ToDateTime(inp_LLEGADA_AG.Value.ToString());
                    char cEstado = Convert.ToChar(slc_IDESTAD_AG.Value.ToString());

                    if (sIdVuelo != "" && sIdDestin != "" && iIdAerol != '0' && sIdAvion != "" &&
                        dSalida != null && dLlegada != null && cEstado != '0')
                    {

                        BDClient listarDatos = new BDClient();
                        String sMensajeError = "";
                        DataTable parametros = new DataTable();
                        DataTable ObjListar = new DataTable();

                        parametros = listarDatos.CrearDTParametros();
                        parametros.Rows.Add("@IdVuelo", "1", sIdVuelo);
                        parametros.Rows.Add("@IdDestino", "1", sIdDestin);
                        parametros.Rows.Add("@IdAerolinea", "2", iIdAerol);
                        parametros.Rows.Add("@IdAvion", "1", sIdAvion);
                        parametros.Rows.Add("@FechaHoraSalida", "5", dSalida);
                        parametros.Rows.Add("@FechaHoraLlegada", "5", dLlegada);
                        parametros.Rows.Add("@IdEstado", "3", cEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_Vuelos", false, parametros, ref sMensajeError);

                        if (sMensajeError != string.Empty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL AGREGAR EL NUEVO ITEM, ERROR: [" + sMensajeError + "]');", true);
                        }
                        else
                        {
                            RecargarPagina('L');
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('SE AGREGO CORRECTAMENTE');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('PARA AGREGAR UN NUEVO ITEM SE DEBEN LLENAR TODOS LOS CAMPOS');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sesión caducada, vuelve a iniciar sessión');", true);
                }



            }

            #region METODOS PRIVADOS
            private void RecargarPagina(char tipo)
            {
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

                        ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Vuelos", parametros, ref sMensajeError);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
                    }
                }
                else
                {
                    parametros = null;
                    ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Vuelos", parametros, ref sMensajeError);
                }

                if (sMensajeError != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS, ERROR: [" + sMensajeError + "]');", true);
                }
                else
                {
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
                        sb.Append("<button type=\"button\" class=\"btn btn-primary\" onclick=\"EDITAR(" + row.ItemArray[0] + ",'" + row.ItemArray[1] + "','" + row.ItemArray[2] + "')\" >");
                        sb.Append("<i class=\"fas fa-edit\"> </i></button>");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.Append("<button type=\"button\" class=\"btn btn-danger\" onclick=\"ELIMINAR_MD(" + row.ItemArray[0] + ",'" + row.ItemArray[1] + "')\" >");
                        sb.Append("<i class=\"fas fa-trash\"> </i></button>");
                        sb.Append("</td>");

                        sb.Append("</tr>");
                        count++;
                    }
                    sb.Append("</tbody>");
                    sb.Append("</table>");

                    labelTable.Text = sb.ToString();
                }

            }

            private void LlenarSelectEstado()
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
                        slc_IDESTAD.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                        slc_IDESTAD_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    }
                }
            }

            private void LlenarSelectDestino()
            {
                BDClient listarDatos = new BDClient();
                String sMensajeError = "";

                DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Destinos", null, ref sMensajeError);

                if (sMensajeError != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DE LOS SELECTS');", true);
                }
                else
                {
                    foreach (DataRow row in ObjListar.Rows)
                    {
                        //AGREGAMOS LA LISTA DE DATOS AL SELECT, EL PRIMER PARAMETRO ES EL TEXTO Y EL SEGUNDO ES EL VALUE
                        slc_IDDESTIN.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                        slc_IDDESTIN_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    }
                }
            }

            private void LlenarSelectAerolinea()
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
                        slc_IDAEROL.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                        slc_IDAEROL_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    }
                }
            }

            private void LlenarSelectAvion()
            {
                BDClient listarDatos = new BDClient();
                String sMensajeError = "";

                DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Aviones", null, ref sMensajeError);

                if (sMensajeError != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DE LOS SELECTS');", true);
                }
                else
                {
                    foreach (DataRow row in ObjListar.Rows)
                    {
                        //AGREGAMOS LA LISTA DE DATOS AL SELECT, EL PRIMER PARAMETRO ES EL TEXTO Y EL SEGUNDO ES EL VALUE
                        slc_IDAVION.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                        slc_IDAVION_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    }
                }
            }
        #endregion
    }
    }