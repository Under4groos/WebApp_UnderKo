﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_UnderKo.Components.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPController : ControllerBase
    {
        // GET: api/<IPController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
             
        }

        
    }
}
