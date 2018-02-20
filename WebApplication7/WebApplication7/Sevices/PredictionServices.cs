using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApplication7.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication7.Sevices

{
    public class PredictionServices
    {
       
        //////////////
            public  string ServiceCall(PredictionViewModel user)
            {
              string r= InvokeRequestResponseService(user).Result;
            return r;


            }

            static async Task<string> InvokeRequestResponseService(PredictionViewModel user)
            {
                using (var client = new HttpClient())
                {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "Staff ID", user.StaffID.ToString()
                                            },
                                            {
                                                "Dept ID", user.Dept.ToString()
                                            },
                                            {
                                                "Date", user.Date.ToString("yyyy-MM-dd")
                                            },
                                            {
                                                "Day", user.Date.ToString("ddd")
                                            },
                                            {
                                                "Event", user.Event.ToString()
                                            },
                                            {
                                                "Potential Days", user.PotentialDay.ToString()
                                            },
                                            {
                                                "Session", user.Session.ToString()
                                            },
                                            {
                                                "Weather", user.Weather.ToString()
                                            },
                                            {
                                                "jobSatisfaction", user.jobSatisfaction.ToString()
                                            },
                                }
                            }
                        },
                    },
                        GlobalParameters = new Dictionary<string, string>()
                        {
                        }
                    };

                    const string apiKey = "+8aJ+VW/gC5ImiZn+Uk0JhUM7YOiHGOSF5PPs2s6EILGXCnu+9Hn2h+SupdFyh/2HHPtef8Q2mS3RkamxZwFig=="; // Replace this with the API key for the web service
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/dbc7a4587f874d97886dab4e20cfc6dc/services/cb43f8aef93c43629a153e275af1e559/execute?api-version=2.0&format=swagger");
                    HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                    dynamic stuff = JObject.Parse(result);

                    var r= stuff.Results.output1[0]["Scored Labels"];
                    string apiresult = r.ToString();

                    return apiresult;
                    }
                    else
                    {
                       // Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));
                        string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                    }
                }
            }
}
}
