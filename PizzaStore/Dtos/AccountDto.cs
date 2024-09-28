namespace PizzaStore.Dtos
{
    public class AccountDto
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public AccountType? Type { get; set; }
    }

}
