using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thor.Data.Enums
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
