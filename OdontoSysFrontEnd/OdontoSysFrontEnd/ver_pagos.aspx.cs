using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysBusiness.BO;
using OdontoSysBusiness.comprobanteWS;

namespace OdontoSysFrontEnd
{
    public partial class ver_pagos : System.Web.UI.Page
    {
        private ComprobanteBO comprobanteBO;
        private BindingList<comprobante> listaComprobantes;

        public ver_pagos()
        {
            this.ComprobanteBO = new ComprobanteBO();
            this.ListaComprobantes = this.ComprobanteBO.ListarComprobante();
        }

        public ComprobanteBO ComprobanteBO { get => comprobanteBO; set => comprobanteBO = value; }
        public BindingList<comprobante> ListaComprobantes { get => listaComprobantes; set => listaComprobantes = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            dgvPagos.DataSource = this.ListaComprobantes;
            dgvPagos.DataBind();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}