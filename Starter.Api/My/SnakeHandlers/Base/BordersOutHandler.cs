using Starter.Api.Requests;

namespace Starter.Api
{
    public class BordersOutHandler : ISnakeHandler
    {
        public void Handle(List<string> directions, GameStatusRequest context)
        {
            if (context.You.Head.X == 0)
            {
                directions.Remove("left");
            }

            if (context.You.Head.X == context.Board.Width - 1)
            {
                directions.Remove("right");
            }

            if (context.You.Head.Y == 0)
            {
                directions.Remove("down");
            }

            if (context.You.Head.Y == context.Board.Height - 1)
            {
                directions.Remove("up");
            }
        }

        public void Handle(List<string> directions, GameStatusRequest context, Coordinate headPosition)
        {
            if (headPosition.X == 0)
            {
                directions.Remove("left");
            }

            if (headPosition.X == context.Board.Width - 1)
            {
                directions.Remove("right");
            }

            if (headPosition.Y == 0)
            {
                directions.Remove("down");
            }

            if (headPosition.Y == context.Board.Height - 1)
            {
                directions.Remove("up");
            }
        }
    }
}
