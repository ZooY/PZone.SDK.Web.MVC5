using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace PZone.Web.Mvc
{
    /// <summary>
    /// Расширение функционала класса <see cref="HtmlHelper"/>.
    /// </summary>
    public static class HtmlHelperExtension
    {
        /// <summary>
        /// Вывод описания для свойства модели.
        /// </summary>
        /// <param name="html">Экземпляр класса <see cref="HtmlHelper"/>.</param>
        /// <param name="expression">Выражение, указывающее на свойство модели.</param>
        /// <typeparam name="TModel">Тип модели.</typeparam>
        /// <typeparam name="TValue">Тип значения свойства модели.</typeparam>
        /// <returns>
        /// Метод возвращает описание из атрибута <see cref="DisplayAttribute"/>, определенного для свойства модели.
        /// </returns>
        /// <remarks>
        /// Описание помещается в тэг параграфа (&lt;p&gt;).
        /// </remarks>
        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.DescriptionFor(expression, null);
        }


        /// <summary>
        /// Вывод описания для свойства модели.
        /// </summary>
        /// <param name="html">Экземпляр класса <see cref="HtmlHelper"/>.</param>
        /// <param name="expression">Выражение, указывающее на свойство модели.</param>
        /// <param name="htmlAttributes">HTML-атрибуты тега описания.</param>
        /// <typeparam name="TModel">Тип модели.</typeparam>
        /// <typeparam name="TValue">Тип значения свойства модели.</typeparam>
        /// <returns>
        /// Метод возвращает описание из атрибута <see cref="DisplayAttribute"/>, определенного для свойства модели.
        /// </returns>
        /// <remarks>
        /// Описание помещается в тэг параграфа (&lt;p&gt;).
        /// </remarks>
        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            if (string.IsNullOrEmpty(metadata.Description))
                return MvcHtmlString.Empty;
            var tagBuilder = new TagBuilder("p");
            tagBuilder.SetInnerText(metadata.Description);
            tagBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), true);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }



        /// <summary>
        /// Формирование элемента меню.
        /// </summary>
        /// <param name="htmlHelper">Экземпляр класса <see cref="HtmlHelper"/>.</param>
        /// <param name="linkText">Заголовок ссылки.</param>
        /// <param name="actionName">Имя действия контроллера.</param>
        /// <param name="controllerName">Имя контродера.</param>
        /// <returns>Метод формирует элемент меню в виде ссылки. Для текущего пункта меню устанавливается CSS-стиль "current".</returns>
        public static MvcHtmlString MenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName)
        {
            var routeDataValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            if (routeDataValues["controller"].ToString().Equals(controllerName) &&
                routeDataValues["action"].ToString().Equals(actionName))
                return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new { @class = "current" });
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }
    }
}