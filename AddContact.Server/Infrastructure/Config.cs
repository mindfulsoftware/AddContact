using Microsoft.Extensions.Configuration;

namespace AddContact.Server.Infrastructure
{
    public interface IConfig
    {
        string ConnectionString { get; }
    }

    public class Config : IConfig
    {
        const string ConnectionStringKey = "AddContactConnection";

        public Config(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString(ConnectionStringKey);
        }

        public string ConnectionString { get; }
    }
}
