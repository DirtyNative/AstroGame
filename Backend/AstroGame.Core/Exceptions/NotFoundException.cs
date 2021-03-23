using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AstroGame.Core.Exceptions
{
	[DefaultStatusCode(404)]
	public class NotFoundException : Exception, IHttpException
	{
		public NotFoundException(string message) : base(message)
		{
			Message = message;
		}

		public NotFoundException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

		public override string Message { get; }
	}
}
