using RobotBicycle.RobotModule;

Console.WriteLine("Опытно - экспериментальный робот");

var program = new[] { new RobotAction("Привет от робота!") };
var robot = new Robot(program);

robot.Run();


Console.WriteLine("Для завершения нажми любую кнопку ...");
Console.ReadKey();