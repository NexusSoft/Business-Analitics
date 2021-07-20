using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDeDatos
{
    public class ConexionBase
    {
        static public string ServerR { get; set; }
        static public string DBaseR { get; set; }
        static public string UserR { get; set; }
        static public string PasswordR { get; set; }

        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public DataTable Datos { get; set; }

        protected string cadenaConexion = ConexionSQL.LeerConexion();
        protected string cadenaconexionR = ConexionSQL.LeerConexionR(ServerR, DBaseR, UserR, PasswordR);

        protected Conexion _conexion = new Conexion(ConexionSQL.LeerConexion());
        protected Conexion _conexionR = new Conexion(ConexionSQL.LeerConexionR(ServerR, DBaseR, UserR, PasswordR));
    }
}
