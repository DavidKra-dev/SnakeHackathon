namespace Starter.Api.My.Algorithms
{
    public class DFS
    {
        private List<Coordinate> _visitedSteps = new List<Coordinate>();
        private Stack<Coordinate> _notVisitedSteps = new Stack<Coordinate>();

        public List<Coordinate> VisitedSteps { get { return _visitedSteps; } }
        public Stack<Coordinate> NotVisitedSteps { get { return _notVisitedSteps; } }

        public void Start(int[][] graph)
        {
            _visitedSteps.Clear();
            _notVisitedSteps.Clear();

            Algorithm(graph);
        }

        private void Algorithm(int[][] graph)
        {

        }
    }
}
