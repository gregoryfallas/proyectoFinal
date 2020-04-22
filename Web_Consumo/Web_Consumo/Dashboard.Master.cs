using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Consumo
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Cookie"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btn_btnCerrarSesion_ServerClick(object sender, EventArgs e)
        {
            Request.Cookies["Cookie"].Value = null;
            Request.Cookies["Cookie"].Expires = DateTime.Now;
            Response.Redirect("index.aspx");
        }
    }
}