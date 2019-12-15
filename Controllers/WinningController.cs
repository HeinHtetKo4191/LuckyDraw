using LuckyD.Models;
using LuckyD.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;



namespace LuckyD.Controllers
{
    public class WinningController : Controller
    {
        public ApplicationDbContext _context;
        public WinningController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Custom Validation for Number Picking
        public JsonResult IsNumberExist(string Number, int? Id)
        {
            var validateName = _context.WinningNumber.FirstOrDefault
                                (x => x.Number == Number && x.Id != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        //Custom Validation for Price Picking
        public JsonResult IsPriceExist(int PriceId, Price Price)
        {
            var validateName = _context.WinningNumber.FirstOrDefault
                                (x => x.Price.Id == PriceId &&
                                x.Price == Price &&
                                x.Price.IsAwarded == true);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }




        //Generate RandomNo

        public ActionResult GenerateRandomNum()
        {
            Random _rdm = new Random();
            ViewBag.Ran = _rdm.Next(1000, 9999);
            return View("AddWinning");

        }



        // Get : Winning/AddWinning
        public ActionResult AddWinning()
        {
            return View();
        }

        // Post: Winning
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WinningNumber winningNumber)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var id = User.Identity.GetUserName().First().ToString().ToUpper() + User.Identity.GetUserName().Split('@')[0].Substring(1);
                    var list = _context.WinningNumber.Where(x => x.User == id).ToList();
                    var alist = _context.WinningNumber.ToList();
                    ViewBag.count = list.Count();
                    int qty = list.Count() + 1;
                    int allqty = alist.Count() + 1;

                    winningNumber.PriceId = 7;
                    winningNumber.User = User.Identity.GetUserName().First().ToString().ToUpper() + User.Identity.GetUserName().Split('@')[0].Substring(1);
                    winningNumber.Quantity = qty;
                    winningNumber.AllQuentity = allqty;
                    _context.WinningNumber.Add(winningNumber);
                    _context.SaveChanges();
                    return RedirectToAction("About");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }


            }
            catch (Exception)
            {
                return Content("Sorry");
            }
        }

        // Get: About Showing User Winning Numbers

        public ActionResult About(string id)
        {
            if (!User.IsInRole("Admin"))
            {
                id = User.Identity.GetUserName().First().ToString().ToUpper() + User.Identity.GetUserName().Split('@')[0].Substring(1);
                var list = _context.WinningNumber.Where(x => x.User == id).ToList();
                return View(list);
            }
            else
            {
                var list = _context.WinningNumber.ToList();
                return View(list);
            }



        }

        //Get: Admin Controlling Page
        [Authorize(Roles = "Admin")]
        public ActionResult Admin(int? id)
        {
            var pri = _context.Prices;
            var viewModel = new CustomViewModel
            {
                Prices = pri,
                WinningNumber = new WinningNumber()
            };
            if (id == 1) {
                ViewBag.span = "Please select the price name";
                ViewBag.winning = "Please press generate randomly button";
            }
            if (id == 2)
            {
                ViewBag.span = "The Price you have choosen is already Awarded!!";
            }
            return View(viewModel);
        }

        //Post: Admin GenerateRandomFromDb
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult GenerateRandomFromDb(WinningNumber winningNumber)
        {
            var pri = _context.Prices;
            var viewModel = new CustomViewModel
            {
                Prices = pri,
                WinningNumber = new WinningNumber()
            };
            //Getting most quantity added number that isn't winner
            var grand = _context.WinningNumber
                .Where(x=> x.IsWinner == false)
                .OrderByDescending(x => x.Quantity).Select(x => x.Quantity)
                .FirstOrDefault();

            //Getting Random User from first query related
            var user = _context.WinningNumber
                 .Where(x => x.Quantity == grand && x.IsWinner == false)
                 .Select(x=>x.User)
                 .OrderBy(c => Guid.NewGuid())
                 .FirstOrDefault();
            
            //Getting Random Number from second query related
            var grandP = _context.WinningNumber
                .Where(x => x.User == user && x.IsWinner == false)
                .Select(x => x.Number)
                .OrderBy(c => Guid.NewGuid())
                .FirstOrDefault();

            if (grandP != null)
            {
                ViewBag.Random = grandP;
            }
            else
            {
                ViewBag.Random = "All The User have been awarded";
            }
            return View("Admin", viewModel);
        }

        //Post: Award for Admin
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public ActionResult Award(WinningNumber winningNumber)
        {
            try
            {
                //isWinner 
                if (ModelState.IsValid)
                {
                    
                    var award = winningNumber.PriceId;
                    bool actual = _context.Prices.Where(x => x.Id == award && x.IsAwarded == false).Any();
                    if (actual == true)
                    {
                        var winner = _context.WinningNumber
            .Where(x => x.Number == winningNumber.Number)
            .SingleOrDefault();

                        var list = _context.WinningNumber
                            .Where(x => x.User == winner.User)
                            .ToList();
                        var listP = _context.WinningNumber
                            .Where(x => x.User == winner.User)
                            .FirstOrDefault();

                        foreach (var item in list)
                        {
                            item.IsWinner = true;
                            item.PriceId = winningNumber.PriceId;
                        }

                        //Price Awarded History
                        var price = _context.Prices.Where(x => x.Id == winningNumber.PriceId).SingleOrDefault();
                        price.Winner = listP.User;
                        price.AwardedNumber = winningNumber.Number;
                        price.IsAwarded = true;


                        _context.SaveChanges();
                        return RedirectToAction("Winner", "Winning");
                    }
                    else
                    {
                        return RedirectToAction("Admin","Winning",new {id =2 });
                    }
                }
                else
                {
                    
                    return RedirectToAction("Admin","Winning",new {id = 1 });


                }
            }
            catch (Exception)
            {
                return Content("Sorry Our System Will Maintain Soon");
            }


        }


        //Winner 
        public ActionResult Winner()
        {
            var list = _context.Prices.ToList();
            return View(list);
        }
    }
}






