using Starter.Api.Requests;

namespace Starter.Api
{
    public class TrapHandler : ISnakeHandler
    {
        public int MaxSteps { get; set; }

        private int _currentSteps;
        private List<Coordinate> _visitiedSteps = new List<Coordinate>();

        public void Handle(List<string> directions, GameStatusRequest context)
        {
            for (int i = 0; i < directions.Count; i++)
            {
                _currentSteps = 0;
                _visitiedSteps.Clear();
                var isSaveWay = Analyze(directions[i], context, context.You.Head);
                Console.WriteLine(directions[i] + " " + isSaveWay);
                if (!isSaveWay)
                {
                    directions.RemoveAt(i);
                }
            }
            Console.WriteLine();
        }

        public bool Analyze(string direction, GameStatusRequest context, Coordinate headPos)
        {
            Coordinate dirVec = StringDirectionConverter.String2Dir(direction);

            Coordinate nextHeadPos = new Coordinate(headPos.X + dirVec.X, headPos.Y + dirVec.Y); 
            foreach (var step in _visitiedSteps)
                if (nextHeadPos.X == step.X && nextHeadPos.Y == step.Y)
                    return false;
            var nextSaveDirs = new List<string> { "down", "left", "right", "up" };
            nextSaveDirs.Remove(StringDirectionConverter.Dir2String(new Coordinate(headPos.X - nextHeadPos.X, headPos.Y - nextHeadPos.Y)));
            new BordersOutHandler().Handle(nextSaveDirs, context, nextHeadPos);
            new SnakesCollisionHandler().Handle(nextSaveDirs, context, nextHeadPos);

            _currentSteps++;
            _visitiedSteps.Add(headPos);

            Console.WriteLine(_currentSteps);
            Console.WriteLine(" X: " + dirVec.X + " Y: " + dirVec.Y);
            Console.WriteLine(" X: " + headPos.X + " Y: " + headPos.Y);
            Console.WriteLine(" X: " + nextHeadPos.X + " Y: " + nextHeadPos.Y);

            if (nextSaveDirs.Count < 1)
                return false;
            if (_currentSteps == MaxSteps)
                return true;

            return Analyze(nextSaveDirs[0], context, nextHeadPos);
        }
    }
}