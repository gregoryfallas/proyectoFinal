using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerías para conexión a la BD y para uso de DataSet/DataTables
using System.Data;
using System.Data.SqlClient;

namespace DAL_Aeropuerto.DB
{
    public class cls_DB_DAL
    {
        #region Variables
        private string _sMensError; //Toma mensajes de error del TRY-CATCH cada vez que los métodos contactan con la BD
        private string _sValScalar; //String que devuelve el SGBD con la posición o último ID de la tabla en BD
        private string _sCadenaCNX; //String de configuración para conectarse a la BD -viene del App.config-
        private string _sNombre_SP; //Nombre del Stored procedure -viene del App.config-
        private string _sNombTabla; //Nombre de la tabla -viene del App.config-
        private DataSet _dsDatos; //Recibe tablas con datos desde la BD
        private DataTable _dtParametros; //Se usa para enviar parámetros de control a la BD (ejemplo: nombre, tipo, valor)
        private SqlConnection _Obj_SQL_CNX; //Objeto de conexión a la BD
        private SqlDataAdapter _Obj_SQL_DAP; //Objeto de tipo BD para ejecutar comandos de listar, filtrar y eliminar
        private SqlCommand _Obj_SQL_CMD; //Objeto de tipo BD para ejecutar comandos de insertar, actualizar y borrar
        #endregion

        #region Setters & Getters
        /// <summary>
        /// Variable: Contiene mensaje de error 
        /// </summary>
        public string sMensError
        {
            get
            {
                return _sMensError;
            }

            set
            {
                _sMensError = value;
            }
        }

        /// <summary>
        /// String desde el SGBD con la posición o último ID de la tabla en BD
        /// </summary>
        public string sValScalar
        {
            get
            {
                return _sValScalar;
            }

            set
            {
                _sValScalar = value;
            }
        }

        /// <summary>
        /// String de configuración para conectarse a la BD
        /// </summary>
        public string sCadenaCNX
        {
            get
            {
                return _sCadenaCNX;
            }

            set
            {
                _sCadenaCNX = value;
            }
        }

        /// <summary>
        /// String con el nombre del Stored procedure
        /// </summary>
        public string sNombre_SP
        {
            get
            {
                return _sNombre_SP;
            }

            set
            {
                _sNombre_SP = value;
            }
        }

        /// <summary>
        /// String con el nombre de la tabla
        /// </summary>
        public string sNombTabla
        {
            get
            {
                return _sNombTabla;
            }

            set
            {
                _sNombTabla = value;
            }
        }

        /// <summary>
        /// Variable para recibir resultados/datos desde la BD
        /// </summary>
        public DataSet dsDatos
        {
            get
            {
                return _dsDatos;
            }

            set
            {
                _dsDatos = value;
            }
        }

        /// <summary>
        /// String para enviar parámetros de control a la BD
        /// </summary>
        public DataTable dtParametros
        {
            get
            {
                return _dtParametros;
            }

            set
            {
                _dtParametros = value;
            }
        }

        /// <summary>
        /// Objeto de conexión a la BD
        /// </summary>
        public SqlConnection Obj_SQL_CNX
        {
            get
            {
                return _Obj_SQL_CNX;
            }

            set
            {
                _Obj_SQL_CNX = value;
            }
        }

        /// <summary>
        /// Objeto de tipo BD para ejecutar comandos de listar, filtrar y eliminar
        /// </summary>
        public SqlDataAdapter Obj_SQL_DAP
        {
            get
            {
                return _Obj_SQL_DAP;
            }

            set
            {
                _Obj_SQL_DAP = value;
            }
        }

        /// <summary>
        /// Objeto de tipo BD para ejecutar comandos de insertar, actualizar y borrar
        /// </summary>
        public SqlCommand Obj_SQL_CMD
        {
            get
            {
                return _Obj_SQL_CMD;
            }

            set
            {
                _Obj_SQL_CMD = value;
            }
        }
        #endregion



    }
}
