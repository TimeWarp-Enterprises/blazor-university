namespace BlazorUniversityCom;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Web;
using Statiq.Docs;

internal class Program
{
  public static async Task<int> Main(string[] aArgumentArray) =>
    await Bootstrapper
      .Factory
      .CreateDocs(aArgumentArray)
      .DeployToGitHubPages(
          owner: "TimeWarp-Enterprises",
          name: "blazor-university",
          Config.FromSetting<string>("GITHUB_TOKEN")
      )
      .RunAsync();
}
