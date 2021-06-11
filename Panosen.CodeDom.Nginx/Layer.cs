using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx
{
    /// <summary>
    /// Layer
    /// </summary>
    public abstract class Layer
    {
        /// <summary>
        /// UpstreamList
        /// </summary>
        public List<Upstream> UpstreamList { get; set; }

        /// <summary>
        /// ServerList
        /// </summary>
        public List<NginxServer> ServerList { get; set; }
    }

    /// <summary>
    /// http
    /// </summary>
    public static class LayerExtension
    {
        /// <summary>
        /// add an upstream
        /// </summary>
        public static TLayer AddUpstream<TLayer>(this TLayer layer, Upstream upstream) where TLayer : Layer
        {
            if (layer.UpstreamList == null)
            {
                layer.UpstreamList = new List<Upstream>();
            }

            layer.UpstreamList.Add(upstream);

            return layer;
        }

        /// <summary>
        /// add a server
        /// </summary>
        public static TLayer AddServer<TLayer>(this TLayer layer, NginxServer server) where TLayer : Layer
        {
            if (layer.ServerList == null)
            {
                layer.ServerList = new List<NginxServer>();
            }

            layer.ServerList.Add(server);

            return layer;
        }

        /// <summary>
        /// add an upstream and return it.
        /// </summary>
        public static Upstream AddUpstream(this Layer layer, string name, string server = null)
        {
            if (layer.UpstreamList == null)
            {
                layer.UpstreamList = new List<Upstream>();
            }

            Upstream upstream = new Upstream();
            upstream.Name = name;
            if (!string.IsNullOrEmpty(server))
            {
                upstream.Servers = new List<string> { server };
            }

            layer.UpstreamList.Add(upstream);

            return upstream;
        }

        /// <summary>
        /// add a server and return it.
        /// </summary>
        public static NginxServer AddServer(this Layer layer)
        {
            if (layer.ServerList == null)
            {
                layer.ServerList = new List<NginxServer>();
            }

            NginxServer server = new NginxServer();
            layer.ServerList.Add(server);

            return server;
        }
    }
}
