using System;

namespace CapaDeDatos
{
    public class CLS_Cosecha_Expedientes : ConexionBase
    {
        public string Id_Cosecha { get; set; }
        public int Id_Doc { get; set; }
        public byte[] ArchivoPDF { get; set; }
        public byte[] TarjetaApeam { get; set; }
        public byte[] Identificacion_INE_IFE { get; set; }
        public byte[] Opinion_Cumplimiento { get; set; }
        public byte[] Constancia_de_Situacion_Fiscal { get; set; }
        public byte[] Clave_Interbancaria { get; set; }
        public byte[] Contrato_entre_Terceros { get; set; }
        public byte[] Contrato_GEST { get; set; }
        public string d_TarjetaApeam { get; set; }
        public string d_Identificacion_INE_IFE { get; set; }
        public string d_Opinion_Cumplimiento { get; set; }
        public string d_Constancia_de_Situacion_Fiscal { get; set; }
        public string d_Clave_Interbancaria { get; set; }
        public string d_Contrato_entre_Terceros { get; set; }
        public string d_Contrato_GEST { get; set; }
        public string Usuario { get; set; }

        public void MtdSeleccionarCosechaArchivoPDFXML()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Expedientes_PDF_Select";
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
        public void MtdSeleccionarCosechaArchivoPDFXMLView()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Expediente_PDF_Select";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Id_Doc;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Id_Doc");
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
                _conexion.NombreProcedimiento = "SP_Cosecha_Expedientes_PDF_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");

                _dato.Archivo = TarjetaApeam;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "TarjetaApeam");

                _dato.Texto = d_TarjetaApeam;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_TarjetaApeam");

                _dato.Archivo = Identificacion_INE_IFE;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "Identificacion_INE_IFE");

                _dato.Texto = d_Identificacion_INE_IFE;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_Identificacion_INE_IFE");

                _dato.Archivo = Opinion_Cumplimiento;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "Opinion_Cumplimiento");

                _dato.Texto = d_Opinion_Cumplimiento;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_Opinion_Cumplimiento");

                _dato.Archivo = Constancia_de_Situacion_Fiscal;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "Constancia_de_Situacion_Fiscal");

                _dato.Texto = d_Constancia_de_Situacion_Fiscal;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_Constancia_de_Situacion_Fiscal");

                _dato.Archivo = Clave_Interbancaria;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "Clave_Interbancaria");

                _dato.Texto = d_Clave_Interbancaria;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_Clave_Interbancaria");

                _dato.Archivo = Contrato_entre_Terceros;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "Contrato_entre_Terceros");

                _dato.Texto = d_Contrato_entre_Terceros;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_Contrato_entre_Terceros");

                _dato.Archivo = Contrato_GEST;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "Contrato_GEST");

                _dato.Texto = d_Contrato_GEST;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_Contrato_GEST");
                _dato.Texto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Usuario");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                    string valor = Datos.Rows[0][0].ToString();
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
                _conexion.NombreProcedimiento = "SP_Cosecha_Expedientes_PDF_Delete";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Id_Doc;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Id_Doc");
                _dato.Archivo = ArchivoPDF;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "ArchivoPDF");
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
    }
}
