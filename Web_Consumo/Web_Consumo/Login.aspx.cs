﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_Consumo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

            //ESTE PROCESO  REALIZA EL FILTRADO
            dtParametros = Obj_WCF_BD.CrearDTParametros();
            dtParametros.Rows.Add("@username", "1", txt_Username.Text.Trim());
            dtParametros.Rows.Add("@password", "1", txt_Password.Text.Trim());
            sNombSP = "SP_Filtrar_Login";

            dt = Obj_WCF_BD.ListarFiltrarDatos(sNombSP, dtParametros, ref sMsjError);

            if(dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Usuario o contraseña Incorrectas');", true);
            }
            else
            {
                Response.Redirect("index.aspx");
            }
           
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}