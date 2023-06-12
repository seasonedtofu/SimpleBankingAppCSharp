namespace Simple_Banking_System;

public class Singleton<T> where T : new()
{
    protected static T _instance;
    protected static readonly object padlock = new();

    public static T Instance
    {
        get
        {
            lock (padlock)
            {
                _instance ??= new T();
                return _instance;
            }
        }
    }
}