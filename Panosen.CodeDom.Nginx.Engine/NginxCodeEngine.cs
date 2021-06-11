using Panosen.CodeDom;
using System;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine
{
    /// <summary>
    /// NginxCodeEngine
    /// </summary>
    public partial class NginxCodeEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        public void Generate(NginxFile nginxFile, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (nginxFile == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.WriteLine("user nginx;");
            codeWriter.WriteLine("worker_processes auto;");

            codeWriter.WriteLine();
            codeWriter.WriteLine("error_log /var/log/nginx/error.log warn;");
            codeWriter.WriteLine("pid /var/run/nginx.pid;");

            GenerateEvents(nginxFile.Events, codeWriter, options);

            GenerateHttp(nginxFile.Http, codeWriter, options);

            GenerateStream(nginxFile.Stream, codeWriter, options);
        }

    }
}
