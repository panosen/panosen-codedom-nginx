using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine
{
    partial class NginxCodeEngine
    {
        private void GenerateLocation(Location location, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (location == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write("location");
            if (!string.IsNullOrEmpty(location.Alias))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(location.Alias);
            }
            codeWriter.Write(Marks.WHITESPACE).Write(location.Path).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            //root /usr/share/nginx/html;
            if (!string.IsNullOrEmpty(location.Root))
            {
                codeWriter.Write(options.IndentString).Write("root")
                    .Write(Marks.WHITESPACE).Write(location.Root).WriteLine(Marks.SEMICOLON);
            }

            //index index.html index.htm;
            if (location.Index != null && location.Index.Count > 0)
            {
                codeWriter.Write(options.IndentString).Write("index");
                foreach (var item in location.Index)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(item);
                }
                codeWriter.WriteLine(Marks.SEMICOLON);
            }

            //try_files $uri $uri/ /index.html;
            if (location.TryFiles != null && location.TryFiles.Count > 0)
            {
                codeWriter.Write(options.IndentString).Write("try_files");
                foreach (var item in location.TryFiles)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(item);
                }
                codeWriter.WriteLine(Marks.SEMICOLON);
            }

            #region Proxy

            //proxy_set_header Host $host;
            if (!string.IsNullOrEmpty(location.ProxySetHeader_Host))
            {
                codeWriter.Write(options.IndentString).Write("proxy_set_header")
                    .Write(Marks.WHITESPACE).Write("Host").Write(Marks.WHITESPACE).Write(location.ProxySetHeader_Host).WriteLine(Marks.SEMICOLON);
            }

            //proxy_set_header X-Forwarded-Proto https;
            if (!string.IsNullOrEmpty(location.ProxySetHeader_XForwardedProto))
            {
                codeWriter.Write(options.IndentString).Write("proxy_set_header")
                    .Write(Marks.WHITESPACE).Write("X-Forwarded-Proto").Write(Marks.WHITESPACE).Write(location.ProxySetHeader_XForwardedProto).WriteLine(Marks.SEMICOLON);
            }

            //proxy_set_header X-Real-IP $remote_addr;
            if (!string.IsNullOrEmpty(location.ProxySetHeader_XRealIP))
            {
                codeWriter.Write(options.IndentString).Write("proxy_set_header")
                    .Write(Marks.WHITESPACE).Write("X-Real-IP").Write(Marks.WHITESPACE).Write(location.ProxySetHeader_XRealIP).WriteLine(Marks.SEMICOLON);
            }

            //proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
            if (!string.IsNullOrEmpty(location.ProxySetHeader_XForwadedFor))
            {
                codeWriter.Write(options.IndentString).Write("proxy_set_header")
                    .Write(Marks.WHITESPACE).Write("X-Forwarded-For").Write(Marks.WHITESPACE).Write(location.ProxySetHeader_XForwadedFor).WriteLine(Marks.SEMICOLON);
            }

            //proxy_pass http://domain-icp;
            if (!string.IsNullOrEmpty(location.ProxyPass))
            {
                codeWriter.Write(options.IndentString).Write("proxy_pass").Write(Marks.WHITESPACE).Write(location.ProxyPass).WriteLine(Marks.SEMICOLON);
            }

            #endregion

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
