using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_EmpresasComercializadora_Contacto : ConexionBase
    {
        public string Id_Contacto { get; set; }
        public string Nombre_Contacto { get; set; }
        public string Telefono_Contacto { get; set; }
        public string Email_Contacto { get; set; }
        public string Id_EmpresaComercializacion { get; set; }
        public string c_codigo_hue { get; set; }
        public string Usuario { get; set; }

        public void MtdSeleccionarContacto()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Contacto_Select";
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
        public void MtdInsertarContacto()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Contacto_Insert";
                _dato.Texto = Id_Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Contacto");
                _dato.Texto = Nombre_Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Contacto");
                _dato.Texto = Telefono_Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Telefono_Contacto");
                _dato.Texto = Email_Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Email_Contacto");
                _dato.Texto = Id_EmpresaComercializacion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaComercializacion");
                _dato.Texto = c_codigo_hue;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_hue");
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
        public void MtdEliminarContacto()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Contacto_Delete";
                _dato.Texto = Id_Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Contacto");
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
        public void MtdSeleccionarContactoEmpresa()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Contacto_Empresa_Select";
                _dato.Texto = Id_EmpresaComercializacion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaComercializacion");
                _dato.Texto = c_codigo_hue;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_hue");
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
