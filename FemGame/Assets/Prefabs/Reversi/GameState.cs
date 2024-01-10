using System.Collections.Generic;
using System;

public class GameState
{
    public const int Rows = 8;
    public const int Cols = 8;

    public PlayerReversi[,] Board { get; }
    public Dictionary<PlayerReversi, int> DiscCount { get; }
    public PlayerReversi CurrentPlayer { get; private set; }
    public bool GameOver { get; private set; }
    public PlayerReversi Winner { get; private set; }
    public Dictionary<Position, List<Position>> LegalMoves { get; private set; }

    public GameState()
    {
        Board = new PlayerReversi[Rows, Cols];
        Board[3, 3] = PlayerReversi.White;
        Board[3, 4] = PlayerReversi.Black;
        Board[4, 3] = PlayerReversi.Black;
        Board[4, 4] = PlayerReversi.White;

        DiscCount = new Dictionary<PlayerReversi, int>
        {
            {PlayerReversi.Black, 2 },
            {PlayerReversi.White, 2 }
        };

        CurrentPlayer = PlayerReversi.Black;
        LegalMoves = FindLegalMoves(CurrentPlayer);
    }

    public bool MakeMove(Position pos, out MoveInfo moveInfo)
    {
        if(!LegalMoves.ContainsKey(pos))
        {
            moveInfo = null;
            return false;
        }

        PlayerReversi movePlayer = CurrentPlayer;
        List<Position> outflanked = LegalMoves[pos];

        Board[pos.Row, pos.Col] = movePlayer;
        FlipDiscs(outflanked);
        UpdateDiscCounts(movePlayer, outflanked.Count);
        PassTurn(); 

        moveInfo = new MoveInfo { PlayerReversi = movePlayer, Position = pos, Outflanked = outflanked };
        return true;
    }

    public IEnumerable<Position> OccupiedPositions()
    {
        for(int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Cols; c++)
            {
                if (Board[r, c] != PlayerReversi.None)
                {
                    yield return new Position(r,c);
                }
            }
        }
    }

    private void FlipDiscs(List<Position> positions)
    {
        foreach(Position pos  in positions)
        {
            Board[pos.Row, pos.Col] = Board[pos.Row, pos.Col].Opponent();
        }
    }

    private void UpdateDiscCounts(PlayerReversi movePlayer, int outflankedCount)
    {
        DiscCount[movePlayer] += outflankedCount + 1;
        DiscCount[movePlayer.Opponent()] -= outflankedCount;
    }

    private void ChangePlayer()
    {
        CurrentPlayer = CurrentPlayer.Opponent();
        LegalMoves = FindLegalMoves(CurrentPlayer);
    }

    private PlayerReversi FindWinner()
    {
        if (DiscCount[PlayerReversi.Black] > DiscCount[PlayerReversi.White])
        {
            return PlayerReversi.Black;
        }
        if (DiscCount[PlayerReversi.White] > DiscCount[PlayerReversi.Black])
        {
            return PlayerReversi.White;
        }

        return PlayerReversi.None;
    }

    private void PassTurn()
    {
        ChangePlayer();

        if(LegalMoves.Count > 0)
        {
            return;
        }

        ChangePlayer();

        if(LegalMoves.Count == 0)
        {
            CurrentPlayer = PlayerReversi.None;
            GameOver = true;
            Winner = FindWinner();
        }
    }


    private bool IsInsideBoard(int r, int c)
    {
        return r >= 0 && r < Rows && c >= 0 && c < Cols;
    }

    private List<Position> OutflankedInDir(Position pos, PlayerReversi playerReversi, int rDelta, int cDelta)
    {
        List<Position> outflanked = new List<Position>();
        int r = pos.Row + rDelta;
        int c = pos.Col + cDelta;

        while (IsInsideBoard(r, c) && Board[r,c] != PlayerReversi.None)
        {
            if (Board[r,c] == playerReversi.Opponent())
            {
                outflanked.Add(new Position(r, c));
                r += rDelta;
                c += cDelta;
            }
            else // if (Board[r,c] == playerReversi)
            {
                return outflanked;
            }
        }

        return new List<Position>();
    }

    private List<Position> Outflanked(Position pos, PlayerReversi playerReversi)
    {
        List <Position> outflanked = new List<Position> ();
        for(int rDelta = -1; rDelta <= 1;  rDelta++)
        {
            for(int cDelta = -1; cDelta <= 1; cDelta++)
            {
                if(rDelta == 0 && cDelta == 0)
                {
                    continue;
                }

                outflanked.AddRange(OutflankedInDir(pos, playerReversi, rDelta, cDelta));
            }
        }

        return outflanked;
    }

    private bool isMoveLegal(PlayerReversi playerReversi, Position pos, out List<Position> outflanked)
    {
        if (Board[pos.Row, pos.Col] != PlayerReversi.None)
        {
            outflanked = null;
            return false;
        }

        outflanked = Outflanked(pos, playerReversi);
        return outflanked.Count > 0;    
    }

    private Dictionary<Position, List<Position>> FindLegalMoves(PlayerReversi playerReversi)
    {
        Dictionary<Position, List<Position>> legalMoves = new Dictionary<Position, List<Position>>();
        
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Cols; c++)
            {
                Position pos = new Position(r, c);

                if(isMoveLegal(playerReversi, pos, out List<Position> outflanked))
                {
                    legalMoves[pos] = outflanked;
                }
            }
        }

        return legalMoves;
    }

    public GameState(GameState other)
    {
        Board = new PlayerReversi[Rows, Cols];
        Array.Copy(other.Board, Board, Rows * Cols);
        DiscCount = new Dictionary<PlayerReversi, int>(other.DiscCount);
        CurrentPlayer = other.CurrentPlayer;
        GameOver = other.GameOver;
        Winner = other.Winner;
        LegalMoves = new Dictionary<Position, List<Position>>(other.LegalMoves);
    }
}
