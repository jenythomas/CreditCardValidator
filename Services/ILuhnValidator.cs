namespace CreditCardValidator.Services
{
    public interface ILuhnValidator
    {
        bool IsValid(string creditCardNumber);
    }
}
