using Microsoft.Extensions.Logging;
using MyWebApi;

namespace ClassLibrary1
{
    public class MyBetterService : IMyService
    {
        private readonly CountService countService;
        private readonly ILogger<MyBetterService> logger;

        public MyBetterService(CountService countService, ILogger<MyBetterService> logger )
        {
            this.countService = countService;
            this.logger = logger;
            logger.LogWarning($"MyBetterService ctor CountService count: {countService.Count}");


        }
        public string GetName()
        {
            logger.LogWarning($"MyBetterService CountService count: {countService.Count}");
            return "Jozko from better service";
        }
    }
}