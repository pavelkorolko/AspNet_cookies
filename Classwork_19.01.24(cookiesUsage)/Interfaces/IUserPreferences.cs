using Classwork_19._01._24_cookiesUsage_.Models;

namespace Classwork_19._01._24_cookiesUsage_.Interfaces
{
    public interface IUserPreferences
    {
        Preference GetUserPrefences(string key, HttpContext context);
        void SetUserPreferences(string key, HttpContext context, Preference preference);
    }
}
