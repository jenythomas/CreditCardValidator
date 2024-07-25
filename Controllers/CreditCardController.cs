using Microsoft.AspNetCore.Mvc;
using CreditCardValidator.Services;

namespace CreditCardValidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController:ControllerBase
    {
        private readonly LuhnValidator _luhnValidator;

        public CreditCardController(LuhnValidator luhnValidator)
        {
            _luhnValidator = luhnValidator;
        }

        [HttpGet("validate/{cardNumber}")]
        public IActionResult ValidateCredirCard(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || 
                !cardNumber.All(char.IsDigit)) 
            {
                return BadRequest("Please enter valid credit card number.");
            }
            bool isValid=_luhnValidator.IsValid(cardNumber);
            return Ok(isValid);
        }
    }
}
