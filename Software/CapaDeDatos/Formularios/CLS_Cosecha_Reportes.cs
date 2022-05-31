using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Cosecha_Reportes : ConexionBase
    {
        public string Usuario { get; set; }
        //OrdenCorte
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }

        public void MtdSelecccionarRelacionFrutaCortada()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_ReporteFruta_Cortada_Select";
                _dato.Texto = Fecha_Inicio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Inicio");
                _dato.Texto = Fecha_Fin;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Fin");
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

        public void MtdSelecccionarRelacionEmpresaCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_ReporteEmpresa_Corte_Select";
                _dato.Texto = Fecha_Inicio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Inicio");
                _dato.Texto = Fecha_Fin;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Fin");
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

        public void MtdSelecccionarRelacionEmpresaAcarreo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_ReporteEmpresa_Acarreo_Select";
                _dato.Texto = Fecha_Inicio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Inicio");
                _dato.Texto = Fecha_Fin;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Fin");
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

        public void MtdSelecccionarRelacionAcumulada()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_ReporteAcumulado_Select";
                _dato.Texto = Fecha_Inicio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "FechaInicio");
                _dato.Texto = Fecha_Fin;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "FechaFin");
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
