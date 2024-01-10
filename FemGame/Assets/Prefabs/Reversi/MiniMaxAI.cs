using System;

// An AI implemented using the MiniMax algorithm with alpha-beta pruning.
public class MiniMaxAI
{
    public PlayerReversi PlayerReversi { get; }
    private readonly PlayerReversi opponent;
    private readonly IStateAnalyser analyser;
    private readonly int maxDepth;

    // Is the AI white or black? How are boards analysed? How many moves ahead should the AI look?
    public MiniMaxAI(PlayerReversi playerReversi, IStateAnalyser analyser, int maxDepth)
    {
        if (playerReversi == PlayerReversi.None) throw new ArgumentException("Invalid player");
        if (analyser == null) throw new ArgumentNullException("StateAnalyser is null");
        if (maxDepth <= 0) throw new ArgumentException("Depth must be > 0");

        PlayerReversi = playerReversi;
        opponent = playerReversi.Opponent();
        this.analyser = analyser;
        this.maxDepth = maxDepth;
    }

    // Decide which move to make in the given gameState
    public Position ChooseMove(GameState gameState)
    {
        return MinimaxDecision(gameState);
    }

    // Decide what the best move is at the root of the game tree
    private Position MinimaxDecision(GameState gameState)
    {
        Position bestMove = null;
        double alpha = double.NegativeInfinity;
        double beta = double.PositiveInfinity;

        foreach (var move in gameState.LegalMoves.Keys)
        {
            GameState resultState = GetResultState(gameState, move);
            double value = MinValue(resultState, alpha, beta, maxDepth - 1);
            if (value > alpha)
            {
                bestMove = move;
                alpha = value;
            }
        }

        return bestMove;
    }

    // Minimax value at a max node
    private double MaxValue(GameState gameState, double alpha, double beta, int depth)
    {
        if (IsTerminalState(gameState)) return UtilityValue(gameState);
        if (depth == 0) return HeuristicValue(gameState);
        if (WasTurnSkipped(gameState, PlayerReversi)) return MinValue(gameState, alpha, beta, depth - 1);

        double bestValue = double.NegativeInfinity;

        foreach (var move in gameState.LegalMoves.Keys)
        {
            GameState resultState = GetResultState(gameState, move);
            double value = MinValue(resultState, alpha, beta, depth - 1);
            bestValue = Math.Max(value, bestValue);
            if (bestValue >= beta) break;
            alpha = Math.Max(alpha, value);
        }

        return bestValue;
    }

    // Minimax value at a min node
    private double MinValue(GameState gameState, double alpha, double beta, int depth)
    {
        if (IsTerminalState(gameState)) return UtilityValue(gameState);
        if (depth == 0) return HeuristicValue(gameState);
        if (WasTurnSkipped(gameState, opponent)) return MaxValue(gameState, alpha, beta, depth - 1);

        double bestValue = double.PositiveInfinity;

        foreach (Position move in gameState.LegalMoves.Keys)
        {
            GameState resultState = GetResultState(gameState, move);
            double value = MaxValue(resultState, alpha, beta, depth - 1);
            bestValue = Math.Min(value, bestValue);
            if (value <= alpha) break;
            beta = Math.Min(beta, value);
        }

        return bestValue;
    }

    // Create a copy of gameState and apply move to it
    private GameState GetResultState(GameState gameState, Position move)
    {
        GameState copy = new GameState(gameState);
        copy.MakeMove(move, out _);
        return copy;
    }

    // Is the game over?
    private bool IsTerminalState(GameState gameState)
    {
        return gameState.GameOver;
    }

    // Check if a turn was skipped (the expected player could not move)
    private bool WasTurnSkipped(GameState gameState, PlayerReversi playerReversi)
    {
        return gameState.CurrentPlayer != playerReversi;
    }

    // What is the utility value of gameState? (Performed on terminal states)
    private double UtilityValue(GameState gameState)
    {
        int playerCount = gameState.DiscCount[PlayerReversi];
        int opponentCount = gameState.DiscCount[opponent];

        return playerCount - opponentCount;
    }

    // Apply a heuristic function to the given game state
    private double HeuristicValue(GameState gameState)
    {
        return analyser.Evaluate(gameState, PlayerReversi);
    }
}
