using System;

namespace PoConverter
{
    public static class MessageHelper
    {
        public static void ShowInfo(string message)
        {
            Console.WriteLine("Information: "+ message);
        }

        public static void ShowWarning(string message)
        {
            Console.WriteLine("Warning: "+ message);
        }

        public static void ShowError(string message)
        {
            Console.WriteLine("Error: "+ message);
        }
    }
}
