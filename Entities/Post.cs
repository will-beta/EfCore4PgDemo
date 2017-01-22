using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string[] Tags { get; set; }

        public DateTime[] Festivals { get; set; }

        public string Author { get; set; }

        public PostTypeEnum PostType { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----------------------------------");
            sb.AppendLine($"{PostId}        {CreatedAt.ToString("o")}       [ {PostTitle} ]");
            sb.AppendLine($"{Author}        {PostType}");
            sb.AppendLine($"Tags: {string.Join(",", Tags)}");
            sb.AppendLine($"Festivals: {string.Join(",", Festivals)}");
            sb.AppendLine($"{Content}");
            sb.AppendLine("-----------------------------------");
            return sb.ToString();
        }
    }
}
