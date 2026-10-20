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

//DisplaySessions(sessionNames, sessionDates, sessionDurations);

SearchSession(sessionNames, sessionDates, sessionDurations, "Function");


Console.WriteLine();


void DisplaySessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    for(int i = 0; i < sessionNames.Length; i++)
    {
        Console.WriteLine($"Session: {sessionNames[i]}");
        Console.WriteLine($"Date: {sessionDates[i].ToString("dd MMMM yyyy")}");// 10 September 2026
        Console.WriteLine($"Start Time: {sessionDates[i].ToString("hh:mm tt")}");
        Console.WriteLine($"Duration: {sessionDurations[i]} minutes");
        Console.WriteLine("");
    }
}

bool SearchSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations, string sessionName)
{
    int index = Array.IndexOf(sessionNames, sessionName);

    if(index == -1)
    {
        Console.WriteLine("Session not found.");
        return false;
    }

    Console.WriteLine($"Session: {sessionNames[index]}");
    Console.WriteLine($"Date: {sessionDates[index].Date.ToString("dd MMMM yyyy")}");// 10 September 2026
    Console.WriteLine($"Start Time: {sessionDates[index].ToString("hh:mm tt")}");
    Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
    Console.WriteLine("");
    
    return true;
}

