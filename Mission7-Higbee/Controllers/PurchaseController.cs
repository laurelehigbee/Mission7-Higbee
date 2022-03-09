using Microsoft.AspNetCore.Mvc;
using Mission7_Higbee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_Higbee.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository Repo { get; set; }
        private Cart Cart { get; set; }
    
        public PurchaseController(IPurchaseRepository temp, Cart c)
        {
            Repo = temp;
            Cart = c;
        }
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if(Cart.Items.Count()==0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty");
            }
            if (ModelState.IsValid)
            {
                purchase.Lines = Cart.Items.ToArray();
                Repo.SavePurchase(purchase);
                Cart.ClearCart();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
