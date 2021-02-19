using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using forkgg.Logic.Model;

namespace forkgg.Logic
{
    public class FeatureTools
    {
        private static FeatureTools instance;
        public static FeatureTools Instance => instance??=new FeatureTools();

        private FeatureTools()
        {
            features = FeaturesFromJson();
            UpdateFeatures();
        }

        private List<Feature> features;

        public List<Feature> Features
        {
            get
            {
                //TODO add file watcher to this
                features = FeaturesFromJson();
                UpdateFeatures();
                return features;
            }
        }
        
        private void UpdateFeatures()
        {
            DirectoryInfo featureDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\features"));
            List<Feature> newFeatures = FindNewFeatures();
            if (newFeatures.Count > 0)
            {
                features.AddRange(newFeatures);
                File.WriteAllText(Path.Combine(featureDirectory.FullName, "features.json"), JsonSerializer.Serialize(features, new JsonSerializerOptions{WriteIndented = true}));
            }
        }

        private List<Feature> FeaturesFromJson()
        {
            DirectoryInfo featureDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\features"));
            FileInfo json = new FileInfo(Path.Combine(featureDirectory.FullName, "features.json"));
            if (!json.Exists)
            {
                return new List<Feature>();
            }

            try
            {
                List<Feature> result =
                    JsonSerializer.Deserialize<List<Feature>>(File.ReadAllText(json.FullName));
                var list = result;
                if (list != null)
                {
                    List<Feature> finalResult = new List<Feature>();
                    foreach (Feature feature in result)
                    {
                        if (new FileInfo(Directory.GetCurrentDirectory()+ @"\wwwroot"+ feature.IconPath.Replace("/", @"\")).Exists)
                        {
                            finalResult.Add(feature);
                        }
                    }
                    return finalResult;
                }
                return new List<Feature>();
            }
            catch (Exception e)
            {
                Console.WriteLine("["+DateTime.Now+"] "+e);
                return new List<Feature>();
            }
        }

        private List<Feature> FindNewFeatures()
        {
            List<Feature> result = new List<Feature>();
            DirectoryInfo featureDirectory =
                new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\features"));
            foreach (FileInfo file in featureDirectory.GetFiles("*.svg"))
            {
                string path = "/data/features/" + file.Name;
                if (features.Count(f => f.IconPath == path) == 0
                    && result.Count(f =>f.IconPath == path) == 0)
                {
                    result.Add(new Feature
                    {
                        Title = file.Name, IconPath = "/data/features/" + file.Name,
                        Description = ""
                    });
                }
            }

            return result;
        }
    }
}