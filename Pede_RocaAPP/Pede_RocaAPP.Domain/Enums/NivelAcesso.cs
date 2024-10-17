using System.Runtime.Serialization;

namespace Pede_RocaAPP.Domain.Enums
{
    public enum NivelAcesso
    {
        [EnumMember(Value = "comum")]
        Comum,

        [EnumMember(Value = "adm")]
        Adm,

        [EnumMember(Value = "produtor")]
        Produtor,

        [EnumMember(Value = "assinante")]
        Assinante,

        [EnumMember(Value = "entregador")]
        Entregador,

        [EnumMember(Value = "god")]
        God
    }
}