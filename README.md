# AntiCaptchaApi.Net Examples

Practical examples demonstrating how to integrate and use the [AntiCaptchaApi.Net NuGet package](https://www.nuget.org/packages/AntiCaptchaApi.Net) for solving various CAPTCHA types in .NET applications, including reCAPTCHA v2, reCAPTCHA v3, hCaptcha, FunCaptcha, and GeeTest. This repository serves as a companion to the AntiCaptchaApi.Net library, providing ready-to-run code snippets and best practices.

## Topics

`csharp`, `.net`, `dotnet`, `captcha`, `anticaptcha`, `recaptcha`, `hcaptcha`, `funcaptcha`, `geetest`, `examples`, `automation`, `web-scraping`

## Prerequisites

- .NET 9.0 SDK or later
- An Anti-Captcha API key (sign up at [anti-captcha.com](https://anti-captcha.com))

## Examples

### RecaptchaExample

This example demonstrates how to solve a Google reCAPTCHA v2 on the [captchas.info](https://captchas.info) website using the AntiCaptchaApi.Net library.

> **Note**: [captchas.info](https://captchas.info) is our own website specifically created for testing CAPTCHA solutions. It provides various types of CAPTCHAs in a controlled environment, making it perfect for demonstrating how AntiCaptchaApi.Net works.

#### How to Run

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/RemarkableSolutions/AntiCaptchaApi.Net.Examples.git
    cd AntiCaptchaApi.Net.Examples
    ```
2.  **Update API Key:** Open the `RecaptchaExample/Program.cs` file and replace `"YOUR_API_KEY_HERE"` with your actual Anti-Captcha API key.
3.  **Run the example:**
    ```bash
    dotnet run --project RecaptchaExample
    ```

## How It Works

The example uses the AntiCaptchaApi.Net library to communicate with the Anti-Captcha API service. The process flow is:

1.  Initialize the `AnticaptchaClient` with your API key.
2.  Create a request for the specific CAPTCHA type (`RecaptchaV2ProxylessRequest` in this example).
3.  Send the request to the Anti-Captcha service using `SolveCaptchaAsync`.
4.  Wait for the solution.
5.  Use the solution token in an HTTP request to verify it works.
6.  (Optional) Report the outcome of the solution back to Anti-Captcha.

## Additional Resources

-   [AntiCaptchaApi.Net NuGet Package](https://www.nuget.org/packages/AntiCaptchaApi.Net)
-   [AntiCaptchaApi.Net GitHub Repository](https://github.com/RemarkableSolutions/AntiCaptchaApi.Net)
-   [Anti-Captcha API Documentation](https://anti-captcha.com/apidoc)
-   [Medium Article: Breaking Through the CAPTCHA Barrier: A Developer's Guide to AntiCaptchaApi.Net](https://medium.com/@remarkablesolutions/breaking-through-the-captcha-barrier-a-developers-guide-to-anticaptchaapi-net-XXXX)
-   [Selenium.AntiCaptcha Library (for Selenium integration)](https://github.com/RemarkableSolutions/Selenium.AntiCaptcha)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.