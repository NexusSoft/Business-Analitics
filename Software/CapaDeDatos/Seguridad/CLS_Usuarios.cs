using System;

namespace CapaDeDatos
{
    public class CLS_Usuarios : ConexionBase
    {

        public string Id_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Id_Perfil { get; set; }

        public string Activo { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Usuarios_Select";
                _dato.Texto = Activo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Activo");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }



        public void MtdInsertarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Usuarios_Insert";
                _dato.Texto = Id_Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Usuario");
                _dato.Texto = Nombre_Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Usuario");
                _dato.Texto = Contrasena;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Contrasena");
                _dato.Texto = Id_Perfil;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Perfil");
                _dato.Texto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Usuario");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }

        public void MtdEliminarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Usuarios_Delete";
                _dato.Texto = Id_Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Usuario");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }


    }
}
