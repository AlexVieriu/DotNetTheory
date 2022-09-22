namespace TimCorey_DI;

public class Chore
{
    public string ChroeName { get; set; }
    public Person Owner { get; set; }
    public double HourWorked { get; private set; }
    public bool IsComplete { get; set; }

    public void PerformedWork(double hours)
    {
        HourWorked += hours;
        Logger log = new Logger();
        log.Log($"Performed work on {ChroeName}");
    }

    public void CompleteChore()
    {
        IsComplete = true;

        Logger log = new Logger();
        log.Log($"Completed {ChroeName}");

        Emailer emailer = new Emailer();
        emailer.SendEmail(Owner, $"The chore {ChroeName} is complete.");
    }
}

