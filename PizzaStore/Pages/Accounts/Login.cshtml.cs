namespace PizzaStore.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly PizzaContext _context;

        public LoginModel(PizzaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var user = _context.Accounts.FirstOrDefault(a => a.UserName == Account.UserName && a.Password == Account.Password);

            if (user != null)
            {
                //HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToPage("/Index");
            }
            // ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
