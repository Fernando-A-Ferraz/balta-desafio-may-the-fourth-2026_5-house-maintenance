using HouseMaintenance.Console.Models;

namespace HouseMaintenance.Console.Agents;

public class RepairAgent
{
    public RepairTask CreateTask(
        string taskName,
        string toolKit,
        int priority)
    {
        return new RepairTask
        {
            Name = taskName.Trim(),
            ToolKit = toolKit.Trim(),
            Priority = priority
        };
    }
}
