namespace Helpers
{
    public static class Order
    {
        public static string Alphabetically(string input)
        {
            var sortedChars = input.OrderBy(c => char.ToLower(c)).ToArray();
            return new string(sortedChars);
        }
    }
}