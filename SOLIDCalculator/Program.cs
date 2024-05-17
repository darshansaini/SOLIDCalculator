using System;

// Interface for mathematical operations
public interface IOperation
{
    double Calculate(double num1, double num2);
}

// Addition operation
public class Addition : IOperation
{
    public double Calculate(double num1, double num2)
    {
        return num1 + num2;
    }
}

// Subtraction operation
public class Subtraction : IOperation
{
    public double Calculate(double num1, double num2)
    {
        return num1 - num2;
    }
}

// Multiplication operation
public class Multiplication : IOperation
{
    public double Calculate(double num1, double num2)
    {
        return num1 * num2;
    }
}

// Division operation
public class Division : IOperation
{
    public double Calculate(double num1, double num2)
    {
        if (num2 == 0)
        {
            throw new ArgumentException("Division by zero is not allowed.");
        }
        return num1 / num2;
    }
}

// Calculator class
public class Calculator
{
    private readonly IOperation _operation;

    public Calculator(IOperation operation)
    {
        _operation = operation;
    }

    public double PerformOperation(double num1, double num2)
    {
        return _operation.Calculate(num1, num2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Display menu options
        Console.WriteLine("Calculator Menu:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("Enter your choice (1-4):");

        // Get user choice
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4:");
        }

        // Get input numbers
        Console.WriteLine("Enter first number:");
        double num1;
        while (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Invalid input. Please enter a valid number:");
        }

        Console.WriteLine("Enter second number:");
        double num2;
        while (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Invalid input. Please enter a valid number:");
        }

        // Perform selected operation
        IOperation operation = null;
        switch (choice)
        {
            case 1:
                operation = new Addition();
                break;
            case 2:
                operation = new Subtraction();
                break;
            case 3:
                operation = new Multiplication();
                break;
            case 4:
                operation = new Division();
                break;
            //default:
             //   Console
        }

        // Perform operation and display result
        if (operation != null)
        {
            Calculator calculator = new Calculator(operation);
            try
            {
                double result = calculator.PerformOperation(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
