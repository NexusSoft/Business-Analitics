using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Parametros : ConexionBase
    {
        public string c_codigo_mat { get;  set; }
        public string v_nombre_mat { get;  set; }
        public string c_codigo_tmat { get; set; }
        public string c_codigo_pai { get; set; }
        public string v_nombre_pai { get; set; }
        //Precios del Termo
        public string PrecioMaquilaId { get; set; }
        public int PrecioMaquilaDesde { get; set; }
        public int PrecioMaquilaHasta { get; set; }
        public decimal PrecioMaquilaCosto { get; set; }
        //Precio Maquila
        public decimal PrecioNacional { get; set; }
        public decimal PrecioMalla { get; set; }
        public decimal PrecioAPEAM { get; set; }
        public decimal PrecioCharola25Lb { get; set; }
        public decimal PrecioCharolaRPC { get; set; }
        public decimal PrecioCarton25Lb { get; set; }
        public decimal PrecioCaja10kg { get; set; }
        public decimal PrecioCaja6kg { get; set; }
        public decimal PrecioCaja4kg { get; set; }
        public decimal PrecioCajaSAMS { get; set; }
        public decimal PrecioCajaRPC { get; set; }

        public string c_codigo_pro { get; set; }
        public string v_nombre_pro { get; set; }
        public string c_codigo_causa { get;  set; }
        public string c_codigo_causah { get;  set; }

        public void MtdSeleccionarParametroTermo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroPrecioTermo_Select";
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
        public void MtdSeleccionarParametroPrecios()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroPrecios_Select";
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
        public void MtdSeleccionarParametroAPEAM()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroAPEAM_Select";
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
        public void MtdSeleccionarParametroProductoExt()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaProductosExcluidos_Select";
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
        public void MtdSeleccionarParametroMaterial()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroMaterial_Select";
                _dato.Texto = c_codigo_tmat;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tmat");
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

        public void MtdSeleccionarParametroCausa()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroCausa_Select";
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
        public void MtdSeleccionarParametroCausaHorario()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroCausaHorario_Select";
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
        public void MtdSeleccionarParametroCausaPrecio()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroCausaPrecio_Select";
                _dato.Texto = c_codigo_causa;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_causa");
                _dato.Texto = c_codigo_causah;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_causah");
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

        public void MtdProductoMaterial_Insert()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroMaterial_Insert";

                _dato.Texto = c_codigo_mat;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_mat");
                _dato.Texto = v_nombre_mat;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_mat");
                _dato.Texto = c_codigo_tmat;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tmat");
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
        public void MtdProductoAPEAM_Insert()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroAPEAM_Insert";

                _dato.Texto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_pai");
                _dato.Texto = v_nombre_pai;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_pai");
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
        public void MtdProductoExc_Insert()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroProductoExc_Insert";

                _dato.Texto = c_codigo_pro;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_pro");
                _dato.Texto = v_nombre_pro;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_pro");
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
        

        public void MtdProductoMaterial_Delete()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroMaterial_Delete";
                _dato.Texto = c_codigo_mat;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_mat");
                _dato.Texto = c_codigo_tmat;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tmat");
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
        public void MtdProductoAPEAM_Delete()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroAPEAM_Delete";
                _dato.Texto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_pai");
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
        public void MtdProductoExc_Delete()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroProductoExc_Delete";
                _dato.Texto = c_codigo_pro;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_pro");
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
       

        public void MtdPrecioTermo_Update()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroPrecioTermo_Update";
                _dato.Entero = PrecioMaquilaDesde;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PrecioMaquilaDesde");
                _dato.Entero = PrecioMaquilaHasta;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PrecioMaquilaHasta");
                _dato.Decimal = PrecioMaquilaCosto;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioMaquilaCosto");
                _dato.Texto = PrecioMaquilaId;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "PrecioMaquilaId");
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
        public void MtdPrecio_Update()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaParametroPrecios_Update";
                _dato.Decimal = PrecioNacional;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioNacional");
                _dato.Decimal = PrecioMalla;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioMalla");
                _dato.Decimal = PrecioAPEAM;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioAPEAM");
                _dato.Decimal = PrecioCharola25Lb;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCharola25Lb");
                _dato.Decimal = PrecioCharolaRPC;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCharolaRPC");
                _dato.Decimal = PrecioCarton25Lb;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCarton25Lb");
                _dato.Decimal = PrecioCaja10kg;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCaja10kg");
                _dato.Decimal = PrecioCaja6kg;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCaja6kg");
                _dato.Decimal = PrecioCaja4kg;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCaja4kg");
                _dato.Decimal = PrecioCajaSAMS;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCajaSAMS");
                _dato.Decimal = PrecioCajaRPC;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCajaRPC");
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
