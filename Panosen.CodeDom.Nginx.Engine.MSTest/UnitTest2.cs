using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Nginx.Engine.MSTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod()
        {
            NginxServer nginxFile = PrepareNginxServer();

            var actual = nginxFile.TransformText();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private static string PrepareExpected()
        {
            return @"server {
  listen 80;
  server_name localhost;
  error_page 500 502 503 504 /50x.html;

  location / {
    root /usr/share/nginx/html;
    index index.html index.htm;
    try_files $uri $uri/ /index.html;
  }

  location = /50x.html {
    root /usr/share/nginx/html;
  }
}
";
        }

        private static NginxServer PrepareNginxServer()
        {
            var server = new NginxServer();
            server.ServerName = "localhost";
            server.Listen = 80;
            server.AddErrorPage("500", "502", "503", "504", "/50x.html");

            {
                var location = server.AddLocation("/");
                location.Root = "/usr/share/nginx/html";
                location.AddIndex("index.html", "index.htm");
                location.AddTryFiles("$uri", "$uri/", "/index.html");
            }

            {
                var location = server.AddLocation("/50x.html");
                location.Alias = "=";
                location.Root = "/usr/share/nginx/html";
            }

            return server;
        }
    }
}
