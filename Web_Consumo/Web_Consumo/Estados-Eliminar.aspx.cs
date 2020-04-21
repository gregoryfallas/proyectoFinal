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
    public partial class Estados_Eliminar : System.Web.UI.Page
    {
        //CARGA LA PAGINA CON EL PROCESO CargarDatos()
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        //TOMA EL SP DE LISTAR, FILTAR Y CARGA LA DV
        private void CargarDatos()
        {

            #region VARIABLES LOCALES

            DataTable dt = new DataTable();
            DataTable dtParametros = new DataTable();
            WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();


            string sNombSP = string.Empty;
            string sMsjError = string.Empty;

            #endregion

            lb_Nombre_Estado.Visible = false;
            txt_Nombre_Estado.Visible = false;
            Label1.Visible = Visible = false;
            txt_filtroEstados.Visible = false;
       
            if (txt_filtroEstados.Text == string.Empty)
            {//ESTE LISTA LA INFORMACION DE LA TABLA
                dtParametros = null;
                sNombSP = "SP_Listar_Estados";
            }
            else
            {   //ESTE PROCESO  REALIZA EL FILTRADO
                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@filtro", "1", txt_filtroEstados.Text.Trim());
                sNombSP = "SP_Filtrar_Estados";

            }

            dt = Obj_WCF_BD.ListarFiltrarDatos(sNombSP, dtParametros, ref sMsjError);



            DGV_DATOS.DataSource = null;
            DGV_DATOS.DataSource = dt;
            DGV_DATOS.DataBind();
        }
        protected void btn_Insertar_Click(object sender, EventArgs e)
        {

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

        protected void txt_filtroEliminarEstados_TextChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}