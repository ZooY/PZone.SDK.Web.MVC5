using System.Net;
using System.Web.Mvc;


namespace PZone.Web.Mvc
{
    /// <summary>
    /// Ошибка HTTP-протокола BadRequest (400).
    /// </summary>
    public class HttpBadRequestResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Конструктор класса, создающий ошибку со стандартным текстом сообщения.
        /// </summary>
        public HttpBadRequestResult() : this(null)
        {
        }


        /// <summary>
        /// Конструктор класса, позволяющий указать текст сообщения об ошибке. 
        /// </summary>
        /// <param name="message">Текст сообщения об ошибке.</param>
        public HttpBadRequestResult(string message) : base((HttpStatusCode)HttpStatusCode.BadRequest, message)
        {
        }
    }
}