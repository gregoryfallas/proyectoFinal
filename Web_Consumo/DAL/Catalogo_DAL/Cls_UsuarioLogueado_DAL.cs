using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Catalogo_DAL
{
    public class Cls_UsuarioLogueado_DAL
    {
        private string _sUserName;
        private int _iTipoUsuario;

        public string sUserName { get => _sUserName; set => _sUserName = value; }
        public int iTipoUsuario { get => _iTipoUsuario; set => _iTipoUsuario = value; }
    }
}
