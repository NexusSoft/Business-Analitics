using System;
using System.Data.SqlClient;


namespace CapaDeDatos
{

    public class ConexionSQL
    {


        const string NombreProyecto = "Business_Analitics";
        static public string LeerConexion()
        {
            string StrConexion;
            string valServer;
            string valDB;
            string valLogin;
            string valPass;
            try
            {
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();

                valServer = RegOut.GetSetting("ConexionSQL", "Server");
                valDB = RegOut.GetSetting("ConexionSQL", "DBase");
                valLogin = RegOut.GetSetting("ConexionSQL", "User");
                valPass = RegOut.GetSetting("ConexionSQL", "Password");
                if (valServer != string.Empty && valLogin != string.Empty && valLogin != string.Empty && valPass != string.Empty)
                {
                    valServer = DesencriptarTexto.Desencriptar(valServer);
                    valDB = DesencriptarTexto.Desencriptar(valDB);
                    valLogin = DesencriptarTexto.Desencriptar(valLogin);
                    valPass = DesencriptarTexto.Desencriptar(valPass);
                }
                else
                {
                    throw new Exception("Faltan datos para la Conexión");
                }
            }

            catch
            {
                valServer = string.Empty;
                valDB = string.Empty;
                valLogin = string.Empty;
                valPass = string.Empty;
            }

            if (valServer != string.Empty && valLogin != string.Empty && valLogin != string.Empty && valPass != string.Empty)
            {
                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                return StrConexion;
            }
            else
            {
                throw new Exception("Faltan datos para la Conexión");
            }
        }
        public string LeerConexionL()
        {
            try
            {
                string StrConexion;
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Server"));
                ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBase"));
                ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "User"));
                ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Password"));


                StrConexion = "Data Source=" + ValServer + ";Initial Catalog=" + ValDBase + ";Persist Security Info=True;User ID=" + ValUser + ";Password=" + ValPass;
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public string LeerConexionR(string ServerR, string DBaseR, string UserR, string PasswordR)
        {
            try
            {
                string StrConexion;
                string ValServerR = string.Empty;
                string ValDBaseR = string.Empty;
                string ValUserR = string.Empty;
                string ValPassR = string.Empty;

                if (ServerR != null && DBaseR != null && UserR != null && PasswordR != null)
                {
                    MSRegistro RegOut = new MSRegistro();
                    Crypto DesencriptarTexto = new Crypto();
                    ValServerR = DesencriptarTexto.Desencriptar(ServerR);
                    ValDBaseR = DesencriptarTexto.Desencriptar(DBaseR);
                    ValUserR = DesencriptarTexto.Desencriptar(UserR);
                    ValPassR = DesencriptarTexto.Desencriptar(PasswordR);

                }
                StrConexion = "Data Source=" + ValServerR + ";Initial Catalog=" + ValDBaseR + ";Persist Security Info=True;User ID=" + ValUserR + ";Password=" + ValPassR;
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean ValidaConexion()
        {
            try
            {
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                try
                {
                    ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Server"));
                    ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBase"));
                    ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "User"));
                    ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Password"));
                }
                catch
                {
                    ValServer = string.Empty;
                    ValDBase = string.Empty;
                    ValUser = string.Empty;
                    ValPass = string.Empty;
                }

                if (ValServer != string.Empty && ValDBase != string.Empty && ValUser != string.Empty && ValPass != string.Empty)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection("Data Source=" + ValServer + ";Initial Catalog=" + ValDBase + ";Persist Security Info=True;User ID=" + ValUser + ";Password=" + ValPass);
                        conn.Open();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
