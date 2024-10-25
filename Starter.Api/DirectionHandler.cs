namespace Starter.Api
{
    public class DirectionHandler
    {
        public static void CheckBordersOut(List<string> directions, Coordinate head, int boardWidth, int boardHeight)
        {
            if (head.X == 1)
            {
                directions.Remove("left");
            }
            else if (head.X == boardWidth -1)
            {
                directions.Remove("right");
            }
            else if (head.Y == 1)
            {
                directions.Remove("down");
            }
            else if (head.Y == boardHeight - 1)
            {
                directions.Remove("up");
            }
        }

        public static void CheckMove2Self(List<string> directions, Coordinate head, IEnumerable<Coordinate> bodys)
        {
            List<Coordinate> directionsVec = new List<Coordinate>();
            foreach(var dir in directions)
            {
                Coordinate newCord = new Coordinate(0, 0);
                switch (dir)
                {
                    case "left":
                        newCord.X = -1; newCord.Y = 0;
                        break;
                    case "right":
                        newCord.X = 1; newCord.Y = 0;
                        break;
                    case "up":
                        newCord.X = 0; newCord.Y = 1;
                        break;
                    case "down":
                        newCord.X = 0; newCord.Y = -1;
                        break;
                }
                directionsVec.Add(newCord);
            }

            foreach (var body in bodys)
            {
                for (var i = 0; i < directions.Count; i++)
                {
                    //Console.WriteLine(directions[i]);
                    var directionPos = new Coordinate(head.X + directionsVec[i].X, head.Y + directionsVec[i].Y);
                    if (directionPos.X == body.X && directionPos.Y == body.Y)
                    {
                        directions.Remove(directions[i]);
                    }
                }
            }
        }
    }
}
