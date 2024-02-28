namespace CodeCop009;

public class GameManager
{
    private GameManager()
    {

    }

    public static GameManager Instance { get; } = new();

    private readonly List<Game> _games = [];
    public Game CreateNewGame()
    {
        var game = new Game();
        _games.Add(game);
        return game;
    }

    public Game? GetGameById(Guid id)
    {
        return _games.SingleOrDefault(x => x.Id == id);
    }

    public bool DeleteGame(Guid id)
    {
        var game = GetGameById(id);
        return game is not null && _games.Remove(game);
    }
}

public class Game
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public List<Player> Players { get; init; } = [];
}

public class Player
{
    public Player(string name)
    {

    }
}