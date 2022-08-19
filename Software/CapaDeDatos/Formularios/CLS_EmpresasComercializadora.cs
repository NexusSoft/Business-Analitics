using System;

namespace CapaDeDatos
{
    public class CLS_EmpresasComercializadora : ConexionBase
    {
        public string Id_EmpresaComercializacion { get; set; }
        public string Nombre_EmpresaComercializacion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public string RFC { get; set; }
        public string Usuario { get; set; }

        public void MtdSeleccionarEmpresas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Select";

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
        public void MtdInsertarEmpresas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Insert";
                _dato.Texto = Id_EmpresaComercializacion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaComercializacion");
                _dato.Texto = Nombre_EmpresaComercializacion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_EmpresaComercializacion");
                _dato.Texto = Telefono1;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Telefono1");
                _dato.Texto = Telefono2;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Telefono2");
                _dato.Texto = Email;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Email");
                _dato.Texto = Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Contacto");
                _dato.Texto = RFC;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "RFC");
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
        public void MtdEliminarEmpresas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Delete";
                _dato.Texto = Id_EmpresaComercializacion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaComercializacion");
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
