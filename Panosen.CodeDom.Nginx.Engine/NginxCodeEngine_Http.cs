using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine
{
    /// <summary>
    /// NginxCodeEngine
    /// </summary>
    partial class NginxCodeEngine
    {
        private void GenerateHttp(Http http, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (http == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write("http").Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            codeWriter.Write(options.IndentString).Write("include").Write(Marks.WHITESPACE).Write("/etc/nginx/mime.types").WriteLine(Marks.SEMICOLON);
            codeWriter.Write(options.IndentString).Write("default_type").Write(Marks.WHITESPACE).Write("application/octet-stream").WriteLine(Marks.SEMICOLON);

            codeWriter.WriteLine();
            codeWriter.Write(options.IndentString).Write("log_format").Write(Marks.WHITESPACE).Write("main").Write(Marks.WHITESPACE)
                .Write("'$remote_addr - $remote_user [$time_local] \"$request\" $status $body_bytes_sent \"$http_referer\" \"$http_user_agent\" \"$http_x_forwarded_for\"'")
                .WriteLine(Marks.SEMICOLON);

            codeWriter.WriteLine();
            codeWriter.Write(options.IndentString).Write("access_log").Write(Marks.WHITESPACE).Write("/var/log/nginx/access.log").Write(Marks.WHITESPACE).Write("main")
                .WriteLine(Marks.SEMICOLON);

            codeWriter.WriteLine();
            codeWriter.Write(options.IndentString).Write("sendfile").Write(Marks.WHITESPACE).Write("on").WriteLine(Marks.SEMICOLON);
            codeWriter.Write(options.IndentString).Write("#tcp_nopush").Write(Marks.WHITESPACE).Write("on").WriteLine(Marks.SEMICOLON);

            codeWriter.WriteLine();
            codeWriter.Write(options.IndentString).Write("keepalive_timeout").Write(Marks.WHITESPACE).Write("65").WriteLine(Marks.SEMICOLON);

            codeWriter.WriteLine();
            codeWriter.Write(options.IndentString).Write("#gzip").Write(Marks.WHITESPACE).Write("on").WriteLine(Marks.SEMICOLON);

            codeWriter.WriteLine();
            codeWriter.Write(options.IndentString).Write("include").Write(Marks.WHITESPACE).Write("/etc/nginx/conf.d/*.conf").WriteLine(Marks.SEMICOLON);

            if (http.UpstreamList != null && http.UpstreamList.Count > 0)
            {
                foreach (var upstream in http.UpstreamList)
                {
                    codeWriter.WriteLine();
                    GenerateUpstream(upstream, codeWriter, options);
                }
            }

            if (http.ServerList != null && http.ServerList.Count > 0)
            {
                foreach (var server in http.ServerList)
                {
                    codeWriter.WriteLine();
                    Generate(server, codeWriter, options);
                }
            }

            options.PopIndent();
            codeWriter.WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
