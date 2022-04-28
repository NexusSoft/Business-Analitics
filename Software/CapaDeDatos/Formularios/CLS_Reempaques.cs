using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Reempaques:ConexionBase
    {
        public string c_codigo_pro { get; set; }
        public string d_fecha_rem { get; set; }
        public string v_nombre_pro_O { get; set; }
        public string v_nombre_env_O { get; set; }
        public string v_nombre_eti_O { get; set; }
        public string v_nombre_plu_O { get; set; }
        public int n_cajas_rem_O { get; set; }
        public string v_nombre_pro_N { get; set; }
        public string v_nombre_env_N { get; set; }
        public string v_nombre_eti_N { get; set; }
        public string v_nombre_plu_N { get; set; }
        public int n_cajas_rem_N { get; set; }
        public string v_Observaciones { get; set; }
        public decimal n_kilogramos { get; set; }
        public string v_nombre_causa { get; set; }
        public decimal n_costo_rem { get; set; }
        public string d_fecha_inicio_maq { get; set; }
        public string d_fecha_fin_maq { get; set; }
        public int n_semana_maq { get; set; }
        public int n_secuencia { get; set; }
        public string c_codigo_causa { get;  set; }
        public string c_codigo_causah { get;  set; }
        public string v_nombre_horario { get;  set; }
        public string v_unidad_causa { get;  set; }
        public int? n_cantidad_causa { get;  set; }
        public decimal? n_total_causa { get;  set; }
        public decimal? n_precio_causa { get;  set; }
        public string d_fecha_causa { get; set; }

        public void MtdSeleccionarProductosReempaque()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaReempaqueProductos_Select";
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
        public void MtdSeleccionarEnvaseReempaque()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaReempaqueEnvase_Select";
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
        public void MtdSeleccionarEtiquetaReempaque()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaReempaqueEtiqueta_Select";
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
        public void MtdSeleccionarPLUReempaque()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaReempaquePLU_Select";
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
        public void MtdSeleccionarCausaReempaque()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaReempaqueCausa_Select";
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
        public void MtdInsertarReempaque()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaReempaqueXSemana_Insert";
                _dato.Texto = d_fecha_rem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_rem");
                _dato.Texto = v_nombre_pro_O;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_pro_O");
                _dato.Texto = v_nombre_env_O;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_env_O");
                _dato.Texto = v_nombre_eti_O;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_eti_O");
                _dato.Texto = v_nombre_plu_O;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_plu_O");
                _dato.Entero = n_cajas_rem_O;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_cajas_rem_O");
                _dato.Texto = v_nombre_pro_N;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_pro_N");
                _dato.Texto = v_nombre_env_N;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_env_N");
                _dato.Texto = v_nombre_eti_N;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_eti_N");
                _dato.Texto = v_nombre_plu_N;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_plu_N");
                _dato.Entero = n_cajas_rem_N;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_cajas_rem_N");
                _dato.Texto = v_Observaciones;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_Observaciones");
                _dato.Decimal = n_kilogramos;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "n_kilogramos");
                _dato.Texto = v_nombre_causa;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_causa");
                _dato.Decimal = n_costo_rem;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "n_costo_rem");
                _dato.Texto = d_fecha_inicio_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_inicio_maq");
                _dato.Texto = d_fecha_fin_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_fin_maq");
                _dato.Entero = n_semana_maq;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_semana_maq");
                _dato.Entero = n_secuencia;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_secuencia");
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
        public void MtdSeleccionarReempaque()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaReempaque_Select";
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
        public void MtdEliminarReempaque()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaReempaqueXSemana_Delete";
                _dato.Texto = d_fecha_inicio_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_inicio_maq");
                _dato.Texto = d_fecha_fin_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_fin_maq");
                _dato.Entero = n_semana_maq;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_semana_maq");
                _dato.Entero = n_secuencia;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_secuencia");
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

        // Extra
        public void MtdSeleccionarCausaExtraG()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaCausaExtra_Select";
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
        public void MtdSeleccionarCausaExtra()
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
        public void MtdSeleccionarCausaHorarioExtra()
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
        public void MtdSeleccionarCausaPrecioExtra()
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
        public void MtdInsertarCausaExtra()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaCausaExtraXSemana_Insert";
                _dato.Entero = n_semana_maq;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_semana_maq");
                _dato.Entero = n_secuencia;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_secuencia");
                _dato.Texto = v_nombre_causa;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_causa");
                _dato.Texto = v_nombre_horario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_horario");
                _dato.Texto = v_unidad_causa;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_unidad_causa");
                _dato.Decimal = n_precio_causa;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "n_precio_causa");
                _dato.Entero = n_cantidad_causa;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_cantidad_causa");
                _dato.Decimal = n_total_causa;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "n_total_causa");
                _dato.Texto = d_fecha_inicio_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_inicio_maq");
                _dato.Texto = d_fecha_fin_maq;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_fin_maq");
                _dato.Texto = d_fecha_causa;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_fecha_causa");
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
        public void MtdEliminarCausaExtra()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "MaquilaCausaExtraXSemana_Delete";
                _dato.Entero = n_semana_maq;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_semana_maq");
                _dato.Entero = n_secuencia;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_secuencia");
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
