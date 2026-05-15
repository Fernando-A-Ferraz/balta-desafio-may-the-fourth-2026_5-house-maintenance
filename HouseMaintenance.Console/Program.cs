using HouseMaintenance.Console.Services;

Console.Title = "House Maintenance - May The Fourth 2026";

ExibirCabecalho();

var houseService = new HouseMaintenanceService();

if (!houseService.HasTasks())
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("🏠 Quantos reparos deseja cadastrar? ");
    Console.ResetColor();

    var quantityInput = Console.ReadLine();

    if (!int.TryParse(quantityInput, out var totalTasks) || totalTasks <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Quantidade inválida.");
        Console.ResetColor();
        return;
    }

    for (int i = 1; i <= totalTasks; i++)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"🛠️ Reparo {i}");
        Console.ResetColor();

        Console.Write("Nome do reparo: ");
        var taskName = Console.ReadLine() ?? string.Empty;

        Console.Write("Kit/ferramenta necessária: ");
        var toolKit = Console.ReadLine() ?? string.Empty;

        Console.Write("Prioridade (1 = Alta, 2 = Média, 3 = Baixa): ");
        var priorityInput = Console.ReadLine() ?? "3";

        houseService.AddTask(
            taskName,
            toolKit,
            priorityInput);
    }

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("✅ Reparos cadastrados com sucesso!");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("✅ Reparos carregados do arquivo repairs.json.");
    Console.ResetColor();
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("🧠 Ordem inteligente sugerida:");
Console.WriteLine("Agrupado para minimizar bagunça e troca de ferramentas.");
Console.ResetColor();

var organizedTasks = houseService.GetOrganizedTasks();

foreach (var group in organizedTasks)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"🔧 Kit/Ferramenta: {group.Key}");
    Console.ResetColor();

    foreach (var task in group.Value)
    {
        Console.WriteLine($"- {task.Name} | Prioridade: {task.PriorityDescription}");
    }
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Pressione qualquer tecla para encerrar...");
Console.ResetColor();
Console.ReadKey();

static void ExibirCabecalho()
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("======================================");
    Console.WriteLine(" 🌌 MAY THE FOURTH 2026");
    Console.WriteLine("  HOUSE MAINTENANCE");
    Console.WriteLine("======================================");

    Console.ResetColor();
    Console.WriteLine();
}