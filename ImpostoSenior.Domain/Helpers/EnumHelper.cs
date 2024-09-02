using System.ComponentModel;

namespace ImpostoSenior.Domain.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription<TEnum>(this TEnum source)
        {
            var fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
