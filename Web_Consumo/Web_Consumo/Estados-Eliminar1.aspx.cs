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
    public partial class Estados_Eliminar1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {

            #region VARIABLES LOCALES

            DataTable dt = new DataTable();
            DataTable dtParametros = new DataTable();
            WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();


            string sNombSP = string.Empty;
            string sMsjError = string.Empty;

            #endregion
            txt_filtroVuelos.Visible = false;
            if (txt_filtroVuelos.Text == string.Empty)
            {//ESTE LISTA LA INFORMACION DE LA TABLA
                dtParametros = null;
                sNombSP = "SP_Listar_Estados";
            }
            else
            {   //ESTE PROCESO  REALIZA EL FILTRADO
                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@filtro", "1", txt_filtroVuelos.Text.Trim());
                sNombSP = "SP_Filtrar_Estados";

            }

            dt = Obj_WCF_BD.ListarFiltrarDatos(sNombSP, dtParametros, ref sMsjError);

            DGV_DATOS.DataSource = null;
            DGV_DATOS.DataSource = dt;
            DGV_DATOS.DataBind();
         
        }

        protected void btn_EliminarEstados_Click(object sender, EventArgs e)
        {
            #region VARIABLES LOCALES

            DataTable dtParametros = new DataTable();
            WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();


            string sNombSP = string.Empty;
            string sMsjError = string.Empty;
            string message = string.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            #endregion

            dtParametros = Obj_WCF_BD.CrearDTParametros();
            dtParametros.Rows.Add("@IdEstado", "0", txt_ID_Estados.Text.Trim());
            sNombSP = "SP_Borrar_Estados";

            Obj_WCF_BD.Ins_Mod_Eli_Datos(sNombSP, false, dtParametros, ref sMsjError);
            //ESTO MUESTRA UN ERROR EN PANTALLA AL USUARIO
            if (sMsjError != string.Empty)
            {   //DEFINE EL MENSAJE A MOSTRAR
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Se presento un error a la hora de eliminar el estado.');", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('msg');", true);
            }

            txt_ID_Estados.Text = string.Empty;
            CargarDatos();
        }
    }
}