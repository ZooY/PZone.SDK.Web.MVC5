using System.Web.Mvc;


namespace PZone.Web.Mvc
{
    /// <summary>
    /// Расширеный класс контроллера.
    /// </summary>
    public abstract class ExtendedController : Controller
    {
        /// <summary>
        /// Ошибка HTTP-протокола BadRequest (400).
        /// </summary>
        /// <returns>Метод возвращает экземпляр класса ошибки, который может быть использован в качестве возвращаемого значения контроллера.</returns>
        public virtual HttpBadRequestResult HttpBadRequest()
        {
            return new HttpBadRequestResult();
        }


        /// <summary>
        /// Ошибка HTTP-протокола BadRequest (400).
        /// </summary>
        /// <param name="message">Текст сообщения об ошибке.</param>
        /// <returns>Метод возвращает экземпляр класса ошибки, который может быть использован в качестве возвращаемого значения контроллера.</returns>
        public virtual HttpBadRequestResult HttpBadRequest(string message)
        {
            return new HttpBadRequestResult(message);
        }
    }
}