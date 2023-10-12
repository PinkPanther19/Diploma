public enum PlayerReversi
{
    None, Black, White
}

public static class PlayerExtensions
{
    public static PlayerReversi Opponent(this PlayerReversi playerReversi)
    {
        if (playerReversi == PlayerReversi.Black)
        {
            return PlayerReversi.White;
        }
        else if (playerReversi == PlayerReversi.White)
        {
            return PlayerReversi.Black;
        }

        return PlayerReversi.None;
    }
}