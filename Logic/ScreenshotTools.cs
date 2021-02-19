using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using forkgg.Logic.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace forkgg.Logic
{
    public class ScreenshotTools
    {
        private static ScreenshotTools instance;

        public static ScreenshotTools Instance => instance??=new ScreenshotTools();

        private List<CustomFileInfo> screenshots;

        private ScreenshotTools()
        {
            screenshots = ScreenshotsFromJson();
            UpdateScreenshots();
        }
        
        public List<CustomFileInfo> Screenshots
        {
            get
            {
                //TODO update with file watcher
                //screenshots = ScreenshotsFromJson();
                //UpdateScreenshots();
                return screenshots;
            }
        }

        private void UpdateScreenshots()
        {
            DirectoryInfo screenshotDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\screenshots"));
            List<CustomFileInfo> newScreenshots = FindNewScreenshots();
            if (newScreenshots.Count > 0)
            {
                screenshots.AddRange(newScreenshots);
                File.WriteAllText(Path.Combine(screenshotDirectory.FullName, "screenshots.json"), JsonSerializer.Serialize(screenshots, new JsonSerializerOptions{WriteIndented = true}));
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
                    JsonSerializer.Deserialize<List<CustomFileInfo>>(File.ReadAllText(json.FullName));
                var list = result;
                if (list != null)
                {
                    List<CustomFileInfo> finalResult = new List<CustomFileInfo>();
                    foreach (CustomFileInfo fileInfo in result)
                    {
                        if (new FileInfo(Directory.GetCurrentDirectory()+ @"\wwwroot"+ fileInfo.Path.Replace("/", @"\")).Exists)
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
                Console.WriteLine("["+DateTime.Now+"] "+e);
                return new List<CustomFileInfo>();
            }
        }

        private List<CustomFileInfo> FindNewScreenshots()
        {
            List<CustomFileInfo> result = new List<CustomFileInfo>();
            DirectoryInfo screenshotDirectory =
                new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\screenshots"));
            foreach (FileInfo file in screenshotDirectory.GetFiles("*.png"))
            {
                string path = "/data/screenshots/" + file.Name;
                if (screenshots.Count(s => s.Path == path) == 0
                    && result.Count(s => s.Path == path) == 0)
                {
                    result.Add(new CustomFileInfo
                    {
                        Name = file.Name, Path = "/data/screenshots/" + file.Name,
                        Description = ""
                    });
                }
            }

            return result;
        }
    }
}