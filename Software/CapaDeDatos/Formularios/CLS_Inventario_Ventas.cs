using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Inventario_Ventas : ConexionBase
    {
        public string Id_Registro { get; set; }
        public string Fecha { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Id_Pais { get; set; }
        public string Id_Tratamiento { get; set; }
        public string Id_Categoria { get; set; }
        public string Id_Tamanio { get; set; }
        public decimal Volumen { get; set; }
        public decimal Venta { get; set; }
        public string Usuario { get; set; }

        public void MtdSeleccionarInventario_Ventas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Ventas_Select";
                _dato.Texto = Fecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha");
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

        public void MtdInsertarInventario_Ventas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Ventas_Insert";
                _dato.Texto = Id_Registro;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Registro");
                _dato.Texto = Fecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha");
                _dato.Texto = Id_Pais;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Pais");
                _dato.Texto = Id_Tratamiento;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Tratamiento");
                _dato.Texto = Id_Categoria;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Categoria");
                _dato.Texto = Id_Tamanio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Tamanio");
                _dato.Decimal = Volumen;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Volumen");
                _dato.Decimal = Venta;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Venta");
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

        public void MtdEliminarInventario_Ventas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Ventas_Delete";
                _dato.Texto = Id_Registro;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Registro");
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
        public void MtdSeleccionarInventario_Historico()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Inventario_Historico_select";
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
    }
}
