# AntiCaptchaApi.Net Examples

This repository contains examples demonstrating how to use the [AntiCaptchaApi.Net](https://github.com/RemarkableSolutionsAdmin/AntiCaptchaApi.Net) library to solve various types of CAPTCHAs.

## Prerequisites

- .NET 9.0 SDK or later
- An Anti-Captcha API key (sign up at [anti-captcha.com](https://anti-captcha.com))

## Examples

### RecaptchaExample

This example demonstrates how to solve a Google reCAPTCHA v2 on the [captchas.info](https://captchas.info) website using the AntiCaptchaApi.Net library.

> **Note**: [captchas.info](https://captchas.info) is our own website specifically created for testing CAPTCHA solutions. It provides various types of CAPTCHAs in a controlled environment, making it perfect for demonstrating how AntiCaptchaApi.Net works.

#### How to Run

1. Open the `RecaptchaExample/Program.cs` file
2. Replace `YOUR_API_KEY_HERE` with your actual Anti-Captcha API key
3. Navigate to the example directory:
   ```
   cd AntiCaptchaApi.Net.Examples/RecaptchaExample
   ```
4. Run the example:
   ```
   dotnet run
   ```

## How It Works

The example uses the AntiCaptchaApi.Net library to communicate with the Anti-Captcha API service. The process flow is:

1. Initialize the AntiCaptchaClient with your API key
2. Create a request for the specific CAPTCHA type (RecaptchaV2ProxylessRequest in this example)
3. Send the request to the Anti-Captcha service using SolveCaptchaAsync
4. Wait for the solution
5. Use the solution token in an HTTP request to verify it works

## Additional Resources

- [AntiCaptchaApi.Net Documentation](https://github.com/RemarkableSolutionsAdmin/AntiCaptchaApi.Net)
- [Anti-Captcha API Documentation](https://anti-captcha.com/apidoc)
- [Medium Article: Solving CAPTCHAs with AntiCaptchaApi.Net](https://medium.com/@remarkablesolutions/solving-captchas-with-anticaptchaapi-net-a-comprehensive-guide-XXXX)

## License

This project is licensed under the MIT License - see the LICENSE file for details.