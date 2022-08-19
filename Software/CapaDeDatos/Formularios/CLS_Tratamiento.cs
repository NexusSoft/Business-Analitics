using System;

namespace CapaDeDatos
{
    public class CLS_Tratamiento : ConexionBase
    {

        public string Id_Tratamiento { get; set; }
        public string Nombre_Tratamiento { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarTratamiento()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tratamiento_Select";

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

        public void MtdInsertarTratamiento()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tratamiento_Insert";
                _dato.Texto = Id_Tratamiento;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Tratameinto");
                _dato.Texto = Nombre_Tratamiento;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Tratamiento");
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

        public void MtdEliminarPais()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tratamiento_Delete";
                _dato.Texto = Id_Tratamiento;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Tratamiento");
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
