using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Colliebot.Api.Rest
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("_configuration.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMvc(options => options.ValueProviderFactories.AddDelimitedValueProviderFactory(',', '|'))
            .AddJsonOptions(options =>
             {
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                 options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                 options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
             });

            services.AddCollieDatabase();

            var db = services.BuildServiceProvider().GetRequiredService<RootDatabase>();
            db.Add(new DbDiscordGuild
            {
                Id = 158057120493862912,
                CreatedAt = DateTime.UtcNow,
                Name = "Dog Central",
                OwnerId = 158056840402436096
            });
            db.Add(new DbDiscordUser
            {
                Id = 158056840402436096,
                Name = "Auxesis"
            });
            db.Add(new DbDiscordGuildUser
            {
                Id = 1,
                UserId = 158056840402436096,
                GuildId = 158057120493862912,
                Nickname = "Auxesis"
            });
            db.Add(new DbDiscordGuildUser
            {
                Id = 2,
                UserId = 1580568404024360962,
                GuildId = 158057120493862912,
                Nickname = "Auxesis2"
            });
            db.Add(new DbDiscordGuildUser
            {
                Id = 3,
                UserId = 1580568404024360963,
                GuildId = 158057120493862912,
                Nickname = "Auxesis3"
            });
            db.SaveChanges();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
