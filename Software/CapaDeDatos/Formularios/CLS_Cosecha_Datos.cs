using System;

namespace CapaDeDatos
{
    public class CLS_Cosecha_Datos : ConexionBase
    {
        public string Usuario { get; set; }
        //OrdenCorte
        public string Id_Cosecha { get; set; }
        public string ProgramaCorte { get; set; }
        public string ProgramaFecha { get; set; }
        public string Temporada { get; set; }
        public string Mercado { get; set; }
        public string Huerta { get; set; }
        public string Acopiador { get; set; }
        public int ProgramaCajas { get; set; }
        public string TipoCorte { get; set; }
        //Recepcion
        public string OrdendeCorte { get; set; }
        public string Secuencia { get; set; }
        public string RecepcionCodigo { get; set; }
        public string TicketPesada { get; set; }
        public string EstibadeSeleccion { get; set; }
        public decimal CajasCortadas { get; set; }
        public decimal KilosCortados { get; set; }
        public decimal KilosPromedio { get; set; }
        public string TipoCultivo { get; set; }
        public string RecepcionFecha { get; set; }
        public string Id_EmpresaBascula { get; set; }
        public string Nombre_EmpresaBascula { get; set; }
        public decimal KilosBasculaExterna { get; set; }
        public int TomarkgProductor { get; set; }
        public decimal KilosDiferencia { get; set; }
        public decimal Ajuste { get; set; }
        public decimal KilosST { get; set; }
        public decimal KilosProductor { get; set; }
        //Comercializadora
        public string Id_EmpresaComercializacion { get; set; }
        public string Nombre_EmpresaComercializacion { get; set; }
        public string Nombre_Contacto { get; set; }
        public string Telefono_Contacto { get; set; }
        public string Email_Contacto { get; set; }
        public byte[] Contrato { get; set; }
        public string d_Contrato { get; set; }
        //Productor
        public string Productor { get; set; }
        public decimal KilosAjustados { get; set; }
        public decimal KilosMuestra { get; set; }
        public int Exportacion { get; set; }
        public decimal KilosaPagar { get; set; }
        public decimal Preciokg { get; set; }
        public decimal TotalaPagar { get; set; }
        public string Observaciones { get; set; }
        //Corte
        public string Id_EmpresaCorte { get; set; }
        public string Nombre_EmpresaCorte { get; set; }
        public string TipodeCorte { get; set; }
        public decimal KilosCortadosC { get; set; }
        public decimal KilosAjustadosC { get; set; }
        public decimal PrecioporKilo { get; set; }
        public decimal Preciodecosecha { get; set; }
        public decimal PrecioporDia { get; set; }
        public decimal SalidaenFalso { get; set; }
        public int SalidaenFalsoB { get; set; }
        public decimal CuadrillaApoyo { get; set; }
        public int CuadrillaApoyoB { get; set; }
        public decimal Margen5p { get; set; }
        public decimal KilosnoSolicitados { get; set; }
        public decimal KilosaAjustar { get; set; }
        public int CajasCortadasC { get; set; }
        public decimal TotalaPagarC { get; set; }
        //Acarreo
        public string Id_EmpresaAcarreo { get; set; }
        public string Nombre_EmpresaAcarreo { get; set; }
        public string Id_Camion { get; set; }
        public string Nombre_Camion { get; set; }
        public string Placas { get; set; }
        public string Id_Chofer { get; set; }
        public string Nombre_Chofer { get; set; }
        public decimal CajasProgramadas { get; set; }
        public decimal CajasCortadasA { get; set; }
        public decimal CostoServicio { get; set; }
        public int CostoServicioB { get; set; }
        public decimal CajasExtras { get; set; }
        public decimal CostoCajasExtras { get; set; }
        public decimal TotalAcarreo { get; set; }
        public string c_codigo_hue { get; set; }
        public decimal CargosExtras { get; set; }
        public decimal PreciokgInicial { get; set; }
        public decimal Descuentos { get; set; }
        public int PrecioporKiloB { get; set; }
        public int TomarkgenCorte { get; set; }
        public int Cerrado { get; set; }
        public string Id_TipoCamion { get; set; }
        public string Nombre_TipoCamion { get; set; }
        public string SAGARPA { get; set; }
        public string Estado_Huerta { get; set; }
        public int Autorizado_USA { get; set; }
        public string Poliza_aseguradora { get; set; }
        public string Aseguradora { get; set; }

        public void MtdInsertarOrdencorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_OrdenCorte_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = ProgramaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "ProgramaCorte");
                _dato.Texto = ProgramaFecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "ProgramaFecha");
                _dato.Texto = Temporada;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Temporada");
                _dato.Texto = Mercado;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Mercado");
                _dato.Texto = c_codigo_hue;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_hue");
                _dato.Texto = Huerta;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Huerta");
                _dato.Texto = SAGARPA;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "SAGARPA");
                _dato.Texto = Estado_Huerta;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Estado_Huerta");
                _dato.Texto = Acopiador;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Acopiador");
                _dato.Entero = ProgramaCajas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ProgramaCajas");
                _dato.Texto = TipoCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "TipoCorte");
                _dato.Texto = Poliza_aseguradora;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Poliza_aseguradora");
                _dato.Texto = Aseguradora;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Aseguradora");
                _dato.Entero = Autorizado_USA;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Autorizado_USA");
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
        public void MtdModificarCerradoOrdenCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_CerrarOrdenCorte_Update";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Cerrado;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cerrado");
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
        public void MtdInsertarRecepcion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Recepcion_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = OrdendeCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "OrdendeCorte");
                _dato.Texto = Secuencia;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Secuencia");
                _dato.Texto = RecepcionCodigo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "RecepcionCodigo");
                _dato.Texto = TicketPesada;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "TicketPesada");
                _dato.Texto = EstibadeSeleccion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "EstibadeSeleccion");
                _dato.Decimal = CajasCortadas;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "CajasCortadas");
                _dato.Decimal = KilosCortados;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosCortados");
                _dato.Decimal = KilosPromedio;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosPromedio");
                _dato.Texto = TipoCultivo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "TipoCultivo");
                _dato.Texto = RecepcionFecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "RecepcionFecha");
                _dato.Texto = Id_EmpresaBascula;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaBascula");
                _dato.Texto = Nombre_EmpresaBascula;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_EmpresaBascula");
                _dato.Decimal = KilosBasculaExterna;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosBasculaExterna");
                _dato.Entero = TomarkgProductor;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "TomarkgProductor");
                _dato.Entero = TomarkgenCorte;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "TomarkgenCorte");
                _dato.Decimal = KilosDiferencia;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosDiferencia");
                _dato.Decimal = Ajuste;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Ajuste");
                _dato.Decimal = KilosST;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosST");
                _dato.Decimal = KilosProductor;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosProductor");
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
        public void MtdModificarCerradoRecepcion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_CerrarRecepcion_Update";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Cerrado;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cerrado");
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
        public void MtdInsertarComercializadora()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Comercializadora_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = Id_EmpresaComercializacion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaComercializacion");
                _dato.Texto = Nombre_EmpresaComercializacion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_EmpresaComercializacion");
                _dato.Texto = Nombre_Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Contacto");
                _dato.Texto = Telefono_Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Telefono_Contacto");
                _dato.Texto = Email_Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Email_Contacto");
                _dato.Archivo = Contrato;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "Contrato");
                _dato.Texto = d_Contrato;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "d_Contrato");
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
        public void MtdEliminarContratoComercializadora()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_ComercializadoraContrato_Delete";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Archivo = Contrato;
                _conexion.agregarParametro(EnumTipoDato.Archivo, _dato, "Contrato");
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
        public void MtdModificarCerradoComercializadora()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_CerrarComercializadora_Update";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Cerrado;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cerrado");
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
        public void MtdInsertarProductor()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Productor_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = Productor;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Productor");
                _dato.Decimal = KilosAjustados;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosAjustados");
                _dato.Decimal = KilosMuestra;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosMuestra");
                _dato.Entero = Exportacion;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Exportacion");
                _dato.Decimal = KilosaPagar;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosaPagar");
                _dato.Decimal = PreciokgInicial;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PreciokgInicial");
                _dato.Decimal = Preciokg;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Preciokg");
                _dato.Decimal = TotalaPagar;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "TotalaPagar");
                _dato.Texto = Observaciones;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Observaciones");
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
        public void MtdModificarCerradoProductor()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_CerrarProductor_Update";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Cerrado;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cerrado");
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
        public void MtdInsertarCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Corte_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaCorte");
                _dato.Texto = Nombre_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_EmpresaCorte");
                _dato.Texto = TipodeCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "TipodeCorte");
                _dato.Decimal = KilosCortadosC;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosCortados");
                _dato.Decimal = KilosAjustadosC;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosAjustados");
                _dato.Decimal = PrecioporKilo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioporKilo");
                _dato.Decimal = PrecioporKiloB;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioporKiloB");
                _dato.Decimal = Preciodecosecha;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Preciodecosecha");
                _dato.Decimal = PrecioporDia;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioporDia");
                _dato.Decimal = SalidaenFalso;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "SalidaenFalso");
                _dato.Decimal = SalidaenFalsoB;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "SalidaenFalsoB");
                _dato.Decimal = CuadrillaApoyo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "CuadrillaApoyo");
                _dato.Entero = CuadrillaApoyoB;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "CuadrillaApoyoB");
                _dato.Decimal = Margen5p;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Margen5p");
                _dato.Decimal = KilosnoSolicitados;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosnoSolicitados");
                _dato.Decimal = KilosaAjustar;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "KilosaAjustar");
                _dato.Entero = CajasCortadasC;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "CajasCortadas");
                _dato.Decimal = TotalaPagarC;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "TotalaPagar");
                _dato.Texto = Observaciones;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Observaciones");
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
        public void MtdModificarCerradoCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_CerrarCorte_Update";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Cerrado;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cerrado");
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
        public void MtdInsertarAcarreo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Acarreo_Insert";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Texto = Id_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaAcarreo");
                _dato.Texto = Nombre_EmpresaAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_EmpresaAcarreo");
                _dato.Texto = Id_Camion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Camion");
                _dato.Texto = Nombre_Camion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Camion");
                _dato.Texto = Placas;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Placas");
                _dato.Texto = Id_TipoCamion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_TipoCamion");
                _dato.Texto = Nombre_TipoCamion;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_TipoCamion");
                _dato.Texto = Id_Chofer;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Chofer");
                _dato.Texto = Nombre_Chofer;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Chofer");
                _dato.Decimal = CajasProgramadas;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "CajasProgramadas");
                _dato.Decimal = CajasCortadasA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "CajasCortadas");
                _dato.Decimal = CostoServicio;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "CostoServicio");
                _dato.Entero = CostoServicioB;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "CostoServicioB");
                _dato.Decimal = CajasExtras;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "CajasExtras");
                _dato.Decimal = CostoCajasExtras;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "CostoCajasExtras");
                _dato.Decimal = CargosExtras;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "CargosExtras");
                _dato.Decimal = Descuentos;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Descuentos");
                _dato.Decimal = TotalAcarreo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "TotalAcarreo");
                _dato.Texto = Observaciones;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Observaciones");
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
        public void MtdModificarCerradoAcarreo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_CerrarAcarreo_Update";
                _dato.Texto = Id_Cosecha;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cosecha");
                _dato.Entero = Cerrado;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cerrado");
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

        public void MtdSelecccionarGOrdencorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Select";
                _dato.Texto = Temporada;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Temporada");
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
        public void MtdSelecccionarOrdencorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_GOrdenCorte_Select";
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
        public void MtdSelecccionarRecepcion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_GRecepcion_Select";
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
        public void MtdSelecccionarComercializadora()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_GComercializadora_Select";
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
        public void MtdSelecccionarProductor()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_GProductor_Select";
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
        public void MtdSelecccionarCorte()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_GCorte_Select";
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
        public void MtdSelecccionarAcarreo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_GAcarreo_Select";
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
