using Starter.Api.Requests;

namespace Starter.Api
{
    public class BordersOutHandler : SnakeHandler
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
    }
}
