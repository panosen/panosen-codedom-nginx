using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Nginx.Engine
{
    /// <summary>
    /// NginxFileExtension
    /// </summary>
    public static class NginxFileExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        /// <param name="nginxFile"></param>
        /// <returns></returns>
        public static string TransformText(this NginxFile nginxFile)
        {
            var builder = new StringBuilder();
            new NginxCodeEngine().Generate(nginxFile, builder);
            return builder.ToString();
        }
    }
}
