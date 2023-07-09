namespace DZ_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string login, password, TruePassword;
            try
            {

                Console.Write("Введите Логин - ");
                login = Console.ReadLine();
                Console.Write("Введите Пароль - ");
                password = Console.ReadLine();
                Console.Write("Введите Повторите Пароль - ");
                TruePassword = Console.ReadLine();
                Validator.Validate(login, password, TruePassword);

            }
            catch (LoginEx ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PasswordEx ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public class LoginEx : Exception
        {
            public LoginEx() : base() { }
            public LoginEx(string message) : base(message) { }
        }

        public class PasswordEx : Exception
        {

            public PasswordEx() : base() { }
            public PasswordEx(string message) : base(message) { }
        }

        public static class Validator
        {
            public static bool Validate(string login, string password, string TruePassword)
            {
                if (login.Length >= 20 || login.Contains(" "))
                {
                    throw new LoginEx("Логин должен быть меньше 20 символов и не содержать пробелов");
                }

                if (password.Length >= 20 || password.Contains(" "))
                {
                    throw new PasswordEx("Пароль должен быть меньше 20 символов и не содержать пробелов");
                }

                bool OneDigit = false;
                foreach (char q in password)
                {

                    if (char.IsDigit(q))
                    {
                        OneDigit = true;
                        break;
                    }
                }

                if (!OneDigit)
                {
                    throw new PasswordEx("Пароль должен содержать хотя бы одну цифру");

                }

                if (password != TruePassword)
                {
                    throw new PasswordEx("Пароль и подтверждение пароля должны совпадать");

                }

                Console.WriteLine("Пропускаем");
                return true;

            }
        }




    }
}