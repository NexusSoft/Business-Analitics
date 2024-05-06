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
        //Acopio Precios
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

    }
}
