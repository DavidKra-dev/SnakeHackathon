using Starter.Api.Requests;

namespace Starter.Api
{
    public class BaseHandler
    {
        private static List<ISnakeHandler> _handlers = new List<ISnakeHandler>()
        {
            new BordersOutHandler(),
            new SnakesCollisionHandler(),
        };

        public static void Handle(List<string> directions, GameStatusRequest context)
        {
            foreach (var handler in _handlers)
            {
                if (directions.Count > 1)
                    handler.Handle(directions, context);
            }
        }
    }
}
