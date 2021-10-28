using PoemPost.Shared.Configuration.Identity;
using PoemPost.STS.Identity.Configuration.Interfaces;

namespace PoemPost.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}





