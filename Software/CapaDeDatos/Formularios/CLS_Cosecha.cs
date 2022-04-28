using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Cosecha : ConexionBase
    {
        public string c_codigo_tem { get; set; }
        public string c_codigo_pco { get; set; }
        public string c_codigo_oct { get; set; }
        public string c_secuencia_ocd { get; set; }
        public string d_fecha_pco { get; set; }
        public string v_registro_hue { get; set; }
        public string v_nombre_hue { get; set; }
        public string v_nombre_dno { get; set; }
        public string n_cajas_pcd { get; set; }
        public string c_danio_pcd { get; set; }
        public string c_mercado_pcd { get; set; }
        public string v_tipocorte_pcd { get; set; }
        public string c_codigo_zon { get; set; }
        public string v_nombre_zon { get; set; }

        public void MtdSeleccionarPrograma()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_ProgramaCorte_Select";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_pco;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_pco");
                _dato.Texto = c_codigo_oct;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_oct");
                _dato.Texto = c_secuencia_ocd;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_secuencia_ocd");
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
        public void MtdSeleccionarRecepcion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Cosecha_Recepcion_Select";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _dato.Texto = c_codigo_oct;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_oct");
                _dato.Texto = c_secuencia_ocd;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_secuencia_ocd");
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
        
        //public void MtdInsertarCultivo()
        //{
        //    TipoDato _dato = new TipoDato();
        //    Conexion _conexion = new Conexion(cadenaConexion);

        //    Exito = true;
        //    try
        //    {
        //        _conexion.NombreProcedimiento = "SP_Cultivo_Insert";
        //        _dato.Texto = Id_Cultivo;
        //        _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cultivo");
        //        _dato.Texto = Nombre_Cultivo;
        //        _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Cultivo");
        //        _dato.Texto = Id_Usuario;
        //        _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Usuario");
        //        _conexion.EjecutarDataset();

        //        if (_conexion.Exito)
        //        {
        //            Datos = _conexion.Datos;
        //        }
        //        else
        //        {
        //            Mensaje = _conexion.Mensaje;
        //            Exito = false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Mensaje = e.Message;
        //        Exito = false;
        //    }
        //}
        //public void MtdEliminarCultivo()
        //{
        //    TipoDato _dato = new TipoDato();
        //    Conexion _conexion = new Conexion(cadenaConexion);

        //    Exito = true;
        //    try
        //    {
        //        _conexion.NombreProcedimiento = "SP_Cultivo_Delete";
        //        _dato.Texto = Id_Cultivo;
        //        _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Cultivo");
        //        _dato.Texto = Id_Usuario;
        //        _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Usuario");
        //        _dato.Texto = Activo;
        //        _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Activo");
        //        _conexion.EjecutarDataset();

        //        if (_conexion.Exito)
        //        {
        //            Datos = _conexion.Datos;
        //        }
        //        else
        //        {
        //            Mensaje = _conexion.Mensaje;
        //            Exito = false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Mensaje = e.Message;
        //        Exito = false;
        //    }
        //}

    }
}
