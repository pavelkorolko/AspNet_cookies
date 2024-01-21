using Classwork_19._01._24_cookiesUsage_.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace Classwork_19._01._24_cookiesUsage_.Helpers
{
    public static class TableHelper
    {
        public static HtmlString CreateTable(this IHtmlHelper html, IEnumerable<object> data)
        {
            StringBuilder str = new StringBuilder();
            int count = 0;

            str.AppendLine("""
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Name</th>
                            <th scope="col">Email</th>
                        </tr>
                    </thead>
                """);

            foreach (var item in data) {
                if (item is User)
                {
                    User user = (User)item;
                    str.Append($"""
                        <tr onclick="window.location.href='/home/setuser/{user.Id}'">
                          <th scope="row">{++count}</th>
                          <td>{user.Name}</td>
                          <td>{user.Email}</td>
                        </tr>
                    """);
                }
                else if(item is News)
                {
                    News newsItem = (News)item;
                    str.Append($"""
                        <tr>
                          <th scope="row">{++count}</th>
                          <td>{newsItem.Name}</td>
                          <td>{newsItem.Content}</td>
                        </tr>
                    """);
                }
                else
                {
                    throw new Exception("Unknown type!");
                }
            }
            return new HtmlString(str.ToString());
        }
    }
}
