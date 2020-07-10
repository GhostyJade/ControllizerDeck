/*
    Controllizer Deck - A DIY customizable controller deck
    Copyright (C) 2020  GhostyJade <ghostyjade2410@gmail.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Utils
{
    /// <summary>
    /// This class provides some useful methods to manage HTTP requests
    /// </summary>
    public static class ResponseFactory
    {
        /// <summary>
        /// Get the body from the request
        /// </summary>
        /// <param name="request">The request object instance</param>
        /// <returns>A string containing the JSON body</returns>
        public static string JsonStringFromRequest(HttpListenerRequest request)
        {
            Stream body = request.InputStream;
            Encoding bodyEncoding = request.ContentEncoding;
            StreamReader reader = new StreamReader(body, bodyEncoding);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Generate a response with the specified data and send it back to the client
        /// </summary>
        /// <param name="response">The response instance</param>
        /// <param name="data">The body data</param>
        /// <param name="encoding">The body encoding (default: application/json)</param>
        public static void GenerateResponse(HttpListenerResponse response, string data, string encoding = "application/json")
        {
            byte[] responseData = Encoding.UTF8.GetBytes(data);
            // Write the response info
            response.ContentType = encoding;
            response.ContentEncoding = Encoding.UTF8;
            response.ContentLength64 = responseData.LongLength;

            // Write out to the response stream (asynchronously), then close it
            Task a = response.OutputStream.WriteAsync(responseData, 0, data.Length);
            a.GetAwaiter().GetResult();
            response.Close();
        }
    }
}
