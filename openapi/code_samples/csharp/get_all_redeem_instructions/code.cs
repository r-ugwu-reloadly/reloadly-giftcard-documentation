using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WebAPIClient {
  class Program {

    static async Task Main(string[] args) {
      await ApiCall();
    }

    private static async Task ApiCall() {

      var message = new HttpRequestMessage(HttpMethod.Get, "https://giftcards.reloadly.com/redeem-instructions");
      
      message.Headers.TryAddWithoutValidation("Authorization", "Bearer eyJraXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
      message.Headers.TryAddWithoutValidation("Accept", "application/com.reloadly.giftcards-v1+json");

      using
      var httpClient = new HttpClient();
      var response = await httpClient.SendAsync(message);
      var responseBody = await response.Content.ReadAsStringAsync();
      var result = JsonConvert.DeserializeObject < dynamic > (responseBody);

      Console.WriteLine(result);
    }

  }
}