await Bootstrapper
  .Factory
  .CreateWeb(args)
  .DeployToGitHubPagesBranch(
        "h4wl",
        "l5r",
        Config.FromSetting<string>("GITHUB_TOKEN"),
        "gh-pages"
    )
  .RunAsync();