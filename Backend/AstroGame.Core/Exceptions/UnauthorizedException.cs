using System;
using System.Net;

namespace AstroGame.Core.Exceptions
{
	public class UnauthorizedException : Exception, IHttpException
	{
		public UnauthorizedException(string message) : base(message)
		{
			Message = message;
		}

		public UnauthorizedException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; } = HttpStatusCode.Unauthorized;

		public override string Message { get; }
	}
}
