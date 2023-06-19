namespace Simple_Banking_System;

public class Singleton<T> where T : new()
{
    private static T? _instance;
    private static readonly object _padlock = new();

    public static T Instance
    {
        get
        {
            lock (_padlock)
            {
                _instance ??= new T();
                return _instance;
            }
        }
    }
}