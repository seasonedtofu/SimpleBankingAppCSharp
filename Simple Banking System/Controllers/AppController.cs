namespace Simple_Banking_System;

public class AppController: IAppController
{
    private readonly App _app = App.Instance;
    
    public void StartApp()
    {
        while (true)
        {
            BankLogger.Prompt();
            _app.Choice = Console.ReadKey().KeyChar;
            BankLogger.NewLine();
            
            while (!Validator.ValidPromptChar(_app.Choice))
            {
                BankLogger.InvalidChoice();
                _app.Choice = Console.ReadKey().KeyChar;
                BankLogger.NewLine();
            }
            
            switch (_app.Choice)
            {
                case 'h':
                    return;
                case 'a':
                    BankLogger.AccountNumberIs(BankController.CreateAccount());
                    continue;
            }

            BankLogger.AskForAccountId();
            AskForId(out var appId);
            _app.Id = appId;
            if (!ValidAccountCheck(_app.Id)) continue;
            
            switch (_app.Choice)
            {
                case 'd':
                    BankLogger.BalanceIs(_app.BankController[_app.Id].CheckBalance());
                    break;
                case 'b':
                    BankLogger.AskForDepositAmount();
                    AskForAmount();
                    _app.BankController[_app.Id].Deposit(_app.Amount);
                    break;
                case 'c':
                    BankLogger.AskForWithdrawalAmount();
                    AskForAmount();
                    _app.BankController[_app.Id].Withdraw(_app.Amount);
                    break;
                case 'e':
                    BankLogger.AskForTransferId();
                    AskForId(out var toId);
                    if (!ValidAccountCheck(toId)) continue;
                    BankLogger.AskForTransferAmount();
                    AskForAmount();
                    _app.BankController[_app.Id].Withdraw(_app.Amount);
                    _app.BankController[toId].Deposit(_app.Amount);
                    break;
                case 'f':
                    _app.BankController[_app.Id].ReopenAccount();
                    break;
                case 'g':
                    _app.BankController[_app.Id].CloseAccount();
                    break;
            }
        }
    }

    private void AskForId(out Guid id)
    {
        var success = Guid.TryParse(Console.ReadLine(), out id);
        while (!success)
        {
            BankLogger.TryAgainNumbersOnly();
            success = Guid.TryParse(Console.ReadLine(), out id);
        }
    }
    private void AskForAmount()
    {
        var success = decimal.TryParse(Console.ReadLine(), out var amount);
        while (!success)
        {
            BankLogger.TryAgainNumbersOnly();
            success = decimal.TryParse(Console.ReadLine(), out amount);
        }

        _app.Amount = amount;
    }
    private static bool ValidAccountCheck(Guid id)
    {
        if (!BankController.AccountExists(id))
        {
            BankLogger.AccountDoesntExist();
            return false;
        }

        if (BankController.AccountActive(id)) return true;
        BankLogger.AccountInactive();
        return false;
    }
}