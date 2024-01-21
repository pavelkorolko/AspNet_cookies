using Classwork_19._01._24_cookiesUsage_.Interfaces;
using System.Text.Json;

namespace Classwork_19._01._24_cookiesUsage_.Models
{
    public class UserPreferenceService : IUserPreferences
    {
        public Preference GetUserPrefences(string key, HttpContext context)
        {
            Preference preference = null;

            if (context.Request.Cookies.ContainsKey(key))
            {
                string value = context.Request.Cookies[key];
                return JsonSerializer.Deserialize<Preference>(value);
            }

            return preference;
        }

        public void SetUserPreferences(string key, HttpContext context, Preference preference)
        {
            string value = JsonSerializer.Serialize<Preference>(preference);
            context.Response.Cookies.Append(key, value);
        }
    }
}
