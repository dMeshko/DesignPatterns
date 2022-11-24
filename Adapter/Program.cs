Console.Title = "Adapter";

// object adapter
var objectAdapter = new Adapter.Object.CityAdapter();
var objectCity = objectAdapter.GetCity();
Console.WriteLine($"{objectCity.FullName} - {objectCity.Inhabitants}");

// class adapter
var classAdapter = new Adapter.Class.CityAdapter();
var classCity = classAdapter.GetCity();
Console.WriteLine($"{classCity.FullName} - {classCity.Inhabitants}");

Console.ReadKey();
