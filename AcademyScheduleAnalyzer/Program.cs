string[] sessionNames = 
{
    "C# Basics",
    "Arrays",
    "Functions",
    "Date and Time",
    "Exception Handling"
};

DateTime[] sessionDates =
{
    new DateTime(2026, 9, 10, 18, 0, 0),
    new DateTime(2026, 9, 13, 18, 0, 0),
    new DateTime(2026, 9, 17, 18, 0, 0),
    new DateTime(2026, 9, 20, 18, 0, 0),
    new DateTime(2026, 9, 24, 18, 0, 0)
};

int[] sessionDurations =
{
    180,
    240,
    180,
    240,
    180
};

DisplaySessions(sessionNames, sessionDates, sessionDurations);


Console.WriteLine();

void DisplaySessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    for(int i = 0; i < sessionNames.Length; i++)
    {
        Console.WriteLine($"Session: {sessionNames[i]}");
        Console.WriteLine($"Date: {sessionDates[i].Date.ToString("dd MMMM yyyy")}");// 10 September 2026
        Console.WriteLine($"Start Time: {sessionDates[i].ToShortTimeString()}");
        Console.WriteLine($"Duration: {sessionDurations[i]} minutes");
        Console.WriteLine("");
    }
}