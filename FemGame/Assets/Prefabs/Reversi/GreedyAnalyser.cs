public class GreedyAnalyser : IStateAnalyser
{
    // Scoring is player discs - opponent discs
    public double Evaluate(GameState gameState, PlayerReversi playerReversi)
    {
        int playerCount = gameState.DiscCount[playerReversi];
        int opponentCount = gameState.DiscCount[playerReversi.Opponent()];

        return playerCount - opponentCount;
    }
}
