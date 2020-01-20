using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terrier.Commands;

namespace TagsPlugin.Modules
{
    public class TagModule : DiscordModuleBase
    {
        private readonly TagManager _manager;

        public TagModule(TagManager manager)
        {
            _manager = manager;
        }

        [Command("tags")]
        public async Task TagsAsync([Remainder]SocketUser user = null)
        {
            var tags = new List<Tag>();
            if (user == null)
                tags.AddRange(_manager.Tags.Take(50));
            else
                tags.AddRange(_manager.Tags.Where(x => x.OwnerId == user.Id).Take(50));

            var builder = new EmbedBuilder()
                .WithTitle($"Available Tags ({tags.Count()})")
                .WithDescription(string.Join(", ", tags.Select(x => x.Name)));

            await ReplyAsync(builder.Build());
        }

        [Command("tag")]
        public async Task TagAsync(string name)
        {
            var tag = _manager.GetTag(Context.Guild.Id, name);
            if (tag == null)
                await ReplyAsync($"A tag by that name does not exist");
            else
                await ReplyAsync($"**{tag}:** {tag.Content}");
        }

        [Command("createtag")]
        public async Task CreateTagAsync(string name, [Remainder]string content)
        {
            if (_manager.TagExists(Context.Guild.Id, name))
            {
                await ReplyAsync("A tag by that name already exists");
                return;
            }

            var tag = new Tag
            {
                GuildId = Context.Guild.Id,
                OwnerId = Context.User.Id,
                Name = name.ToLower(),
                Content = content
            };

            await _manager.CreateTagAsync(tag);
            await ReplyAsync($"Created the tag `{tag}` successfully");
        }

        [Command("edittag")]
        public async Task EditTagAsync(string name, [Remainder]string content)
        {
            await Task.Delay(0);
        }

        [Command("deletetag")]
        public async Task DeleteTagAsync(string name)
        {
            await Task.Delay(0);
        }

        [Command("abouttag")]
        public async Task AboutTagAsync(string name)
        {
            await Task.Delay(0);
        }
    }
}
