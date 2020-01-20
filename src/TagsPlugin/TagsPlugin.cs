using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Terrier;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TagsPlugin
{
    public class TagsPlugin : TerrierPlugin
    {
        public static string GetPluginDirectory() => Path.Combine(TerrierConstants.PluginsDirectory, nameof(TagsPlugin));

        public override string Name { get; } = "Tags";
        public override string Description { get; } = "Create and manage simple tag commands for Terrier";
        public override string Version { get; } = "0.1.0";

        public override void OnEnable()
        {
            string configPath = Path.Combine(TagsPlugin.GetPluginDirectory(), "_config.yml");
            if (File.Exists(configPath)) return;

            var serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();

            var yaml = serializer.Serialize(new TagConfig());
            File.WriteAllText(configPath, yaml);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TagManager>()
                .AddTransient<TagDatabase>();
        }
    }
}
