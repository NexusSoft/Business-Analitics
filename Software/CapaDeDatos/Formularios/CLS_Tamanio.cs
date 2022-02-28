using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Tamanio: ConexionBase
    {

        public string Id_Tamanio { get; set; }
        public string Nombre_Tamanio{ get; set; }

        public string Usuario { get; set; }
        public string Id_Registro { get;  set; }

        public void MtdSeleccionarTamanio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tamanio_Select";

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
        public void MtdSeleccionarTamanioId()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tamanio_Id_Select";
                _dato.Texto = Id_Registro;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Registro");
                _dato.Texto = Id_Tamanio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Tamanio");
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
        public void MtdInsertarTamanio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tamanio_Insert";
                _dato.Texto = Id_Tamanio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Tamanio");
                _dato.Texto = Nombre_Tamanio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Tamanio");
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

        public void MtdEliminarTamanio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tamanio_Delete";
                _dato.Texto = Id_Tamanio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Tamanio");
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
