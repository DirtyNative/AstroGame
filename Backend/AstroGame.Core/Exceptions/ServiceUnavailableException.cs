using System;
using System.Net;

namespace AstroGame.Core.Exceptions
{
	public class ServiceUnavailableException : Exception, IHttpException
	{
		public ServiceUnavailableException(string message) : base(message)
		{
			Message = message;
		}

		public ServiceUnavailableException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; } = HttpStatusCode.ServiceUnavailable;

		public override string Message { get; }
	}
}
