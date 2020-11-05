// Licensed under the MIT license. See LICENSE file in the samples root for full license information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Threading.Tasks;

namespace CustomersAPI.Controllers
{
  [Route("api/[controller]")]
  public class CustomersController : Controller
  {
    private readonly ResourceManager _resourceManager;
    private readonly IStringLocalizer<CustomersController> _localizer;
    public CustomersController(ResourceManager resourceManager,
                               IStringLocalizer<CustomersController> localizer)
    {
      _resourceManager = resourceManager;
      _localizer = localizer;
    }

    // GET: api/Customers
    [HttpGet]
    public IEnumerable<dynamic> Get()
    {
      var s = new List<string>
            {
                BuildStringFromResource("English"),
                BuildStringFromResource("French"),
                 BuildStringFromResource("Spanish")

            };
      return new object[] { BuildStringFromResource("Welcome!! Please select language"), s };
    }

    // GET api/Customers/5
    [HttpGet("{id}")]
    public ObjectResult Get(Guid id)
    {

      return Ok(_localizer["CustomerNotFound", id].Value);
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    private string BuildStringFromResource(string resourceStringName, params object[] replacements)
    {
      return string.Format(_resourceManager.GetString(resourceStringName), replacements);
    }
  }
}
