namespace PizzaStore.Data
{
    public class DbInitializer
    {
        // Innit Account 
        public static void Initialize(PizzaContext context)
        {
            if (context.Accounts.Any())
            {
                return;
            }
            var accounts = new Account[]
            {
                new Account { UserName = "staff", Password = "1", FullName = "Owen Ho", Type = AccountType.Staff },
                new Account { UserName = "member", Password = "1", FullName = "Marvin", Type = AccountType.Member },
            };
            context.Accounts.AddRange(accounts);
            context.SaveChanges();
        }
    }
}