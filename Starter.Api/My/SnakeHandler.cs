using Starter.Api.Requests;

namespace Starter.Api
{
    public interface SnakeHandler
    {
        public void Handle(List<string> directions, GameStatusRequest context);
    }
}
