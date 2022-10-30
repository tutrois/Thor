using System.ComponentModel;

namespace Thor.Helpes
{
    public class EnumHelper
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
