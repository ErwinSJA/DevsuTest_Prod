using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DevsuTest.Models.Persona
{
    public class ModelPersona
    {
        [Column("intIdPersona")] public int intIdPersona { set; get; } = 0;
        [Column("vchIdentificacion")] public string strIdentificacion { set; get; } = string.Empty;
        [Column("vchNombre")] public string strNombre { set; get; } = string.Empty;
        [Column("tinGenero")] public byte bytGenero { set; get; } = 0;
        [Column("vchGenero")] public string strGenero { set; get; } = string.Empty;
        [Column("intEdad")] public int intEdad { set; get; } = 0;        
        [Column("vchDireccion")] public string strDireccion { set; get; } = string.Empty;
        [Column("vchTelefono")] public string strTelefono { set; get; } = string.Empty;
    }
}
