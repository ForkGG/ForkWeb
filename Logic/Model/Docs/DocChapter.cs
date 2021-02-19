using System.Collections.Generic;

namespace forkgg.Logic.Model.Docs
{
    public class DocChapter
    {
        public string Name { get; set; }
        public string ContentMd { get; set; }
        public string ContentHtml { get; set; }
        public List<DocEntry> Entries { get; set; }
    }
}