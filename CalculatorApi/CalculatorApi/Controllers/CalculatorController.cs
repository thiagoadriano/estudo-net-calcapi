using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
      
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get() {
            return Ok("Use uma das rotas para realizar os calculos:\nsum/1/1\nmulti/1/1\nsub/1/1\ndiv/1/1\nmed/1/1\nraiz/25");
        }

        [HttpGet("div/{firstNum}/{secondNum}")]
        public IActionResult GetDiv(string firstNum, string secondNum)
        {
            if (IsNumeric(firstNum) && IsNumeric(secondNum))
            {
                var div = ConvertToDecimal(firstNum) / ConvertToDecimal(secondNum);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{firstNum}/{secondNum}")]
        public IActionResult GetSub(string firstNum, string secondNum)
        {
            if (IsNumeric(firstNum) && IsNumeric(secondNum))
            {
                var sub = ConvertToDecimal(firstNum) - ConvertToDecimal(secondNum);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("med/{firstNum}/{secondNum}")]
        public IActionResult GetMed(string firstNum, string secondNum)
        {
            if (IsNumeric(firstNum) && IsNumeric(secondNum))
            {
                var med = (ConvertToDecimal(firstNum) + ConvertToDecimal(secondNum)) / 2;
                return Ok(med.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multi/{firstNum}/{secondNum}")]
        public IActionResult GetMulti(string firstNum, string secondNum)
        {
            if (IsNumeric(firstNum) && IsNumeric(secondNum))
            {
                var multi = ConvertToDecimal(firstNum) * ConvertToDecimal(secondNum);
                return Ok(multi.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("sum/{firstNum}/{secondNum}")]
        public IActionResult GetSum(string firstNum, string secondNum) 
        {
            if (IsNumeric(firstNum) && IsNumeric(secondNum)) 
            {
                var sum = ConvertToDecimal(firstNum) + ConvertToDecimal(secondNum);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("raiz/{firstNum}")]
        public IActionResult GetRaiz(string firstNum)
        {
            if (IsNumeric(firstNum))
            {
                var raiz = Math.Sqrt((double)ConvertToDecimal(firstNum));
                return Ok(raiz.ToString());
            }
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string strNum)
        {
            decimal value;
            if (decimal.TryParse(strNum, out value)) {
                return value;
            }
            return 0;
        }

        private bool IsNumeric(string strNum)
        {
            double number;
            bool isNumeric = double.TryParse(
                strNum, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number
            );

            return isNumeric && number > 0;

        }
    }
}