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
    public string Id_Huerta { get; set; }
    public string Usuario { get; set; }

    public void MtdSeleccionarContacto()
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
    public void MtdInsertarContacto()
    {
        TipoDato _dato = new TipoDato();
        Conexion _conexion = new Conexion(cadenaConexion);

        Exito = true;
        try
        {
            _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Contacto_Insert";
            _dato.CadenaTexto = Id_Contacto;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Contacto");
            _dato.CadenaTexto = Nombre_Contacto;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Contacto");
            _dato.CadenaTexto = Telefono_Contacto;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Telefono_Contacto");
            _dato.CadenaTexto = Email_Contacto;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Email_Contacto");
            _dato.CadenaTexto = Id_EmpresaComercializacion;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaComercializacion");
            _dato.CadenaTexto = Id_Huerta;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Huerta");
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
    public void MtdEliminarContacto()
    {
        TipoDato _dato = new TipoDato();
        Conexion _conexion = new Conexion(cadenaConexion);

        Exito = true;
        try
        {
            _conexion.NombreProcedimiento = "SP_Empresa_Comercializacion_Contacto_Delete";
            _dato.CadenaTexto = Id_Contacto;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Contacto");
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
