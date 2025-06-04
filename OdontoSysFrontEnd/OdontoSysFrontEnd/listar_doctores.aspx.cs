using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysBusiness.odontologoWS;

using OdontoSysBusiness.BO;

namespace OdontoSysFrontEnd
{
    public partial class listar_doctores : System.Web.UI.Page
    {
        private OdontologoBO odontologoBO;
        private BindingList<odontologo> listaDoctores;

        public listar_doctores()
        {
            this.odontologoBO = new OdontologoBO();
            this.listaDoctores = this.odontologoBO.listarOdontologos();
        }

        public OdontologoBO OdontologoBO
        {
            get => odontologoBO;
            set => odontologoBO = value;
        }

        public BindingList<odontologo> ListaDoctores
        {
            get => listaDoctores;
            set => listaDoctores = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            dgvDoctores.DataSource = this.ListaDoctores;
            dgvDoctores.DataBind();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}