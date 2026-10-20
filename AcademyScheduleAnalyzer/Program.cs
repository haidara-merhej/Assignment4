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

//SearchSession(sessionNames, sessionDates, sessionDurations, "Function");

SortSessionNames(sessionNames);

ReverseSessionNames(sessionNames);

// Find Session Index
Console.Write("\nEnter session name: ");
string sessionName = Console.ReadLine()!;
if(!string.IsNullOrEmpty(sessionName))
{
    int index = FindSessionIndex(sessionNames, sessionName);
    Console.WriteLine($"Index: {index}");
}

//Check if a session exists
Console.Write("\nEnter session name: ");
string sessionName2 = Console.ReadLine()!;
if(!string.IsNullOrEmpty(sessionName2))
{
    bool result = DoesSessionExist(sessionNames, sessionName2);
    
    if(result)
        Console.WriteLine("Session exists.");
    else
        Console.WriteLine("Session does not exist.");
}


//Find Session
Console.Write("\nEnter session name: ");
string sessionName3 = Console.ReadLine()!;
string? sessionFound = FindSession(sessionNames, sessionName3);
Console.WriteLine(sessionFound ?? "Session not found");

// Find Session Index
Console.Write("\nEnter session name: ");
string sessionName4 = Console.ReadLine()!;
if(!string.IsNullOrEmpty(sessionName4))
{
    int index = FindSessionIndexByCondition(sessionNames, sessionName4);
    Console.WriteLine($"Index: {index}");
}

DemonstrateArrayCopy(sessionNames);

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

void SortSessionNames(string[] sessionNames)
{
    string[] sortedSessionNames = new string [sessionNames.Length];

    Array.Copy(sessionNames, sortedSessionNames, sessionNames.Length);

    Array.Sort(sortedSessionNames);

    Console.WriteLine("\nSort Session Names:");
    Console.WriteLine(string.Join("\n", sortedSessionNames));
}

void  ReverseSessionNames(string[] sessionNames)
{
    string[] reversedSessionNames = new string[sessionNames.Length];

    Array.Copy(sessionNames, reversedSessionNames, sessionNames.Length);

    Array.Reverse(reversedSessionNames);

    Console.WriteLine("\nReverse Session Names:");
    Console.WriteLine(string.Join("\n", reversedSessionNames));
}

int FindSessionIndex(string[] sessionNames, string sessionName)
{
    return Array.IndexOf(sessionNames, sessionName);
}

bool DoesSessionExist(string[] sessionNames, string sessionName)
{
    return Array.Exists(sessionNames, name => name == sessionName);
}

string? FindSession(string[] sessionNames, string sessionName)
{ 
   return  Array.Find(sessionNames, name => name == sessionName);
}

int FindSessionIndexByCondition(string[] sessionNames, string sessionName)
{
    return Array.FindIndex(sessionNames, name => name == sessionName);
}

void DemonstrateArrayCopy(string[] sessionNames)
{
    var copiedArray = new string[sessionNames.Length];

    Array.Copy(sessionNames, copiedArray, sessionNames.Length);

    copiedArray[4] = "LINQ";

    Console.WriteLine($"Original Array: {string.Join(", ", sessionNames)}");
    Console.WriteLine($"Original Array: {string.Join(", ", copiedArray)}");

    // Array.Copy(): only copy the values from the source array to the destination array
    //and any change in the copied array does not affect the original array
}
