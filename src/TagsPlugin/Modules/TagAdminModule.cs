using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Terrier.Commands;

namespace TagsPlugin.Modules
{
    [RequireUserPermission(GuildPermission.Administrator)]
    public class TagAdminModule : DiscordModuleBase
    {
        private readonly TagManager _manager;

        public TagAdminModule(TagManager manager)
        {
            _manager = manager;
        }

        [Command("settagowner")]
        public async Task TagAsync(string name, [Remainder]SocketGuildUser user)
        {
            await Task.Delay(0);
        }
    }
}
