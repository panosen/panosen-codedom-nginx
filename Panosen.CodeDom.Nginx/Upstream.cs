using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx
{
    /// <summary>
    /// Upstream
    /// </summary>
    public class Upstream
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Servers
        /// </summary>
        public List<string> Servers { get; set; }
    }

    /// <summary>
    /// UpstreamExtension
    /// </summary>
    public static class UpstreamExtension
    {
        /// <summary>
        /// AddServer
        /// </summary>
        public static Upstream AddServer(this Upstream upstream, string server)
        {
            if (upstream.Servers == null)
            {
                upstream.Servers = new List<string>();
            }

            upstream.Servers.Add(server);

            return upstream;
        }
    }
}
