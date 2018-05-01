using System.Collections.Specialized;
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
        /// <returns>
        /// Метод возвращает экземпляр класса ошибки, который может быть использован в качестве 
        /// возвращаемого значения контроллера.
        /// </returns>
        public virtual HttpBadRequestResult HttpBadRequest()
        {
            return new HttpBadRequestResult();
        }


        /// <summary>
        /// Ошибка HTTP-протокола BadRequest (400).
        /// </summary>
        /// <param name="message">Текст сообщения об ошибке.</param>
        /// <returns>
        /// Метод возвращает экземпляр класса ошибки, который может быть использован в качестве 
        /// возвращаемого значения контроллера.
        /// </returns>
        public virtual HttpBadRequestResult HttpBadRequest(string message)
        {
            return new HttpBadRequestResult(message);
        }

        /// <summary>
        /// Перенаправление на указанный URI через отпрвку формы методом POST с данными. 
        /// </summary>
        /// <param name="uri">Адрес перенаправления.</param>
        /// <param name="data">Данные для отпрвки.</param>
        /// <returns>
        /// Метод возвращет экземпляр класса перенаправления, который может быть использован в 
        /// качестве возвращаемого значения контроллера.
        /// </returns>
        public virtual RedirectWithDataResult RedirectWithData(string uri, NameValueCollection data)
        {
            return new RedirectWithDataResult(uri, data);
        }
    }
}