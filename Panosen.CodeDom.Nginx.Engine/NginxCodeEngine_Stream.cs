using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine
{
    partial class NginxCodeEngine
    {
        private void GenerateStream(Stream stream, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (stream == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write("stream").Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            if (stream.UpstreamList != null && stream.UpstreamList.Count > 0)
            {
                foreach (var upstream in stream.UpstreamList)
                {
                    codeWriter.WriteLine();
                    GenerateUpstream(upstream, codeWriter, options);
                }
            }

            if (stream.ServerList != null && stream.ServerList.Count > 0)
            {
                foreach (var server in stream.ServerList)
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
