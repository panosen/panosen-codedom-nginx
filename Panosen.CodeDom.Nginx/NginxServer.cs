using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx
{
    /// <summary>
    /// Server
    /// </summary>
    public class NginxServer
    {
        /// <summary>
        /// listen
        /// </summary>
        public int Listen { get; set; }

        /// <summary>
        /// ssl
        /// </summary>
        public bool SSL { get; set; }

        /// <summary>
        /// server_name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// rewrite
        /// </summary>
        public Rewrite Rewrite { get; set; }

        /// <summary>
        /// ssl_certificate
        /// </summary>
        public string SslCertificate { get; set; }

        /// <summary>
        /// ssl_certificate_key
        /// </summary>
        public string SslCertificateKey { get; set; }

        /// <summary>
        /// client_max_boxy_size
        /// </summary>
        public string ClientMaxBodySize { get; set; }

        /// <summary>
        /// proxy_pass http://domain-icp;
        /// </summary>
        public string ProxyPass { get; set; }

        /// <summary>
        /// LocationList
        /// </summary>
        public List<Location> LocationList { get; set; }

        /// <summary>
        /// error_page
        /// </summary>
        public List<string> ErrorPage { get; set; }
    }

    /// <summary>
    /// ServerExtension
    /// </summary>
    public static class ServerExtension
    {
        /// <summary>
        /// SetServerName
        /// </summary>
        public static NginxServer SetServerName(this NginxServer server, string serverName)
        {
            server.ServerName = serverName;

            return server;
        }

        /// <summary>
        /// AddRewrite
        /// </summary>
        public static NginxServer AddRewrite(this NginxServer server, Rewrite rewrite)
        {
            server.Rewrite = rewrite;

            return server;
        }

        /// <summary>
        /// AddRewrite
        /// </summary>
        public static Rewrite AddRewrite(this NginxServer server)
        {
            Rewrite rewrite = new Rewrite();

            server.Rewrite = rewrite;

            return rewrite;
        }

        /// <summary>
        /// AddLocation
        /// </summary>
        public static NginxServer AddLocation(this NginxServer server, Location location)
        {
            if (server.LocationList == null)
            {
                server.LocationList = new List<Location>();
            }

            server.LocationList.Add(location);

            return server;
        }

        /// <summary>
        /// AddLocation
        /// </summary>
        public static Location AddLocation(this NginxServer server, string prefix)
        {
            if (server.LocationList == null)
            {
                server.LocationList = new List<Location>();
            }

            Location location = new Location();
            location.Path = prefix;

            server.LocationList.Add(location);

            return location;
        }

        /// <summary>
        /// AddErrorPage
        /// </summary>
        /// <param name="server"></param>
        /// <param name="errorPage"></param>
        /// <returns></returns>
        public static NginxServer AddErrorPage(this NginxServer server, params string[] errorPage)
        {
            if (errorPage == null || errorPage.Length == 0)
            {
                return server;
            }

            if (server.ErrorPage == null)
            {
                server.ErrorPage = new List<string>();
            }

            server.ErrorPage.AddRange(errorPage);

            return server;
        }
    }
}
