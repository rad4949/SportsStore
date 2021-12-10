using System;
using System.Text.Json.Serialization;

namespace SportsStoreRad.Models
{
    [Serializable]
    public class DBConnect
    {
        public LogLevel Logging { get; set; }
        [JsonPropertyName("ConnectionStrings")]
        public ConnectionStrings DefaultConnection { get; set; }
        public string AllowedHosts { get; set; }
        public DBConnect()
        {
            Logging = new LogLevel();
            DefaultConnection = new ConnectionStrings();
            AllowedHosts = "*";
        }
    }
    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }

        [JsonPropertyName("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHL { get; set; }
        public LogLevel()
        {
            Default = "Information";
            Microsoft = "Warning";
            MicrosoftHL = "Information";
        }
    }
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public ConnectionStrings()
        {
            DefaultConnection = "Server=den1.mssql8.gear.host; Database=sportsstorerad;" +
                " User Id=sportsstorerad; Password=Pq7nwOB~hg~1; MultipleActiveResultSets=true";
        }
    }

}
