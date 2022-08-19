using System;

namespace CapaDeDatos
{
    public class CLS_CorridaFruta : ConexionBase
    {
        public string c_codigo_sel { get; set; }
        public string c_codigo_tem { get; set; }
        public string v_nombre_tipocorte { get; set; }
        public string c_codigo_rec { get; set; }

        public void MtdSeleccionarRecepcion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaRecepcion_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
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
        public void MtdSeleccionarExportacion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaExportacion_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
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
        public void MtdSeleccionarNacional()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaNacional_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
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
        public void MtdSeleccionarMerma()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaMerma_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
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

        public void MtdSeleccionarRecepcionCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaRecepcion_Corte_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
                _dato.Texto = c_codigo_rec;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_rec");
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
        public void MtdSeleccionarExportacionCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaExportacion_Corte_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
                _dato.Texto = v_nombre_tipocorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_tipocorte");
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
        public void MtdSeleccionarNacionalCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaNacional_Corte_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
                _dato.Texto = v_nombre_tipocorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_tipocorte");
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

        public void MtdSeleccionarRecepcionCorteND()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaRecepcion_CorteND_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
                _dato.Texto = c_codigo_rec;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_rec");
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
        public void MtdSeleccionarKilosCorteND()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CorridaExportacion_CorteND_Select";
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_Codigo_tem");
                _dato.Texto = v_nombre_tipocorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_tipocorte");
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
