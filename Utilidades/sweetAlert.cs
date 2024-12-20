﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Transporte_3Capas.Utilidades
{
    public class sweetAlert
    {
        public static void Sweet_Alert(string title, string msg, string type, Page pg, Object obj)
        {
            string sa = "<script languaje='javascript'>" + "Swal.fire({" +
                "title: '"+ title + " '," +
                "text: '" + msg + " ' , " +
                "icon: '" + type + "'"+
                "]);" + "<script>";


            //Type hace referencia al tipo de objeto que voy a trabajar 
            Type cstype = obj.GetType();
            //clienteScriptMasserger me ayuda a insertar bloques de codigo js en tiempo real dentro de Formulacion
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, sa, sa);
        }

        public static void Sweet_Alert(string title, string msg, string type, Page pg, Object obj, string dir)
        {
            string sa = "<script languaje='javascript'>" + "Swal.fire({" +
                "title: '" + title + " '," +
                "text: '" + msg + " ' , " +
                "icon: '" + type + "'" +
                "]);.then((result)=>{" + "if(result.isComfirmed){" + "window.location.href='" + dir + ""
                + "}" + "});" + "<script>";


            //Type hace referencia al tipo de objeto que voy a trabajar 
            Type cstype = obj.GetType();
            //clienteScriptMasserger me ayuda a insertar bloques de codigo js en tiempo real dentro de Formulacion
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, sa, sa);
        }

    }
}