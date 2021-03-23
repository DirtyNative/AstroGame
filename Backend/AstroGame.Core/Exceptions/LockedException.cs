using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AstroGame.Core.Exceptions
{

	[DefaultStatusCode(423)]
	public class LockedException : Exception, IHttpException
	{
		public LockedException(string message) : base(message)
		{
			Message = message;
		}

		public LockedException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; } = HttpStatusCode.Locked;

		public override string Message { get; }
	}
}
