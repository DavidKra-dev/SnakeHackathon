using Starter.Api.Requests;

namespace Starter.Api
{
    public class TrapHandler : ISnakeHandler
    {
        public int MaxSteps { get; set; }

        private int _currentSteps;

        public void Handle(List<string> directions, GameStatusRequest context)
        {
            _currentSteps = 0;
            for (int i = 0; i < directions.Count; i++)
            {
                Console.WriteLine(directions[i]);
                _currentSteps = 0;
                var isSaveWay = Analyze(directions[i], context);
                if (!isSaveWay)
                {
                    directions.RemoveAt(i);
                }
                Console.WriteLine(isSaveWay);
            }
            Console.WriteLine();
        }

        public bool Analyze(string direction, GameStatusRequest context)
        {
            Coordinate dirVec = StringDirectionConverter.String2Dir(direction);

            GameStatusRequest nextContext = context;
            nextContext.You.Head = new Coordinate(nextContext.You.Head.X + dirVec.X, nextContext.You.Head.Y + dirVec.Y);
            var nextSaveDirs = new List<string> { "down", "left", "right", "up" };
            BaseHandler.Handle(nextSaveDirs, nextContext);

            _currentSteps++;

            Console.WriteLine("Current step: " + _currentSteps);
            Console.WriteLine("Head Pos: " + " X: " + context.You.Head.X + " Y: " + context.You.Head.Y);
            Console.WriteLine("Save directions: " + nextSaveDirs.Count);

            if (nextSaveDirs.Count < 1)
                return false;
            if (_currentSteps == MaxSteps)
                return true;

            return Analyze(nextSaveDirs[0], nextContext);
        }
    }
}