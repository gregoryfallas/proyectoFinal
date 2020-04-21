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


            if (slc_IDESTAD.ToString() != "0" && inp_NOMPAIS.Value != "" && inp_CODPAIS.Value != "" && inp_CODAREA.Value != "" && slc_IDESTAD.Value != "0")
            {
          
                BDClient listarDatos = new BDClient();

                String sMensajeError = "";
                DataTable dtParametros = new DataTable();
                DataTable ObjListar = new DataTable();

                dtParametros = listarDatos.CrearDTParametros();
                dtParametros.Rows.Add("@IdPais", "2", inp_IDPAIS.Value.Trim());
                dtParametros.Rows.Add("@NombrePais", "1", inp_NOMPAIS.Value.Trim());
                dtParametros.Rows.Add("@CodigoISOPais", "3", inp_CODPAIS.Value.Trim());
                dtParametros.Rows.Add("@CodigoAreaPais", "3", inp_CODAREA.Value.Trim());
                dtParametros.Rows.Add("@IdEstado", "3", slc_IDESTAD.Value);

                listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_TiposEmpleados",false, dtParametros, ref sMensajeError);

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
        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {

            if (inp_ELIMIDPAIS.Value != "" && inp_ELIMNOMPAIS.Value != "")
            {
                BDClient listarDatos = new BDClient();
                String sMensajeError = "";
                DataTable dtParametros = new DataTable();
                DataTable ObjListar = new DataTable();

                dtParametros = listarDatos.CrearDTParametros();
                dtParametros.Rows.Add("@IdPais", "2", inp_ELIMIDPAIS.Value.Trim());

                listarDatos.Ins_Mod_Eli_Datos("dbo.SP_Borrar_Paises",false, dtParametros, ref sMensajeError);

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
        protected void btn_Agregar_Click(object sender, EventArgs e)
        {

            if (inp_AGNOMPAIS.Value != "" && inp_AGCODPAIS.Value != "" && inp_AGCODAREA.Value != "" && slc_IDESTAD_AG.ToString() != "0")
            {
                BDClient listarDatos = new BDClient();
                String sMensajeError = "";
                DataTable dtParametros = new DataTable();
                DataTable ObjListar = new DataTable();

                dtParametros = listarDatos.CrearDTParametros();
                dtParametros.Rows.Add("@NombrePais", "1", inp_AGNOMPAIS.Value.Trim());
                dtParametros.Rows.Add("@CodigoISOPais", "3", inp_AGCODPAIS.Value.Trim());
                dtParametros.Rows.Add("@CodigoAreaPais", "3", inp_AGCODAREA.Value.Trim());
                dtParametros.Rows.Add("@IdEstado", "3", slc_IDESTAD_AG.Value);

                listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_Paises",true, dtParametros, ref sMensajeError);

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
        private void RecargarPagina(char tipo)
        {
            BDClient listarDatos = new BDClient();
            String sMensajeError = "";
            DataTable dtParametros = new DataTable();
            DataTable ObjListar = new DataTable();

            if (tipo == 'F')
            {
                dtParametros = listarDatos.CrearDTParametros();
                dtParametros.Rows.Add("@filtro", "1", inp_Filtrar.Value.ToString());

                ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Paises", dtParametros, ref sMensajeError);
            }
            else
            {
                dtParametros = null;
                ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Paises", dtParametros, ref sMensajeError);
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
            BDClient listarDatos = new BDClient();
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