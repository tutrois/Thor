using System.ComponentModel;

namespace Thor.Enums
{
    public enum StatusTicket
    {
        [Description("Em Aberto")]
        Ativo,
        [Description("Em andamento")]
        EmAndamento,
        [Description("Concluído")]
        Concluido,
        [Description("Cancelado")]
        Cancelado
    }
}
