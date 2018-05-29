using FiyakaliOlsun.Infrastructure;
using System.Web.Mvc;

namespace FiyakaliOlsun
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TransactionFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}