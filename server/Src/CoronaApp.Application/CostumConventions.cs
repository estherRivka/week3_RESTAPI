using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api
{
    public static class CostumConventions
    {
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static void insert() { }
    }
}
