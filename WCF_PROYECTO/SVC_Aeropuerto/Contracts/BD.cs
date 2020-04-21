using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Aeropuerto;
using DAL_Aeropuerto;

namespace SVC_Aeropuerto.Contracts
{
    class BD : Interfaces.IBD 
    {
        /// <summary>
        /// Metodo para crear Datatable con parametros con 3 columnas
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable CrearDTParametros()
        {
            //Instancia de clase
            DataTable dt = new DataTable("Parametros");

            //Definicion de columnas
            dt.Columns.Add("NOM_PARAM");
            dt.Columns.Add("TIPO_DATO");
            dt.Columns.Add("VALOR");

            return dt;
        }

        /// <summary>
        /// Metodo para listar con o sin filtros desde la base de datos
        /// </summary>
        /// <param name="sNombreSP">Nombre proceso almacenado</param>
        /// <param name="DT_Parametros">Datatable con los parametros</param>
        /// <param name="sMsjError">Mensaje de error</param>
        /// <returns>Datatable con resultado de base de datos</returns>
        public DataTable ListarFiltrarDatos(string sNombreSP, DataTable DT_Parametros, ref string sMsjError)
        {
            //Instancias de clase
            DAL_Aeropuerto.DB.cls_DB_DAL Obj_BD_DAL = new DAL_Aeropuerto.DB.cls_DB_DAL();
            BLL_Aeropuerto.DB.cls_DB_BLL Obj_BD_BLL = new BLL_Aeropuerto.DB.cls_DB_BLL();

            //Definicion de proceso almacenado y parametros
            Obj_BD_DAL.sNombre_SP = sNombreSP;
            Obj_BD_DAL.dtParametros = DT_Parametros;

            //Ejecucion del data adapter
            Obj_BD_BLL.Execute_DataAdapter(ref Obj_BD_DAL);

            //Si no hubo errores devuelve la tabla solicitada si no devuelve el error obtenido
            if(Obj_BD_DAL.sMensError == string.Empty)
            {
                return Obj_BD_DAL.dsDatos.Tables[0];
            } else
            {
                sMsjError = Obj_BD_DAL.sMensError;
                return null;
            }
        }
        
        /// <summary>
        /// Metodo para insertar, modificar o eliminar de la base de datos
        /// </summary>
        /// <param name="sNombreSP">Nombre proceso almacenado</param>
        /// <param name="bBandera">True: Si la tabla contiene llave primaria identity || False: Si es tabla normal</param>
        /// <param name="DT_Parametros">Datatable con parametros</param>
        /// <param name="sMsjError">Mensaje de error</param>
        /// <returns>String con resultado o error</returns>
        public string Ins_Mod_Eli_Datos(string sNombreSP, bool bBandera, DataTable DT_Parametros, ref string sMsjError)
        {
            //Instancias de clase
            DAL_Aeropuerto.DB.cls_DB_DAL Obj_BD_DAL = new DAL_Aeropuerto.DB.cls_DB_DAL();
            BLL_Aeropuerto.DB.cls_DB_BLL Obj_BD_BLL = new BLL_Aeropuerto.DB.cls_DB_BLL();

            //Definicion de proceso almacenado y parametros
            Obj_BD_DAL.sNombre_SP = sNombreSP;
            Obj_BD_DAL.dtParametros = DT_Parametros;

            //Si bandera es false ejecuta NonQuery a una tabla normal, si es true ejecutamos Scalar a una tabla con llave primaria identity
            if (bBandera == false)
            {
                Obj_BD_BLL.Execute_NonQuery(ref Obj_BD_DAL);
            }
            else
            {
                Obj_BD_BLL.Execute_Scalar(ref Obj_BD_DAL);
            }
            //Si no hay mensaje de error devuelve el valor scalar en el objeto DAL, si no devuelve string vacio mas el mensaje de error
            if (Obj_BD_DAL.sMensError == String.Empty)
            {
                return Obj_BD_DAL.sValScalar;
            } else
            {
                sMsjError = Obj_BD_DAL.sMensError;
                return string.Empty;
            }
        }
    }
}
