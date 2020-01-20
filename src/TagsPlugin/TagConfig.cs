namespace TagsPlugin
{
    public class TagConfig
    {
        public int MaxOwnedTags { get; } = 50;
        public int TagsPerPage { get; } = 50;
        public bool CaseSensitiveNaming { get; } = true;
    }
}
