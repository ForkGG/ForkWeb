using System.Collections.Generic;

namespace forkgg.Logic.Model.Docs
{
    public class DocChapter
    {
        public Dictionary<Language, DocLanguageChapter> LanguageChapters { get; set; } = new();
    }
}