namespace HouseMaintenance.Console.Models;

public class RepairTask
{
    public string Name { get; set; } = string.Empty;
    public string ToolKit { get; set; } = string.Empty;
    public int Priority { get; set; }

    public string PriorityDescription =>
        Priority switch
        {
            1 => "Alta",
            2 => "Média",
            3 => "Baixa",
            _ => "Não definida"
        };
}
