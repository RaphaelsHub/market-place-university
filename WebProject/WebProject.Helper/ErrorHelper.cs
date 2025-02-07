using System.Web;
using System.Web.Routing;

namespace WebProject.Helper
{
    public class ErrorHelper
    {
        public static RouteData GetRouteData(HttpException exception)
        {
            var routeData = new RouteData
            {
                Values =
                {
                    ["controller"] = "Home",
                    ["action"] = "Error",
                    ["errorCode"] = exception?.GetHttpCode() ?? 500,
                }
            };
            return routeData;
        }

        public static string GetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                // 4xx - Client Errors
                case 400: return "Bad Request. The server cannot process the request due to a client error.";
                case 401: return "Unauthorized. Authentication is required to access this resource.";
                case 402: return "Payment Required. Reserved for future use.";
                case 403: return "Forbidden. You do not have permission to access this page.";
                case 404: return "Page Not Found. The requested resource could not be found on the server.";
                case 405: return "Method Not Allowed. The HTTP method used is not supported for this resource.";
                case 406: return "Not Acceptable. The server cannot provide data in the requested format.";
                case 407: return "Proxy Authentication Required. Authentication with the proxy is required.";
                case 408: return "Request Timeout. The server timed out waiting for the request.";
                case 409: return "Conflict. The request conflicts with the current state of the server.";
                case 410: return "Gone. The requested resource is no longer available.";
                case 411: return "Length Required. The request must include a content length.";
                case 412: return "Precondition Failed. A precondition for the request was not met.";
                case 413: return "Payload Too Large. The request exceeds the server's allowed size.";
                case 414: return "URI Too Long. The request URI is too long for the server to process.";
                case 415: return "Unsupported Media Type. The server does not support the request's data format.";
                case 416: return "Range Not Satisfiable. The requested range cannot be fulfilled.";
                case 417: return "Expectation Failed. The server cannot meet the requirements of the Expect header.";
                case 418: return "I'm a Teapot. (HTTP joke, not used in real applications.)";
                case 422: return "Unprocessable Entity. The request contains semantic errors.";
                case 423: return "Locked. The resource you are trying to access is locked.";
                case 424: return "Failed Dependency. The request depends on another request that failed.";
                case 425: return "Too Early. The server is not ready to process the request.";
                case 426: return "Upgrade Required. The client must switch to a different protocol.";
                case 428: return "Precondition Required. The server requires certain conditions to be met.";
                case 429: return "Too Many Requests. You have exceeded the request limit.";
                case 431: return "Request Header Fields Too Large. The server cannot process the request due to oversize headers.";
                case 451: return "Unavailable For Legal Reasons. Access to the resource is restricted for legal reasons.";

                // 5xx - Server Errors
                case 500: return "Internal Server Error. The server encountered an unexpected error.";
                case 501: return "Not Implemented. The server does not support the functionality required to fulfill the request.";
                case 502: return "Bad Gateway. The server received an invalid response from an upstream server.";
                case 503: return "Service Unavailable. The server is temporarily unable to handle requests.";
                case 504: return "Gateway Timeout. The server did not receive a response from an upstream server.";
                case 505: return "HTTP Version Not Supported. The server does not support the HTTP version used in the request.";
                case 506: return "Variant Also Negotiates. The server has an internal configuration error.";
                case 507: return "Insufficient Storage. The server does not have enough space to fulfill the request.";
                case 508: return "Loop Detected. The server detected an infinite loop while processing the request.";
                case 510: return "Not Extended. The server requires additional extensions to fulfill the request.";
                case 511: return "Network Authentication Required. The client must authenticate to access the network.";

                // For unknown status codes
                default: return "An unknown error occurred.";
            }
        }
    }
}