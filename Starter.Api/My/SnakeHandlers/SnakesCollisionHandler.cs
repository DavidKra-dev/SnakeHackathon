using Starter.Api.Requests;

namespace Starter.Api
{
    public class SnakesCollisionHandler : ISnakeHandler
    {
        public void Handle(List<string> directions, GameStatusRequest context)
        {
            List<Coordinate> directionsVec = new List<Coordinate>();
            foreach (var dir in directions)
            {
                directionsVec.Add(StringDirectionConverter.String2Dir(dir));
            }

            foreach (var snake in context.Board.Snakes)
            {
                foreach (var body in snake.Body)
                {
                    for (var i = 0; i < directionsVec.Count; i++)
                    {
                        var directionPos = new Coordinate(context.You.Head.X + directionsVec[i].X, context.You.Head.Y + directionsVec[i].Y);
                        if (directionPos.X == body.X && directionPos.Y == body.Y)
                        {
                            directionsVec.Remove(directionsVec[i]);
                        }
                    }
                }
            }

            directions.Clear();
            foreach(var dir in directionsVec)
            {
                directions.Add(StringDirectionConverter.Dir2String(dir));
            }
        }

        public void Handle(List<string> directions, GameStatusRequest context, Coordinate headPosition)
        {
            List<Coordinate> directionsVec = new List<Coordinate>();
            foreach (var dir in directions)
            {
                directionsVec.Add(StringDirectionConverter.String2Dir(dir));
            }

            foreach (var snake in context.Board.Snakes)
            {
                foreach (var body in snake.Body)
                {
                    for (var i = 0; i < directionsVec.Count; i++)
                    {
                        var directionPos = new Coordinate(headPosition.X + directionsVec[i].X, headPosition.Y + directionsVec[i].Y);
                        if (directionPos.X == body.X && directionPos.Y == body.Y)
                        {
                            directionsVec.Remove(directionsVec[i]);
                        }
                    }
                }
            }

            directions.Clear();
            foreach (var dir in directionsVec)
            {
                directions.Add(StringDirectionConverter.Dir2String(dir));
            }
        }
    }
}
