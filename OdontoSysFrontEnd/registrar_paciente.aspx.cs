using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysFrontEnd
{
    public partial class registrar_paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}