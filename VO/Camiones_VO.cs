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
        private int _Id_camion;
        private string _matricula;
        private string _tipo_camion;
        private string _marca;
        private string _modelo;
        private int _capacidad;
        private double _kilometraje;
        private string _urlFoto;
        private bool _Disponibilidad;
        //para encapsular: seleccionar todos los atributos dar ctrl y . (punto) y dar clic a la opcion "encapsular campos y utilizar  

        //Encapsulamiento
        public int ID_Camion { get => _Id_camion; set => _Id_camion = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Tipo_Camion { get =>_tipo_camion; set => _tipo_camion = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public int Capacidad1 { get => _capacidad; set => _capacidad = value; }
        public double Kilometraje { get => _kilometraje; set => _kilometraje = value; }
        public string UrlFoto { get => _urlFoto; set => _urlFoto = value; }
        public bool Disponibilidad { get => _Disponibilidad; set => _Disponibilidad = value; }


        //constructores
        ////por defecto
        public Camiones_VO()
        {
            _Id_camion = 0;
            _matricula = "";
            _tipo_camion= string.Empty;
            _matricula ="";
            _modelo="";
            _capacidad=0;
            _kilometraje=0;
            _urlFoto="";
            _Disponibilidad=true;
        }

        ///con parametros
        public Camiones_VO(DataRow dr)
        {
            _Id_camion = int.Parse(dr["Id_camion"].ToString());
            _matricula= dr["matricula"].ToString();
            _tipo_camion = dr["tipo_camion"].ToString();
            _marca = dr["marca"].ToString();
            _modelo = dr["modelo"].ToString();
            _capacidad = int.Parse(dr["capacidad"].ToString());
            _kilometraje = float.Parse(dr["kilometraje"].ToString());
            _urlFoto = dr["UrlFoto"].ToString();
            _Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
        }
        
    }
}
