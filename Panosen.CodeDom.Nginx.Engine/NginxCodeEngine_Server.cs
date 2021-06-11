using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine
{
    partial class NginxCodeEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="server"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void Generate(NginxServer server, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (server == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write("server").Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            //listen
            if (server.Listen > 0)
            {
                codeWriter.Write(options.IndentString).Write("listen").Write(Marks.WHITESPACE).Write(server.Listen.ToString());
                if (server.SSL)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write("ssl");
                }
                codeWriter.WriteLine(Marks.SEMICOLON);
            }

            //server_name
            if (!string.IsNullOrEmpty(server.ServerName))
            {
                codeWriter.Write(options.IndentString).Write("server_name").Write(Marks.WHITESPACE).Write(server.ServerName).WriteLine(Marks.SEMICOLON);
            }
            if (server.Rewrite != null)
            {
                codeWriter.Write(options.IndentString);
                GenerateRewrite(server.Rewrite, codeWriter, options);
            }

            //ssl_certificate /sample.crt;
            if (!string.IsNullOrEmpty(server.SslCertificate))
            {
                codeWriter.Write(options.IndentString).Write("ssl_certificate").Write(Marks.WHITESPACE).Write(server.SslCertificate).WriteLine(Marks.SEMICOLON);
            }

            //ssl_certificate_key /sample.key;
            if (!string.IsNullOrEmpty(server.SslCertificateKey))
            {
                codeWriter.Write(options.IndentString).Write("ssl_certificate_key").Write(Marks.WHITESPACE).Write(server.SslCertificateKey).WriteLine(Marks.SEMICOLON);
            }

            //client_max_body_size 10m;
            if (!string.IsNullOrEmpty(server.ClientMaxBodySize))
            {
                codeWriter.Write(options.IndentString).Write("client_max_body_size").Write(Marks.WHITESPACE).Write(server.ClientMaxBodySize).WriteLine(Marks.SEMICOLON);
            }

            //proxy_pass http://domain-icp;
            if (!string.IsNullOrEmpty(server.ProxyPass))
            {
                codeWriter.Write(options.IndentString).Write("proxy_pass").Write(Marks.WHITESPACE).Write(server.ProxyPass).WriteLine(Marks.SEMICOLON);
            }

            //error_page   500 502 503 504  /50x.html;
            if (server.ErrorPage != null && server.ErrorPage.Count > 0)
            {
                codeWriter.Write(options.IndentString).Write("error_page");
                foreach (var item in server.ErrorPage)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(item);
                }
                codeWriter.WriteLine(Marks.SEMICOLON);
            }

            //location
            if (server.LocationList != null && server.LocationList.Count > 0)
            {
                foreach (var location in server.LocationList)
                {
                    codeWriter.WriteLine();
                    GenerateLocation(location, codeWriter, options);
                }
            }

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
