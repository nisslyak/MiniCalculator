using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace MiniCalculator
{
    internal class Program
    {
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new Logger();

            try
            {
                Console.WriteLine("Welcome to the Mini Calculator.");

                Console.WriteLine("Please enter the first number");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter the second number");
                double b = Convert.ToDouble(Console.ReadLine());

                Calculator calculator = new Calculator(Logger);
                double sum = calculator.Sum(a, b);
                Console.WriteLine("The sum of the numbers you entered is " + sum);
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Logger.Error("Error: Invalid number entered. Please enter a numeric value.");
            }
            catch (OverflowException)
            {
                Logger.Error("Error: The number you entered is either too big or too small.");
            }
            catch (Exception ex)
            {
                Logger.Error("There was an issue during the calculations. " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Thank you for using the Mini Calculator. Come back for more calculations.");
            }
        }
    }

    public interface ICalculator
    {
        double Sum(double a, double b);
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }
}
