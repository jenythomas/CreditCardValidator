using System;


namespace CreditCardValidator.Services
{
    public class LuhnValidator:ILuhnValidator
    {
        public bool IsValid(string creditCardNumber)
        {
            if (string.IsNullOrWhiteSpace(creditCardNumber) || creditCardNumber.Length < 13 || creditCardNumber.Length > 19)
            {
                return false;
            }

            creditCardNumber = new string(creditCardNumber.Where(char.IsDigit).ToArray());

            int sum = 0;
            bool alternate = false;

            Console.WriteLine("Starting validation...");

            // Traverse the string from right to left
            for (int i=creditCardNumber.Length-1; i>=0;i--)
            {
                /* char[] nx=creditCardNumber.ToCharArray();
                 int n;

                 if (Int32.TryParse(nx[i].ToString(),out n)==false)
                 {
                     return false;
                 }*/
                if (!char.IsDigit(creditCardNumber[i]))
                {
                    return false; // Invalid character
                }

                int n = creditCardNumber[i] - '0'; // Convert char to int

                if (alternate)
                {
                    n *= 2;
                    if (n>9)
                    {
                        n -= 9; // Equivalent to adding the digits of the result
                    }
                }
                sum += n;
                alternate = !alternate;
                Console.WriteLine($"Digit: {creditCardNumber[i]}, Processed: {n}, Sum: {sum}");


            }
            Console.WriteLine($"Total Sum: {sum}, Valid: {sum % 10 == 0}");
            return (sum%10==0);// Valid if sum modulo 10 is 0
        }        
    }
}
