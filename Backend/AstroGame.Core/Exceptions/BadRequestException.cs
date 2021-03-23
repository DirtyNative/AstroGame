using System;
using System.Net;

namespace AstroGame.Core.Exceptions
{
	public class BadRequestException : Exception, IHttpException
	{
		public BadRequestException(string message) : base(message)
		{
			Message = message;
		}

		public BadRequestException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

		public override string Message { get; }
	}
}
