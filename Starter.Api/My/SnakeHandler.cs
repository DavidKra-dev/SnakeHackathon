using Starter.Api.Requests;

namespace Starter.Api
{
    public interface ISnakeHandler
    {
        public void Handle(List<string> directions, GameStatusRequest context);
    }
}
