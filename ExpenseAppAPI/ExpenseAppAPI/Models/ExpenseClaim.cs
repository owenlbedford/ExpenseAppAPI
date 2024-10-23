using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseAppAPI.Models
{
    public class ExpenseClaim
    {

        public int Id { get; set; }
        public string ClaimType { get; set; }

        public string currencyType { get; set; }
        public int PurchaseAmount { get; set; }

        public string Description {  get; set; }

        public string Date {  get; set; }




    }
}
