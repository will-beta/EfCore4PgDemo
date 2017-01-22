using Dal;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Bll
{
    public class Demo
    {
        private readonly ILogger<Demo> _logger;
        private readonly BlogDbContext _context;

        public Demo(ILogger<Demo> logger, BlogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void Run()
        {
            try
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
                _context.Posts.AddRange(newPosts);
                _context.SaveChanges();

                //U操作
                _context.Posts.Where(p => p.PostId > 5).AsParallel().ForAll(p => p.Content = "*");
                _context.SaveChanges();

                //R操作
                _context.Posts.AsNoTracking().AsParallel().ForAll(Console.WriteLine);

                //D操作
                _context.Posts.RemoveRange(_context.Posts);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
