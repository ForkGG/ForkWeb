using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using forkgg.Logic.Model;
using Microsoft.AspNetCore.Mvc;

namespace forkgg.Logic
{
    public class FaqTools
    {
        private static FaqTools instance;
        public static FaqTools Instance => instance??=new FaqTools();

        private FaqTools()
        {
            faqList = ScreenshotsFromJson();
        }

        private List<Faq> faqList;

        public List<Faq> FaqList {
            get
            {
                faqList = ScreenshotsFromJson();
                return faqList;
            }
        }

        private List<Faq> ScreenshotsFromJson()
        {
            DirectoryInfo screenshotDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\faq"));
            FileInfo json = new FileInfo(Path.Combine(screenshotDirectory.FullName, "faq.json"));
            if (!json.Exists)
            {
                return new List<Faq>();
            }

            try
            {
                return JsonSerializer.Deserialize<List<Faq>>(File.ReadAllText(json.FullName));
            }
            catch (Exception e)
            {
                Console.WriteLine("["+DateTime.Now+"] "+e);
                return new List<Faq>();
            }
        }
    }
}