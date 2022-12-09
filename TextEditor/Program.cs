Menu();

static void Menu()
{
    Console.Clear();
    System.Console.WriteLine("Selecioone uma opção");
    System.Console.WriteLine();
    System.Console.WriteLine("1 - Abrir arquivo");
    System.Console.WriteLine("2 - Criar novo arquivo");
    System.Console.WriteLine();
    System.Console.WriteLine("0 - Sair");
    System.Console.WriteLine();
    System.Console.Write("Opção: ");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: Environment.Exit(0); break;
        case 1: Open(); break;
        case 2: Edit(); break;
        default: Menu(); break;
    }
}

static void Open()
{
    Console.Clear();
    System.Console.Write("Digite o caminho do arquivo: ");
    string path = Console.ReadLine();
    System.Console.WriteLine();

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        System.Console.WriteLine(text);
    }
    System.Console.WriteLine("---------------");
    System.Console.WriteLine("Pressione ENTER para voltar ao menu.");
    Console.ReadLine();
    Menu();
}

static void Edit()
{
    Console.Clear();
    System.Console.WriteLine("Digite seu texto abaixo (Aperte ESC para sair)");
    System.Console.WriteLine();
    string text = "";

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Save(text);
}

static void Save(string text)
{
    Console.Clear();
    System.Console.WriteLine("Selecione onde gostaria de salvar o arquivo:");
    var path = Console.ReadLine();

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }
    System.Console.WriteLine($"Arquivo {path} salvo com sucesso!");
    System.Console.WriteLine();
    System.Console.WriteLine("Pressione Enter para voltar ao menu.");
    Console.ReadLine();
    Menu();
}