using System.Net.Http.Headers;

internal class Program
{
    private static void Main(string[] args)
    {
        var url = "http://localhost:5233/api/v1/Auth";
        
        HttpClient fetchClient = new HttpClient();
        
        var token  = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InN0cmluZyIsImp0aSI6ImI4ZGFiNGY0LThkMWUtNDRkOC1iMGRjLWQ5NWEyNmE1ZGMyMyIsImV4cCI6MTcwNTg1NzIwNiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MjMzIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MjMzIn0.Ga7daP_O7D7WryGhd99nml9Fa7MNefW4KZ9wZfE-tj8";
        fetchClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        
        var response = fetchClient.GetAsync(url).Result;
        
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
}