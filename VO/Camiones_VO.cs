using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Camiones_VO
    {
        //VO = View Object
        ////Representacion de una tabla a nivel de codigo de C#
        private int _ID_Camion;
        private string _Matricula;
        private string _Tipo_Camion;
        private string _Marca;
        private string _Modelo;
        private int _Capacidad;
        private double _Kilometraje;
        private string _UrlFoto;
        private bool _Disponibilidad;
        //para encapsular: seleccionar todos los atributos dar ctrl y . (punto) y dar clic a la opcion "encapsular campos y utilizar  

        //Encapsulamiento
        public int ID_Camion { get => _ID_Camion; set => _ID_Camion = value; }
        public string Matricula { get => _Matricula; set => _Matricula = value; }
        public string Tipo_Camion { get => _Tipo_Camion; set => _Tipo_Camion = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public int Capacidad1 { get => _Capacidad; set => _Capacidad = value; }
        public double Kilometraje { get => _Kilometraje; set => _Kilometraje = value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto = value; }
        public bool Disponibilidad1 { get => _Disponibilidad; set => _Disponibilidad = value; }


        //constructores
        ////por defecto
        public Camiones_VO()
        {
            _ID_Camion = 0;
            _Matricula = "";
            _Tipo_Camion= string.Empty;
            _Marca ="";
            _Modelo="";
            _Capacidad=0;
            _Kilometraje=0;
            _UrlFoto="";
            _Disponibilidad=true;
        }

        ///con parametros
        public Camiones_VO(DataRow dr)
        {
            _ID_Camion = int.Parse(dr[""].ToString());
            _Matricula = dr["Matricula"].ToString();
            _Tipo_Camion = dr["Tipo_Camion"].ToString();
            _Marca = dr["Marca"].ToString();
            _Modelo = dr["Modelo"].ToString();
            _Capacidad = int.Parse(dr["Capacidad"].ToString());
            _Kilometraje = double.Parse(dr["Kilometraje"].ToString());
            _UrlFoto = dr["UrlFoto"].ToString();
            _Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
        }
        
    }
}
