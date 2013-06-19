using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Twitter.Tests.Config
{
    public class TwitterSession : Session 
    {
        public TwitterSession(IDriverEnvironment environment) : base(environment)
        {
        }

        public string GetBaseUrl()
        {
            return "https://twitter.com";
        }

        public void GoToSite<T>() where T : IBlock
        {
            NavigateTo<T>(GetBaseUrl());
        }

    }
}
