interface IBank
{
    int NextAccountIndex();
    bool AccountExists(int id);
    int CreateAccount();
}
