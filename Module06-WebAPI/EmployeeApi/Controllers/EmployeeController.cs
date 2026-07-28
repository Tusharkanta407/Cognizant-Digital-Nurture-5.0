using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Filters;
using System;
using System.Collections.Generic;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/Emp")]
    // Lab 5 requirement: Secure with Authorize allowing Roles Admin and POC
    [Authorize(Roles = "Admin,POC")] 
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [CustomAuthFilter] // Lab 3: Apply the Custom Header interceptor
        [ProducesResponseType(200)]
        public IActionResult GetEmployees()
        {
            var list = new List<string> { "Alice", "Bob", "Charlie" };
            return Ok(list);
        }

        [HttpGet("error")]
        [ProducesResponseType(500)] // Lab 3: Exception test endpoint
        public IActionResult ThrowError()
        {
            throw new Exception("Simulated crash for CustomExceptionFilter testing.");
        }
    }
}