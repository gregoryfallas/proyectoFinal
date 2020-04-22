using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Consumo.WCF_BD;

namespace Web_Consumo
{
    public partial class tbl_Destinos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos('L');
            CargarIdAerolinea_slc();
            CargarId_Estado_slc();
            CargarId_Paises_slc();
        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"].Value != null)
            {
                string sIdDestino = inp_ID_Destino_ED.Value.ToString();
                int iId_Aerolinea = Convert.ToInt16(slc_ID_Aerolinea_ED.Value.ToString());
                string sNombreDestino = inp_NombDestino_ED.Value.ToString();
                int iId_PaisSalida = Convert.ToInt16(slc_ID_PaisSalida_ED.Value.ToString());
                int iId_PaisLlegada = Convert.ToInt16(slc_ID_PaisLlegada_ED.Value.ToString());
                char cEstado = Convert.ToChar(slc_ID_Estado_ED.Value.ToString());

                if (sIdDestino != "" && iId_Aerolinea != 0 && sNombreDestino
                    != "" && iId_PaisSalida != 0 && iId_PaisLlegada != 0 && cEstado != '0')
                {

                    BDClient listarDatos = new BDClient();
                    String sMensajeError = "";
                    DataTable parametros = new DataTable();
                    DataTable ObjListar = new DataTable();

                    parametros = listarDatos.CrearDTParametros();

                    parametros.Rows.Add("@IdDestino", "1", sIdDestino);
                    parametros.Rows.Add("@IdAerolinea", "2", iId_Aerolinea);
                    parametros.Rows.Add("@NomDestino", "1", sNombreDestino);
                    parametros.Rows.Add("@PaisSalida", "2", iId_PaisSalida);
                    parametros.Rows.Add("@PaisLlegada", "2", iId_PaisLlegada);
                    parametros.Rows.Add("@IdEstado", "3", cEstado);


                    listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_Destinos", false, parametros, ref sMensajeError);

                    if (sMensajeError != string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL MODIFICAR EL ITEM [" + sNombreDestino + "], ERROR: [" + sMensajeError + "]');", true);
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

        protected void btn_EliminarRegist_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"].Value != null)
            {
                if (Request.Cookies["Cookie"].Value == "8")
                {
                    string sId_Destino = inp_ID_Dest_Elim.Value.ToString();
                    string sNombreDestino = inp_Nomb_Dest_Elim.Value.ToString();

                    if (sId_Destino != "" && sNombreDestino != "")
                    {

                        BDClient listarDatos = new BDClient();
                        String sMensajeError = "";
                        DataTable parametros = new DataTable();
                        DataTable ObjListar = new DataTable();

                        parametros = listarDatos.CrearDTParametros();
                        parametros.Rows.Add("@IdDestino", "1", sId_Destino);

                        listarDatos.Ins_Mod_Eli_Datos("SP_Borrar_Destinos", false, parametros, ref sMensajeError);

                        if (sMensajeError != string.Empty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL ELIMINAR EL ITEM [" + sNombreDestino + "], ERROR: [" + sMensajeError + "]');", true);
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
            if (Request.Cookies["Cookie"].Value != null)
            {
                string sId_Destino = inp_IdDestino_AG.Value.ToString();
                int iIdAerolinea = Convert.ToUInt16(slc_ID_Aerolinea_AG.Value.ToString());
                string sNombDestino = inp_NombreDestino_AG.Value.ToString();
                int iPaisSalida = Convert.ToUInt16(slc_ID_PaisSalida_AG.Value.ToString());
                int iPaisLLegada = Convert.ToUInt16(slc_ID_PaisLlegada_AG.Value.ToString());
                char cIDEstado = Convert.ToChar(slc_ID_Estado_AG.Value);

                if (sId_Destino != "" && iIdAerolinea != 0 && sNombDestino
                    != ""&&iPaisSalida!=0 && iPaisLLegada !=0 && cIDEstado !=' ')
                {
                    BDClient listarDatos = new BDClient();
                    String sMensajeError = "";
                    DataTable parametros = new DataTable();
                    DataTable ObjListar = new DataTable();

                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@IdDestino", "1", sId_Destino);
                    parametros.Rows.Add("@IdAerolinea", "2", iIdAerolinea);
                    parametros.Rows.Add("@NomDestino", "1", sNombDestino);
                    parametros.Rows.Add("@PaisSalida", "2", iPaisSalida);
                    parametros.Rows.Add("@PaisLlegada", "2", iPaisLLegada);
                    parametros.Rows.Add("@IdEstado", "3", cIDEstado);

                        listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_Destinos",true, parametros, ref sMensajeError);

                    if (sMensajeError != string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL AGREGAR EL NUEVO ITEM, ERROR: [" + sMensajeError + "]');", true);
                    }
                    else
                    {
                        CargarDatos('L');
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


        #region Metodos privados

        private void CargarDatos(char tipo)
        {
            //Declaracion de objetos

            BDClient listarDatos = new BDClient();
            String sMensajeError = "";
            DataTable parametros = new DataTable();
            DataTable ObjListar = new DataTable();

            if (tipo == 'F')
            {
                if (Request.Cookies["Cookie"].Value != null)
                {
                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@filtro", "1", inp_Filtrar.Value.ToString());

                    ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Destinos", parametros, ref sMensajeError);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
                }
            }
            else
            {
                parametros = null;
                ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Destinos", parametros, ref sMensajeError);
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
                    sb.Append("<button type=\"button\" class=\"btn btn-primary\" onclick=\"EDITAR_DEST_MD(" + row.ItemArray[0] + ",'" + row.ItemArray[1] + "','" + row.ItemArray[2] + "', '" + row.ItemArray[3] + "','" + row.ItemArray[4] + "','" + row.ItemArray[5] + "')\" >");
                    sb.Append("<i class=\"fas fa-edit\"> </i></button>");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("<button type=\"button\" class=\"btn btn-danger\" onclick=\"ELIMINAR_DESTI_MD(" + row.ItemArray[0] + ",'" + row.ItemArray[2] + "')\" >");
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


        private void  CargarIdAerolinea_slc()
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
                    slc_ID_Aerolinea_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }


        }


        private void CargarId_Paises_slc()
        {
            BDClient listarDatos = new BDClient();
            String sMensajeError = "";

            DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Paises", null, ref sMensajeError);

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DE LOS SELECTS');", true);
            }
            else
            {
                foreach (DataRow row in ObjListar.Rows)
                {
                    //AGREGAMOS LA LISTA DE DATOS AL SELECT, EL PRIMER PARAMETRO ES EL TEXTO Y EL SEGUNDO ES EL VALUE
                    slc_ID_PaisLlegada_ED.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_ID_PaisLlegada_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_ID_PaisSalida_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_ID_PaisSalida_ED.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }


        }

        private void CargarId_Estado_slc()
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
                    slc_ID_Estado_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                   
                }
            }


        }


        #endregion
    }


}