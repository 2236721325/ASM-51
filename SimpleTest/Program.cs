using Complier.Helpers;


namespace SimpleTest


{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse("01f2f", System.Globalization.NumberStyles.AllowHexSpecifier);
            var bytes = ByteHelper.Zip(BitConverter.GetBytes(num));

            Console.WriteLine(bytes.GetString());

        }
    }
}