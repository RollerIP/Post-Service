using Newtonsoft.Json;
using Post_Service.Contexts;
using Post_Service.Messaging;
using Post_Service.Models;

namespace Post_Service.Services
{
    public class UserService : IHostedService
    {
        private readonly IMessageService _messageService;
        private readonly IServiceScopeFactory _scopeFactory;

        public UserService(IMessageService messageService, IServiceScopeFactory scopeFactory)
        {
            _messageService = messageService;
            _scopeFactory = scopeFactory;

            _messageService.Subscribe("UserUpdate", OnUserUpdate);
        }

        private void OnUserUpdate(NatsMessage message)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(message.content);

            using (var scope = _scopeFactory.CreateScope())
            {
                DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();

                context.UpdateRange(users);
                context.SaveChanges();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _messageService.Subscribe("UserUpdate", OnUserUpdate);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
