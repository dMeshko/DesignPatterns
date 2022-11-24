using Command;

Console.Title = "Memento";

var commandManager = new CommandManager();
var employeeManagerRepository = new EmployeeManagerRepository();

employeeManagerRepository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagersList(
    employeeManagerRepository, 1, new Employee(1, "Darko")));
employeeManagerRepository.WriteDataStore();

commandManager.Revoke();
employeeManagerRepository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagersList(
    employeeManagerRepository, 1, new Employee(2, "Clara")));
employeeManagerRepository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagersList(
    employeeManagerRepository, 2, new Employee(3, "Tom")));
employeeManagerRepository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagersList(
    employeeManagerRepository, 2, new Employee(3, "Tom")));
employeeManagerRepository.WriteDataStore();

commandManager.Reset();
employeeManagerRepository.WriteDataStore();

Console.ReadKey();