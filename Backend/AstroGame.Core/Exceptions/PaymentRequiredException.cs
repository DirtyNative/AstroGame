using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AstroGame.Core.Exceptions
{
	[DefaultStatusCode(402)]
	public class PaymentRequiredException : Exception, IHttpException
	{
		public PaymentRequiredException(string message) : base(message)
		{
			Message = message;
		}

		public PaymentRequiredException(string message, Exception inner) : base(message, inner)
		{
			Message = message;
		}

		public HttpStatusCode StatusCode { get; } = HttpStatusCode.PaymentRequired;

		public override string Message { get; }
	}
}
