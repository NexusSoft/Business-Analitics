using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_EmpresasAcarreo : ConexionBase
    {
        public string Id_EmpresaAcarreo { get; set; }
        public string Nombre_EmpresaAcarreo { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public string RFC { get; set; }
        public string Usuario { get; set; }
        public decimal PrecioA { get; set; }
        public decimal PrecioB { get; set; }
        public decimal Precio_Acarreo { get; set; }
        public decimal Precio_Caja { get; set; }
        public decimal Precio_SalidaForanea { get; set; }

        public void MtdSeleccionarEmpresas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Select";

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
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Insert";
                _dato.CadenaTexto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaAcarreo");
                _dato.CadenaTexto = Nombre_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_EmpresaAcarreo");
                _dato.CadenaTexto = Telefono1;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Telefono1");
                _dato.CadenaTexto = Telefono2;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Telefono2");
                _dato.CadenaTexto = Email;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Email");
                _dato.CadenaTexto = Contacto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Contacto");
                _dato.CadenaTexto = RFC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "RFC");
                _dato.DecimalValor = PrecioA;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "PrecioA");
                _dato.DecimalValor = PrecioB;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "PrecioB");
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
        public void MtdEliminarEmpresas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Delete";
                _dato.CadenaTexto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaAcarreo");
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
        // Servicios
        public void MtdSeleccionarEmpresasServicios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Servicios_Select";
                _dato.CadenaTexto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaAcarreo");
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
        public void MtdInsertarEmpresasServicios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Servicios_Insert";
                _dato.CadenaTexto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaAcarreo");
                _dato.DecimalValor = Precio_Acarreo;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_Acarreo");
                _dato.DecimalValor = Precio_Caja;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_Caja");
                _dato.DecimalValor = Precio_SalidaForanea;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_SalidaForanea");
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
        public void MtdEliminarEmpresasServicios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Servicios_Delete";
                _dato.CadenaTexto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaAcarreo");
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
