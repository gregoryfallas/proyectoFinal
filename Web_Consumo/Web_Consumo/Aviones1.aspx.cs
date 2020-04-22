using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Web_Consumo
{
    public partial class Aviones1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RecargarPagina('L');
            LlenarSelectEstado();
            LlenarSelectEstadoIdAerolinea();
            LlenarSelectEstadoIdTpAvion();
        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"].Value != null)
            {
                string sId = inp_IDAVION.Value.ToString();
                string sNomAvion = inp_NOMAVION.Value.ToString();
                string sDescAvion = inp_DESCAVION.Value.ToString();
                int iIdAerolinea = Convert.ToInt32(slc_IDAerolinea.Value.ToString());
                string iIdTpAvion = slc_IDtpAVION.Value.ToString();
                char cEstado = Convert.ToChar(slc_IDESTAD.Value.ToString());

                //if (sId != "" && sNomAvion != "" && cEstado != '0')
                if (sId != "" && sNomAvion != "" && sDescAvion != "" && iIdAerolinea != '0' && iIdTpAvion != "" && cEstado != '0')
                {
                    WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                    String sMensajeError = "";
                    DataTable parametros = new DataTable();
                    DataTable ObjListar = new DataTable();

                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@IdAvion", "1", sId);
                    parametros.Rows.Add("@NomAvion", "1", sNomAvion);
                    parametros.Rows.Add("@DescAvion", "1", sDescAvion);
                    parametros.Rows.Add("@IdAerolinea", "2", iIdAerolinea);
                    parametros.Rows.Add("@IdTipoAvion", "1", iIdTpAvion);
                    parametros.Rows.Add("@IdEstado", "3", cEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_Aviones", false, parametros, ref sMensajeError);

                    if (sMensajeError != string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL MODIFICAR EL ITEM [" + sNomAvion + "], ERROR: [" + sMensajeError + "]');", true);
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
                    string idTipoEmp = inp_IDTIP_ELIM.Value.ToString();
                    string sDesc = inp_DESCR_ELIM.Value.ToString();

                    if (idTipoEmp != "" && sDesc != "")
                    {
                        WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                        String sMensajeError = "";
                        DataTable parametros = new DataTable();
                        DataTable ObjListar = new DataTable();

                        parametros = listarDatos.CrearDTParametros();
                        parametros.Rows.Add("IdAvion", "1", idTipoEmp);

                        listarDatos.Ins_Mod_Eli_Datos("SP_Borrar_Aviones", false, parametros, ref sMensajeError);

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
            if (Request.Cookies["Cookie"].Value != null)
            {
                string sId = inp_IDAVION_AG.Value.ToString();
                string sNomAvion = inp_NOMAVION_AG.Value.ToString();
                string sDescAvion = inp_DESCAVION_AG.Value.ToString();
                int iIdAerolinea = Convert.ToInt32(slc_IDAerolinea_AG.Value.ToString());
                string iIdTpAvion = slc_IDtpAVION_AG.Value.ToString();
                char cEstado = Convert.ToChar(slc_IDESTAD_AG.Value.ToString());

                //if (sNomAvion != "" && cEstado != '0')
                if (sId != "" && sNomAvion != "" && sDescAvion != "" && iIdAerolinea != '0' && iIdTpAvion != "" && cEstado != '0')
                {
                    WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                    String sMensajeError = "";
                    DataTable parametros = new DataTable();
                    DataTable ObjListar = new DataTable();

                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@IdAvion", "1", sId);
                    parametros.Rows.Add("@NomAvion", "1", sNomAvion);
                    parametros.Rows.Add("@DescAvion", "1", sDescAvion);
                    parametros.Rows.Add("@IdAerolinea", "2", iIdAerolinea);
                    parametros.Rows.Add("@IdTipoAvion", "1", iIdTpAvion);
                    parametros.Rows.Add("@IdEstado", "3", cEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_Aviones", false, parametros, ref sMensajeError);

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

        #region METODOS PRIVADOS
        private void RecargarPagina(char tipo)
        {
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
            String sMensajeError = "";
            DataTable parametros = new DataTable();
            DataTable ObjListar = new DataTable();

            if (tipo == 'F')
            {
                if (Request.Cookies["Cookie"].Value != null)
                {
                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@filtro", "0", inp_Filtrar.Value.ToString());

                    ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Aviones", parametros, ref sMensajeError);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
                }
                
            }
            else
            {
                parametros = null;
                ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Aviones", parametros, ref sMensajeError);
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
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
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

        private void LlenarSelectEstadoIdAerolinea()
        {
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
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

                    slc_IDAerolinea.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_IDAerolinea_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }
        }

        private void LlenarSelectEstadoIdTpAvion()
        {
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
            String sMensajeError = "";

            DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_TiposAviones", null, ref sMensajeError);

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DE LOS SELECTS');", true);
            }
            else
            {
                foreach (DataRow row in ObjListar.Rows)
                {
                    //AGREGAMOS LA LISTA DE DATOS AL SELECT, EL PRIMER PARAMETRO ES EL TEXTO Y EL SEGUNDO ES EL VALUE

                    slc_IDtpAVION.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_IDtpAVION_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }
        }

    }
}