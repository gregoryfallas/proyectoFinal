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
     public partial class Estados : System.Web.UI.Page
    //public partial class Estados : Page
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
            btn_EliminarEstados.Visible = false;
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

        protected void btn_FiltrarEstados_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void txt_filtroEstados_TextChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }
        //CLICK AL BOTON INSERTAR
        protected void btn_Insertar_Click(object sender, EventArgs e)
        {//
            #region VARIABLES LOCALES

            DataTable dtParametros = new DataTable();
            WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();

            string sNombSP = string.Empty;
            string sMsjError = string.Empty;

            #endregion

            dtParametros = Obj_WCF_BD.CrearDTParametros();
            dtParametros.Rows.Add("@IdEstado", "3", txt_ID_Estados.Text.Trim());
            dtParametros.Rows.Add("@Descripcion", "1", txt_Nombre_Estado.Text.Trim());
            sNombSP = "SP_Insertar_Estados";

            Obj_WCF_BD.Ins_Mod_Eli_Datos(sNombSP, false, dtParametros, ref sMsjError);

            //ESTO MUESTRA UN ERROR EN PANTALLA AL USUARIO
            if (sMsjError != string.Empty)
            {   //DEFINE EL MENSAJE A MOSTRAR
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Se presento un error a la hora de insertar el estado.');", true);
            }

            txt_filtroEstados.Text = string.Empty;
            txt_ID_Estados.Text = string.Empty;
            txt_Nombre_Estado.Text = string.Empty;

            CargarDatos();
        }
        //CLICK AL BOTON MODIFICAR
        protected void btn_Modificar_Click(object sender, EventArgs e)
        {
            #region VARIABLES LOCALES

            DataTable dtParametros = new DataTable();
            WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();

            string sNombSP = string.Empty;
            string sMsjError = string.Empty;

            #endregion

            dtParametros = Obj_WCF_BD.CrearDTParametros();
            dtParametros.Rows.Add("@IdEstado", "3", txt_ID_Estados.Text.Trim());
            dtParametros.Rows.Add("@Descripcion", "1", txt_Nombre_Estado.Text.Trim());
            sNombSP = "SP_Modificar_Estados";

            Obj_WCF_BD.Ins_Mod_Eli_Datos(sNombSP, false, dtParametros, ref sMsjError);

            //ESTO MUESTRA UN ERROR EN PANTALLA AL USUARIO
            if (sMsjError != string.Empty)
            {   //DEFINE EL MENSAJE A MOSTRAR
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Se presento un error a la hora de modificar el estado.');", true);
            }

            txt_filtroEstados.Text = string.Empty;
            txt_ID_Estados.Text = string.Empty;
            txt_Nombre_Estado.Text = string.Empty;

            CargarDatos();
        }
        //CLICK AL BOTON ELIMINAR
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

        protected void btn_Refrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}