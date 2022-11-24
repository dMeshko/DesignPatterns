using Observer;

Console.Title = "Observer";

var ticketStockService = new TicketStockService();
var ticketResellerService = new TicketResellerService();
var orderService = new OrderService();

orderService.AddObserver(ticketStockService);
orderService.AddObserver(ticketResellerService);

orderService.CompleteTicketSale(1, 2);

orderService.RemoveObserver(ticketStockService);
orderService.CompleteTicketSale(3, 5);

Console.ReadKey();