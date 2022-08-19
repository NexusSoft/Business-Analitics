using System;

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
        public string Id_TipoCamion { get; set; }

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
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
                _dato.Texto = Nombre_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_EmpresaAcarreo");
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
                _dato.Decimal = PrecioA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioA");
                _dato.Decimal = PrecioB;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioB");
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
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Delete";
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
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
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
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
        public void MtdSeleccionarEmpresasCostoServicios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_CostoServicios_Select";
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
                _dato.Texto = Id_TipoCamion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_TipoCamion");
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
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
                _dato.Decimal = Precio_Acarreo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_Acarreo");
                _dato.Decimal = Precio_Caja;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_Caja");
                _dato.Decimal = Precio_SalidaForanea;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_SalidaForanea");
                _dato.Texto = Id_TipoCamion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_TipoCamion");
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
        public void MtdEliminarEmpresasServicios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Servicios_Delete";
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
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
