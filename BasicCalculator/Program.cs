using System;

class Calculator
{
    static void Main(string[] args)
    {
        // Welcome message
        Console.WriteLine("Welcome to C# Calculator!");
        Console.WriteLine("Enter an expression (e.g., 2 + 2) or 'exit' to quit:");

        // Continuous loop until user decides to exit
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            // Check if the user wants to exit
            if (input.ToLower() == "exit")
                break;

            try
            {
                // Evaluate the expression and display the result
                double result = EvaluateExpression(input);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during evaluation
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Function to evaluate the expression
    static double EvaluateExpression(string expression)
    {
        // Split the expression into parts based on spaces
        string[] parts = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Check if the expression has correct number of parts
        if (parts.Length != 3)
            throw new ArgumentException("Invalid expression format. Please provide a valid expression with two operands and an operator separated by spaces.");

        double operand1, operand2;

        // Parse operands from string to double
        if (!double.TryParse(parts[0], out operand1) || !double.TryParse(parts[2], out operand2))
            throw new ArgumentException("Invalid operands. Please provide valid numeric operands.");

        // Perform the operation based on the operator
        switch (parts[1])
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                // Check for division by zero
                if (operand2 == 0)
                    throw new DivideByZeroException("Cannot divide by zero.");
                return operand1 / operand2;
            default:
                // Handle invalid operator
                throw new ArgumentException("Invalid operator. Please provide a valid operator (+, -, *, /).");
        }
    }
}