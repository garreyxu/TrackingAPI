// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Tracking.Client;

HttpClient client = new()
{
    BaseAddress = new Uri("https://localhost:7165")
};
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/issue");
response.EnsureSuccessStatusCode();

if (response.IsSuccessStatusCode)
{
    var issues = await response.Content.ReadFromJsonAsync<IEnumerable<IssueDTO>>();
    foreach (var issue in issues)
    {
        Console.WriteLine(issue.Title);
    }
}
else
{
    Console.WriteLine("No result.");
}
Console.ReadLine();
