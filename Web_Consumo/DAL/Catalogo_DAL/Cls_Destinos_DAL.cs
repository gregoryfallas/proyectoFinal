namespace DAL.Catalogo_DAL
{
    public class Cls_Destinos_DAL
    {
        private string _sIdDestino;
        private int _iIdAerolinea;
        private string _sNomDestino;
        private int _iPaisSalida;
        private int _iPaisLlegada;
        private char _cIdEstado;

        private string _sStoreProcedure;
        private string _sMsjError;
        private string _sFiltro;


        public Cls_Destinos_DAL()
        {
        }

        public string SIdDestino { get => _sIdDestino; set => _sIdDestino = value; }
        public int IIdAerolinea { get => _iIdAerolinea; set => _iIdAerolinea = value; }
        public string SNomDestino { get => _sNomDestino; set => _sNomDestino = value; }
        public int IPaisSalida { get => _iPaisSalida; set => _iPaisSalida = value; }
        public int IPaisLlegada { get => _iPaisLlegada; set => _iPaisLlegada = value; }
        public char CIdEstado { get => _cIdEstado; set => _cIdEstado = value; }
        public string SStoreProcedure { get => _sStoreProcedure; set => _sStoreProcedure = value; }
        public string SMsjError { get => _sMsjError; set => _sMsjError = value; }
        public string SFiltro { get => _sFiltro; set => _sFiltro = value; }
    }
}
