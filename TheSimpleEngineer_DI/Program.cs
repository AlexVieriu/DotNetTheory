public class Program
{
    public static void Main(string[] args)
    {
        var user = new User();
        var userIoc = new UserIoc(new OracleDatabase());
        user.Add("This is a bad way");
        userIoc.Add("This is a good way");
    }
}

// Business Layer Logic

public class User                               // Precedural Programming Flow of Control
{
    MySqlDatabase database;

    public User()
       => database = new MySqlDatabase();

    public void Add(string data)
       => database.Persist(data);
}

public class UserIoc                            // Structered Ioc(Inversion of Control)
{
    private readonly IDataBase _database;

    public UserIoc(IDataBase database)
        => _database = database;


    public void Add(string data)
        => _database.Persist(data);
}


public interface IDataBase
{
    void Persist(string data);
}

// Database Access layer
public class MySqlDatabase : IDataBase
{
    public void Persist(string data)
       => Console.WriteLine("MySqlDatabase" + data);
}


public class OracleDatabase : IDataBase
{
    public void Persist(string data)
        => Console.WriteLine("Oracledatabase:" + data);
}

public class SqlServerDatabase : IDataBase
{
    public void Persist(string data)
        => Console.WriteLine("SqlServerDatabase: " + data);
}
