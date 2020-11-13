namespace FP.Demos._01_Functions
{
    public class Customer
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public int Age { get; }

        public Customer(string firstName, string lastName, string email, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }
    }
}