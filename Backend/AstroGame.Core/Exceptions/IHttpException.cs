using System.Net;

namespace AstroGame.Core.Exceptions
{
	public interface IHttpException
	{
		HttpStatusCode StatusCode { get; }

		string Message { get; }
	}
}
