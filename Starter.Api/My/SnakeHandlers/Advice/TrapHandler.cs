using Starter.Api.Requests;

namespace Starter.Api
{
    public class TrapHandler : ISnakeHandler
    {
        private List<Coordinate> _visitedSteps = new List<Coordinate>();
        private Stack<Coordinate> _notVisitedSteps = new Stack<Coordinate>();

        public void Handle(List<string> directions, GameStatusRequest context)
        {
            Dictionary<string, int> stepsCount = new Dictionary<string, int>();
            foreach (var dir in directions)
            {
                _visitedSteps.Clear();
                _notVisitedSteps.Clear();

                Coordinate dirVec = StringDirectionConverter.String2Dir(dir);
                Coordinate dirHeadPos = new Coordinate(context.You.Head.X + dirVec.X, context.You.Head.Y + dirVec.Y);
                _notVisitedSteps.Push(dirHeadPos);
                DFS(context);

                stepsCount.Add(dir, _visitedSteps.Count);
            }

            int lowestDir = 0;
            string lowestDirName = "";
            foreach (var step in stepsCount)
            {
                if (step.Value > lowestDir)
                {
                    lowestDir = step.Value;
                    lowestDirName = step.Key;
                }
            }
            directions.Remove(lowestDirName);
        }

        public void DFS(GameStatusRequest context)
        {
            var headPos = _notVisitedSteps.Pop();

            var directions = new List<string> { "down", "left", "right", "up" };
            foreach (var dir in directions)
            {
                var dirVec = StringDirectionConverter.String2Dir(dir);
                var nextHeadPos = new Coordinate(headPos.X + dirVec.X, headPos.Y + dirVec.Y);
                foreach (var visited in _visitedSteps)
                {
                    if (nextHeadPos.X == visited.X && nextHeadPos.Y == visited.Y)
                        directions.Remove(dir);
                }
            }
            new BordersOutHandler().Handle(directions, context, headPos);
            new SnakesCollisionHandler().Handle(directions, context, headPos);

            foreach (var dir in directions)
            {
                var dirVec = StringDirectionConverter.String2Dir(dir);
                var nextHeadPos = new Coordinate(headPos.X + dirVec.X, headPos.Y + dirVec.Y);
                _notVisitedSteps.Push(nextHeadPos);
            }
            _visitedSteps.Add(headPos);
            if (_notVisitedSteps.Count > 0)
                DFS(context);
        }
    }
}