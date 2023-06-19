namespace Simple_Banking_System;

public interface IAccount
{
    Guid Id { get; }
    string Name { get; }
    decimal Balance { get; set; }
    bool Active { get; set; }
}
