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
    new DateTime(2026, 10, 10, 18, 0, 0),
    new DateTime(2026, 10, 13, 18, 0, 0),
    new DateTime(2026, 10, 17, 18, 0, 0),
    new DateTime(2026, 10, 20, 18, 0, 0),
    new DateTime(2026, 10, 24, 18, 0, 0)
};

int[] sessionDurations =
{
    180,
    240,
    180,
    240,
    180
};

while(true)
{
    Console.Clear();
    ShowMenuOptions();

    int choice = ReadNumericInput();
    HandleMenuChoice(choice, sessionNames, sessionDates, sessionDurations);
    
    Console.ReadKey();
}

void ShowMenuOptions()
{
    Console.WriteLine("===================================");
    Console.WriteLine("Academy Schedule Analyzer");
    Console.WriteLine("===================================");

    Console.WriteLine("\nMenu Options:");
    Console.WriteLine("1. Display all sessions");
    Console.WriteLine("2. Search for a session");
    Console.WriteLine("3. Sort session names");
    Console.WriteLine("4. Reverse session names");
    Console.WriteLine("5. Find session index");
    Console.WriteLine("6. Check if session exists");
    Console.WriteLine("7. Show duration statistics");
    Console.WriteLine("8. Show session date details");
    Console.WriteLine("9. Show past and upcoming sessions");
    Console.WriteLine("10. Find next session");
    Console.WriteLine("11. Compare two session dates");
    Console.WriteLine("12. Read and validate a custom date");
    Console.WriteLine("13. Select session by index");
    Console.WriteLine("14. Validate session duration");
    Console.WriteLine("15. Generate report using string");
    Console.WriteLine("16. Generate report using StringBuilder");
    Console.WriteLine("0. Exit");
}

void HandleMenuChoice(int choice, string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    switch(choice)
    {
        case 1:
            {
                Console.Clear();
                DisplaySessions(sessionNames, sessionDates, sessionDurations);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 2:
            {
                Console.Clear();
                SearchSession(sessionNames, sessionDates, sessionDurations);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 3:
            {
                Console.Clear();
                SortSessionNames(sessionNames);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 4:
            {
                Console.Clear();
                ReverseSessionNames(sessionNames);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 5:
            {
                Console.Clear();
                Console.Write("Enter a session name: ");
                string sessionName = Console.ReadLine()!;
                int index = FindSessionIndex(sessionNames, sessionName);
                if(index == -1) 
                    Console.WriteLine("\nSession not found");
                else
                    Console.WriteLine($"Session found at index: {index}");
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 6:
            {
                Console.Clear();
                Console.Write("Enter a session name: ");
                string sessionName = Console.ReadLine()!;
                bool isfound = DoesSessionExist(sessionNames, sessionName);
                if(!isfound) 
                    Console.WriteLine("\nSession not found.");
                else
                    Console.WriteLine($"Session found.");
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 7:
            {
                Console.Clear();
                ShowDurationStatistics(sessionDurations);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 8:
            {
                Console.Clear();
                Console.Write("Enter a session name: ");
                string sessionName = Console.ReadLine()!;
                DisplaySessionDateDetails(sessionNames, sessionDates, sessionDurations, sessionName);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 9:
            {
                Console.Clear();
                DisplayPastAndUpcomingSessions(sessionNames, sessionDates);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 10:
            {
                Console.Clear();
                FindNextUpcomingSession(sessionNames, sessionDates);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 11:
            {
                Console.Clear();
                //Compare two session dates
                Console.Write("Enter first session name: ");
                string firstSessionName = Console.ReadLine()!;
                Console.Write("Enter second session name: ");
                string secondSessionName = Console.ReadLine()!;

                int firstIndex = FindSessionIndex(sessionNames, firstSessionName);
                int secondIndex = FindSessionIndex(sessionNames, secondSessionName);

                if(firstIndex == -1 || secondIndex == -1)
                {
                    Console.WriteLine("\nOne or both sessions not found.");
                }
                else
                {
                    TimeSpan difference = GetDateDifference(sessionDates[firstIndex], sessionDates[secondIndex]);
                    Console.WriteLine($"\nTime difference between {firstSessionName} and {secondSessionName}: {difference.Days} days, {difference.Hours} hours, {difference.Minutes} minutes");
                }

                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 12:
            {
                Console.Clear();
                DateTime customDate = ReadSessionDate();
                Console.WriteLine($"\nYou entered: {customDate.ToString("yyyy-MM-dd HH:mm")}");
                Console.WriteLine("\nPress any key to back...");
                break;
            }       
        case 13:
            {
                Console.Clear();
                SelectSessionNameByIndex(sessionNames);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 14:
            {
                Console.Clear();
                ValidateSessionDuration();
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 15:
            {
                Console.Clear();
                string report = BuildReportUsingString(sessionNames, sessionDates, sessionDurations);
                Console.WriteLine(report);
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 16:
            {
                Console.Clear();
                StringBuilder report = BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations);
                Console.WriteLine(report.ToString());
                Console.WriteLine("\nPress any key to back...");
                break;
            }
        case 0:
            {
                Environment.Exit(0);
                break;
            }
        default:
            {
                Console.WriteLine("Invalid choice. Please try again.");
                break;
            }
    }
}

void ShowDurationStatistics(int[] sessionDurations)
{
    Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
    Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations)} minutes");
    Console.WriteLine($"Shortest Duration: {GetShortestDuration(sessionDurations)} minutes");
    Console.WriteLine($"Longest Duration: {GetLongestDuration(sessionDurations)} minutes");
}

void DisplaySessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    for(int i = 0; i < sessionNames.Length; i++)
    {
        DisplaySessionDetails(sessionNames, sessionDates, sessionDurations, i);
    }
}

bool SearchSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    Console.Write("\nEnter a session name: ");
    string sessionName = Console.ReadLine()!;

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
    int index = Array.IndexOf(sessionNames, sessionName);
    return index;
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
        else
        {
            Console.WriteLine("Invalid date.");
            Console.ReadKey();
            continue;
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

int CalculateTotalDuration(params int[] durations)
{
    int totalDurations = 0;
    foreach(var duration in durations)
    {
        totalDurations += duration;
    }

    return totalDurations;
}

void DisplaySessionDateDetails(string[] sessionNames, DateTime[] sessionDates, 
    int[] sessionDurations, string sessionName)
{
    int index = FindSessionIndex(sessionNames, sessionName);

    if(index == -1)
    {
        Console.WriteLine("Session not found.");
        return;
    }

    Console.WriteLine($"\nSession: {sessionName}\n");
    Console.WriteLine($"Date: {sessionDates[index].Date.ToString("dd MMMM yyyy")}");
    Console.WriteLine($"Day: {sessionDates[index].DayOfWeek}");
    Console.WriteLine($"Year: {sessionDates[index].Year}");
    Console.WriteLine($"Month: {sessionDates[index].Month}");
    Console.WriteLine($"Day Number: {sessionDates[index].Day}");
    Console.WriteLine($"Start Time: {sessionDates[index].ToString("hh:mm tt")}");
    Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
    Console.WriteLine($"End Time: {GetSessionEndTime(sessionDates[index], sessionDurations[index]).ToString("hh:mm tt")}");
}

DateTime GetSessionEndTime(DateTime sessionStartTime, int sessionDuration)
{
    return sessionStartTime.AddMinutes(sessionDuration);
}

TimeSpan GetDateDifference(DateTime firstSessionDate, DateTime secondSessionDate)
{
    return secondSessionDate - firstSessionDate;
}

void DisplayPastAndUpcomingSessions(string[] sessionNames, DateTime[] sessionDates)
{
    for(int i = 0; i < sessionNames.Length; i++)
    {
        string status = sessionDates[i] < DateTime.Now ? "Past" : "Upcoming"; 
        Console.WriteLine($"{sessionNames[i]} - {status}");
    }
}

void FindNextUpcomingSession(string[] sessionNames, DateTime[] sessionDates)
{
    int nextSessionIndex = -1;
    DateTime? nextSessionDate = null;
    for(int i = 1; i < sessionNames.Length; i++)
    {
        if(sessionDates[i] > DateTime.Now && (nextSessionDate.HasValue == false || nextSessionDate > sessionDates[i]))
        {
            nextSessionDate = sessionDates[i];
            nextSessionIndex = i;
        }
    }

    Console.WriteLine($"\nNext Session: {sessionNames[nextSessionIndex]}");
    Console.WriteLine($"\n{sessionDates[nextSessionIndex].ToString("dd MMMM yyyy")}");
    Console.WriteLine($"{sessionDates[nextSessionIndex].ToString("hh:mm tt")}");
    Console.WriteLine("\nTime Remaining:");
    Console.WriteLine($"{sessionDates[nextSessionIndex].Day - DateTime.Now.Day} days");
    Console.WriteLine($"{sessionDates[nextSessionIndex].Hour - DateTime.Now.Hour} hours");
}

void DisplaySessionDateFormats(DateTime sessionDate)
{
    Console.WriteLine($"\n{sessionDate.ToString("yyyy-MM-dd")}");
    Console.WriteLine($"{sessionDate.ToString("dd/MM/yyyy")}");
    Console.WriteLine($"{sessionDate.ToString("dd MMMM yyyy")}");
    Console.WriteLine($"{sessionDate.ToString("dddd, dd MMMM yyyy")}");
    Console.WriteLine($"{sessionDate.ToString("hh:mm tt")}");
}

int ReadNumericInput()
{

    while(true)
    {
        Console.Write("\nChoose an option:");
        string input = Console.ReadLine()!;
        try
        {
            int number = int.Parse(input);

            Console.WriteLine(number);
            return number;
        }
        catch(FormatException ex)
        {
            Console.WriteLine("Invalid menu option. Enter a number.");
        }
    } 
}

int SelectSessionNameByIndex(string[] sessionNames)
{
    while(true)
    {
        try
        {
            Console.Write("\nEnter session index:");
            int index = int.Parse(Console.ReadLine()!);

            string sessionName = sessionNames[index];

            Console.WriteLine($"Session: {sessionName}");
            return index;
        }
        catch(IndexOutOfRangeException ex)
        {
            Console.WriteLine("The selected session index is out of range.");
        }
    }
}

void ValidateSessionDuration()
{
    try
    {
        Console.Write("\nEnter duration:");
        int duration = int.Parse(Console.ReadLine()!);

        if(duration <= 0)
            throw new ArgumentException();

        Console.WriteLine("Duration accepted.");
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine("Duration must be greater than zero.");
    }
    finally
    {
        Console.WriteLine("Input operation finished.");
    }
}

