using System;

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
        public string Fecha_Programacion { get; set; }
        //REP
        public string UUID { get; set; }
        public decimal FacturaTotal { get; set; }
        public string MetodoPago { get; set; }
        public decimal SubTotalXML { get; set; }
        public decimal TotalXML { get; set; }
        //Facturas
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
                _dato.Texto = Fecha_Programacion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Fecha_Programacion");
                _dato.Texto = UUID;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "UUID");
                _dato.Texto = MetodoPago;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "MetodoPago");
                _dato.Decimal = SubTotalXML;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "SubTotalXML");
                _dato.Decimal = TotalXML;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "TotalXML");
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
                _dato.Archivo = FacturaPDF;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "FacturaPDF");
                _dato.Archivo = FacturaXML;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "FacturaXML");
                _dato.Entero = Id_Archivo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Id_Archivo");
                _dato.Texto = UUID;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "UUID");
                _dato.Texto = MetodoPago;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "MetodoPago");
                _dato.Decimal = SubTotalXML;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "SubTotalXML");
                _dato.Decimal = TotalXML;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "TotalXML");
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
        //REP
        public void MtdSeleccionarCosechaArchivoREP_PDFXML()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_FacturasREP_PDFXML_Select";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
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
        public void MtdSeleccionarCosechaArchivoREP_PDFXMLView()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_FacturaREP_PDFXML_Select";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = UUID;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "UUID");
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
        public void MtdSeleccionarCosechaTotalREP()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_TotalREP_Select";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
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
        public void MtdInsertarCosechaArchivoREP_PDFXML()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_FacturasREP_PDFXML_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = UUID;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "UUID");
                _dato.Archivo = FacturaPDF;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "FacturaPDF");
                _dato.Archivo = FacturaXML;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "FacturaXML");
                _dato.Decimal = FacturaTotal;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "FacturaTotal");
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
        public void MtdDeleteCosechaArchivoREP_PDFXML()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_FacturasREP_PDFXML_Delete";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = UUID;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "UUID");
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
        public void MtdDeleteCosechaTodosArchivoREP_PDFXML()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_FacturasREPTodas_PDFXML_Delete";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
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
