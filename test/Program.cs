using System.Net.NetworkInformation;

namespace test;

class Program
{
    public static async Task<string> GetWebContent(string url)
    {
        using var httpClient = new HttpClient();
        try
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            string html = await httpResponseMessage.Content.ReadAsStringAsync();
            return html;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return "Loi";
        }

    }
    public static async Task<byte[]> DownloadImage(string url)
    {
        using var httpClient = new HttpClient();
        try
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
            return bytes;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }

    }
    public static async Task DownloadStream(string url, string fileName)
    {
        using var httpClient = new HttpClient();
        try
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
            return bytes;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }

    }
    static async Task Main(string[] args)
    {
        var url = "https://img1.freepng.fr/20180204/pyq/kisspng-cristiano-ronaldo-portugal-national-football-team-cristiano-ronaldo-png-picture-5a77078653a020.7826161715177501503425.jpg";
        var bytes = await DownloadImage(url);
        string fileName = "cr7.jpg";
        using var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
        stream.Write(bytes, 0, bytes.Length);
    }
}
