using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine
{
    partial class NginxCodeEngine
    {
        private void GenerateUpstream(Upstream upstream, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (upstream == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write("upstream").Write(Marks.WHITESPACE).Write(upstream.Name).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            if (upstream.Servers != null && upstream.Servers.Count > 0)
            {
                foreach (var server in upstream.Servers)
                {
                    codeWriter.Write(options.IndentString).Write("server").Write(Marks.WHITESPACE).Write(server).WriteLine(Marks.SEMICOLON);
                }
            }

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
