using System.Collections.Generic;

namespace forkgg.Logic.Model.Docs;

public class Language
{
    public string Name { get; set; }                        
    public string LocalizedName { get; set; }
    public string DirectoryName { get; set; }
    
    private Language(){}


    public static Language ENGLISH = new() {Name = "English", LocalizedName = "English", DirectoryName = "en"};
    public static Language FRENCH = new() {Name = "French", LocalizedName = "Français",DirectoryName = "fr"};
    public static Language SPANISH = new() { Name = "Spanish", LocalizedName = "Español", DirectoryName = "es" };
    public static Language GERMAN = new() {Name = "German", LocalizedName = "Deutsch", DirectoryName = "de"};
    
    public static List<Language> SupportedLanguages { get; } = new() { ENGLISH, FRENCH, SPANISH};
}