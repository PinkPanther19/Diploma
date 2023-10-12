public class Position //возвращает строку и столбец вроде
{
   public int Row { get; }
   public int Col { get; }

   public Position(int row, int col)
   {
        Row = row;
        Col = col;
   }

   public override bool Equals(object obj)
    {
        if (obj is Position other)
        {
            return Row == other.Row && Col == other.Col;
        }
         
        return false;
    }
     
    public override int GetHashCode() //уникальный код €чейки вроде
    {
        return 8* Row + Col;
    }
}
