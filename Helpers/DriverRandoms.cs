


namespace Helpers
{
    public static class DriverRandoms
    {
        public static string GetRandomName()
        {
            List<string> names = new List<string> { "Amr", "Lura", "Bob", "Eva", "Mo", "Salah" };
            return names[new Random().Next(names.Count)];
        }

        public static string GetRandomEmail()
        {
            return $"{Guid.NewGuid().ToString().Substring(0, 8)}@example.com";
        }

        public static string GetRandomPhoneNumber()
        {
            return $"{RandomNumber(100, 999)}{RandomNumber(100, 999)}{RandomNumber(1000, 9999)}";
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

    }
}