﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Scaffolder.API.Application;
using Scaffolder.Core.Base;
using System.Collections.Generic;
using System.Linq;

namespace Scaffolder.API.Controllers
{
    [Route("[controller]")]
    public class TableController : Scaffolder.API.Application.ControllerBase
    {
        public TableController(IOptions<AppSettings> settings)
            : base(settings)
        {
        }

        [HttpGet]
        public IEnumerable<BaseObject> Get()
        {
            return DatabaseModel.Tables.Select(o => new BaseObject
            {
                Name = o.Name,
                Title = o.Title,
                Description = o.Description
            }).ToList();
        }

        [HttpGet("{name}")]
        public Table Get(string name)
        {
            return DatabaseModel.GetTable(name);
        }
    }
}
