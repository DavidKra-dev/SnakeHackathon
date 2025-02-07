using Starter.Api.Requests;

namespace Starter.Api
{
    public class SelfCollisionHandler : ISnakeHandler
    {
        public void Handle(List<string> directions, GameStatusRequest context)
        {
            List<Coordinate> directionsVec = new List<Coordinate>();
            foreach (var dir in directions)
                directionsVec.Add(dir.String2Dir());

            foreach (var body in context.You.Body)
            {
                for (var i = 0; i < directionsVec.Count; i++)
                {
                    var directionPos = new Coordinate(context.You.Head.X + directionsVec[i].X, context.You.Head.Y + directionsVec[i].Y);
                    if (directionPos.X == body.X && directionPos.Y == body.Y)
                        directionsVec.Remove(directionsVec[i]);
                }
            }

            directions.Clear();
            foreach(var dir in directionsVec)
                directions.Add(dir.Dir2String());
        }
    }
}
