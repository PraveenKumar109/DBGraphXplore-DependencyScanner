using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.Collections.Specialized;
using System.Configuration;

namespace DBGraphXplore.CodeDocument.AzureOpenAI
{
    public class DocumentGenerator
    {
        private string ApiKey;
        private string Endpoint;
        private string DeploymentId;

        public DocumentGenerator()
        {
            NameValueCollection configurations = ConfigurationManager.GetSection("OpenAIConfigurations") as NameValueCollection;

            // Get the API key and endpoint from the environment
            this.ApiKey = configurations.Get("OPENAI_API_KEY") ?? throw new InvalidOperationException("OPENAI_API_KEY not found in .config file.");
            this.Endpoint = configurations.Get("OPENAI_ENDPOINT") ?? throw new InvalidOperationException("OPENAI_ENDPOINT not found in .config file.");
            this.DeploymentId = configurations.Get("OPENAI_DEPLOYMENT_ID") ?? throw new InvalidOperationException("OPENAI_DEPLOYMENT_ID not found in .config file.");

        }

        public async Task<string> GenerateTechnicalDocumentAsync(string storedProcedureCode)
        {
            try
            {
                // Initialize the Azure OpenAI client
                AzureOpenAIClient azureClient = new(new Uri(this.Endpoint), new ApiKeyCredential(this.ApiKey));
                ChatClient chatClient = azureClient.GetChatClient(this.DeploymentId);

                var prompt = @"You are an expert technical document writer and SQL specialist. Your task is to create a detailed technical document for a given SQL stored procedure. 
                                The document should include the following sections:
                                Procedure Overview: A brief summary of the stored procedure's purpose, including its functionality and the business use case it addresses.
                                Input Parameters: A detailed description of each input parameter, including the data type, purpose, and expected values or constraints.
                                Output Parameters: (If applicable) Description of any output parameters, their data types, and their significance.
                                Logic Description: A step-by-step explanation of the logic and flow within the stored procedure, including key operations such as validations, conditions, loops, and SQL queries used.
                                Dependencies: A list of tables, views, or other stored procedures referenced or modified by this procedure, with a brief explanation of their role.
                                Example Usage: A sample SQL script demonstrating how to call the procedure, including example values for input parameters and expected results.
                                Error Handling: Explanation of how errors are managed within the procedure, including the use of TRY-CATCH blocks or specific error codes.
                                Performance Considerations: Any optimization techniques used, potential performance bottlenecks, and recommendations for efficient use.
                                Version History: (Optional) Details of any updates or changes made to the procedure, including dates and descriptions.
                                
                                Generate a comprehensive technical document based on the stored procedure definition provided.

                                Below is the SQL stored procedure definition:                             
";

                ChatCompletion completion = chatClient.CompleteChat(
                [
                    // System messages represent instructions or other guidance about how the assistant should behave
                    new SystemChatMessage("You are an expert database analyst and technical writer.\""),

                    // User messages represent user input, whether historical or the most recen tinput
                    new UserChatMessage(prompt+"\n\n"+ storedProcedureCode),
                ]);

                var result = completion.Content[0];
                // Extract the generated response
                return result.Text;
            }
            catch (RequestFailedException ex)
            {
                throw new Exception($"Error during Azure OpenAI API request: {ex.Message}", ex);
            }
        }
    }

}
