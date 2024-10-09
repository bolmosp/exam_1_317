using CalculatorWebService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly Calculator _calculator;

        public CalculatorController()
        {
            _calculator = new Calculator();
        }

        // Endpoint para evaluar expresiones infijas
        [HttpPost("infija")]
        public IActionResult EvaluarInfija([FromBody] string expresion)
        {
            try
            {
                double resultado = _calculator.EvaluarInfija(expresion);
                return Ok(new { resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // Endpoint para evaluar expresiones prefijas
        [HttpPost("prefija")]
        public IActionResult EvaluarPrefija([FromBody] string expresion)
        {
            try
            {
                double resultado = _calculator.EvaluarPrefija(expresion);
                return Ok(new { resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
