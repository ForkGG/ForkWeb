using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace forkgg.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<CustomFileInfo> Screenshots{get;set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            UpdateScreenshots();
        }

        public void OnGet()
        {

        }

        private void UpdateScreenshots()
        {
            DirectoryInfo screenshotDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\screenshots"));
            Screenshots = new List<CustomFileInfo>();
            foreach (FileInfo file in screenshotDirectory.GetFiles("*.png"))
            {
                Screenshots.Add(new CustomFileInfo {Name = file.Name, Path="/img/screenshots/"+file.Name });
            }
        }

        public class CustomFileInfo
        {
            public string Name { get; set; }
            public string Path { get; set; }
        }
    }
}
