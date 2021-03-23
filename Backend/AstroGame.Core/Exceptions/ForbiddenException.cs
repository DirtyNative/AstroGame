using System;
using System.Net;

namespace AstroGame.Core.Exceptions
{
	public class ForbiddenException : Exception, IHttpException
	{
		public ForbiddenException(string message) : base(message)
		{
			Message = message;
		}

		public ForbiddenException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;

		public override string Message { get; }
	}
}
