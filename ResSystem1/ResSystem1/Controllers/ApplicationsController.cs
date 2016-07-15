using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Logic;
using Models;

namespace ResSystem1.Controllers
{
    public class ApplicationsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        Business b = new Business();
        public ActionResult Index()
        {
            if(Request.IsAuthenticated)
            {
                return View(b.getAllResidences());
            }
            else
            {
                return HttpNotFound();
            }
            
        }
        public ActionResult Details(string id)
        {
            ViewBag.RmType = new SelectList(b.RoomsByRes(id), "roomType", "roomType");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingConf(Residence Rpar)
        {
            return RedirectToAction("BookingMade");
        }
        public ActionResult BookingMade()
        {
            return View();
        }
        [HttpPost]
        public ActionResult A(string A)
        {
            return View(db.Residences.Where(x=> x.ResName.Contains(A)).ToList());
        }
        [HttpGet]
        public ActionResult B(string B)
        {
            return View(db.Residences.Where(x => x.ResName.Contains(B)).ToList());
        }
        [HttpPost]
        public ActionResult C(string C)
        {
            return View(b.LetterSearch(C));
        }
        [HttpPost]
        public ActionResult D(string D)
        {
            return View(b.LetterSearch(D));
        }
        [HttpPost]
        public ActionResult E(string E)
        {
            return View(b.LetterSearch(E));
        }
        [HttpPost]
        public ActionResult F(string F)
        {
            return View(b.LetterSearch(F));
        }
        [HttpPost]
        public ActionResult G(string G)
        {
            return View(b.LetterSearch(G));
        }
        [HttpPost]
        public ActionResult H(string H)
        {
            return View(b.LetterSearch(H));
        }
        [HttpPost]
        public ActionResult I(string I)
        {
            return View(b.LetterSearch(I));
        }
        [HttpPost]
        public ActionResult J(string J)
        {
            return View(b.LetterSearch(J));
        }
        [HttpPost]
        public ActionResult K(string K)
        {
            return View(b.LetterSearch(K));
        }
        [HttpPost]
        public ActionResult L(string L)
        {
            return View(b.LetterSearch(L));
        }
        [HttpPost]
        public ActionResult M(string M)
        {
            return View(b.LetterSearch(M));
        }
        [HttpPost]
        public ActionResult N(string N)
        {
            return View(b.LetterSearch(N));
        }
        [HttpPost]
        public ActionResult O(string O)
        {
            return View(b.LetterSearch(O));
        }
        [HttpPost]
        public ActionResult P(string P)
        {
            return View(b.LetterSearch(P));
        }
        [HttpPost]
        public ActionResult Q(string Q)
        {
            return View(b.LetterSearch(Q));
        }
        [HttpPost]
        public ActionResult R(string R)
        {
            return View(b.LetterSearch(R));
        }
        [HttpPost]
        public ActionResult S(string S)
        {
            return View(b.LetterSearch(S));
        }
        [HttpPost]
        public ActionResult T(string T)
        {
            return View(b.LetterSearch(T));
        }
        [HttpPost]
        public ActionResult U(string U)
        {
            return View(b.LetterSearch(U));
        }
        [HttpPost]
        public ActionResult V(string V)
        {
            return View(b.LetterSearch(V));
        }
        [HttpPost]
        public ActionResult W(string W)
        {
            return View(b.LetterSearch(W));
        }
        [HttpPost]
        public ActionResult X(string X)
        {
            return View(b.LetterSearch(X));
        }
        [HttpPost]
        public ActionResult Y(string Y)
        {
            return View(b.LetterSearch(Y));
        }
        [HttpPost]
        public ActionResult Z(string Z)
        {
            return View(b.LetterSearch(Z));
        }
    }
}