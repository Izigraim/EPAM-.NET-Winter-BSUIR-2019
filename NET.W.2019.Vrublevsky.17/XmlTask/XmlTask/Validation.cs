using System;
using System.Collections.Generic;
using System.Text;

namespace XmlTask
{
    public static class Validation
    {
        public static bool IsValid(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
