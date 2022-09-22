namespace TimCorey_DI;

public class Emailer
{
    public void SendEmail(Person person, string message)
        => Console.WriteLine($"Simulation sending an email to {person.EmailAddress}");
}

