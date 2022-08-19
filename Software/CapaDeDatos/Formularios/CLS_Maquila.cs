using System;

namespace CapaDeDatos
{
    public class CLS_Maquila : ConexionBase
    {
        public int Semana { get; set; }
        public string cManifiesto { get; set; }
        public string cDistribuidor { get; set; }
        public string cFechaEmbarque { get; set; }
        public string cProducto { get; set; }
        public string cEnvase { get; set; }
        public decimal cPesoEstandar { get; set; }
        public int cCajas { get; set; }
        public decimal cMontoMaquila { get; set; }
        public decimal cMallas { get; set; }
        public decimal cAPEAM { get; set; }
        public decimal cSubTotal1 { get; set; }
        public decimal cCharola { get; set; }
        public decimal cSubTotal { get; set; }
        public decimal cTOTAL { get; set; }
        public int Anio { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string d_fecha_inicio_maq { get; set; }
        public string d_fecha_fin_maq { get; set; }
        public int? n_semana_maq { get; set; }
        public decimal cCaja { get; set; }

        public void MtdSeleccionarMaquila()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaXSemana_Select";
                _dato.Texto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "FechaInicio");
                _dato.Texto = FechaFin;
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
        public void MtdInsertarMaquila()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaXSemana_Insert";
                _dato.Texto = cManifiesto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cManifiesto");
                _dato.Texto = cDistribuidor;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cDistribuidor");
                _dato.Texto = cFechaEmbarque;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cFechaEmbarque");
                _dato.Texto = cProducto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cProducto");
                _dato.Texto = cEnvase;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cEnvase");
                _dato.Decimal = cPesoEstandar;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cPesoEstandar");
                _dato.Entero = cCajas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "cCajas");
                _dato.Decimal = cMontoMaquila;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cMontoMaquila");
                _dato.Decimal = cMallas;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cMallas");
                _dato.Decimal = cAPEAM;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cAPEAM");
                _dato.Decimal = cSubTotal1;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cSubTotal1");
                _dato.Decimal = cCharola;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cCharola");
                _dato.Decimal = cSubTotal;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cSubTotal");
                _dato.Decimal = cCaja;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cCaja");
                _dato.Decimal = cTOTAL;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cTOTAL");
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
        public void MtdEliminarMaquila()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaXSemana_Delete";
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

        public void MtdGuardarMaquilaDetalles()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaDetalles_Insert";
                _dato.Texto = cManifiesto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cManifiesto");
                _dato.Texto = cDistribuidor;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cDistribuidor");
                _dato.Texto = cFechaEmbarque;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cFechaEmbarque");
                _dato.Texto = cProducto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cProducto");
                _dato.Texto = cEnvase;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "cEnvase");
                _dato.Decimal = cPesoEstandar;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cPesoEstandar");
                _dato.Entero = cCajas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "cCajas");
                _dato.Decimal = cMontoMaquila;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cMontoMaquila");
                _dato.Decimal = cMallas;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cMallas");
                _dato.Decimal = cAPEAM;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cAPEAM");
                _dato.Decimal = cCaja;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cCaja");
                _dato.Decimal = cSubTotal;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cSubTotal");
                _dato.Decimal = cCharola;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cCharola");
                _dato.Decimal = cSubTotal1;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cSubTotal1");
                _dato.Decimal = cTOTAL;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "cTOTAL");
                _dato.Texto = d_fecha_inicio_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_inicio_maq");
                _dato.Texto = d_fecha_fin_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_fin_maq");
                _dato.Entero = n_semana_maq;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_semana_maq");
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
        public void MtdEliminarMaquilaDetalles()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaDetalles_Delete";
                _dato.Texto = d_fecha_inicio_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_inicio_maq");
                _dato.Texto = d_fecha_fin_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_fin_maq");
                _dato.Entero = n_semana_maq;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_semana_maq");
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
        public void MtdSeleccionarMaquilaDetalles()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaDetalles_Select";
                _dato.Texto = d_fecha_inicio_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_inicio_maq");
                _dato.Texto = d_fecha_fin_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_fin_maq");
                _dato.Entero = n_semana_maq;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_semana_maq");
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
