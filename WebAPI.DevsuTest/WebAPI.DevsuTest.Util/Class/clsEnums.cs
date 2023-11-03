using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.DevsuTest.Util.Class
{
    public class clsEnums
    {
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        [SwaggerSchema(Title = "Capa Origen del Error", Description = "0: NoAsignada, 1: CapaControlador, 2: CapaServicio, 3: CapaRepositorio, 4: BaseDatos", Format = "byte")]
        [SwaggerSchemaExample("1")]
        public enum ENCapaOrigenLogError : byte
        {
            [EnumMember(Value = "0")] NoAsignada = 0,
            [EnumMember(Value = "1")] CapaControlador = 1,
            [EnumMember(Value = "2")] CapaServicio = 2,
            [EnumMember(Value = "3")] CapaRepositorio = 3,
            [EnumMember(Value = "4")] BaseDatos = 4
        }
    }
}