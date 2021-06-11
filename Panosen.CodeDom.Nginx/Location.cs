using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx
{
    /// <summary>
    /// Location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 正则表达式，[ = | ~ | ~* | ^~ ]
        /// 参考http://nginx.org/en/docs/http/ngx_http_core_module.html
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 路径前缀
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// proxy_set_header Host $host;
        /// </summary>
        public string ProxySetHeader_Host { get; set; }

        /// <summary>
        /// proxy_set_header X-Forwarded-Proto https;
        /// </summary>
        public string ProxySetHeader_XForwardedProto { get; set; }

        /// <summary>
        /// proxy_set_header X-Real-IP $remote_addr;
        /// </summary>
        public string ProxySetHeader_XRealIP { get; set; }

        /// <summary>
        /// proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        /// </summary>
        public string ProxySetHeader_XForwadedFor { get; set; }

        /// <summary>
        /// proxy_pass http://domain-icp;
        /// </summary>
        public string ProxyPass { get; set; }

        /// <summary>
        /// root   /usr/share/nginx/html;
        /// </summary>
        public string Root { get; set; }

        /// <summary>
        /// index  index.html index.htm;
        /// </summary>
        public List<string> Index { get; set; }

        /// <summary>
        /// try_files $uri $uri/ /index.html;
        /// </summary>
        public List<string> TryFiles { get; set; }
    }

    /// <summary>
    /// LocationExtension
    /// </summary>
    public static class LocationExtension
    {
        /// <summary>
        /// AddIndex
        /// </summary>
        /// <param name="location"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Location AddIndex(this Location location, params string[] index)
        {
            if (index == null || index.Length == 0)
            {
                return location;
            }

            if (location.Index == null)
            {
                location.Index = new List<string>();
            }

            location.Index.AddRange(index);

            return location;
        }

        /// <summary>
        /// AddTryFiles
        /// </summary>
        /// <param name="location"></param>
        /// <param name="tryFiles"></param>
        /// <returns></returns>
        public static Location AddTryFiles(this Location location, params string[] tryFiles)
        {
            if (tryFiles == null || tryFiles.Length == 0)
            {
                return location;
            }

            if (location.TryFiles == null)
            {
                location.TryFiles = new List<string>();
            }

            location.TryFiles.AddRange(tryFiles);

            return location;
        }
    }
}
