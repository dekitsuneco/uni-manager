namespace MTP_UManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run ()
        {
            System.Console.ForegroundColor = System.ConsoleColor.White;
            PageManager.MakeLoginPage();
            PageManager.MakeMainPage();
        }
    }
}
