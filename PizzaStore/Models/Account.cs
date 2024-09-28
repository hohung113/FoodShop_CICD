namespace PizzaStore.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DisplayFormat(NullDisplayText = "Password be Hiddened")]
        public string Password { get; set; }
        public string FullName { get; set; }
        [DisplayFormat(NullDisplayText = "NormalUser")]
        public AccountType? Type { get; set; }
    }
}
