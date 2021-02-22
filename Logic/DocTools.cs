using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using forkgg.Logic.Model.Docs;
using Markdig;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace forkgg.Logic
{
    public class DocTools
    {
        private static DocTools instance;
        public static DocTools Instance => instance ??= new DocTools();

        private DocTools()
        {
            pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseBootstrap().Build();
            Chapters = BuildChapters();
        }

        public void RefreshDocs()
        {
            Chapters = BuildChapters();
        }

        private readonly MarkdownPipeline pipeline;

        public List<DocChapter> Chapters { get; private set; }

        private List<DocChapter> BuildChapters()
        {
            DirectoryInfo docsDir =
                new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\data\docs"));
            IEnumerable<string> chapters = File.ReadAllLines(Path.Combine(docsDir.FullName,"chapters.txt"));
            List<DirectoryInfo> chapterDirs = new List<DirectoryInfo>(docsDir.EnumerateDirectories());

            List<DocChapter> result = new List<DocChapter>();

            foreach (string chapter in chapters)
            {
                if (string.IsNullOrEmpty(chapter) || !chapterDirs.Any(dir => dir.Name.ToLower().Equals(chapter.ToLower())))
                {
                    Console.WriteLine("No directory found for chapter: "+chapter);
                    continue;
                }
                DirectoryInfo chapterDir = chapterDirs.First(dir => dir.Name.ToLower().Equals(chapter.ToLower()));
                try
                {
                    DocChapter docChapter = ConstructChapter(chapterDir);
                    result.Add(docChapter);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Could not create chapter "+chapter+": "+e);
                }
            }

            return result;
        }

        private DocChapter ConstructChapter(DirectoryInfo chapterDir)
        {
            DocChapter result = new DocChapter {Name = chapterDir.Name, Entries = new List<DocEntry>()};
            List<FileInfo> entryFiles = new List<FileInfo>(chapterDir.EnumerateFiles());
            
            //Read index
            if (entryFiles.Any(file => file.Name.ToLower().Equals("index.md")))
            {
                try
                {
                    DocFileContent indexContent =
                        ReadFileContent(entryFiles.First(file => file.Name.ToLower().Equals("index.md")));
                    result.ContentMd = indexContent.Md;
                    result.ContentHtml = indexContent.Html;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not read index for chapter "+chapterDir.Name+": "+e);
                }
            }

            IEnumerable<string> entryNames = File.ReadAllLines(Path.Combine(chapterDir.FullName, "entries.txt"));
            foreach (string entryName in entryNames)
            {
                if (string.IsNullOrEmpty(entryName) || !entryFiles.Any(dir => dir.Name.ToLower().Equals(entryName.ToLower()+".md")))
                {
                    Console.WriteLine("No file found for chapter: "+entryName);
                    continue;
                }
                FileInfo entryFile = entryFiles.First(dir => dir.Name.ToLower().Equals(entryName.ToLower()+".md"));
                try
                {
                    DocEntry docEntry = ConstructEntry(entryFile);
                    result.Entries.Add(docEntry);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Could not create chapter "+entryName+": "+e);
                }
            }

            return result;
        }

        private DocEntry ConstructEntry(FileInfo entryFileInfo)
        {
            DocFileContent content = ReadFileContent(entryFileInfo);
            return new DocEntry {Name = Path.GetFileNameWithoutExtension(entryFileInfo.Name), ContentMd = content.Md, ContentHtml = content.Html};
        }

        private DocFileContent ReadFileContent(FileInfo fileInfo)
        {
            string md = File.ReadAllText(fileInfo.FullName);
            string html = Markdown.ToHtml(md, pipeline);
            return new DocFileContent {Md = md, Html = html};
        }
        
        
        
        private class DocFileContent
        {
            public string Md { get; set; }
            public string Html { get; set; }
        }
    }
}