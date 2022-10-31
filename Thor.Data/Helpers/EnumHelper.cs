using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thor.Data.Helpers
{
    internal class EnumHelper
    {
        public static string GetDescription(System.Enum @enum)
        {
            var type = @enum.GetType();
            var memInfo = type.GetMember(@enum.ToString());

            if (memInfo.Length <= 0)
                return @enum.ToString();

            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : @enum.ToString();
        }
    }
}
