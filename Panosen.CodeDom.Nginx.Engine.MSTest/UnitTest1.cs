using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Panosen.CodeDom.Nginx.Engine.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NginxFile nginxFile = PrepareNginxFile();

            var actual = nginxFile.TransformText();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private static string PrepareExpected()
        {
            return @"user nginx;
worker_processes auto;

error_log /var/log/nginx/error.log warn;
pid /var/run/nginx.pid;
events {
  worker_connections 1024;
}
http {
  include /etc/nginx/mime.types;
  default_type application/octet-stream;

  log_format main '$remote_addr - $remote_user [$time_local] ""$request"" $status $body_bytes_sent ""$http_referer"" ""$http_user_agent"" ""$http_x_forwarded_for""';

  access_log /var/log/nginx/access.log main;

  sendfile on;
  #tcp_nopush on;

  keepalive_timeout 65;

  #gzip on;

  include /etc/nginx/conf.d/*.conf;

  upstream haget {
    server 192.168.1.122:80;
  }

  server {
    listen 80;
    server_name www.sample.cn;
    rewrite ^(.*)$ https://$host$1 permanent;
  }

  server {
    listen 443 ssl;
    server_name www.sample.cn;
    ssl_certificate /sample.crt;
    ssl_certificate_key /sample.key;
    client_max_body_size 10m;

    location / {
      proxy_set_header Host $host;
      proxy_set_header X-Forwarded-Proto https;
      proxy_set_header X-Real-IP $remote_addr;
      proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
      proxy_pass http://haget;
    }
  }
}
stream {

  upstream db {
    server 127.0.0.1:3306;
  }

  server {
    listen 3306;
    proxy_pass db;
  }
}
";
        }

        private static NginxFile PrepareNginxFile()
        {
            var nginxFile = new NginxFile();

            nginxFile.AddEvents();

            var http = nginxFile.AddHttp();
            {
                http.AddUpstream("haget", "192.168.1.122:80");

                {
                    var server = http.AddServer();
                    server.ServerName = "www.sample.cn";
                    server.Listen = 80;

                    var rewrite = server.AddRewrite();
                    rewrite.Regex = "^(.*)$";
                    rewrite.Replacement = "https://$host$1";
                    rewrite.Flag = RewriteFlag.Permanent;
                }

                {
                    var server = http.AddServer();
                    server.ServerName = "www.sample.cn";
                    server.Listen = 443;
                    server.SSL = true;
                    server.SslCertificate = "/sample.crt";
                    server.SslCertificateKey = "/sample.key";
                    server.ClientMaxBodySize = "10m";

                    var location = server.AddLocation("/");
                    location.ProxySetHeader_Host = "$host";
                    location.ProxySetHeader_XForwardedProto = "https";
                    location.ProxySetHeader_XRealIP = "$remote_addr";
                    location.ProxySetHeader_XForwadedFor = "$proxy_add_x_forwarded_for";
                    location.ProxyPass = "http://haget";
                }
            }

            var stream = nginxFile.AddStream();
            {

                stream.AddUpstream("db", "127.0.0.1:3306");

                {
                    var server = stream.AddServer();
                    server.Listen = 3306;
                    server.ProxyPass = "db";
                }
            }

            return nginxFile;
        }
    }
}
