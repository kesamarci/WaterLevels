using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WaterLevels.Client
{
    internal class Program
    {
        static string Url = "http://localhost:5104/api/Data";
        static string Url2 = "https://localhost:7200/api/Data";
        static string path = "InputData/InputData.json";
        static async Task Main(string[] args)
        {
             await  UploadEntriesFromFile();
        }
        public static async Task<bool> UploadEntriesFromFile()
        {
            Console.WriteLine("Most van csoda.");
            var jsonString = File.ReadAllText(path); 
            using var client = new HttpClient();
            //var content = new StringContent(JsonSerializer.Serialize(jsonString), Encoding.UTF8, "application/json");
           
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
           
            // HttpRequestMessage requestMessage=new HttpRequestMessage(HttpMethod.Get, baseUrl2);
            var response = await client.PostAsync(Url2,content);
                response.EnsureSuccessStatusCode();
            
           
            response.EnsureSuccessStatusCode();
           
            return true;


        }
    }
}
