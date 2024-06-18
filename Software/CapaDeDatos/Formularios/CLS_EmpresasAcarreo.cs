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
        public string Id_EmpresaAcarreo_Zona { get; set; }
        public string v_nombre_zona { get; set; }

        //Precios
        public string Id_EmpresaAcarreo_Precios { get; set; }
        public string c_codigo_est { get; set; }
        public string v_nombre_est { get; set; }
        public string c_codigo_ciu { get; set; }
        public string v_nombre_ciu { get; set; }
        public decimal Km { get; set; }
        public decimal Rabon { get; set; }
        public decimal Torton { get; set; }
        public decimal Contenedor { get; set; }
        public decimal kgRabon { get; set; }
        public decimal kgTorton { get; set; }
        public decimal kgContenedor { get; set; }
        public string c_codigo_hue { get; set; }

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
        // Zonas
        public void MtdSeleccionarEmpresasZonas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Zona_Select";

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
        public void MtdInsertarEmpresasZonas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Zona_Insert";
                _dato.Texto = Id_EmpresaAcarreo_Zona;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo_Zona");
                _dato.Texto = v_nombre_zona;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_zona");

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
        public void MtdEliminarEmpresasZonas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Zona_Delete";
                _dato.Texto = Id_EmpresaAcarreo_Zona;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo_Zona");
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
        // Precios
        public void MtdSeleccionarEmpresasPrecios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Precio_Select";

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
        public void MtdInsertarEmpresasPrecios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Precio_Insert";
                _dato.Texto = Id_EmpresaAcarreo_Precios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo_Precios");
                _dato.Texto = Id_EmpresaAcarreo_Zona;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo_Zona");
                _dato.Texto = c_codigo_est;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_est");
                _dato.Texto = v_nombre_est;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_est");
                _dato.Texto = c_codigo_ciu;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_ciu");
                _dato.Texto = v_nombre_ciu;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "v_nombre_ciu");
                _dato.Decimal = Km;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Km");
                _dato.Decimal = Rabon;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Rabon");
                _dato.Decimal = Torton;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Torton");
                _dato.Decimal = Contenedor;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Contenedor");
                _dato.Decimal = kgRabon;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "kgRabon");
                _dato.Decimal = kgTorton;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "kgTorton");
                _dato.Decimal = kgContenedor;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "kgContenedor");
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
        public void MtdEliminarEmpresasPrecios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Precio_Delete";
                _dato.Texto = Id_EmpresaAcarreo_Precios;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo_Precios");
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
        //Estado - Ciudad
        public void MtdSeleccionarEmpresasEstado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Estado_Select";
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
        public void MtdSeleccionarEmpresasCiudad()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Acarreo_Ciudad_Select";
                _dato.Texto = c_codigo_est;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_est");
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
