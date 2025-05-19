using System.Net.Http;
using System.Threading.Tasks;

public class Downloader
{
    public async Task<string> DownloadAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
