using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using VO;

namespace Transporte_3Capas.Catalogos.Camiones
{
    public partial class formulariocamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar si es Postback
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Titulo.Text = "Agregar Camion";
                    subTitulo.Text = "Registro de un nuevo camion";
                    lbldisponibilidad.Visible = false;
                    chkdisponibilidad.Visible = false;
                    imgfoto.Visible = false;
                    lblurlfoto.Visible = false;
                }
                else
                {
                    //voy a Actualizar
                    //Recuperar el ID que proviene de URl
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //Obtengo el objeto original de la BD y coloco sus valores en los campos correspondiente
                    Camiones_VO _camion_origina_ = BLL_Camiones.Get_Camiones("@Id", _id)[0];
                    //validar que realmente obtenga el objeto y sus balores, de lo contrario, me regreso al formulario
                    if(_camion_origina_.ID_Camion != 0)
                    {
                        //si encontre el camion y soloco sus valores 
                        Titulo.Text = "Actualizar camion";
                        subTitulo.Text = $"Modificar los datos del camion #{_id}";
                        txtmatricula.Text = _camion_origina_.Matricula;
                        txtcapacidad.Text = _camion_origina_.Capacidad1.ToString();
                        txtkilometraje.Text = _camion_origina_.Kilometraje.ToString();
                        txttipo.Text = _camion_origina_.Tipo_Camion.ToString();
                        txtmarca.Text = _camion_origina_.Marca;
                        txtmodelo.Text = _camion_origina_.Modelo;
                        chkdisponibilidad.Checked = _camion_origina_.Disponibilidad;
                        imgfoto.ImageUrl = _camion_origina_.UrlFoto;
                    }
                    else
                    {
                        //no encontre el objeto y me voy pa' tras
                        Response.Redirect("Listado_Camiones.aspx");
                    }
                }
            }
        }

        protected void btnsubeimagen_Click(object sender, EventArgs e)
        {
            ///este metodo sirve para almacenar la imagen en el servidor y posteriormente recuperarla info desde la BD
            if(subeimagen.Value != "")
            {
                //recuperar el nombre del archivo
                string filename = Path.GetFileName(subeimagen.Value);
                //Valido la estencion del archivo
                string fileExt = Path.GetExtension(filename).ToLower();
                if((fileExt != ".jpg") && (fileExt != ".png"))
                    {
                    //Sweet Alert
                }
                else
                {
                    //verifico que existe el directorio en el servidor, para poder almacener la imagen , de lo contrario, procedo  a crearlo

                    string pathdir = Server.MapPath("~/Imagenes/Camiones/");

                    //si no existe el directorio, lo creamos
                    if(!Directory.Exists(pathdir))
                    {
                        //Creo el directorio
                        Directory.CreateDirectory(pathdir);
                    }
                    //subo la imagen a la carpeta del servidor 
                    subeimagen.PostedFile.SaveAs(pathdir + filename);
                    //recuperamos la ruta de la URL que almacenamos en la BD
                    string urlfoto = "/Imagenes/Camiones/" + filename;
                    //mostramos en pantalla la URL creada
                    this.urlfoto.Text = urlfoto;
                    //mostramos la imagen
                    imgcamion.ImageUrl = urlfoto;
                }
            }else
            {
                Utilidades.sweetAlert(Titulo, respuesta, lbltipo, this.Page, this.GetType(), "/catalogos/camiones/Listado_Camiones.aspx");
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";
            try
            {
                //crearemos el objeto que enviaremos para actualizar o insertar a las BD 
                //existen 2 formas de instanciar y llegar un objeto
                //forma 1 (por atributos)
                Camiones_VO _camion_aux = new Camiones_VO();
                _camion_aux.Matricula = txtmatricula.Text;
                _camion_aux.Marca = txtmarca.Text;
                _camion_aux.Tipo_Camion = txttipo.Text;
                _camion_aux.Modelo = txtmodelo.Text;
                _camion_aux.Capacidad1 = Convert.ToInt32(txtcapacidad.Text);
                _camion_aux.Kilometraje = Convert.ToDouble(txtkilometraje.Text);
                _camion_aux.UrlFoto = imgcamion.ImageUrl;
                _camion_aux.Disponibilidad = chkdisponibilidad.Checked;
                //forma2 ( durabte la propia instancia)

                //Camiones_VO _camion_aux2 = new Camiones_VO();
                //{
                  //  Matricula = txtmatricula.Text,
                    //    Marca = txtmarca.Text;
                //};

                //decido si voy a insertar o actualizar 
                if (Request.QueryString["Id"] == null)
                {
                    //voy a insertar 
                    _camion_aux.Disponibilidad = true;
                    salida = BLL_Camiones.Insertar_camion(_camion_aux);
                }
                else
                {
                    //Actualizar
                    _camion_aux.ID_Camion = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Camiones.Actualizar_camion(_camion_aux);
                }
                //preparamos la salida para chcar el error y mostrar el Sweet Alert
                if (salida.ToUpper().Contains("Error")) { } else { }

            }catch(Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = ex.StackTrace;
            }
            //sweet alert
        }
    }
}