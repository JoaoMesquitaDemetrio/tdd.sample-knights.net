namespace Sample.Knights.Core.Domain.Settings;

public class AppSettings
{
    public ConnectionStringsSettings ConnectionStrings { get; set; }
    public Dictionary<string, string> MongoEntityCollectionMapping { get; set; }

}
