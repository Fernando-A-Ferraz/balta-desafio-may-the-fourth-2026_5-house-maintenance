using System.Text.Json;
using HouseMaintenance.Console.Agents;
using HouseMaintenance.Console.Models;

namespace HouseMaintenance.Console.Services;

public class HouseMaintenanceService
{
    private readonly RepairAgent _repairAgent = new();
    private readonly PriorityAgent _priorityAgent = new();
    private readonly ToolOrganizerAgent _toolOrganizerAgent = new();

    private readonly string _filePath = "Data/repairs.json";
    private readonly List<RepairTask> _tasks;

    public HouseMaintenanceService()
    {
        _tasks = LoadTasks();
    }

    public bool HasTasks()
    {
        return _tasks.Any();
    }

    public void AddTask(
        string taskName,
        string toolKit,
        string priorityInput)
    {
        var priority = _priorityAgent.ValidatePriority(priorityInput);

        var task = _repairAgent.CreateTask(
            taskName,
            toolKit,
            priority);

        _tasks.Add(task);
        SaveTasks();
    }

    public Dictionary<string, List<RepairTask>> GetOrganizedTasks()
    {
        return _toolOrganizerAgent.OrganizeByToolKit(_tasks);
    }

    private List<RepairTask> LoadTasks()
    {
        if (!File.Exists(_filePath))
            return [];

        var json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
            return [];

        return JsonSerializer.Deserialize<List<RepairTask>>(json) ?? [];
    }

    private void SaveTasks()
    {
        Directory.CreateDirectory("Data");

        var json = JsonSerializer.Serialize(
            _tasks,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(_filePath, json);
    }
}
