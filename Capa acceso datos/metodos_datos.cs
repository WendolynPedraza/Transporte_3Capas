using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_acceso_datos
{
    internal class metodos_datos
    {
        //metodod para ejecutar un dataset
        //Utilizado para ejecutar una consulta SQL que devuelve un conjunto de datos
        //que púede contener una o varias tablas con filas y columnas.
        public static DataSet execute_DataSet(string sp, params object[] parametros)
        {
            //insertamos un DS (DataSet) => Objeto ADO (Access Data Objet)
            DataSet ds = new DataSet();
            //obtenemo la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos una conexion => SqlConnection Objeto de ADO
            SqlConnection SQLcon = new SqlConnection(conn);
            try
            {
                //verificamos si la conexipon esta abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLcon.Close();
                }
                else
                {
                    //comando para SQL (sp, conexion )=> sql Commad objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    //defino que el comando sera como una SP (Stored Procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //pasamos el sp
                    cmd.CommandText = sp;

                    //validar si existen y estan completos los parametros
                    //si es diferente de null  y su residuo es diferente de 0
                    //parametros = {clave: valor}
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("los parametros deben estar en pares (clave:valor)");

                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for(int i = 0; i<parametros.Length; i= i +2){
                            //sqlparameter => objeto ADO (Access Data Objet)
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }
                        //abrimos la conexion
                        SQLcon.Open();
                        //EJECUTARMOS EL COMANDO
                        //SQLDATAADAPTER => OBJETO DE ADO
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //LLAMAMOS EL DS
                        adapter.Fill(ds);
                        //creamos la conexion
                        SQLcon.Close();
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //verificamos si la conexipon esta abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLcon.Close();
                }
            }
        }

        //Metodo que ejecute un escalar 
        //ejecuta una consulta sql que devuelve un solo valor o una sola columna de datos
        //retorna el valor de la primera columna y la primera fila del conjunto de resultado
        public static int execute_Scalar(string sp, params object[] parametros)
        {
            //insertamos un entero
            int id =0;
            //obtenemo la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos una conexion => SqlConnection Objeto de ADO
            SqlConnection SQLcon = new SqlConnection(conn);
            try
            {
                //verificamos si la conexipon esta abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLcon.Close();
                }
                else
                {
                    //comando para SQL (sp, conexion )=> sql Commad objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    //defino que el comando sera como una SP (Stored Procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //pasamos el sp
                    cmd.CommandText = sp;

                    //validar si existen y estan completos los parametros
                    //si es diferente de null  y su residuo es diferente de 0
                    //parametros = {clave: valor}
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("los parametros deben estar en pares (clave:valor)");

                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i=i+2)
                        {
                            //sqlparameter => objeto ADO (Access Data Objet)
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }
                        //abrimos la conexion
                        SQLcon.Open();
                        //EJECUTARMOS EL COMANDO de forma que reciba un escalar 
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                        //cerramos la conexion
                        SQLcon.Close();
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //verificamos si la conexipon esta abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLcon.Close();
                }
            }
        }

        //metodo que ejecuta un NonQuery
        //Utilizado para ejecutar consultas SQL que no devuelven un conjunto de resultados.
        //como sentencias Insert, update o delete 
        //retornar un valor que representa el numero de filas afectadad por la operacion.
        //(por ejemplo , el numero de filas insertadas, actualizadas o eliminadas.
        public static int execute_nonQuery(string sp, params object[] parametros)
        {
            //insertamos un entero
            int id = 0;
            //obtenemo la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos una conexion => SqlConnection Objeto de ADO
            SqlConnection SQLcon = new SqlConnection(conn);
            try
            {
                //verificamos si la conexipon esta abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLcon.Close();
                }
                else
                {
                    //comando para SQL (sp, conexion )=> sql Commad objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    //defino que el comando sera como una SP (Stored Procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //pasamos el sp
                    cmd.CommandText = sp;

                    //validar si existen y estan completos los parametros
                    //si es diferente de null  y su residuo es diferente de 0
                    //parametros = {clave: valor}
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("los parametros deben estar en pares (clave:valor)");

                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i=i+2)
                        {
                            //sqlparameter => objeto ADO (Access Data Objet)
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }
                        //abrimos la conexion
                        SQLcon.Open();
                        //EJECUTARMOS EL COMANDO sin esperar retorno
                        cmd.ExecuteNonQuery();
                        id = 1;
                        //cerramos la conexion
                        SQLcon.Close();
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //verificamos si la conexipon esta abierta
                if (SQLcon.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    SQLcon.Close();
                }
            }
        }
    }
}
