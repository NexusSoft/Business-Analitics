using System;

namespace CapaDeDatos
{
    public class CLS_AcarreroPrecios : ConexionBase
    {
        //Filtro
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        // Precio
        public string Id_AcopioPrecios { get; set; }
        public string Fecha { get; set; }
        public string Estiba { get; set; }
        public int Todas { get; set; }
        public string Usuario { get; set; }

        // Precios Detalle
        public int Orden { get; set; }
        public string Categoria { get; set; }
        public string Calibre { get; set; }
        public string Gramaje { get; set; }
        public decimal Precio { get; set; }
        public string Mercado { get; set; }
        // precios Estiba
        public int Semana { get; set; }
        public int Anio { get; set; }
        public string c_codigo_tem { get; set; }
        public string c_codigo_sel { get; set; }
        public int b_pagocosecha { get; set; }
        public int b_pagoacarreo { get; set; }
        public int b_descuentocosecha { get; set; }
        public int b_descuentoacarreo { get; set; }
        public string v_tipocamion { get; set; }
        public int b_PagoBanda { get; set; }
        public decimal n_preciocompra { get; set; }


        // Filtro
        public void MtdSeleccionarAcopioPrecios_Filtro()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_PreciosFiltro_Select";
                _dato.Texto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "FechaInicio");
                _dato.Texto = FechaFin;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "FechaFin");
                _dato.Texto = Estiba;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Estiba");
                _dato.Entero = Todas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Todas");

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
        public void MtdSeleccionarAcopioPreciosEncabezado_Filtro()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Encabezado_Select";
                _dato.Texto = Id_AcopioPrecios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_AcopioPrecios");

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
        public void MtdSeleccionarAcopioPreciosDetalle_Nacional_Filtro()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Detalle_Nacional_Select";
                _dato.Texto = Id_AcopioPrecios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_AcopioPrecios");
                
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
        public void MtdSeleccionarAcopioPreciosDetalle_Exportacion_Filtro()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Detalle_Exportacion_Select";
                _dato.Texto = Id_AcopioPrecios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_AcopioPrecios");

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
        public void MtdEliminarAcopioPrecioEditado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Editado_Delete";
                _dato.Texto = Id_AcopioPrecios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_AcopioPrecios");

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
        // Acopio Precios
        public void MtdInsertarAcopioPrecio_Encabezado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Encabezado_Insert";
                _dato.Texto = Id_AcopioPrecios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_AcopioPrecios");
                _dato.Texto = Fecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha");
                _dato.Texto = Estiba;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Estiba");
                _dato.Entero = Todas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Todas");
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
        public void MtdInsertarAcopioPrecio_Detalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Detalle_Insert";
                _dato.Texto = Id_AcopioPrecios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_AcopioPrecios");
                _dato.Texto = Mercado;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Mercado");
                _dato.Entero = Orden;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Orden");
                _dato.Texto = Categoria;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Categoria");
                _dato.Texto = Calibre;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Calibre");
                _dato.Texto = Gramaje;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Gramaje");
                _dato.Decimal = Precio;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio");
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
        public void MtdEliminarAcopioPrecio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Delete";
                _dato.Texto = Id_AcopioPrecios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_AcopioPrecios");
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
        public void MtdEliminarAcopioPrecioRango()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_PreciosRango_Delete";
                _dato.Texto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "FechaInicio");
                _dato.Texto = FechaFin;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "FechaFin");
                _dato.Texto = Estiba;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Estiba");
                _dato.Entero = Todas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Todas");
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
        // Acopio Precios Estiba
        public void MtdInsertarAcopioPrecioEstiba()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_Insert";
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
        public void MtdSeleccionarAcopioPreciosEstiba()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_Select";
                _dato.Entero = Semana;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Semana");
                _dato.Entero = Anio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Anio");

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
        public void MtdActualizarAcopioPreciosEstiba_b_pagocosecha()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_b_pagocosecha_Update";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Entero = b_pagocosecha;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "b_pagocosecha");

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
        public void MtdActualizarAcopioPreciosEstiba_b_pagoacarreo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_b_pagoacarreo_Update";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Entero = b_pagoacarreo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "b_pagoacarreo");

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
        public void MtdActualizarAcopioPreciosEstiba_b_descuentocosecha()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_b_descuentocosecha_Update";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Entero = b_descuentocosecha;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "b_descuentocosecha");

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
        public void MtdActualizarAcopioPreciosEstiba_b_descuentoacarreo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_b_descuentoacarreo_Update";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Entero = b_descuentoacarreo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "b_descuentoacarreo");

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
        public void MtdActualizarAcopioPreciosEstiba_v_tipocamion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_v_tipocamion_Update";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Texto = v_tipocamion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_tipocamion");

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
        public void MtdActualizarAcopioPreciosEstiba_b_PagoBanda()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_b_PagoBanda_Update";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Entero = b_PagoBanda;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "b_PagoBanda");

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
        public void MtdActualizarAcopioPreciosEstiba_n_preciocompra()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Acopio_Precios_Estiba_n_preciocompra_Update";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_sel;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_sel");
                _dato.Decimal = n_preciocompra;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "n_preciocompra");

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
