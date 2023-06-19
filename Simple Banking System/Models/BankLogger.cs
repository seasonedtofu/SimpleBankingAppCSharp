namespace Simple_Banking_System;

public abstract class BankLogger
{
    public static void Prompt()
    {
        Console.WriteLine("Enter the character of the option you would like to choose.");
        Console.WriteLine("a. Create Account");
        Console.WriteLine("b. Deposit");
        Console.WriteLine("c. Withdraw");
        Console.WriteLine("d. Check Balance");
        Console.WriteLine("e. Transfer Funds");
        Console.WriteLine("f. Exit");
    }
    public static void TryAgainNumbersOnly() => Console.WriteLine("Please enter only numbers and try again.");
    public static void InvalidChoice() => Console.WriteLine("Invalid choice, please try again.");
    public static void NewLine() => Console.WriteLine("");
    public static void AccountNumberIs(Guid id) => Console.WriteLine($"Your account number is {id}");
    public static void BalanceIs(decimal amount) => Console.WriteLine($"Your balance is {amount}");
    public static void AskForDepositAmount() => Console.WriteLine("Enter amount you would like to deposit.");
    public static void AskForWithdrawalAmount() => Console.WriteLine("Enter amount you would like to withdraw.");
    public static void AskForTransferAmount() => Console.WriteLine("Enter the amount you would like to transfer.");
    public static void AccountDoesntExist() => Console.WriteLine("Account does not exist, please re-select option and try again.");
    public static void AccountInactive() => Console.WriteLine("Account is inactive, please re-select option and try again.");
    public static void AskForAccountId() => Console.WriteLine("Please enter your bank account id.");
    public static void AskForTransferId() => Console.WriteLine("Enter the id of the account you would like to transfer to.");
    public static void EnterName() => Console.WriteLine("Enter your name:");
    public static void NameLength() => Console.WriteLine("Name length must be greater than 0, please re-enter.");
    public static void OnlyCharacters() => Console.WriteLine("Please enter only characters for name (no numbers).");
}