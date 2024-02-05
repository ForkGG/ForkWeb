using System.Collections.Generic;
using forkgg.Logic;
using forkgg.Logic.Model.Docs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace forkgg.Pages
{
    public class Docs : PageModel
    {
        public List<DocChapter> Chapters => DocTools.Instance.Chapters;
        
        public void OnGet()
        {
#if DEBUG
            DocTools.Instance.RefreshDocs();
#endif
        }
    }
}