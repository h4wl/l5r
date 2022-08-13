namespace Dhb.L5r
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>

          await Bootstrapper
            .Factory
            .CreateWeb(args)
            .AddSetting(WebKeys.MakeLinksAbsolute, true)
            .DeployToGitHubPagesBranch(
                  "h4wl",
                  "l5r",
                  Config.FromSetting<string>("GITHUB_TOKEN"),
                  "gh-pages"
              )
            .RunAsync();
    }
}