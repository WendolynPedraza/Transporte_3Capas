using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_acceso_datos
{
    public class configuracion


    {
        //Cadena de conexion 
        //data sourse=nombre del servidor del DB
        //localhost
        //.
        // Nombre de mi estancia
        //Inital Catalogo= nombre de BD
        //=false (Credenciales de acceso)
        //se habilitan los campos de:
        //User=;
        //password=;
        static string _CadenaConexion = @"Data Source= DESKTOP-GGDL61L; 
                                                Initial Catalog = transportes; 
                                                Integrated Security=true;";

        //Encapsulamiento
        public static string CadenaConexion
        {
            get
            {
                return _CadenaConexion;
            }
        }
    }
}
