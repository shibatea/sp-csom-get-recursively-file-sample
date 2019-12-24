using System.Security;
using Microsoft.SharePoint.Client;

namespace sp_csom_get_recursively_file_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            const string account = "<account>";
            const string password = "<password>";
            const string webUrl = "https://<tenantname>.sharepoint.com/sites/hogehoge";
            const string libraryTitle = "ライブラリ名";

            var secureString = new SecureString();
            foreach (var c in password) secureString.AppendChar(c);
            secureString.MakeReadOnly();

            var context = new ClientContext(webUrl)
            {
                Credentials = new SharePointOnlineCredentials(account, secureString)
            };

            using (context)
            {
                var library = context.Web.Lists.GetByTitle(libraryTitle);
                library.RootFolder.RecursiveFolder();
            }
        }
    }
}
