using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFinance.Infrastructure.Helper
{
    public class GlobalFunction
    {
        public static string GetName(string currency)
        {
            DateTimeOffset dataAtualSemHora = new DateTimeOffset(DateTime.UtcNow.Date);
            var timestampAtualSemHora = dataAtualSemHora.ToUnixTimeSeconds();

            return $"{currency}_{timestampAtualSemHora}";
        }
    }
}
