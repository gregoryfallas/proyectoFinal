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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RecargarPagina('L');
            LlenarSelectEstado();
            LlenarSelectIdTipoCliente();
        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();

            if (obj_Usuario != null)
            {
                string sId = inp_Idcliente.Value.ToString();
                string sCed = inp_Cedula.Value.ToString();
                string sNom = inp_Nombre.Value.ToString();
                string sApe = inp_Apellidos.Value.ToString();
                string sTel = inp_Telefono.Value.ToString();
                int iTip = Convert.ToInt16(slc_IdTipoCliente.Value.ToString());
                char cEstado = Convert.ToChar(slc_Idestado.Value.ToString());

                if (sId != "" && sCed != "" && sNom != "" && sApe != "" && sTel != "" && iTip != 0 && cEstado != '0')
                {
                    WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                    String sMensajeError = "";
                    DataTable parametros = new DataTable();
                    DataTable ObjListar = new DataTable();

                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@IdCliente", "2", sId);
                    parametros.Rows.Add("@Cedula", "1", sCed);
                    parametros.Rows.Add("@Nombre", "1", sNom);
                    parametros.Rows.Add("@Apellidos", "1", sApe);
                    parametros.Rows.Add("@Telefono", "1", sTel);
                    parametros.Rows.Add("@IdTipoCliente", "2", iTip);
                    parametros.Rows.Add("@IdEstado", "3", cEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Modificar_Clientes", false, parametros, ref sMensajeError);

                    if (sMensajeError != string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL MODIFICAR EL ITEM [" + sCed + "], ERROR: [" + sMensajeError + "]');", true);
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
                    string sId = inp_Idcliente_ELIM.Value.ToString();
                    string sCed = inp_Cedula_ELIM.Value.ToString();

                    if (sId != "" && sCed != "")
                    {
                        WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                        String sMensajeError = "";
                        DataTable parametros = new DataTable();
                        DataTable ObjListar = new DataTable();

                        parametros = listarDatos.CrearDTParametros();
                        parametros.Rows.Add("@IdCliente", "2", sId);

                        listarDatos.Ins_Mod_Eli_Datos("SP_Borrar_Clientes", false, parametros, ref sMensajeError);

                        if (sMensajeError != string.Empty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL ELIMINAR EL ITEM [" + sCed + "], ERROR: [" + sMensajeError + "]');", true);
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
                string sId = inp_Idcliente_AG.Value.ToString();
                string sCed = inp_Cedula_AG.Value.ToString();
                string sNom = inp_Nombre_AG.Value.ToString();
                string sApe = inp_Apellidos_AG.Value.ToString();
                string sTel = inp_Telefono_AG.Value.ToString();
                int iTip = Convert.ToInt32(slc_IdTipoCliente_AG.Value.ToString());
                char cEstado = Convert.ToChar(slc_Idestado_AG.Value.ToString());

                if (sId != "" && sCed != "" && sNom != "" && sApe != "" && sTel != "" && iTip != '0' && cEstado != '0')
                {
                    WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
                    String sMensajeError = "";
                    DataTable parametros = new DataTable();
                    DataTable ObjListar = new DataTable();

                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@IdCliente", "1", sId);
                    parametros.Rows.Add("@Cedula", "1", sCed);
                    parametros.Rows.Add("@Nombre", "1", sNom);
                    parametros.Rows.Add("@Apellidos", "1", sApe);
                    parametros.Rows.Add("@Telefono", "1", sTel);
                    parametros.Rows.Add("@IdTipoCliente", "2", iTip);
                    parametros.Rows.Add("@IdEstado", "3", cEstado);

                    listarDatos.Ins_Mod_Eli_Datos("SP_Insertar_Clientes", true, parametros, ref sMensajeError);

                    if (sMensajeError == string.Empty)
                    {
                        RecargarPagina('L');
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL AGREGAR EL NUEVO CLIENTE, ERROR: [" + sMensajeError + "]');", true);
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
                ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL obj_Usuario = new ClassLibrary2.Catalogo_DAL.Cls_UsuarioLogueado_DAL();

                if (obj_Usuario != null)
                {
                    parametros = listarDatos.CrearDTParametros();
                    parametros.Rows.Add("@filtro", "1", inp_Filtrar.Value.ToString());

                    ObjListar = listarDatos.ListarFiltrarDatos("SP_Filtrar_Clientes", parametros, ref sMensajeError);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
                }
                
            }
            else
            {
                parametros = null;
                ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_Clientes", parametros, ref sMensajeError);
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
                    slc_Idestado.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_Idestado_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }
        }

        private void LlenarSelectIdTipoCliente()
        {
            WCF_BD.BDClient listarDatos = new WCF_BD.BDClient();
            String sMensajeError = "";

            DataTable ObjListar = listarDatos.ListarFiltrarDatos("SP_Listar_TiposClientes", null, ref sMensajeError);

            if (sMensajeError != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OCURRIO UN ERROR AL CARGAR LOS DATOS DE LOS SELECTS');", true);
            }
            else
            {
                foreach (DataRow row in ObjListar.Rows)
                {
                    //AGREGAMOS LA LISTA DE DATOS AL SELECT, EL PRIMER PARAMETRO ES EL TEXTO Y EL SEGUNDO ES EL VALUE
                    slc_IdTipoCliente.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                    slc_IdTipoCliente_AG.Items.Add(new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString()));
                }
            }
        }
        #endregion
    }
}