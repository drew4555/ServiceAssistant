using System;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;
public class SendSimpleMessageChunk
{
    public static IRestResponse SendSimpleMessage()
    {
        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3/"); 

        client.Authenticator = new HttpBasicAuthenticator("api",
                "2c54d6ad956059ff1b57bc3d767362d4-2b0eef4c-5c431e93");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "sandbox0cada1f93e474dc180b76798ca15baca.mailgun.org", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "drew8177@yahoo.com");
        request.AddParameter("to", "drew4555@yahoo.com");
        request.AddParameter("to", "drew4555@yahoo.com");
        request.AddParameter("subject", "Hello");
        request.AddParameter("text", "There Has been a change in your vehicle status. Please Log in to see the change");
        request.Method = Method.POST;
        return client.Execute(request);
    }
    public static IRestResponse SendTechMessage()
    {
        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3/");

        client.Authenticator = new HttpBasicAuthenticator("api",
                "2c54d6ad956059ff1b57bc3d767362d4-2b0eef4c-5c431e93");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "sandbox0cada1f93e474dc180b76798ca15baca.mailgun.org", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "drew8177@yahoo.com");
        request.AddParameter("to", "drew4555@yahoo.com");
        request.AddParameter("to", "drew4555@yahoo.com");
        request.AddParameter("subject", "Hello");
        request.AddParameter("text", "The quote for the vehicle your working on has been updated");
        request.Method = Method.POST;
        return client.Execute(request);
    }
    public static IRestResponse SendPartMessage()
    {
        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3/");

        client.Authenticator = new HttpBasicAuthenticator("api",
                "2c54d6ad956059ff1b57bc3d767362d4-2b0eef4c-5c431e93");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "sandbox0cada1f93e474dc180b76798ca15baca.mailgun.org", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "drew8177@yahoo.com");
        request.AddParameter("to", "drew4555@yahoo.com");
        request.AddParameter("to", "drew4555@yahoo.com");
        request.AddParameter("subject", "Hello");
        request.AddParameter("text", "There is a new Quote awaiting For Part Prices");
        request.Method = Method.POST;
        return client.Execute(request);
    }
    public static IRestResponse SendFinalMessage()
    {
        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3/");

        client.Authenticator = new HttpBasicAuthenticator("api",
                "2c54d6ad956059ff1b57bc3d767362d4-2b0eef4c-5c431e93");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "sandbox0cada1f93e474dc180b76798ca15baca.mailgun.org", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "drew8177@yahoo.com");
        request.AddParameter("to", "drew4555@yahoo.com");
        request.AddParameter("to", "drew4555@yahoo.com");
        request.AddParameter("subject", "Hello");
        request.AddParameter("text", "The Vehicle you have in for service is now complete.");
        request.Method = Method.POST;
        return client.Execute(request);
    }
}