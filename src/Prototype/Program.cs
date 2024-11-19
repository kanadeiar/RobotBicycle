using Prototype.RobotFunc;

Console.WriteLine("Прототип робота-помощника");

StringVariable[] vars =
[
    new StringVariable("name", string.Empty),
    new StringVariable("message", "Сообщение"),
];

ActionBase[] program =
[
    new InputTextAction("Введите свое имя:> ", "name"),
    new ConcatAction("Привет, ", "name", "message"),
    new MessageAction("message"),
];

var robot = new Robot(vars, program);

robot.Run();

Console.WriteLine("Для завершения нажмите любую кнопку ...");
Console.ReadKey();
