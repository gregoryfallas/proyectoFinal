using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Aeropuerto.DB;
//Librerías para conexión a la BD y para uso de DataSet/DataTables
using System.Data;
using System.Data.SqlClient;
//Libería para uso del ConfigurationManager (se debe agregar una referencia en la capa BLL)
using System.Configuration;

namespace BLL_Aeropuerto.DB
{
    public class cls_DB_BLL
    {
        #region Variables
        //Inicia un objeto de tipo de variable de dases de datos
        SqlDbType DB_TYPE = SqlDbType.VarChar;
        #endregion

        /// <summary>
        /// Método para listar y filtrar valores de la DB
        /// </summary>
        /// <param name="Obj_DB_DAL"></param>
        public void Execute_DataAdapter(ref cls_DB_DAL Obj_DB_DAL)
        {
            #region TRY
            try
            {
                //Crea la conexión
                //Obtiene el string de configuration desde el XML AppConfig
                Obj_DB_DAL.sCadenaCNX = ConfigurationManager.ConnectionStrings["Win_Aut"].ToString(); 
                //Convierte el string a un Objeto adecuado para el motor de la base de datos
                Obj_DB_DAL.Obj_SQL_CNX = new SqlConnection(Obj_DB_DAL.sCadenaCNX);

                //Abre la conexión
                if (Obj_DB_DAL.Obj_SQL_CNX != null)
                {
                    if (Obj_DB_DAL.Obj_SQL_CNX.State == ConnectionState.Closed)
                    {
                        Obj_DB_DAL.Obj_SQL_CNX.Open();
                    }
                    //Se crea el Objeto Data Adapter. IMPORTANTE: No se ha ejecutado aun.
                    Obj_DB_DAL.Obj_SQL_DAP = new SqlDataAdapter(Obj_DB_DAL.sNombre_SP, Obj_DB_DAL.Obj_SQL_CNX);

                    //Se le agrega seguridad al Objeto Data Adapter
                    //Esto no permite que se le meta texto, lo que le da seguridad para contra "SQL Injection attacks"
                    //Solamente aceptará un Stored Procedure
                    Obj_DB_DAL.Obj_SQL_DAP.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //Verifica si el Objeto viene con algún parámetro
                    if (Obj_DB_DAL.dtParametros != null)
                    {
                        //Si lo tiene, entonces revisa si hay más de 1 parámetro
                        if (Obj_DB_DAL.dtParametros.Rows.Count >= 1)
                        {
                            //Se recorre el DataTable de parámetros
                            foreach (DataRow DR in Obj_DB_DAL.dtParametros.Rows)
                            {
                                //Determina el tipo de variable dependiendo del número recibido
                                #region DEFINICIÓN DE TIPO DE DATO DE ACUERDO A COLUMNA 2
                                switch (DR[1].ToString())
                                {
                                    case "1":
                                        DB_TYPE = SqlDbType.VarChar;
                                        break;
                                    case "2":
                                        DB_TYPE = SqlDbType.Int;
                                        break;
                                    case "3":
                                        DB_TYPE = SqlDbType.Char;
                                        break;
                                    case "4":
                                        DB_TYPE = SqlDbType.Decimal;
                                        break;
                                    case "5":
                                        DB_TYPE = SqlDbType.DateTime;
                                        break;
                                    default:
                                        DB_TYPE = SqlDbType.NVarChar;
                                        break;
                                }
                                #endregion
                                /*
                                 Prepara el SQLDataAdapter dándole una instrucción SQL constituída de parámetros:
                                 (Nombre -DR[0]-, Tipo -DB_TYPE-, Valor -DR[2]-)
                                 */
                                Obj_DB_DAL.Obj_SQL_DAP.SelectCommand.Parameters.Add(DR[0].ToString(), DB_TYPE).Value = DR[2].ToString();
                            }
                        }
                    }

                    //Inicializa el DataSet
                    Obj_DB_DAL.dsDatos = new DataSet();
                    //Ejecuta el Data Adapter
                    //Data Adapter necesita el nombre del Stored procedure y el nombre de la tabla
                    //Aquí es donde se trae la información de la DB al código del programa
                    Obj_DB_DAL.Obj_SQL_DAP.Fill(Obj_DB_DAL.dsDatos);

                    //Limpia el mensaje de error
                    Obj_DB_DAL.sMensError = string.Empty;
                }
                else
                {
                    Obj_DB_DAL.sMensError = "Error en DB.BLL.Execute_DataAdapter() debido a que el Obj_SQL_CNX es null";
                }

            }
            #endregion

            #region CATCH
            catch (Exception ex)
            {
                //Captura error del Sistema y lo guarda en el string
                Obj_DB_DAL.sMensError = "Error en DB.BLL.Execute_DataAdapter(): " + ex.Message.ToString();
            }
            #endregion

            #region FINALLY
            finally //Instrucción que SIEMPRE se ejecutará para cerrar y eliminar la conexión (best practice)
            {
                if (Obj_DB_DAL.Obj_SQL_CNX != null)
                {
                    if (Obj_DB_DAL.Obj_SQL_CNX.State == ConnectionState.Open)
                    {
                        Obj_DB_DAL.Obj_SQL_CNX.Close();
                    }
                    Obj_DB_DAL.Obj_SQL_CNX.Dispose();
                }

            }
            #endregion
        }

        /// <summary>
        /// Método para ejecutar el Insert, Update y Delete con llave primaria (SIN IDENTITY)
        /// </summary>
        /// <param name="Obj_DB_DAL"></param>
        public void Execute_NonQuery(ref cls_DB_DAL Obj_DB_DAL)
        {
            #region TRY
            try
            {
                //Crea la conexión
                //Obtiene el string de configuration desde el XML AppConfig
                Obj_DB_DAL.sCadenaCNX = ConfigurationManager.ConnectionStrings["Sql_aut"].ToString();
                //Convierte el string a un Objeto adecuado para el motor de la base de datos
                Obj_DB_DAL.Obj_SQL_CNX = new SqlConnection(Obj_DB_DAL.sCadenaCNX);

                //Abre la conexión
                if (Obj_DB_DAL.Obj_SQL_CNX != null)
                {
                    if (Obj_DB_DAL.Obj_SQL_CNX.State == ConnectionState.Closed)
                    {
                        Obj_DB_DAL.Obj_SQL_CNX.Open();
                    }

                    //Se crea el Objeto COMMAND. NOTA: No se ha ejecutado aun.
                    Obj_DB_DAL.Obj_SQL_CMD = new SqlCommand(Obj_DB_DAL.sNombre_SP, Obj_DB_DAL.Obj_SQL_CNX);

                    //Se le agrega seguridad al Objeto Data Adapter
                    //Esto no permite que se le meta texto, lo que le da seguridad para contra SQL Injection attacks
                    //Solamente aceptará un Stored Procedure
                    Obj_DB_DAL.Obj_SQL_CMD.CommandType = CommandType.StoredProcedure;

                    //Verifica si el Objeto viene con un parámetro
                    if (Obj_DB_DAL.dtParametros != null)
                    {
                        //Si lo tiene, entonces revisa si más de 1 parámetro
                        if (Obj_DB_DAL.dtParametros.Rows.Count >= 1)
                        {
                            //Se recorre el DataTable de parámetros
                            foreach (DataRow DR in Obj_DB_DAL.dtParametros.Rows)
                            {
                                //Determina el tipo de variable dependiendo del número recibido
                                #region DEFINICIÓN DE TIPO DE DATO DE ACUERDO A COLUMNA 2
                                switch (DR[1].ToString())
                                {
                                    case "1":
                                        DB_TYPE = SqlDbType.VarChar;
                                        break;
                                    case "2":
                                        DB_TYPE = SqlDbType.Int;
                                        break;
                                    case "3":
                                        DB_TYPE = SqlDbType.Char;
                                        break;
                                    case "4":
                                        DB_TYPE = SqlDbType.Decimal;
                                        break;
                                    case "5":
                                        DB_TYPE = SqlDbType.DateTime;
                                        break;
                                    default:
                                        DB_TYPE = SqlDbType.NVarChar;
                                        break;
                                }
                                #endregion
                                /*
                                 Prepara el SQLDataAdapter dándole una instrucción SQL constituída de parámetros:
                                 (Nombre -DR[0]-, Tipo -DB_TYPE-, Valor -DR[2]-)
                                 */
                                Obj_DB_DAL.Obj_SQL_CMD.Parameters.Add(DR[0].ToString(), DB_TYPE).Value = DR[2].ToString();
                            }
                        }
                    }

                    //Ejecuta el Non Query
                    Obj_DB_DAL.Obj_SQL_CMD.ExecuteNonQuery();

                    //Limpia el mensaje de error
                    Obj_DB_DAL.sMensError = string.Empty;
                }
                else
                {
                    Obj_DB_DAL.sMensError = "Error en DB.BLL.Execute_NonQuery() debido a que el Obj_SQL_CNX es null";
                }
            }
            #endregion

            #region CATCH
            catch (Exception ex)
            {
                //Captura error del Sistema y lo guarda en el string
                Obj_DB_DAL.sMensError = "Error en DB.BLL.Execute_NonQuery(): " + ex.Message.ToString();
            }
            #endregion

            #region FINALLY
            finally //Instrucción que SIEMPRE se ejecutará: Cerrar la conexión (best practice)
            {
                if (Obj_DB_DAL.Obj_SQL_CNX != null)
                {
                    if (Obj_DB_DAL.Obj_SQL_CNX.State == ConnectionState.Open)
                    {
                        Obj_DB_DAL.Obj_SQL_CNX.Close();
                    }
                    Obj_DB_DAL.Obj_SQL_CNX.Dispose();
                }

            }
            #endregion
        }

        /// <summary>
        /// Método para ejecutar el Insert, Update y Delete con llave primaria (CON IDENTITY)
        /// </summary>
        /// <param name="Obj_DB_DAL"></param>
        public void Execute_Scalar(ref cls_DB_DAL Obj_DB_DAL)
        {
            #region TRY
            try
            {
                //Crea la conexión
                //Obtiene el string de configuration desde el XML AppConfig
                Obj_DB_DAL.sCadenaCNX = ConfigurationManager.ConnectionStrings["Win_Aut"].ToString();
                //Convierte el string a un Objeto adecuado para el motor de la base de datos
                Obj_DB_DAL.Obj_SQL_CNX = new SqlConnection(Obj_DB_DAL.sCadenaCNX);

                //Abre la conexión
                if (Obj_DB_DAL.Obj_SQL_CNX != null)
                {
                    if (Obj_DB_DAL.Obj_SQL_CNX.State == ConnectionState.Closed)
                    {
                        Obj_DB_DAL.Obj_SQL_CNX.Open();
                    }

                    //Se crea el Objeto COMMAND. NOTA: No se ha ejecutado aun.
                    Obj_DB_DAL.Obj_SQL_CMD = new SqlCommand(Obj_DB_DAL.sNombre_SP, Obj_DB_DAL.Obj_SQL_CNX);

                    //Se le agrega seguridad al Objeto Data Adapter
                    //Esto no permite que se le meta texto, lo que le da seguridad para contra SQL Injection attacks
                    //Solamente aceptará un Stored Procedure
                    Obj_DB_DAL.Obj_SQL_CMD.CommandType = CommandType.StoredProcedure;

                    //Verifica si el Objeto viene con un parámetro
                    if (Obj_DB_DAL.dtParametros != null)
                    {
                        //Si lo tiene, entonces revisa si más de 1 parámetro
                        if (Obj_DB_DAL.dtParametros.Rows.Count >= 1)
                        {
                            //Se recorre el DataTable de parámetros
                            foreach (DataRow DR in Obj_DB_DAL.dtParametros.Rows)
                            {
                                //Determina el tipo de variable dependiendo del número recibido
                                #region DEFINICIÓN DE TIPO DE DATO DE ACUERDO A COLUMNA 2
                                switch (DR[1].ToString())
                                {
                                    case "1":
                                        DB_TYPE = SqlDbType.VarChar;
                                        break;
                                    case "2":
                                        DB_TYPE = SqlDbType.Int;
                                        break;
                                    case "3":
                                        DB_TYPE = SqlDbType.Char;
                                        break;
                                    case "4":
                                        DB_TYPE = SqlDbType.Decimal;
                                        break;
                                    case "5":
                                        DB_TYPE = SqlDbType.DateTime;
                                        break;
                                    default:
                                        DB_TYPE = SqlDbType.NVarChar;
                                        break;
                                }
                                #endregion
                                /*
                                 Prepara el SQLDataAdapter dándole una instrucción SQL constituída de parámetros:
                                 (Nombre -DR[0]-, Tipo -DB_TYPE-, Valor -DR[2]-)
                                 */
                                Obj_DB_DAL.Obj_SQL_CMD.Parameters.Add(DR[0].ToString(), DB_TYPE).Value = DR[2].ToString();
                            }
                        }
                    }

                    //Ejecuta el Scalar y finalmente recoge el valor resultado
                    Obj_DB_DAL.sValScalar = Obj_DB_DAL.Obj_SQL_CMD.ExecuteScalar().ToString();
                    //Limpia el mensaje de error
                    Obj_DB_DAL.sMensError = string.Empty;
                }
                else
                {
                    Obj_DB_DAL.sMensError = "Error al ejecutar el método BLL.DB.Execute_Scalar() debido a que el Obj_SQL_CNX es Null";
                }
            }
            #endregion Try

            #region CATCH
            catch (Exception ex)
            {
                //Captura error del Sistema y lo guarda en el string
                Obj_DB_DAL.sMensError = "Error en BLL.DB.Execute_Scalar(): " + ex.Message.ToString();
            }
            #endregion

            #region FINALLY
            finally //Instrucción que SIEMPRE se ejecutará. Ejemplo: Cerrar la conexión (best practice)
            {
                if (Obj_DB_DAL.Obj_SQL_CNX != null)
                {
                    if (Obj_DB_DAL.Obj_SQL_CNX.State == ConnectionState.Open)
                    {
                        Obj_DB_DAL.Obj_SQL_CNX.Close();
                    }
                    Obj_DB_DAL.Obj_SQL_CNX.Dispose();
                }

            }
            #endregion
        }


    }
}
