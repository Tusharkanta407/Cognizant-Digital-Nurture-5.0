using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace EmployeeApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log details to a system file
            string logPath = Path.Combine(Directory.GetCurrentDirectory(), "error_log.txt");
            string logMessage = $"[{DateTime.Now}] Exception: {context.Exception.Message}\nStack Trace: {context.Exception.StackTrace}\n\n";
            
            File.AppendAllText(logPath, logMessage);

            // Set result to 500 Internal Server Error
            context.Result = new ObjectResult(new { error = "An internal server error occurred.", message = context.Exception.Message })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}