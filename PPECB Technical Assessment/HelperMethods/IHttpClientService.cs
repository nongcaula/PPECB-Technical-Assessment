using PPECB_Technical_Assessment.HelperMethods;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PPECB_Technical_Assessment.HelperMethods
{
    public interface IHttpClientService
    {
        HttpClient HttpClient();
    }
}
public class GetHttpClientService : IHttpClientService
{
    //Insted of creating HttpClient every time i decided to make it an interface for re-usabiliy
    public HttpClient HttpClient()
    {
        HttpClient client = new HttpClient();
        string Baseurl = HttpContext.Current.Request.Url.AbsoluteUri;
        client.BaseAddress = new Uri(Baseurl);
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return client;
    }
}
