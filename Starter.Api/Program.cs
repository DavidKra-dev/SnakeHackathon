using Starter.Api.Requests;
using Starter.Api.Responses;
using Starter.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

/// <summary>
/// This request will be made periodically to retrieve information about your Battlesnake,
/// including its display options, author, etc.
/// </summary>
app.MapGet("/", () =>
{
    return new InitResponse
    {
        ApiVersion = "1",
        Author = "WRLD ON DRUGS",
        Color = "#ff0066",
        Head = "crystal-power",
        Tail = "crystal-power"
    };
});

/// <summary>
/// Your Battlesnake will receive this request when it has been entered into a new game.
/// Every game has a unique ID that can be used to allocate resources or data you may need.
/// Your response to this request will be ignored.
/// </summary>
app.MapPost("/start", (GameStatusRequest gameStatusRequest) =>
{
    Results.Ok();
});

/// <summary>
/// This request will be sent for every turn of the game.
/// Use the information provided to determine how your
/// Battlesnake will move on that turn, either up, down, left, or right.
/// </summary>
app.MapPost("/move", (GameStatusRequest gameStatusRequest) =>
{
    Console.WriteLine($"TURN: {gameStatusRequest.Turn} -----------------------------");
    
    // Возможные ходы
    var direction = new List<string> { "down", "left", "right", "up" };
    
    // Обработчики добавлят!
    List<ISnakeHandler> handlers = new List<ISnakeHandler>()
    {
        new BordersOutHandler(),
        new SelfCollisionHandler()
    };
    
    // Обработчики вызыват!
    foreach (var h in handlers)
        h.Handle(direction, gameStatusRequest);
    
    
    return new MoveResponse
    {
        Move = direction[Random.Shared.Next(direction.Count)],
        Shout = "I am moving!"
    };
});

/// <summary>
/// Your Battlesnake will receive this request whenever a game it was playing has ended.
/// Use it to learn how your Battlesnake won or lost and deallocated any server-side resources.
/// Your response to this request will be ignored.
/// </summary>
app.MapPost("/end", (GameStatusRequest gameStatusRequest) =>
{
    Results.Ok();
});

app.Run();