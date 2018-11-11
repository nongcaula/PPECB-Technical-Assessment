using PPECB_Technical_Assessment.HelperMethods;

namespace PPECB_Technical_Assessment.HelperMethods
{
    public interface IApiHelperService
    {
        string GetAllEmpoyeeAPIUrl();
        string GetEditEmpoyeeUrl(int id);
        string GetDeleteEmpoyeeUrl(int id);
        string GetCreateEmpoyeeUrl();
        string GetSingleEmpoyeeUrl(int id);
    }
}
public class GetAPIHelperUrls : IApiHelperService
{
    //My Helper Urls they will work for any host.
    public string GetAllEmpoyeeAPIUrl()
    {
        return "/api/values";
    }
    public string GetSingleEmpoyeeUrl(int id)
    {
        return "/api/values/" + id;
    }

    public string GetCreateEmpoyeeUrl()
    {
        return "/api/values";
    }

    public string GetDeleteEmpoyeeUrl(int id)
    {
        return "/api/values/" + id;
    }

    public string GetEditEmpoyeeUrl(int id)
    {
        return "/api/values/" + id;
    }
}
