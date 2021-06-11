using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Nginx
{
    /// <summary>
    /// 标记符号
    /// </summary>
    public enum RewriteFlag
    {
        /// <summary>
        /// 无
        /// </summary>
        None,

        /// <summary>
        /// 本条规则匹配完成后继续向下匹配新的location URI规则
        /// </summary>
        Last,

        /// <summary>
        /// 本条规则匹配完成后终止，不在匹配任何规则
        /// </summary>
        Break,

        /// <summary>
        /// 返回302临时重定向
        /// </summary>
        Redirect,

        /// <summary>
        /// 返回301永久重定向
        /// </summary>
        Permanent
    }
}
