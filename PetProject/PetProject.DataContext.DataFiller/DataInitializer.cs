using Microsoft.Extensions.Logging;
using PetProject.DataContext.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.DataContext.DataFiller
{
    /// <summary>
    /// Инициализация данных БД
    /// </summary>
    public static class DataInitializer
    {
        /// <summary>
        /// Заполнить БД данными
        /// </summary>
        public static void Seed(this IAppContext context, ILogger logger)
        {
            context.SeedBD();
        }

        public static void SeedBD(this IAppContext context)
        {
            //const string neosyntezAddress = "https://kaskad-dev.io.neolant.su"; // TODO: "https://spb99-kpdm-ns1d"
            //const string dataroomAddress = "https://localhost:6001"; // TODO: заменить на нормальный
        }
    }
}
