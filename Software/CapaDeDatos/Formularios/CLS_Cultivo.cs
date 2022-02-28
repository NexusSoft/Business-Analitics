using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Cultivo : ConexionBase
    {

        public string Id_Cultivo { get; set; }
        public string Nombre_Cultivo { get; set; }
        public string Id_Usuario { get; set; }
        public string Activo { get; set; }

        public void MtdSeleccionarCultivo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cultivo_Select";
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
        public void MtdInsertarCultivo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cultivo_Insert";
                _dato.Texto = Id_Cultivo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cultivo");
                _dato.Texto = Nombre_Cultivo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Cultivo");
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
        public void MtdEliminarCultivo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cultivo_Delete";
                _dato.Texto = Id_Cultivo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cultivo");
                _dato.Texto = Id_Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Usuario");
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

    }
}
