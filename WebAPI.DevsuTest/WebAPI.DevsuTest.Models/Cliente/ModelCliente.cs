using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.DevsuTest.Models.Persona;

namespace WebAPI.DevsuTest.Models.Cliente
{
    public class ModelCliente : ModelPersona
    {
        [Column("intIdCliente")] public int intIdCliente { set; get; } = 0;
        [Column("vchPasswordSalt")] public string strPasswordSalt { set; get; } = string.Empty;
        [Column("vchPasswordHash")] public string strPasswordHash { set; get; } = string.Empty;
        [Column("bitEstado")] public bool blnEstado { set; get; } = true;
    }
}
