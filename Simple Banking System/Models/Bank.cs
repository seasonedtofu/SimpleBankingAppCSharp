namespace Simple_Banking_System;
public class Bank: Singleton<Bank>
{
    public readonly Dictionary<Guid, IAccountController> Accounts = new();
}
