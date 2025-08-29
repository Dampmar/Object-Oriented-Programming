
public class Ship1D : Ship
{
    public int Length { get; private set; }
    public int Direction { get; private set; } // 0 = horizontal, 1 = vertical

    public Ship1D(int length, int startRow, int startCol, int direction)
        : base(startRow, startCol)
    {
        Length = length;
        Direction = direction;
    }

    // Generate coordinates for a 1D ship (either horizontal or vertical)
    public override IEnumerable<(int row, int col)> GetCoordinates()
    {
        for (int i = 0; i < Length; i++)
        {
            int row = StartRow;
            int col = StartCol;

            switch (Direction)
            {
                case 0: col += i; break; // Right
                case 1: row += i; break; // Down
                default: throw new ArgumentOutOfRangeException(); // Ensure valid direction
            }

            yield return (row, col);
        }
    }
}
