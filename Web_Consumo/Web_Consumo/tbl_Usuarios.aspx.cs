using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Consumo
{
    public partial class tbl_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RecargarPagina('L');
            LlenarSelectEstado();
            LlenarSelectEmpleados();
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
            string sUSER = inp_USER_AG.Value.ToString();
            string sPASS = inp_PASS_AG.Value.ToString();
            char cESTADO = Convert.ToChar(slc_IDESTAD_AG.Value.ToString());
            string sEMPLEADO = slc_IDEMPLE_AG.Value.ToString();

            if (sUSER != "" && cESTADO != '0' && sPASS != "" && sEMPLEADO != "0")
            {
                WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                String sMensajeError = "";
                DataTable parametros = new DataTable();
                DataTable ObjListar = new DataTable();

                parametros = listarDatos.CrearDTParametros();
                parametros.Rows.Add("@Username", "1", sUSER);
                parametros.Rows.Add("@Password", "1", sPASS);
                parametros.Rows.Add("@IdEmpleado", "1", sEMPLEADO);
                parametros.Rows.Add("@IdEstado", "3", cESTADO);

                listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_Usuarios", false, parametros, ref sMensajeError);

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

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string sUSER = inp_USER_ELIM.Value.ToString();

            if (sUSER != "")
            {
                WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                String sMensajeError = "";
                DataTable parametros = new DataTable();
                DataTable ObjListar = new DataTable();

                parametros = listarDatos.CrearDTParametros();
                parametros.Rows.Add("@Username", "1", sUSER);

                listarDatos.Ins_Mod_Eli_Datos("SP_Borrar_Usuarios", false, parametros, ref sMensajeError);

                if (sMensajeError != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL ELIMINAR EL ITEM [" + sUSER + "], ERROR: [" + sMensajeError + "]');", true);
                }
                else
                {
                    RecargarPagina('L');
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('SE ELIMINO CORRECTAMENTE');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL LEER LOS VALORES, FAVOR INTENTARLO NUEVAMENTE');", true);
            }


        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            string sUSER = inp_USER_ED.Value.ToString();
            string sPASS = inp_PASS_ED.Value.ToString();
            char cESTADO = Convert.ToChar(slc_IDESTAD_ED.Value.ToString());
            string sEMPLEADO = slc_IDEMPLE_ED.Value.ToString();

            if (sUSER != "" && cESTADO != '0' && sPASS != "" && sEMPLEADO != "0")
            {
                WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                String sMensajeError = "";
                DataTable parametros = new DataTable();
                DataTable ObjListar = new DataTable();

                parametros = listarDatos.CrearDTParametros();
                parametros.Rows.Add("@Username", "1", sUSER);
                parametros.Rows.Add("@Password", "1", sPASS);
                parametros.Rows.Add("@IdEmpleado", "1", sEMPLEADO);
                parametros.Rows.Add("@IdEstado", "3", cESTADO);

                listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_Usuarios", false, parametros, ref sMensajeError);

                if (sMensajeError != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL MODIFICAR EL ITEM [" + sUSER + "], ERROR: [" + sMensajeError + "]');", true);
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

        #region METODOS PRIVADOS
        private void RecargarPagina(char tipo)
        {
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
            String sMensajeError = "";
            DataTable parametros = new DataTable();
            DataTable ObjListar = new DataTable();

            if (tipo == 'F')
            {
                parametros = listarDatos.CrearDTParametros();
                parametros.Rows.Add("@filtro", "1", inp_Filtrar.Value.ToString());

                ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Usuarios", parametros, ref sMensajeError);
            }
            else
            {
                parametros = null;
                ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Usuarios", parametros, ref sMensajeError);
            }

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS, ERROR: [" + sMensajeError + "]');", true);
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<table style=\"width: 100 %\" class=\"table table-striped\">");
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
                    sb.Append("<button type=\"button\" class=\"btn btn-primary\" onclick=\"EDITAR_USER('" + row.ItemArray[0] + "','" + row.ItemArray[1] + "','" + row.ItemArray[2] + "','" + row.ItemArray[3] + "')\" >");
                    sb.Append("<i class=\"fas fa-edit\"> </i></button>");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("<button type=\"button\" class=\"btn btn-danger\" onclick=\"ELIMINAR_USER_MD('" + row.ItemArray[0] + "')\" >");
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DEL SELECT ESTADOS');", true);
            }
            else
            {
                if (slc_IDESTAD_ED.Items.Count <= 1)
                {
                    foreach (DataRow row in ObjListar.Rows)
                    {
                        slc_IDESTAD_ED.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    }
                }

                if (slc_IDESTAD_AG.Items.Count <= 1)
                {
                    foreach (DataRow row in ObjListar.Rows)
                    {
                        slc_IDESTAD_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    }
                }
            }
        }

        private void LlenarSelectEmpleados()
        {
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
            String sMensajeError = "";

            DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Empleados", null, ref sMensajeError);

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DEL SELECT EMPLEADOS');", true);
            }
            else
            {
                if (slc_IDEMPLE_AG.Items.Count <= 1)
                {
                    foreach (DataRow row in ObjListar.Rows)
                    {
                        slc_IDEMPLE_AG.Items.Add(new ListItem(row.ItemArray[2].ToString() + " " + row.ItemArray[3].ToString(), row.ItemArray[0].ToString()));
                    }
                }

                if (slc_IDEMPLE_ED.Items.Count <= 1)
                {
                    foreach (DataRow row in ObjListar.Rows)
                    {
                        slc_IDEMPLE_ED.Items.Add(new ListItem(row.ItemArray[2].ToString() + " " + row.ItemArray[3].ToString(), row.ItemArray[0].ToString()));
                    }
                }
            }
        }

        #endregion
    }
}