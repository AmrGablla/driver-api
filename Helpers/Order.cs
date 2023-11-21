namespace Helpers
{
    public static class Order
    {
        public static string Alphabetically(string input)
        {
            if (input != null)
            {
                var sortedChars = input.OrderBy(c => char.ToLower(c)).ToArray();
                return new string(sortedChars);
            }
            return string.Empty;
        }
    }
}