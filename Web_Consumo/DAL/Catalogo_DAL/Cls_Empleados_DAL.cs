

namespace DAL.Catalogo_DAL
{
    public class Cls_Empleados_DAL
    {

        private string _sIdEmpleado;
        private string _sCedula;
        private string _sNombre;
        private string _sApellidos;
        private string _sDireccion;
        private int _iEdad;
        private string _sTelefonoCasa;
        private string _sTelefonoReferencia;
        private string _sCelular;
        private decimal _dSalario;
        private int _iIdTipoEmpleado;
        private int _iIdAerolinea;
        private char _cIdEstado;

        private string _sStoreProcedure;
        private string _sMsjError;
        private string _sFiltro;
       

        public Cls_Empleados_DAL()
        {
        }

        public string SIdEmpleado { get => _sIdEmpleado; set => _sIdEmpleado = value; }
        public string SCedula { get => _sCedula; set => _sCedula = value; }
        public string SNombre { get => _sNombre; set => _sNombre = value; }
        public string SApellidos { get => _sApellidos; set => _sApellidos = value; }
        public string SDireccion { get => _sDireccion; set => _sDireccion = value; }
        public int IEdad { get => _iEdad; set => _iEdad = value; }
        public string STelefonoCasa { get => _sTelefonoCasa; set => _sTelefonoCasa = value; }
        public string STelefonoReferencia { get => _sTelefonoReferencia; set => _sTelefonoReferencia = value; }
        public string SCelular { get => _sCelular; set => _sCelular = value; }
        public decimal DSalario { get => _dSalario; set => _dSalario = value; }
        public int IIdTipoEmpleado { get => _iIdTipoEmpleado; set => _iIdTipoEmpleado = value; }
        public int IIdAerolinea { get => _iIdAerolinea; set => _iIdAerolinea = value; }
        public char CIdEstado { get => _cIdEstado; set => _cIdEstado = value; }
        public string SMsjError { get => _sMsjError; set => _sMsjError = value; }
        public string SFiltro { get => _sFiltro; set => _sFiltro = value; }
        public string SStoreProcedure { get => _sStoreProcedure; set => _sStoreProcedure = value; }
    }
}
