using AntiCaptchaApi.Net;
using AntiCaptchaApi.Net.Models;
using AntiCaptchaApi.Net.Models.Solutions;
using AntiCaptchaApi.Net.Requests;
using AntiCaptchaApi.Net.Enums;
using Newtonsoft.Json;

// Replace with your actual Anti-Captcha API key
const string ANTI_CAPTCHA_API_KEY = "";

await SolveRecaptchaExampleAsync();

async Task SolveRecaptchaExampleAsync()
{
    Console.WriteLine("Starting reCAPTCHA v2 example...");
    
    try
    {
        // Initialize the AntiCaptcha client
        var client = new AnticaptchaClient(ANTI_CAPTCHA_API_KEY);
        
        // Configure client behavior (optional)
        client.Configure(new ClientConfig
        {
            SolveAsyncRetries = 3,
            MaxWaitForTaskResultTimeMs = 120000, // 2 minutes
            DelayTimeBetweenCheckingTaskResultMs = 1000 // 1 second
        });
        
        // Get your account balance (optional)
        var balanceResponse = await client.GetBalanceAsync();
        Console.WriteLine($"Account balance: ${balanceResponse.Balance}");
        
        // Create a request to solve reCAPTCHA v2 on captchas.info
        // Note: captchas.info is our own testing website created specifically for this purpose
        var request = new RecaptchaV2ProxylessRequest
        {
            WebsiteUrl = "https://captchas.info/captchas/recaptcha-v2-standard",
            WebsiteKey = "6LcCfkcrAAAAABjY1ja80Q_xa8zMZ-E7O5Z37N9D",
            IsInvisible = false
        };
        
        Console.WriteLine("Solving reCAPTCHA...");
        
        // Solve the CAPTCHA
        var result = await client.SolveCaptchaAsync<RecaptchaSolution>(request);
        
        // Check for success
        if (result is { ErrorId: 0 or null, Solution: not null })
        {
            Console.WriteLine("CAPTCHA solved successfully!");
            
            // Get a preview of the token
            var tokenPreview = result.Solution.GRecaptchaResponse[..20];
            Console.WriteLine($"Solution token: {tokenPreview}...");
            
            // Use the solution token to submit a form
            using var httpClient = new HttpClient();
            
            // Prepare form data
            var formData = new Dictionary<string, string>
            {
                ["token"] = result.Solution.GRecaptchaResponse
            };
            
            // Submit the form
            var content = new StringContent(JsonConvert.SerializeObject(formData), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(
                "https://captchasinfoapi-production.up.railway.app/api/captcha/verify-recaptcha-v2-standard",
                content);
            
            // Process the response
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Verification response: {responseContent}");
            
            // Report correct solution (optional but helpful)
            if (result.CreateTaskResponse?.TaskId is not null)
            {
                await client.ReportTaskOutcomeAsync(result.CreateTaskResponse.TaskId.Value, ReportOutcome.CorrectRecaptcha);
                Console.WriteLine("Reported solution as correct");
            }
        }
        else
        {
            // Handle error
            var errorDescription = result?.ErrorDescription ?? "Unknown error";
            Console.WriteLine($"Failed to solve CAPTCHA: {errorDescription}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
        Console.WriteLine(ex.StackTrace);
    }
    
    Console.WriteLine("Example completed");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
