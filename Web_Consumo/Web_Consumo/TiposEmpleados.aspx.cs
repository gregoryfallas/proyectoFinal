﻿using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Consumo.WCF_BD;


namespace Web_Consumo
{
    public partial class TiposEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RecargarPagina('L');
            LlenarSelectEstado();
        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            string sId = inp_IDTIPOEMP.Value.ToString();
            string sDesc = inp_DESCRIP.Value.ToString();
            char cEstado = Convert.ToChar(slc_IDESTAD.Value.ToString());

            if (sId != "" && sDesc != "" && cEstado != '0')
            {

                BDClient listarDatos = new BDClient();
                String sMensajeError = "";
                DataTable parametros = new DataTable();
                DataTable ObjListar = new DataTable();

                parametros = listarDatos.CrearDTParametros();
                parametros.Rows.Add("@IdTipoEmpleado", "2", sId);
                parametros.Rows.Add("@DescTipo", "1", sDesc);
                parametros.Rows.Add("@IdEstado", "3", cEstado);

                listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_TiposEmpleados" ,false, parametros, ref sMensajeError);

                if (sMensajeError != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL MODIFICAR EL ITEM ["+ sDesc + "], ERROR: [" + sMensajeError + "]');", true);
                }
                else
                {
                    RecargarPagina('L');
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('SE MODIFICO CORRECTAMENTE');", true);
                }
            }
            else{
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('PARA MODIFICAR UN ITEM SE DEBEN LLENAR TODOS LOS CAMPOS');", true);
            }
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string idTipoEmp = inp_IDTIP_ELIM.Value.ToString();
            string sDesc = inp_DESCR_ELIM.Value.ToString();

            if (idTipoEmp != "" && sDesc != "")
            {

                BDClient listarDatos = new BDClient();
                String sMensajeError = "";
                DataTable parametros = new DataTable();
                DataTable ObjListar = new DataTable();

                parametros = listarDatos.CrearDTParametros();
                parametros.Rows.Add("@IdTipoEmpleado", "2", idTipoEmp);

                listarDatos.Ins_Mod_Eli_Datos("SP_Borrar_TiposEmpleados", false, parametros, ref sMensajeError);

                if (sMensajeError != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL ELIMINAR EL ITEM [" + sDesc + "], ERROR: [" + sMensajeError + "]');", true);
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

        protected void btn_Filtrar_Click(object sender, EventArgs e)
        {            
            string sFiltrar = inp_Filtrar.Value.ToString();

            if (sFiltrar == "")
            {
                RecargarPagina('L');
            }
            else{
                RecargarPagina('F');
            }
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            string sDesc = inp_DESCRIP_AG.Value.ToString();
            char cEstado = Convert.ToChar(slc_IDESTAD_AG.Value.ToString());

            if (sDesc != "" && cEstado != '0')
            {
                BDClient listarDatos = new BDClient();
                String sMensajeError = "";
                DataTable parametros = new DataTable();
                DataTable ObjListar = new DataTable();

                parametros = listarDatos.CrearDTParametros();
                parametros.Rows.Add("@DescTipo", "1", sDesc);
                parametros.Rows.Add("@IdEstado", "3", cEstado);

                listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_TiposEmpleados",true, parametros, ref sMensajeError);

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

        #region METODOS PRIVADOS
        private void RecargarPagina(char tipo)
        {
            BDClient listarDatos = new BDClient();
            String sMensajeError = "";
            DataTable parametros = new DataTable();
            DataTable ObjListar = new DataTable();

            if (tipo == 'F')
            {
                parametros = listarDatos.CrearDTParametros();
                parametros.Rows.Add("@filtro", "1" ,inp_Filtrar.Value.ToString());

                ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_TiposEmpleados", parametros, ref sMensajeError);
            }
            else
            {
                parametros = null;
                ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_TiposEmpleados", parametros, ref sMensajeError);
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
        #endregion
    }
}