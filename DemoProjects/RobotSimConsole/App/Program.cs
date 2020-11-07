using System;
using System.IO;
using RobotSimApp.Controllers;
using RobotSimApp.Models;

namespace RobotSimApp
{
    class Program
    {
        static int BUFFERSIZE = 25;
        static RobotSimController robotSimContoller;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Robot Simulator. Type 'q' to Quit!");
            bool waitForInput = true;
            var input = string.Empty;
            
            try
            {
                robotSimContoller = new RobotSimController(new Table(), new Robot());
                Stream inStream = Console.OpenStandardInput(BUFFERSIZE);

                while (waitForInput)
                {
                    Console.Write("% ");
                    Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, BUFFERSIZE));
                    input = Console.ReadLine().Trim();

                    waitForInput = ProcessUserInput(input);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception running program: {0}", ex.Message);
            }
            
            
        }

        private static bool ProcessUserInput(string input){
            bool waitForInput = true;

            input = input.ToLower();

            if (input.Contains("place")){

                var args = input.Substring(input.IndexOf(" ")).Split(",");

                if (args.Length < 3)
                {
                    Console.WriteLine("Invalid argument count or format");
                    return true;
                }

                var x = ParseNumber(args[0]);
                var y = ParseNumber(args[1]);
                var f = ParseOrientation(args[2].Trim());

                if (x == null || y == null || f == null){
                    Console.WriteLine("Invalid arguments: {0}", string.Join(", ", args));
                    return waitForInput;
                }
                

                robotSimContoller.Place(x.Value, y.Value, f);
            }
            else if (input.Contains("move")){
                robotSimContoller.Move();
            }
            else if (input.Contains("left")){
                robotSimContoller.Left();
            }
            else if (input.Contains("right")){
                robotSimContoller.Right();
            }
            else if (input.Contains("report")){
                Console.WriteLine("{0}", robotSimContoller.Report());
            }
            else if (input.Contains("q")){
                waitForInput = false;
            }

            return waitForInput; 
        }

        private static int? ParseNumber(string arg){

            int retval;
            bool isValid = int.TryParse(arg, out retval);
            
            if (isValid == false)
                return null;
            else 
                return retval;
        }

        private static string ParseOrientation(string arg){

            string retval = string.Empty;

            switch (arg.ToLower()){
                case "north":
                case "east":
                case "south":
                case "west":
                    retval = arg.ToLower();
                    break;
                default:
                    retval = null;
                    break;
            }

            return retval;
        }
    }
}
