using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx
{
    /// <summary>
    /// 地址重定向
    /// </summary>
    public class Rewrite
    {
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Regex { get; set; }

        /// <summary>
        /// 替换
        /// </summary>
        public string Replacement { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        public RewriteFlag Flag { get; set; }
    }

    /// <summary>
    /// Rewrite
    /// </summary>
    public static class RewriteExtension
    {
        /// <summary>
        /// SetRegex
        /// </summary>
        public static Rewrite SetRegex(this Rewrite rewrite, string regex)
        {
            rewrite.Regex = regex;

            return rewrite;
        }

        /// <summary>
        /// SetReplacement
        /// </summary>
        public static Rewrite SetReplacement(this Rewrite rewrite, string replacement)
        {
            rewrite.Replacement = replacement;

            return rewrite;
        }

        /// <summary>
        /// SetFlag
        /// </summary>
        public static Rewrite SetFlag(this Rewrite rewrite, RewriteFlag rewriteFlag)
        {
            rewrite.Flag = rewriteFlag;

            return rewrite;
        }
    }
}
