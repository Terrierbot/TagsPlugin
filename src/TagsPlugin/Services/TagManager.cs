using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace TagsPlugin
{
    public class TagManager
    {
        public IQueryable<Tag> Tags => _db.Tags.AsQueryable();

        private readonly ILogger<TagManager> _logger;
        private readonly TagDatabase _db;

        public TagManager(ILogger<TagManager> logger, TagDatabase db)
        {
            _logger = logger;
            _db = db;
        }

        public bool TagExists(ulong guildId, string name)
            => _db.Tags.Any(x => x.GuildId == guildId && x.Name == name.ToLower());

        public Tag GetTag(ulong guildId, string name)
            => _db.Tags.SingleOrDefault(x => x.GuildId == guildId && x.Name == name.ToLower());

        public async Task CreateTagAsync(Tag tag)
        {
            await _db.Tags.AddAsync(tag);
            await _db.SaveChangesAsync();
        }
    }
}
