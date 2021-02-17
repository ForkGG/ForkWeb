using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
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
            DirectoryInfo screenshotDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\screenshots"));
            Screenshots = ScreenshotsFromJson();
            List<CustomFileInfo> newScreenshots = FindNewScreenshots();
            if (newScreenshots.Count > 0)
            {
                Screenshots.AddRange(newScreenshots);
                System.IO.File.WriteAllText(Path.Combine(screenshotDirectory.FullName, "screenshots.json"), JsonSerializer.Serialize(Screenshots, new JsonSerializerOptions{WriteIndented = true}));
            }
        }

        private List<CustomFileInfo> ScreenshotsFromJson()
        {
            DirectoryInfo screenshotDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\screenshots"));
            FileInfo json = new FileInfo(Path.Combine(screenshotDirectory.FullName, "screenshots.json"));
            if (!json.Exists)
            {
                return new List<CustomFileInfo>();
            }

            try
            {
                List<CustomFileInfo> result =
                    JsonSerializer.Deserialize<List<CustomFileInfo>>(System.IO.File.ReadAllText(json.FullName));
                var list = result;
                if (list != null)
                {
                    List<CustomFileInfo> finalResult = new List<CustomFileInfo>();
                    foreach (CustomFileInfo fileInfo in result)
                    {
                        if (new FileInfo(fileInfo.FullName).Exists)
                        {
                            finalResult.Add(fileInfo);
                        }
                    }
                    return finalResult;
                }
                return new List<CustomFileInfo>();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.ToString());
                return new List<CustomFileInfo>();
            }
        }

        private List<CustomFileInfo> FindNewScreenshots()
        {
            List<CustomFileInfo> result = new List<CustomFileInfo>();
            DirectoryInfo screenshotDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\screenshots"));
            foreach (FileInfo file in screenshotDirectory.GetFiles("*.png"))
            {
                string path = "/data/screenshots/" + file.Name;
                if (Screenshots.Count(s => s.Path == path) == 0
                    && result.Count(s => s.Path == path) == 0)
                {
                    result.Add(new CustomFileInfo {Name = file.Name, FullName = file.FullName, Path="/data/screenshots/"+file.Name, Description = ""});
                }
            }
            
            return result;
        }

        public class CustomFileInfo
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public string FullName { get; set; }
            public string Description { get; set; }
        }
    }
}
