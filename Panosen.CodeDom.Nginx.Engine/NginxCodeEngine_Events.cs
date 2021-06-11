using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine
{
    partial class NginxCodeEngine
    {
        private void GenerateEvents(Events events, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (events == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write("events").Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            codeWriter.Write(options.IndentString).Write("worker_connections").Write(Marks.WHITESPACE).Write(events.WorkConnection.ToString()).WriteLine(Marks.SEMICOLON);

            options.PopIndent();
            codeWriter.WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
