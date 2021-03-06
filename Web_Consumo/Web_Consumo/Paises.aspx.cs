﻿using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Consumo.WCF_BD;

namespace Web_Consumo
{
    public partial class Paises : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RecargarPagina('L');
            LlenarSelectEstado();

        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"].Value != null)
            {
                int idPais = Convert.ToInt32(inp_IDPAIS.Value.ToString());
                string nomPais = inp_NOMPAIS.Value.ToString();
                string codIsoPais = inp_CODPAIS.Value.ToString();
                string codArea = inp_CODAREA.Value.ToString();
                char cEstado = Convert.ToChar(slc_IDESTAD.Value.ToString());

                if (idPais != '0' && nomPais != "" && codIsoPais != "" && codArea != "" && cEstado != '0')
                {
                    WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                    String sMensajeError = "";
                    DataTable dtParametros = new DataTable();
                    DataTable ObjListar = new DataTable();


                    dtParametros = listarDatos.CrearDTParametros();
                    dtParametros.Rows.Add("@IdPais", "2", idPais);
                    dtParametros.Rows.Add("@NombrePais", "1", nomPais);
                    dtParametros.Rows.Add("@CodigoISOPais", "3", codIsoPais);
                    dtParametros.Rows.Add("@CodigoAreaPais", "3", codArea);
                    dtParametros.Rows.Add("@IdEstado", "3", cEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_Paises", false, dtParametros, ref sMensajeError);

                    if (sMensajeError != string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL MODIFICAR EL ITEM [" + inp_NOMPAIS.Value + "], ERROR: [" + sMensajeError + "]');", true);
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
            if (Request.Cookies["Cookie"].Value != null)
            {
                if (Request.Cookies["Cookie"].Value == "8")
                {
                    int idPais = Convert.ToInt32(inp_ELIMIDPAIS.Value.ToString());

                    if (idPais != '0')
                    {
                        WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                        String sMensajeError = "";
                        DataTable dtParametros = new DataTable();
                        DataTable ObjListar = new DataTable();

                        dtParametros = listarDatos.CrearDTParametros();
                        dtParametros.Rows.Add("@IdPais", "2", idPais);

                        listarDatos.Ins_Mod_Eli_Datos("SP_Borrar_Paises", false, dtParametros, ref sMensajeError);

                        if (sMensajeError != string.Empty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL ELIMINAR EL ITEM [" + inp_NOMPAIS.Value + "], ERROR: [" + sMensajeError + "]');", true);
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

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"].Value != null)
            {
                if (inp_AGNOMPAIS.Value != "" && inp_AGCODPAIS.Value != "" && inp_AGCODAREA.Value != "" && slc_IDESTAD_AG.ToString() != "0")
                {
                    WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                    String sMensajeError = "";
                    DataTable dtParametros = new DataTable();
                    DataTable ObjListar = new DataTable();
                    string nomPais = inp_AGNOMPAIS.Value.ToString();
                    string codIsoPais = inp_AGCODPAIS.Value.ToString();
                    string codArea = inp_AGCODAREA.Value.ToString();
                    char cEstado = Convert.ToChar(slc_IDESTAD_AG.Value.ToString());

                    dtParametros = listarDatos.CrearDTParametros();
                    dtParametros.Rows.Add("@NombrePais", "1", nomPais);
                    dtParametros.Rows.Add("@CodigoISOPais", "3", codIsoPais);
                    dtParametros.Rows.Add("@CodigoAreaPais", "3", codArea);
                    dtParametros.Rows.Add("@IdEstado", "3", cEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_Paises", true, dtParametros, ref sMensajeError);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
            }
        }

        private void RecargarPagina(char tipo)
        {
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
            String sMensajeError = "";
            DataTable dtParametros = new DataTable();
            DataTable ObjListar = new DataTable();

            if (tipo == 'F')
            {
                ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();

                if (Request.Cookies["Cookie"].Value != null)
                {
                    dtParametros = listarDatos.CrearDTParametros();
                    dtParametros.Rows.Add("@filtro", "1", inp_Filtrar.Value.ToString());

                    ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Paises", dtParametros, ref sMensajeError);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
                }
                
            }
            else
            {
                dtParametros = null;
                ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Paises", dtParametros, ref sMensajeError);
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
                    sb.Append("<button type=\"button\" class=\"btn btn-primary\" onclick=\"EDITAR(" + row.ItemArray[0] + ",'" + row.ItemArray[1] + "','" + row.ItemArray[2] + "','" + row.ItemArray[3] + "','" + row.ItemArray[4] + "')\" >");
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

        protected void btn_Filtrar_Click(object sender, EventArgs e)
        {
            string sFiltrar = inp_Filtrar.Value;

            if (sFiltrar == "")
            {
                RecargarPagina('L');
            }
            else
            {
                RecargarPagina('F');
            }
        }

        private void LlenarSelectEstado()
        {
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
            String sMensajeError = "";

            DataTable ObjListar = listarDatos.ListarFiltrarDatos("dbo.SP_Listar_Estados", null, ref sMensajeError);

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
    }
}