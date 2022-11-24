using Strategy;

Console.Title = "Strategy";

var order = new Order("Marvin software", 5, "Visual Studio License", "for students only");
order.ExportService = new CSVExportService();
order.Export();

order.ExportService = new JsonExportService();
order.Export();

Console.ReadKey();