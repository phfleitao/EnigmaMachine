using Enigma.Core.Interfaces;
using Enigma.MachineEnigmaI;
using EnigmaAPI.Adapters.EnigmaI;
using EnigmaAPI.Enums;
using EnigmaAPI.Models.EnigmaI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnigmaAPI.Controllers
{
    [Route("v1/enigmaI")]
    [ApiController]
    public class EnigmaIController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public ActionResult<EnigmaIResponseViewModel> ConvertText([FromBody] EnigmaIRequestViewModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var enigmaI = EnigmaIAdapter.ToEnigmaI(requestModel);
                var text = requestModel.Text;
                var convertedText = enigmaI.WriteText(text);
                var response = new EnigmaIResponseViewModel(ResponseStatus.success, text, convertedText, enigmaI.Logs);
                
                return Ok(response);
            }
            return BadRequest(ModelState);                     
        }
    }
}
