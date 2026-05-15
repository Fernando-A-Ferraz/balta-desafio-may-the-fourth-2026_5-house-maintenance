
namespace HouseMaintenance.Console.Agents;

public class PriorityAgent
{
    public int ValidatePriority(string input)
    {
        return int.TryParse(input, out var priority)
               && priority is >= 1 and <= 3
            ? priority
            : 3;
    }
}