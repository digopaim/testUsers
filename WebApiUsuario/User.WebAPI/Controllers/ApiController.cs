
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;


namespace WebApi.Controllers
{
    /// <summary>
    /// Controller base para a API
    /// </summary>
    public abstract class ApiController : ControllerBase
    {
    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        protected ApiController()
        {
    
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected new IActionResult Response(object result = null)
        {
        
                return Ok(new
                {
                    success = true,
                    data = result
                });
        }
              
    }
}
