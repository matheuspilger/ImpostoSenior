namespace ImpostoSenior.Domain.Helpers
{
    public static class IntHelper
    {
        public static bool StartsWith(this int value, int startsWith)
            => value.ToString().StartsWith(startsWith.ToString());
    }
}
