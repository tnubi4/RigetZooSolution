using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RigetZooSolution.Models;

namespace RigetZooSolution.Controllers
{
    [Authorize]
    public class MembershipController : Controller
    {
        private List<Memberships> GetMemberships()
        {
            return new List<Memberships>
            {
                new Memberships { Id = 1, PlanName = "1 Month Membership", Price = 14.99m, DurationInMonths = 1 },
                new Memberships { Id = 2, PlanName = "6 Month Membership", Price = 59.99m, DurationInMonths = 6 },
                new Memberships { Id = 3, PlanName = "12 Month Membership", Price = 99.99m, DurationInMonths = 12 }
            };
        }

        // Display available plans
        public ActionResult Index()
        {
            var plans = GetMemberships();
            return View(plans);
        }

        // Handle payment for a selected plan
        public ActionResult Checkout(int id)
        {
            var plans = GetMemberships();
            var selectedPlan = plans.Find(p => p.Id == id);

            if (selectedPlan == null)
                return HttpNotFound();

            return View(selectedPlan);
        }

        [HttpPost]
        public ActionResult ProcessPayment(int planId)
        {
            // Simulate payment processing
            var plans = GetMemberships();
            var selectedPlan = plans.Find(p => p.Id == planId);

            if (selectedPlan == null)
                return HttpNotFound();

            // Simulate successful payment
            TempData["Message"] = $"Payment for {selectedPlan.PlanName} was successful!";
            return RedirectToAction("Success");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public ActionResult Success()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
    }
}
