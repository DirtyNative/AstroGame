using System;
using System.Net;

namespace AstroGame.Core.Exceptions
{
	/// <summary>
	/// Exception template if the type is unknown
	/// </summary>
	public class HttpException : Exception, IHttpException
	{
		public HttpException(HttpStatusCode statusCode, string message) : base(message)
		{
			StatusCode = statusCode;
			Message = message;
		}

		public HttpException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; }

		public override string Message { get; }
	}
}
