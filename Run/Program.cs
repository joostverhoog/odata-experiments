namespace Run;

static class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Error.WriteLine("Please provide a file path as a command-line argument.");
            return 1;
        }

        var filePath = args[0];

        if (!File.Exists(filePath))
        {
            Console.Error.WriteLine($"The file at path '{filePath}' does not exist.");
            return 2;
        }

        var content = File.ReadAllText(filePath);
        var model = Parser.Parse(content);
        var report = new ReportGenerator(model).Generate();
        
        foreach (var line in report)
            Console.Out.WriteLine(line);
        
        return 0;
    }
}