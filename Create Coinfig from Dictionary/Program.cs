using System;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;


namespace Create_Coinfig_from_Dictionary
{

    class RunApp
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Create Config Dictionary
            Dictionary<string, string> configDic = new Dictionary<string, string>();
            configDic.Add("Instance", "https://login.microsoftonline.com/{0}");
            configDic.Add("ApiUrl", "https://graph.microsoft.com/");
            configDic.Add("Tenant", "test5678-fb2c-47ae-b42b-a35012345678");
            configDic.Add("ClientId", "test8765-c4fc-4b4f-b69c-8f9812345678");
            configDic.Add("ClientSecret", "secretLNFF.wtZUOQ-kSUJY1phg4KV~_0hSECRET");

            BuildConfig();

        }

        public static void BuildConfig()
        {

            Console.WriteLine("Entered BuildConfig Method");    

            AuthenticationConfig config = AuthenticationConfig.ReadFromJsonFile("D:\\VisualStudio\\repos\\Create Coinfig from Dictionary\\Create Coinfig from Dictionary\\appsettings.json");


            // Even if this is a console application here, a daemon application is a confidential client application
            IConfidentialClientApplication app;


            // Even if this is a console application here, a daemon application is a confidential client application
            app = ConfidentialClientApplicationBuilder.Create(config.ClientId)
                .WithClientSecret(config.ClientSecret)
                .WithAuthority(new Uri(config.Authority))
                .Build();


            app.AddInMemoryTokenCache();

            // With client credentials flows the scopes is ALWAYS of the shape "resource/.default", as the 
            // application permissions need to be set statically (in the portal or by PowerShell), and then granted by
            // a tenant administrator. 
            string[] scopes = new string[] { $"{config.ApiUrl}.default" }; // Generates a scope -> "https://graph.microsoft.com/.default"


            //##################################################

            // Wait Here as this is where we need the config to authenticate against MS Graph

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"The config contains:  {config}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadKey(); 

            //##################################################
        }






    }






}





