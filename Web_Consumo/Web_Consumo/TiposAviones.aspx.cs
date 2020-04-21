using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web_Consumo.WCF_BD;

namespace Web_Consumo
{
    public partial class TiposAviones : System.Web.UI.Page
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
            WCF.BDClient Obj_WCF_BD = new WCF.BDClient();
            string sNomSP = string.Empty;
            string sError = string.Empty;
            #endregion

            if (txtFiltro.Text == string.Empty)
            {
                dtParametros = null;
                sNomSP = "dbo.SP_Listar_TiposAviones";
            }
            else
            {
                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@filtro", "1", txtFiltro.Text.Trim());
                sNomSP = "dbo.SP_Filtrar_TiposAviones";
            }

            dtTabla = Obj_WCF_BD.ListarFiltrarDatos(sNomSP, dtParametros, ref sError);

            dgvTiposAviones.DataSource = null;
            dgvTiposAviones.DataSource = dtTabla;
            dgvTiposAviones.DataBind();

        }

        protected void btnAgr_Click(object sender, EventArgs e)
        {
            #region Variables locales
            DataTable dtTabla = new DataTable();
            DataTable dtParametros = new DataTable();
            WCF.BDClient Obj_WCF_BD = new WCF.BDClient();
            string sNomSP = string.Empty;
            string sError = string.Empty;
            #endregion

            dtParametros = Obj_WCF_BD.CrearDTParametros();
            dtParametros.Rows.Add("@IdtipoAvion", "1", txtID.Text.Trim());
            dtParametros.Rows.Add("@NombreTipoAvion", "1", txtNombre.Text.Trim());
            dtParametros.Rows.Add("@DescTipoAvion", "1", txtDesc.Text.Trim());
            dtParametros.Rows.Add("@CapacidadPasajeros", "2", txtPasaj.Text.Trim());
            dtParametros.Rows.Add("@CapacidadPeso", "4", TxtPeso.Text.Trim());
            dtParametros.Rows.Add("@IdEstado", "5", txtEstado.Text.Trim());
            sNomSP = "dbo.SP_Insertar_TiposAviones";

            Obj_WCF_BD.Ins_Mod_Eli_Datos(sNomSP, false, dtParametros, ref sError);
            
            txtFiltro.Text = string.Empty;

            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtPasaj.Text = string.Empty;
            TxtPeso.Text = string.Empty;
            txtEstado.Text = string.Empty;

            CargarDatos();

        }

        protected void btnMod_Click(object sender, EventArgs e)
        {
            #region Variables locales
            DataTable dtTabla = new DataTable();
            DataTable dtParametros = new DataTable();
            WCF.BDClient Obj_WCF_BD = new WCF.BDClient();
            string sNomSP = string.Empty;
            string sError = string.Empty;
            #endregion

            dtParametros = Obj_WCF_BD.CrearDTParametros();
            dtParametros.Rows.Add("@IdtipoAvion", "1", txtID.Text.Trim());
            dtParametros.Rows.Add("@NombreTipoAvion", "1", txtNombre.Text.Trim());
            dtParametros.Rows.Add("@DescTipoAvion", "1", txtDesc.Text.Trim());
            dtParametros.Rows.Add("@CapacidadPasajeros", "2", txtPasaj.Text.Trim());
            dtParametros.Rows.Add("@CapacidadPeso", "4", TxtPeso.Text.Trim());
            dtParametros.Rows.Add("@IdEstado", "5", txtEstado.Text.Trim());
            sNomSP = "dbo.SP_Modificar_TiposAviones";

            Obj_WCF_BD.Ins_Mod_Eli_Datos(sNomSP, false, dtParametros, ref sError);

            txtFiltro.Text = string.Empty;

            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtPasaj.Text = string.Empty;
            TxtPeso.Text = string.Empty;
            txtEstado.Text = string.Empty;

            CargarDatos();

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtPasaj.Text = string.Empty;
            TxtPeso.Text = string.Empty;
            txtEstado.Text = string.Empty;
        }

        protected void bntEliminar_Click(object sender, EventArgs e)
        {
            DataTable dtParametros = new DataTable();
            WCF.BDClient Obj_WCF_BD = new WCF.BDClient();
            string sNombSP = string.Empty;
            string sError = string.Empty;

            dtParametros = Obj_WCF_BD.CrearDTParametros();
            dtParametros.Rows.Add("@IdtipoAvion", "1", txtFiltro.Text.Trim());
            sNombSP = "dbo.SP_Borrar_TiposAviones";

            Obj_WCF_BD.Ins_Mod_Eli_Datos(sNombSP, false, dtParametros, ref sError);

            txtFiltro.Text = string.Empty;
            CargarDatos();

            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtPasaj.Text = string.Empty;
            TxtPeso.Text = string.Empty;
            txtEstado.Text = string.Empty;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            #region Variables locales
            DataTable dtTabla = new DataTable();
            DataTable dtParametros = new DataTable();
            WCF.BDClient Obj_WCF_BD = new WCF.BDClient();
            string sNomSP = string.Empty;
            string sError = string.Empty;
            #endregion

            if (txtFiltro.Text == string.Empty)
            {
                dtParametros = null;
                sNomSP = "dbo.SP_Listar_TiposAviones";
            }
            else
            {
                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@filtro", "1", txtFiltro.Text.Trim());
                sNomSP = "dbo.SP_Filtrar_TiposAviones";
            }

            dtTabla = Obj_WCF_BD.ListarFiltrarDatos(sNomSP, dtParametros, ref sError);

            dgvTiposAviones.DataSource = null;
            dgvTiposAviones.DataSource = dtTabla;
            dgvTiposAviones.DataBind();

            if (txtFiltro.Text != string.Empty)
            {
                txtID.Text = dtTabla.Rows[0].ItemArray[0].ToString();
                txtNombre.Text = dtTabla.Rows[0].ItemArray[1].ToString();
                txtDesc.Text = dtTabla.Rows[0].ItemArray[2].ToString();
                txtPasaj.Text = dtTabla.Rows[0].ItemArray[3].ToString();
                TxtPeso.Text = dtTabla.Rows[0].ItemArray[4].ToString();
                txtEstado.Text = dtTabla.Rows[0].ItemArray[5].ToString();
            }
            else
            {
                txtID.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtPasaj.Text = string.Empty;
                TxtPeso.Text = string.Empty;
                txtEstado.Text = string.Empty;
            }
                        
        }
    }
}