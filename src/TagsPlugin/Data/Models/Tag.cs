using System;

namespace TagsPlugin
{
    public class Tag
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ulong GuildId { get; set; }
        public ulong OwnerId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public override string ToString()
            => Name;
    }
}
