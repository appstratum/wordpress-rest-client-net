using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;

namespace WebApiClient
{
    class Program
    {

        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("\n\n***********************************************");
            Console.WriteLine("*** Rarify WordPress Data Import Test Suite ***");
            Console.WriteLine("***********************************************\n\n");

            // await ProcessRepositories();

            // await ProcessSurveys("e-consent");
            // await ProcessSurveys("clinical-survey");
            // await ProcessSurveys("pii-survey");

            await ProcessTrafficOrders("traffic-order");
            await ProcessSurveyRules("survey-rule");

            Console.WriteLine("\n\nEnd\n\n");

        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".Net Foundation Repository Reporter");

            // var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

            // var msg = await stringTask;
            // Console.Write(msg);

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

            foreach(var repo in repositories) {
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GitHubHomeUrl);
                Console.WriteLine(repo.Homepage);
                Console.WriteLine(repo.Watchers);
                Console.WriteLine(repo.LastPushUtc);
                Console.WriteLine(repo.LastPush);
                Console.WriteLine("---------------------------");
                Console.WriteLine(repo.License?.Key);
                Console.WriteLine(repo.License?.Name);
                Console.WriteLine(repo.License?.NodeId);
                Console.WriteLine("\n=====================================\n");                
            }

        }

        private static async Task ProcessSurveys(string wpDataType) {

            Console.WriteLine($"\n>>> Reading Wordpress data type: {wpDataType} <<<\n");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".Net Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"http://wordpress.appstratum.com:8000/wp-json/wp/v2/{wpDataType}");
            var surveys = await JsonSerializer.DeserializeAsync<List<SurveyPost>>(await streamTask);          

            foreach(var survey in surveys) {
                Console.WriteLine(survey.Id);
                Console.WriteLine(survey.CreatedDate);
                Console.WriteLine(survey.ModifiedDate);
                Console.WriteLine(survey.Status);
                Console.WriteLine(survey.Type);

                Console.WriteLine(survey.Title);
                Console.WriteLine(survey.SurveyDef);

                Console.WriteLine(survey.SurveyId);
                Console.WriteLine(survey.SurveyVersionNumber);
                Console.WriteLine(survey.SurveyGroup);
                Console.WriteLine(survey.Language);
                Console.WriteLine(survey.Country);
                Console.WriteLine(survey.Device);

                Console.WriteLine(survey.ResultsVisible);
                Console.WriteLine(survey.SurveyTheme);
                Console.WriteLine(survey.TimeToComplete);

                Console.WriteLine(survey.Categories?.Length);
                Console.WriteLine(survey.Tags?.Length);
                Console.WriteLine(survey.EConsentType?.Length);
                Console.WriteLine(survey.Study?.Length);

                Console.WriteLine("\n=====================================\n");                
            }              

        }       


        private static async Task ProcessTrafficOrders(string wpDataType) {

            Console.WriteLine($"\n>>> Reading Wordpress data type: {wpDataType} <<<\n");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".Net Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"http://wordpress.appstratum.com:8000/wp-json/wp/v2/{wpDataType}");
            var trafficOrders = await JsonSerializer.DeserializeAsync<List<TrafficOrder>>(await streamTask);          

            foreach(var trafficOrder in trafficOrders) {
                Console.WriteLine(trafficOrder.Id);
                Console.WriteLine(trafficOrder.CreatedDate);
                Console.WriteLine(trafficOrder.ModifiedDate);
                Console.WriteLine(trafficOrder.Status);
                Console.WriteLine(trafficOrder.Type);

                Console.WriteLine(trafficOrder.Title);


                Console.WriteLine(trafficOrder.Priority);
                Console.WriteLine(trafficOrder.StartDate);
                Console.WriteLine(trafficOrder.EndDate);
                Console.WriteLine(trafficOrder.StartDateRule);
                Console.WriteLine(trafficOrder.EndDateRule);

                Console.WriteLine(trafficOrder.Categories?.Length);
                Console.WriteLine(trafficOrder.Tags?.Length);
                Console.WriteLine(trafficOrder.Study?.Length);

                Console.WriteLine("\n=====================================\n");                
            }              

        }      


        private static async Task ProcessSurveyRules(string wpDataType) {

            Console.WriteLine($"\n>>> Reading Wordpress data type: {wpDataType} <<<\n");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".Net Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"http://wordpress.appstratum.com:8000/wp-json/wp/v2/{wpDataType}");
            var surveyRules = await JsonSerializer.DeserializeAsync<List<SurveyRule>>(await streamTask);          

            foreach(var surveyRule in surveyRules) {
                Console.WriteLine(surveyRule.Id);
                Console.WriteLine(surveyRule.CreatedDate);
                Console.WriteLine(surveyRule.ModifiedDate);
                Console.WriteLine(surveyRule.Status);
                Console.WriteLine(surveyRule.Type);

                Console.WriteLine(surveyRule.Title);
                Console.WriteLine(surveyRule.RuleExpression);

                Console.WriteLine(surveyRule.Categories?.Length);
                Console.WriteLine(surveyRule.Tags?.Length);

                Console.WriteLine("\n=====================================\n");                
            }              

        }                

    }
}
