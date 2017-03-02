public class Tile
{
 
    private Tile up;
    private Tile down;
    private Tile right;
    private Tile left;


    public void SetleftTile (Tile tile)
    {
        left = tile;
    }

    public void SetRightTile (Tile tile)
    {
        right = tile;
    }

    public void SetUpTile (Tile tile)
    {
        up = tile;
    }

    public void SetDownTile (Tile tile)
    {
        down = tile;
    }

    public bool CheckCanMove()
    {
        return up != null;
    }

    public Tile GetUpTile ()
    {
        return up;
    }
}

public class TileMap
{
	private Tile [][] Board;
    public TileMap (int width, int height, int connections)
    {
        Board = new Tile[width][height];
        for (int i=0; i<width; i++)
        {
            for (int j=0; i<height; j++)
            {
                Board[i][j] = new Tile (i, j);
            }
        }
		int VariationPosx = 1;
		int VariationPosy = 0;
        for (int i=0; i<connections; i++)
        {
			int RandomPosx = Random.Range (0, width-1);
			int RandomPosy = Random.Range (0, height-1);
            Tile initial = Board[RandomPosx, RandomPosy];
            Tile tile = Board[RandomPosx+VariationPosx, RandomPosy+VariationPosy];
            if (VariationPosx == 1)
                initial.SetRightTile (tile);
            else if (VariationPosy == 1)
                initial.SetUpTile (tile);
            if (VariationPosx == 0)
                VariationPosx = 1;
            else
                VariationPosx = 0;
            if (VariationPosy == 0)
                VariationPosy = 1;
            else
                VariationPosy = 0;
        }
    }

    public Tile GetTile (int x, int y)
    {
        return Board[x, y];
    }
}

public class Player
{
	private int Posx;
	private int Posy;
    private TileMap map;

    public void TryMove (Direction direction)
    {
        Tile tile = map.GetTile (Posx, Posy);
        switch (direction)
        {
            case Direction.Left:
                if (tile.CheckCanMove ())
                    Posx -= 1;
                break;
            case Direction.Right:
                if (tile.CheckCanMove ())
                    Posx += 1;
                break;
            case Direction.Up:
                if (tile.CheckCanMove ())
                    Posy += 1;
                break;
            case Direction.Down:
                if (tile.CheckCanMove ())
                    Posy -= 1;
                break;
        }
    }
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}