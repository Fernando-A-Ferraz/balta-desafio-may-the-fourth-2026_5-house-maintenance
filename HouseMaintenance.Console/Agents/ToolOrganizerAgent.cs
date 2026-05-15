using HouseMaintenance.Console.Models;

namespace HouseMaintenance.Console.Agents;

public class ToolOrganizerAgent
{
    public Dictionary<string, List<RepairTask>> OrganizeByToolKit(
        List<RepairTask> tasks)
    {
        return tasks
            .OrderBy(t => t.Priority)
            .GroupBy(task => task.ToolKit)
            .ToDictionary(
                group => group.Key,
                group => group.ToList());
    }
}