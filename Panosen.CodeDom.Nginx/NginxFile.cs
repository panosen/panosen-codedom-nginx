using System;

namespace Panosen.CodeDom.Nginx
{
    /// <summary>
    /// NginxFile
    /// </summary>
    public class NginxFile
    {
        /// <summary>
        /// Events
        /// </summary>
        public Events Events { get; set; }

        /// <summary>
        /// Http
        /// </summary>
        public Http Http { get; set; }

        /// <summary>
        /// Stream
        /// </summary>
        public Stream Stream { get; set; }
    }

    /// <summary>
    /// NginxFileExtension
    /// </summary>
    public static class NginxFileExtension
    {

        /// <summary>
        /// AddEvents
        /// </summary>
        /// <returns></returns>
        public static NginxFile AddEvents(this NginxFile nginxFile, Events events)
        {
            nginxFile.Events = events;

            return nginxFile;
        }

        /// <summary>
        /// AddEvents
        /// </summary>
        public static Events AddEvents(this NginxFile nginxFile)
        {
            Events events = new Events();

            nginxFile.Events = events;

            return events;
        }

        /// <summary>
        /// AddHttp
        /// </summary>
        public static NginxFile AddHttp(this NginxFile nginxFile, Http http)
        {
            nginxFile.Http = http;

            return nginxFile;
        }

        /// <summary>
        /// AddHttp
        /// </summary>
        public static Http AddHttp(this NginxFile nginxFile)
        {
            Http http = new Http();

            nginxFile.Http = http;

            return http;
        }

        /// <summary>
        /// AddStream
        /// </summary>
        public static NginxFile AddStream(this NginxFile nginxFile, Stream events)
        {
            nginxFile.Stream = events;

            return nginxFile;
        }

        /// <summary>
        /// AddStream
        /// </summary>
        public static Stream AddStream(this NginxFile nginxFile)
        {
            Stream stream = new Stream();

            nginxFile.Stream = stream;

            return stream;
        }
    }
}
