using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Reporte_Inventario_Ventas : ConexionBase
    {

        public string Fecha1 { get; set; }
        public string Fecha2 { get; set; }
        public string Fecha3 { get; set; }
        public string Fecha4 { get; set; }

        public void MtdSeleccionarInventario()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Fechas_Select";
                _dato.Texto = Fecha1;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha1");
                _dato.Texto = Fecha2;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha2");
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
        public void MtdSeleccionarInventarioTotales()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Totales_Fechas_Select";
                _dato.Texto = Fecha1;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha1");
                _dato.Texto = Fecha2;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha2");
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
        public void MtdSeleccionarInventarioSerie()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Fechas_Series_Select";
                _dato.Texto = Fecha1;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha1");
                _dato.Texto = Fecha2;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha2");
                _dato.Texto = Fecha3;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha3");
                _dato.Texto = Fecha4;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha4");
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
        public void MtdSeleccionarInventarioTotalesSerie()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Totales_Fechas_Series_Select";
                _dato.Texto = Fecha1;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha1");
                _dato.Texto = Fecha2;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha2");
                _dato.Texto = Fecha3;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha3");
                _dato.Texto = Fecha4;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha4");
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
        public void MtdSeleccionarFechaMaxima()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Fechas_Max_Select";
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
        public void MtdSeleccionarFechaValidar()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Fechas_Validar_Select";
                _dato.Texto = Fecha1;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha1");
                _dato.Texto = Fecha2;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha2");
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
