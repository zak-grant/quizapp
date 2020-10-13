using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuizApp.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp
{
    public class ProjectSetup
    {
        public void InitialProjectSetup()
        {
            // Configure Services
            var services = new ServiceCollection();
            ConfigureServices(services);
        }

        // Attempt at adding in logging
        public void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IQuestionService, QuestionService>();
            services.BuildServiceProvider(true);
            services.AddLogging(configure => configure.AddConsole());
        }
    }
}
