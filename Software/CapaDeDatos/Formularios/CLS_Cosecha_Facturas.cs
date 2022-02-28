using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Cosecha_Facturas : ConexionBase
    {
        public string Id_Cosecha { get; set; }
        public string RazonSocial { get; set; }
        public byte[] FacturaPDF { get; set; }
        public byte[] FacturaXML { get; set; }
        public int Diferido { get; set; }
        public string FolioFactura { get; set; }
        public string Moneda { get; set; }
        public decimal Importe_Factura { get; set; }
        public int Pagada { get; set; }
        public string Fecha_Factura { get; set; }
        public string Fecha_Pago { get; set; }
        public int Id_Archivo { get; set; }
        public string Usuario { get; set; }
        public int Retencion { get; set; }
        public decimal Importe_Retencion { get; set; }
        public decimal Total_Factura { get; set; }
        public int IVA { get; set; }
        public decimal Importe_IVA { get; set; }
        public int Retencion_Flete { get; set; }
        public decimal Importe_Retencion_Flete { get; set; }

        public void MtdSeleccionarCosechaArchivoPDFXML()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Facturas_PDFXML_Select";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Id_Archivo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Id_Archivo");
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
        public void MtdSeleccionarCosechaArchivoPDFXMLView()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Facturas_PDFXML_Select";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Id_Archivo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Id_Archivo");
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
        public void MtdInsertarCosechaArchivoPDFXML()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Facturas_PDFXML_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Id_Archivo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Id_Archivo");
                _dato.Texto = RazonSocial;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "RazonSocial");
                _dato.Archivo = FacturaPDF;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "FacturaPDF");
                _dato.Archivo = FacturaXML;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "FacturaXML");
                _dato.Entero = Diferido;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Diferido");
                _dato.Texto = FolioFactura;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "FolioFactura");
                _dato.Texto = Moneda;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Moneda");
                _dato.Decimal = Importe_Factura;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Importe_Factura");
                _dato.Entero = Pagada;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Pagada");
                _dato.Entero = Retencion;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Retencion");
                _dato.Decimal = Importe_Retencion;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Importe_Retencion");
                _dato.Entero = Retencion_Flete;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Retencion_Flete");
                _dato.Decimal = Importe_Retencion_Flete;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Importe_Retencion_Flete");
                _dato.Entero = IVA;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "IVA");
                _dato.Decimal = Importe_IVA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Importe_IVA");
                _dato.Decimal = Total_Factura;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Total_Factura");
                _dato.Texto = Fecha_Factura;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Factura");
                _dato.Texto = Fecha_Pago;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Pago");
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
        public void MtdDeleteCosechaArchivoPDFXML()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Facturas_PDFXML_Delete";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Id_Archivo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Id_Archivo");
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
