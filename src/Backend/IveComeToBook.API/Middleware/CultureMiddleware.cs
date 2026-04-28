using System.Globalization;

namespace IveComeToBook.API.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var suportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("pt-BR");

            if (!string.IsNullOrWhiteSpace(requestCulture) && suportedLanguages.Any(x => x.Name.Equals(requestCulture)))
            {
                cultureInfo = new CultureInfo(requestCulture);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
