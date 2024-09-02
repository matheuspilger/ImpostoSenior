using ImpostoSenior.Domain.Enums.Ecd;
using System.Globalization;

namespace ImpostoSenior.Domain.Helpers
{
    public static class StringHelper
    {
        public static List<string> Values(this string input) 
        {
            return [.. input.Split("|").Skip(1)];
        }

        public static int ToInt(this List<string> values, int position)
        {
            return ToIntNull(values, position).GetValueOrDefault();
        }

        public static int? ToIntNull(this List<string> values, int position)
        {
            if (string.IsNullOrWhiteSpace(values[position])) return null;
            return int.Parse(values[position]);
        }

        public static DateTime ToDateTime(this List<string> values, int position)
        {
            return ToDateTimeNull(values, position).GetValueOrDefault();
        }

        public static DateTime? ToDateTimeNull(this List<string> values, int position)
        {
            if (string.IsNullOrWhiteSpace(values[position])) return null;
            return DateTime.ParseExact(values[position], "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        public static string ToValue(this List<string> values, int position)
        {
            return values[position];
        }

        public static decimal ToDecimal(this List<string> values, int position)
        {
            return decimal.Parse(values[position]);
        }

        public static TEnum GetEnum<TEnum>(this List<string> values, int position) where TEnum : struct, Enum
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), values[position][0]);
        }

        public static bool StartsWithAny(this string value, params string[] filters)
        {
            return filters.Any(filter => value[1..].StartsWith(filter, StringComparison.CurrentCulture));
        }
    }
}
