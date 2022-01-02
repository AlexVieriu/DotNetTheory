using TimCorey_DI;

Person owner = new()
{
    FirstName = "Tim",
    LastName = "Corey",
    EmailAddress = "tim@iamtimcorey.com",
    PhoneNumber = "555-1212"
};

Chore chore = new()
{
    ChroeName = "Take out the trash",
    Owner = owner
};

chore.PerformedWork(3);
chore.PerformedWork(1.5);
chore.CompleteChore();