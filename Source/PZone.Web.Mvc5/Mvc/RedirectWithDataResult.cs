using System.Collections.Specialized;
using System.Text;
using System.Web.Mvc;


namespace PZone.Web.Mvc
{
    /// <summary>
    /// Перенаправление на указанный URI через отпрвку формы методом POST с данными. 
    /// </summary>
    public class RedirectWithDataResult : ActionResult
    {
        private readonly string _uri;
        private readonly NameValueCollection _data;

        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="uri">Адрес перенаправления.</param>
        /// <param name="data">Данные для отпрвки.</param>
        public RedirectWithDataResult(string uri, NameValueCollection data)
        {
            _uri = uri;
            _data = data;
        }


        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            var response = System.Web.HttpContext.Current.Response;
            response.Clear();

            var s = new StringBuilder();
            s.Append("<html>");
            s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
            s.AppendFormat("<form name='form' action='{0}' method='post'>", _uri);
            foreach (string key in _data)
                s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", key, _data[key]);
            s.Append("</form></body></html>");
            response.Write(s.ToString());
            response.End();
        }
    }
}