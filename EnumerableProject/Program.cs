using EnumerableProject;
using System.Text.Json;

var fileContent = await File.ReadAllTextAsync("data.json");
var cars = JsonSerializer.Deserialize<List<CarData>>(fileContent);

var carsWithAtLeastFourDoors = cars.Where(cars => cars.NumberOfDoors >= 4);

// print all cars with at least 4 doors
foreach (var car in carsWithAtLeastFourDoors)
{
    Console.WriteLine($"The car {car.Model} has {car.NumberOfDoors} doors");
}
Console.WriteLine("------------------------------------------");

// print all mazda cars with at least 4 doors

var mazdaCar = cars.Where(car => car.Make == "Mazda" && car.NumberOfDoors >= 4);

foreach (var car in mazdaCar)
{
    Console.WriteLine($"The Mazda car {car.Model} has {car.NumberOfDoors} doors");
}

Console.WriteLine("------------------------------------------");
// print make + model for all makes that start with "M"

cars.Where(car => car.Make.StartsWith("M"))
    .Select(car => $"{car.Make} {car.Model}")
    .ToList()
    .ForEach(car => Console.WriteLine(car));

Console.WriteLine("------------------------------------------");


// Display a list of the 10 most powerful cars (in terms of horsepower)

cars.OrderByDescending(car => car.HorsePower)
    .Take(10)
    .Select(car => $"{car.Make} {car.Model} {car.HorsePower}")
    .ToList()
    .ForEach(car => Console.WriteLine(car));


Console.WriteLine("------------------------------------------");


// Display the number of models per make that appeared after 2000

cars.GroupBy(car => car.Make)
    .ToList()
    .ForEach(item => Console.WriteLine(item));


Console.WriteLine("------------------------------------------");


cars.GroupBy(car => car.Make)
    .ToList()
    .ForEach(item => Console.WriteLine(item.Key));


Console.WriteLine("------------------------------------------");


cars.GroupBy(car => car.Make)
    .Select(car => new { car.Key, Count = car.Count() })
    .ToList()
    .ForEach(car => Console.WriteLine($"{car.Key} {car.Count}"));


Console.WriteLine("------------------------------------------");


cars.Where(car => car.Year > 2000)
    .GroupBy(car => car.Make)
    .Select(car => new { car.Key, Count = car.Count() })
    .ToList()
    .ForEach(car => Console.WriteLine($"{car.Key} {car.Count}"));


Console.WriteLine("------------------------------------------");


// include makes with no cars after 2000

cars.GroupBy(car => car.Make)
    .Select(car => new { car.Key, Count = car.Count(car => car.Year > 2000) })
    .ToList()
    .ForEach(car => Console.WriteLine($"{car.Key} {car.Count}"));


Console.WriteLine("------------------------------------------");


// Display a list of makes that have at least 2 models that with more than 400 horsePower

cars.Where(car => car.HorsePower >= 400) // operates on whole list
    .GroupBy(car => car.Make)
    .Select(car => new { car.Key, Count = car.Count() })
    .Where(car => car.Count >= 2) // operates on grouped data
    .ToList()
    .ForEach(car => Console.WriteLine($"{car.Key} {car.Count}"));

Console.WriteLine("------------------------------------------");


// Display the avg horsepower per make

cars.GroupBy(car => car.Make)
    .Select(car => new { car.Key, avg = car.Average(car => car.HorsePower) })
    .ToList()
    .ForEach(car => Console.WriteLine($"{car.Key} {car.avg}"));


Console.WriteLine("------------------------------------------");


// how many makes build cars with horsepower between 0-100, 101-200, 201-300. 301-400, 401-500

cars.GroupBy(car => car.HorsePower switch
    {
        <= 100 => "0..100",
        <= 200 => "101..200",
        <= 300 => "201..300",
        <= 400 => "301..400",
        _ => "401..500"
    }) // switch expression (not a switch statement)
    .Select(car => new
    {
        car.Key,
        count = car.Select(car => car.Make).Distinct().Count()
    })
    .OrderBy(car => car.Key)
    .ToList()
    .ForEach(car => Console.WriteLine($"{car.Key} {car.count}"));