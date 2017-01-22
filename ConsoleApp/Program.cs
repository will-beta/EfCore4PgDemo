using Entities;
using Dal;
using Dal.Pg;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Bll;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main(string[] args)
    {
        var loggerFactory = new LoggerFactory()
           .AddConsole()
           .AddDebug()
           ;


        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()
            ;

        var serviceCollection = new ServiceCollection()
            .AddDbContext<PgBlogDbContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")))
            .AddScoped<BlogDbContext, PgBlogDbContext>()
            .AddTransient<Demo>()
            .AddSingleton(loggerFactory)
            .AddLogging()
            //.AddOptions()
            //.Configure<IOptions<>>(config)
            ;

        var serviceProvider = serviceCollection
            .BuildServiceProvider()
            ;

        serviceProvider.GetRequiredService<Demo>().Run();

        return;

        using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        using (var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>())
        {
            //C操作
            var newPosts = Enumerable.Range(1, 10).Select(i => new Post
            {
                PostId = i,
                CreatedAt = DateTime.Now,
                PostTitle = $"title{i}",
                Content = "#",
                Tags = new[] { "b", "c" },
                Festivals = new[] { DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-2), },
                //Author = new Person { Name = "aa", Age = 23 },
                Author = @"{""Name"":""Li"",""Age"":23}",
                PostType = i % 2 == 0 ? PostTypeEnum.Original : PostTypeEnum.Repost,
            });
            context.Posts.AddRange(newPosts);
            context.SaveChanges();

            //U操作
            context.Posts.Where(p => p.PostId > 5).AsParallel().ForAll(p => p.Content = "*");
            context.SaveChanges();

            //R操作
            context.Posts.AsParallel().ForAll(Console.WriteLine);

            //D操作
            context.Posts.RemoveRange(context.Posts);
            context.SaveChanges();
        }
    }
}