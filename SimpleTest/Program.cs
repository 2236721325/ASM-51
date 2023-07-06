using Complier.Helpers;


namespace SimpleTest


{
    internal class Program
    {
        static void Main(string[] args)
        {
            var byte1 = 0x00;
            var byte2 = 0x02;
            var result = (byte)(byte1 - byte2);
            Console.WriteLine(result.ToString("X2"));

        }
    }
}