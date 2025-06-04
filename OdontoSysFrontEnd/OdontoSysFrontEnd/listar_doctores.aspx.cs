using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysModel;
using OdontoSysModel.Users;
//using OdontoSysBusiness;

namespace OdontoSysFrontEnd
{
    public partial class listar_doctores : System.Web.UI.Page
    {
        //private OdontologoBO odontologoBO;
        private BindingList<Odontologo> listaDoctores;

        public listar_doctores()
        {
            //this.OdontologoBO = new OdontologoBO();
            //this.ListaDoctores = this.OdontologoBO.ListarTodos();
        }

       /* public OdontologoBO OdontologoBO
        {
            get => odontologoBO;
            set => odontologoBO = value;
        }*/

        public BindingList<Odontologo> ListaDoctores
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