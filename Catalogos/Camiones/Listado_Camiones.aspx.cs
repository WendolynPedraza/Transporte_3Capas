﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Transporte_3Capas.Catalogos.Camiones
{
    public partial class Listado_Camiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Utilizamos la variable "IsPostBack"´para control la primera vez que carga
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }
        public void cargarGrid()
        {
            //cargar la informacion desde la BLL al GV
            GVCamiones.DataSource = BLL_Camiones.Get_Camiones();
            //mostramos todos los resultados de la informacipon
            GVCamiones.DataBind();
        }
        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formulariocamiones.aspx");
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Defeno si eñ comandp (el clic que se detecta ) tiene la propiedad "select"
            if(e.CommandName=="Select")
            {
                //recupero el indice eb funcion de aquel elemento que haya denotado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //Recupero el ID en funcion del indice que recuperamos anteriormente
                string id = GVCamiones.DataKeys[varIndex].Values["ID_Camion"].ToString();
                //redirecciono el formulario de edicion pasando como parametro 
                Response.Redirect($"formulariocamiones.aspx?Id={id}");
            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}