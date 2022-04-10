using System.ComponentModel;

namespace NetcareDoctorsClient
{
    public class StaticClass
    {
        public static class EnumHelper
        {
            public static string GetEnumDescription(Enum enumValue)
            {
                return FirmamentUtilities.Utilities.GetEnumDescription(enumValue);
            }

            public enum MessageSymbol
            {
                [Description("i")]
                Information,
                [Description("x")]
                Error
            }

            public enum ApplicationUserType
            {
                [Description("Administrator")]
                Administrator,
                [Description("GeneralUser")]
                GeneralUser
            }
        }
    }
}
