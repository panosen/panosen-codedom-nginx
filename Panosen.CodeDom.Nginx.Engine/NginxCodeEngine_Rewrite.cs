using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine
{
    partial class NginxCodeEngine
    {
        private void GenerateRewrite(Rewrite rewrite, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (rewrite == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write("rewrite");

            if (!string.IsNullOrEmpty(rewrite.Regex))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(rewrite.Regex);
            }

            if (!string.IsNullOrEmpty(rewrite.Replacement))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(rewrite.Replacement);
            }

            switch (rewrite.Flag)
            {
                case RewriteFlag.None:
                    break;
                case RewriteFlag.Last:
                    codeWriter.Write(Marks.WHITESPACE).Write("last");
                    break;
                case RewriteFlag.Break:
                    codeWriter.Write(Marks.WHITESPACE).Write("break");
                    break;
                case RewriteFlag.Redirect:
                    codeWriter.Write(Marks.WHITESPACE).Write("rewrite");
                    break;
                case RewriteFlag.Permanent:
                    codeWriter.Write(Marks.WHITESPACE).Write("permanent");
                    break;
                default:
                    break;
            }

            codeWriter.WriteLine(Marks.SEMICOLON);
        }
    }
}
