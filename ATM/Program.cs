using System;

public class ATM
{
    private double currentBalance;
    private string username = "user"; 
    private string password = "pass123"; 

    public ATM(double currentBalance)
    {
        this.currentBalance = currentBalance;
    }

    public bool Login(string username, string password)
    {
        return this.username == username && this.password == password;
    }

    public bool Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Error: Amount must be greater than zero.");
            return false;
        }
        if (amount > currentBalance)
        {
            Console.WriteLine("Error: Insufficient balance.");
            return false;
        }
        currentBalance -= amount;
        Console.WriteLine($"Withdrawal successful! Dispensed: {amount:C}");
        return true;
    }

    public double RemainingBalance()
    {
        return currentBalance;
    }

    public static void Main(string[] args)
    {
        ATM atm = new ATM(1000.00); 
        Console.WriteLine("=====================================");
        Console.WriteLine("          ATM Login System           ");
        Console.WriteLine("=====================================");

        Console.Write("Enter your username: ");
        string enteredUsername = Console.ReadLine();

        Console.Write("Enter your password: ");
        string enteredPassword = Console.ReadLine();

        if (atm.Login(enteredUsername, enteredPassword))
        {
            Console.WriteLine("\nLogin successful!\n");
            Console.WriteLine($"Current Balance: {atm.RemainingBalance():C}"); 
            Console.WriteLine("=====================================");
            Console.WriteLine("        Withdrawal Operation          ");
            Console.WriteLine("=====================================");
            Console.Write("Enter the amount you want to withdraw: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double withdrawalAmount))
            {
                bool success = atm.Withdraw(withdrawalAmount);
                if (success)
                {
                    Console.WriteLine($"Remaining Balance: {atm.RemainingBalance():C}");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid amount. Please enter a number.");
            }
        }
        else
        {
            Console.WriteLine("Error: Incorrect username or password.");
        }

        Console.WriteLine("\n=====================================");
        Console.WriteLine("           Have a Nice Day!         ");
        Console.WriteLine("=====================================");
    }
}