using System;
using System.Net;

namespace AstroGame.Core.Exceptions
{
	public class ConflictException : Exception, IHttpException
	{
		public ConflictException(string message) : base(message)
		{
			Message = message;
		}

		public ConflictException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;

		public override string Message { get; }
	}
}
