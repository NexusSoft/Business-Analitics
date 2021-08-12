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
                _dato.CadenaTexto = Fecha;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha");
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
                _dato.CadenaTexto = Id_Registro;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Registro");
                _dato.CadenaTexto = Fecha;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha");
                _dato.CadenaTexto = Id_Pais;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Pais");
                _dato.CadenaTexto = Id_Tratamiento;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Tratamiento");
                _dato.CadenaTexto = Id_Categoria;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Categoria");
                _dato.CadenaTexto = Id_Tamanio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Tamanio");
                _dato.DecimalValor = Volumen;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Volumen");
                _dato.DecimalValor = Venta;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Venta");
                _dato.CadenaTexto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Usuario");
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
                _dato.CadenaTexto = Id_Tamanio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Registro");
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
