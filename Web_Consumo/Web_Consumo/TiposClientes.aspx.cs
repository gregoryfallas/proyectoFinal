using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Consumo.WCF_BD;

namespace Web_Consumo
{
    public partial class TiposClientes1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            #region Variables locales
            DataTable dtTabla = new DataTable();
            DataTable dtParametros = new DataTable();
            BDClient Obj_WCF_BD = new BDClient();
            string sNomSP = string.Empty;
            string sError = string.Empty;
            #endregion

            if (txtFiltro.Text == string.Empty)
            {
                dtParametros = null;
                sNomSP = "dbo.SP_Listar_TiposClientes";
            }
            else
            {
                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@filtro", "1", txtFiltro.Text.Trim());
                sNomSP = "dbo.SP_Filtrar_TiposClientes";
            }

            dtTabla = Obj_WCF_BD.ListarFiltrarDatos(sNomSP, dtParametros, ref sError);

            dgvTiposClientes.DataSource = null;
            dgvTiposClientes.DataSource = dtTabla;
            dgvTiposClientes.DataBind();

        }


        protected void btnAgr_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"].Value != null)
            {
                #region Variables locales
                DataTable dtTabla = new DataTable();
                DataTable dtParametros = new DataTable();
                BDClient Obj_WCF_BD = new BDClient();
                string sNomSP = string.Empty;
                string sError = string.Empty;
                #endregion

                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@TipoCliente", "1", txtTipo.Text.Trim());
                dtParametros.Rows.Add("@Descripcion", "1", txtDesc.Text.Trim());
                dtParametros.Rows.Add("@IdEstado", "3", txtEstado.Text.Trim());
                sNomSP = "dbo.SP_Insertar_Tiposclientes";

                Obj_WCF_BD.Ins_Mod_Eli_Datos(sNomSP, true, dtParametros, ref sError);

                txtFiltro.Text = string.Empty;

                txtID.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtEstado.Text = string.Empty;

                CargarDatos();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msgAlerta", "alert('El Tipo de Cliente ha sido agregado exitosamente');", true);
        
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
            }

        }

        protected void btnMod_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"].Value != null)
            {
                #region Variables locales
                DataTable dtTabla = new DataTable();
                DataTable dtParametros = new DataTable();
                BDClient Obj_WCF_BD = new BDClient();
                string sNomSP = string.Empty;
                string sError = string.Empty;
                #endregion

                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@IdTipoCliente", "2", txtID.Text.Trim());
                dtParametros.Rows.Add("@TipoCliente", "1", txtTipo.Text.Trim());
                dtParametros.Rows.Add("@Descripcion", "1", txtDesc.Text.Trim());
                dtParametros.Rows.Add("@IdEstado", "3", txtEstado.Text.Trim());
                sNomSP = "dbo.SP_Modificar_TiposClientes";

                Obj_WCF_BD.Ins_Mod_Eli_Datos(sNomSP, false, dtParametros, ref sError);

                txtFiltro.Text = string.Empty;

                txtID.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtEstado.Text = string.Empty;

                CargarDatos();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msgAlerta", "alert('El Tipo de Cliente ha sido modificado');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sessión caducada, vuelve a iniciar sessión');", true);
            }

            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            txtID.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtEstado.Text = string.Empty;
        }

        protected void bntEliminar_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"].Value != null)
            {
                if (Request.Cookies["Cookie"].Value == "8")
                {
                    DataTable dtParametros = new DataTable();
                    BDClient Obj_WCF_BD = new BDClient();
                    string sNombSP = string.Empty;
                    string sError = string.Empty;

                    dtParametros = Obj_WCF_BD.CrearDTParametros();
                    dtParametros.Rows.Add("@IdTipoCliente", "2", txtFiltro.Text.Trim());
                    sNombSP = "dbo.SP_Borrar_TiposClientes";

                    Obj_WCF_BD.Ins_Mod_Eli_Datos(sNombSP, false, dtParametros, ref sError);

                    txtFiltro.Text = string.Empty;
                    CargarDatos();

                    txtID.Text = string.Empty;
                    txtTipo.Text = string.Empty;
                    txtDesc.Text = string.Empty;
                    txtEstado.Text = string.Empty;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msgAlerta", "alert('El Tipo de Cliente ha sido eliminado de forma correcta');", true);

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

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            #region Variables locales
            DataTable dtTabla = new DataTable();
            DataTable dtParametros = new DataTable();
            BDClient Obj_WCF_BD = new BDClient();
            string sNomSP = string.Empty;
            string sError = string.Empty;
            #endregion

            if (txtFiltro.Text == string.Empty)
            {
                dtParametros = null;
                sNomSP = "dbo.SP_Listar_TiposClientes";
            }
            else
            {
                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@filtro", "1", txtFiltro.Text.Trim());
                sNomSP = "dbo.SP_Filtrar_TiposClientes";
            }

            dtTabla = Obj_WCF_BD.ListarFiltrarDatos(sNomSP, dtParametros, ref sError);

            dgvTiposClientes.DataSource = null;
            dgvTiposClientes.DataSource = dtTabla;
            dgvTiposClientes.DataBind();

            if (txtFiltro.Text != string.Empty)
            {
                txtID.Text = dtTabla.Rows[0].ItemArray[0].ToString();
                txtTipo.Text = dtTabla.Rows[0].ItemArray[1].ToString();
                txtDesc.Text = dtTabla.Rows[0].ItemArray[2].ToString();
                txtEstado.Text = dtTabla.Rows[0].ItemArray[3].ToString();
            }
            else
            {
                txtID.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtEstado.Text = string.Empty;
            }
        }
    }
}