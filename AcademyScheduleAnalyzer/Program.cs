using System.Globalization;
using System.Text;

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

SearchSession(sessionNames, sessionDates, sessionDurations, "Function");

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

Console.WriteLine($"\nTotal Duration: {GetTotalDuration(sessionDurations)} minutes");
Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations)} minutes");
Console.WriteLine($"Shortest Duration: {GetShortestDuration(sessionDurations)} minutes");
Console.WriteLine($"Longest Duration: {GetLongestDuration(sessionDurations)} minutes");

CopyAndSortSessionDurations(sessionDurations);

Console.WriteLine($"\nSession End Time of Functions(2): {GetSessionEndTime(sessionDates[2], sessionDurations[2])}");

ReadSessionDate();

var reportString = BuildReportUsingString(sessionNames, sessionDates, sessionDurations);
Console.WriteLine(reportString);

var reportStringBuilder = BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations);
Console.WriteLine(reportStringBuilder.ToString());


/*
    Part 7 - ref, out, and Reference-Type Parameters
*/

//7.1 ref
int num = 10;
Console.WriteLine($"Before calling the function: {num}");
ChangeNumberByRef(ref num);
Console.WriteLine($"After calling the function: {num}");

//7.2 out
int idx, duration;
bool isFound;
Console.Write("\nEnter Session:");
string sessionName5 = Console.ReadLine()!;
SearchSessionName(sessionNames, sessionDurations, sessionName5, out idx, out duration, out isFound);

Console.WriteLine($"\nSession is found: {isFound}");
Console.WriteLine($"Session index: {idx}");
Console.WriteLine($"Session duration: {duration} minutes");

//7.3 Reference Type Without ref

int[] numbers = {1 , 3, 7, 5, 10};
//Modifying array without ref
Console.WriteLine($"\nnumbers before calling the function {string.Join(", ", numbers)}");
DemonstrateReferenceType(numbers);
Console.WriteLine($"\nnumbers after calling the function {string.Join(", ", numbers)}");

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

    DisplaySessionDetails(sessionNames, sessionDates, sessionDurations, index);

    
    return true;
}

void DisplaySessionDetails(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations, int index)
{
    Console.WriteLine($"Session: {sessionNames[index]}");
    Console.WriteLine($"Date: {sessionDates[index].Date.ToString("dd MMMM yyyy")}");// 10 September 2026
    Console.WriteLine($"Start Time: {sessionDates[index].ToString("hh:mm tt")}");
    Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
    Console.WriteLine("");
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

int GetTotalDuration(int[] sessionDurations)
{
    int total = 0;

    foreach(var duration in sessionDurations)
    {
        total += duration;
    }

    return total;
}

double GetAverageDuration(int[] sessionDurations)
{
    return (double) GetTotalDuration(sessionDurations) / sessionDurations.Length;
}

int GetShortestDuration(int[] sessionDurations)
{
    int shortest = int.MaxValue;

    foreach(var duration in sessionDurations)
    {
        shortest = shortest > duration ? duration : shortest;
    }

    return shortest;
}

int GetLongestDuration(int[] sessionDurations)
{
    int longest = int.MinValue;

    foreach(var duration in sessionDurations)
    {
        longest = longest < duration ? duration : longest;
    }

    return longest;
}

void CopyAndSortSessionDurations(int[] sessionDurations)
{
    var copiedArray = new int[sessionDurations.Length];

    Array.Copy(sessionDurations, copiedArray, sessionDurations.Length);

    Array.Sort(copiedArray);

    Console.WriteLine($"\nOriginal Array: {string.Join(", ", sessionDurations)}");
    Console.WriteLine($"Copied Array: {string.Join(", ", copiedArray)}");
}

DateTime GetSessionEndTime(DateTime sessionStartTime, int sessionDuration)
{
    return sessionStartTime.AddMinutes(sessionDuration);
}

DateTime ReadSessionDate()
{
    while(true)
    {
        Console.Clear();
        string pattern = "yyyy-MM-dd HH:mm";
        Console.Write($"\nEnter a date ({pattern}): ");
        string dateInput = Console.ReadLine()!;

        if(DateTime.TryParseExact(dateInput, pattern , CultureInfo.InvariantCulture, 
            DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
    }

}

string BuildReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    string report = "\nAcademy Schedule Report\n";
    report += "--------------------------\n";

    for(int i = 0; i < sessionNames.Length; i++)
    {
        report += $"\nSession: {sessionNames[i]}\n"+
        $"Date: {sessionDates[i].ToString("yyyy-MM-dd hh:mm tt")}\n" + 
        $"Duration: {sessionDurations[i]} minutes\n";
    }

    return report;
}

StringBuilder BuildReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    StringBuilder report = new StringBuilder();
    report.AppendLine("\nAcademy Schedule Report");
    report.AppendLine("--------------------------\n");

    for(int i = 0; i < sessionNames.Length; i++)
    {
        report.AppendLine($"Session: {sessionNames[i]}");
        report.AppendLine($"Date: {sessionDates[i].ToString("yyyy-MM-dd hh:mm tt")}");
        report.AppendLine($"Duration: {sessionDurations[i]} minutes\n");
    }

    return report;
}

void ChangeNumberByRef(ref int num)
{
    num = 9;
}

void SearchSessionName(string[] sessionNames, int[] sessionDuration, string sessionName,
    out int index, out int duration, out bool isFound)
{
    index = Array.IndexOf(sessionNames, sessionName);

    if(index == -1)
    {
        duration = 0;
        isFound = false;
        return;
    }

    duration = sessionDuration[index];
    isFound = true;
}

void DemonstrateReferenceType(int[] numbers)
{
    if(numbers.Length < 1)
        return;

    numbers[0] = 3;
}

