using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetProject.Extensions
{
    /// <summary>
    /// Расширения для контроллера
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Универсальный ответ сервера
        /// </summary>
        public static IActionResult ResultResponse(this ControllerBase controller, int statusCode, string message)
        {
            if (message != "")
                return controller.StatusCode(statusCode, message);

            return controller.Ok();
        }
    }
}
