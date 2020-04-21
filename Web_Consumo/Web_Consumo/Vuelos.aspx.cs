﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//SE IMPORTA LA LIBRERIA

namespace Web_Consumo
{
    public partial class Vuelos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
            //validadacion del calendario salida
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
          
            }

            if (!IsPostBack)
            {
                Calendar2.Visible = false;

            }
        }

        private void CargarDatos()
        {
            #region VARIABLES LOCALES

            DataTable dt = new DataTable();
            DataTable dtParametros = new DataTable();
            WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();


            string sNombSP = string.Empty;
            string sMsjError = string.Empty;
            btn_Eliminar.Visible = false;
            btn_Eliminar.Visible = false;
            #endregion

            if (txt_filtroVuelos.Text == string.Empty)
            {//ESTE LISTA LA INFORMACION DE LA TABLA
                dtParametros = null;
                sNombSP = "SP_Listar_Vuelos";
            }
            else
            {   //ESTE PROCESO  REALIZA EL FILTRADO
                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@filtro", "1", txt_filtroVuelos.Text.Trim());
                sNombSP = "SP_Filtrar_Vuelos";

            }

            dt = Obj_WCF_BD.ListarFiltrarDatos(sNombSP, dtParametros, ref sMsjError);



            DGV_DATOSV.DataSource = null;
            DGV_DATOSV.DataSource = dt;
            DGV_DATOSV.DataBind();


        }

        protected void btn_FiltrarVuelos_Click(object sender, EventArgs e)
        {/*
            if(txt_filtroVuelos.Text != "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se encontro el valor Buscado');", true);
            }
            else
            {
                CargarDatos();
            }*/
            CargarDatos();
        }

        protected void btn_Insertar_Click(object sender, EventArgs e)
        {
            #region VARIABLES LOCALES
            if (txt_ID_Vuelos != null && txt_ID_Destinos != null && txt_ID_Aerolinea != null && txt_ID_Avion != null && txt_FechaHoraSalida != null && txt_FechaHoraLlegada != null && txt_ID_Estado != null)
            {
                DataTable dtParametros = new DataTable();
                WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();

                string sNombSP = string.Empty;
                string sMsjError = string.Empty;

                #endregion
           
                dtParametros = Obj_WCF_BD.CrearDTParametros();
                dtParametros.Rows.Add("@IdVuelo", "1", txt_ID_Vuelos.Text.Trim());
                dtParametros.Rows.Add("@IdDestino", "1", txt_ID_Destinos.Text.Trim());
                dtParametros.Rows.Add("@IdAerolinea", "2", txt_ID_Aerolinea.Text.Trim());
                dtParametros.Rows.Add("@IdAvion", "1", txt_ID_Avion.Text.Trim());
                dtParametros.Rows.Add("@FechaHoraSalida", "5", txt_FechaHoraSalida.Text = DateTime.Now.ToLongTimeString());//String.Format("DD/MM/YY hh:mm:ss"));//Text.Trim()); //= ((DateTime).Rows[2]["FechaHoraSalida"]).ToString("dd/MM/yyyy H:MM:ss").ToString());
                dtParametros.Rows.Add("@FechaHoraLlegada", "5", txt_FechaHoraLlegada.Text.Trim()); //= ((DateTime)dtParametros.Rows[2]["FechaHoraLlegada"]).ToString("dd/MM/yyyy H:MM:ss").ToString());
                dtParametros.Rows.Add("@IdEstado", "3", txt_ID_Estado.Text.Trim());
                sNombSP = "SP_Insertar_Vuelos";

                Obj_WCF_BD.Ins_Mod_Eli_Datos(sNombSP, false, dtParametros, ref sMsjError);

                //ESTO MUESTRA UN ERROR EN PANTALLA AL USUARIO
                if (sMsjError != string.Empty)
                {   //DEFINE EL MENSAJE A MOSTRAR
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Se presento un error a la hora de insertar el estado.');" + sMsjError, true);
                }

                txt_filtroVuelos.Text = string.Empty;
                txt_ID_Vuelos.Text = string.Empty;
                txt_ID_Destinos.Text = string.Empty;
                txt_ID_Aerolinea.Text = string.Empty;
                txt_ID_Avion.Text = string.Empty;
                txt_FechaHoraSalida.Text = string.Empty;
                txt_FechaHoraLlegada.Text = string.Empty;
                txt_ID_Estado.Text = string.Empty;

                CargarDatos();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No pueden quedar campos vacios');", true);
            }
        }

        protected void btn_Modificar_Click(object sender, EventArgs e)
        {

            #region VARIABLES LOCALES

            DataTable dtParametros = new DataTable();
            WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();

            string sNombSP = string.Empty;
            string sMsjError = string.Empty;

            #endregion

            dtParametros = Obj_WCF_BD.CrearDTParametros();

            dtParametros.Rows.Add("@IdVuelo", "1", txt_ID_Vuelos.Text.Trim());
            dtParametros.Rows.Add("@IdDestino", "1", txt_ID_Destinos.Text.Trim());
            dtParametros.Rows.Add("@IdAerolinea", "2", txt_ID_Aerolinea.Text.Trim());
            dtParametros.Rows.Add("@IdAvion", "1", txt_ID_Avion.Text.Trim());
            dtParametros.Rows.Add("@FechaHoraSalida", "5", txt_FechaHoraSalida.Text.Trim());
            dtParametros.Rows.Add("FechaHoraLlegada", "5", txt_FechaHoraLlegada.Text.Trim());
            dtParametros.Rows.Add("@IdEstado", "3", txt_ID_Estado.Text.Trim());
            sNombSP = "SP_Modificar_Vuelos";

            Obj_WCF_BD.Ins_Mod_Eli_Datos(sNombSP, false, dtParametros, ref sMsjError);

            //ESTO MUESTRA UN ERROR EN PANTALLA AL USUARIO
            if (sMsjError != string.Empty)
            {   //DEFINE EL MENSAJE A MOSTRAR
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Se presento un error a la hora de modificar el estado.');", true);
            }

            txt_filtroVuelos.Text = string.Empty;
            txt_ID_Vuelos.Text = string.Empty;
            txt_ID_Destinos.Text = string.Empty;
            txt_ID_Aerolinea.Text = string.Empty;
            txt_ID_Avion.Text = string.Empty;
            txt_FechaHoraSalida.Text = string.Empty;
            txt_FechaHoraLlegada.Text = string.Empty;
            txt_ID_Estado.Text = string.Empty;

            CargarDatos();
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            #region VARIABLES LOCALES

            DataTable dtParametros = new DataTable();
            WCF_BD.BDClient Obj_WCF_BD = new WCF_BD.BDClient();


            string sNombSP = string.Empty;
            string sMsjError = string.Empty;
            string message = string.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            #endregion
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Para eliminar solamente ingrese el ID del Vuelo.');", true);
            txt_filtroVuelos.Visible=false;
            txt_ID_Vuelos.Text = string.Empty;
            txt_ID_Destinos.Visible = false;
            txt_ID_Aerolinea.Visible = false;
            txt_ID_Avion.Visible = false;
            txt_FechaHoraSalida.Visible = false;
            txt_FechaHoraLlegada.Visible = false;
            txt_ID_Estado.Visible = false;
            dtParametros = Obj_WCF_BD.CrearDTParametros();
            dtParametros.Rows.Add("@IdVuelo", "1", txt_ID_Vuelos.Text.Trim());
            sNombSP = "SP_Borrar_Vuelos";

            Obj_WCF_BD.Ins_Mod_Eli_Datos(sNombSP, false, dtParametros, ref sMsjError);
            //ESTO MUESTRA UN ERROR EN PANTALLA AL USUARIO
            if (sMsjError != string.Empty)
            {   //DEFINE EL MENSAJE A MOSTRAR
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Se presento un error a la hora de eliminar el estado.');", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('msg');", true);
            }

            txt_ID_Vuelos.Text = string.Empty;
            CargarDatos();
        }

        protected void btn_FiltrarVuelos_Click1(object sender, EventArgs e)
        {

        }

        protected void txt_ID_Vuelos_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if(Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txt_FechaHoraSalida.Text = Calendar1.SelectedDate.ToLongDateString();
            Calendar1.Visible = false;
            
        }

        protected void Calendar2_SelectionChanged1(object sender, EventArgs e)
        {
            txt_FechaHoraLlegada.Text = Calendar2.SelectedDate.ToLongDateString();
            Calendar2.Visible = false;

        }

    }
}