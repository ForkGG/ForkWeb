using System.Collections.Generic;
using System.Linq;
using forkgg.Logic;
using forkgg.Logic.Model.Docs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace forkgg.Pages
{
    public class Docs : PageModel
    {
        public Language ActiveLanguage { get; set; } = Language.ENGLISH;
        public Language DefaultLanguage => Language.ENGLISH;
        public List<DocChapter> Chapters => DocTools.Instance.Chapters;
        public IEnumerable<DocLanguageChapter> LanguageChapters => GetAccordingLanguageChapters();

        public void OnGet()
        {
            string? languageString = HttpContext.Request.Query.TryGetValue("lang", out StringValues languageFromQuery)
                ? languageFromQuery.LastOrDefault()
                : null;
            if (languageString != null)
            {
                ActiveLanguage =
                    Language.SupportedLanguages.FirstOrDefault(l => l.DirectoryName == languageFromQuery) ??
                    Language.ENGLISH;
            }
#if DEBUG
            DocTools.Instance.RefreshDocs();
#endif
        }

        public IEnumerable<DocLanguageChapter> GetAccordingLanguageChapters()
        {
            return Chapters.Select(c =>
                    c.LanguageChapters.TryGetValue(ActiveLanguage, out DocLanguageChapter? value)
                        ? value
                        : c.LanguageChapters.GetValueOrDefault(DefaultLanguage))
                .Where(c => c != null)!;
        }
    }
}