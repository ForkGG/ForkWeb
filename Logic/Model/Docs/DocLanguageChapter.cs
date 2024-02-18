using System.Collections.Generic;

namespace forkgg.Logic.Model.Docs;

public class DocLanguageChapter
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string ContentMd { get; set; }
    public string ContentHtml { get; set; }
    public Language Language { get; set; }
    public List<DocEntry> Entries { get; set; }
}