using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Nginx.Engine
{
    /// <summary>
    /// ServerExtension
    /// </summary>
    public static class NginxServerExtension
    {
        public static string TransformText(this NginxServer server)
        {
            var builder = new StringBuilder();

            new NginxCodeEngine().Generate(server, builder);

            return builder.ToString();
        }
    }
}
