﻿using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.AddressModel;
using System.Linq;
using System.IO;

namespace OnlineGroceryStore.Controllers
{
    public class AddressController : Controller
    {

        public IActionResult Index()
        {

            OnlineGroceryStoreDBContext osgd = new OnlineGroceryStoreDBContext();


            return View(osgd.Addres.ToList());


        }
        public IActionResult Edit(int id)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Addre Addr = ogsd.Addres.FirstOrDefault(i => i.Customerid == id);
            return View(Addr);
        }

        [HttpPost]

        public ActionResult Edit(Addre obj)
        {

            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Addre Adr = ogsd.Addres.FirstOrDefault(i => i.Customerid == obj.Customerid);
            {


                Adr.Name = obj.Name;
                Adr.Mobile = obj.Mobile;
                Adr.Pincode = obj.Pincode;
                Adr.FlatNo = obj.FlatNo;
                Adr.Bulding = obj.Bulding;
                Adr.Company = obj.Company;
                Adr.Apartment = obj.Apartment;
                Adr.Area = obj.Area;
                Adr.Street = obj.Street;
                Adr.Village = obj.Village;
                Adr.Landmark = obj.Landmark;
                Adr.City = obj.City;
                Adr.Town = obj.Town;
                Adr.State = obj.State;
                ogsd.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Addr()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Addr(Addre obj)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();

                    byte[] bt = ms.ToArray();
                    ogsd.Addres.Add(obj);
                    ogsd.SaveChanges();
                }
                return RedirectToAction("Index");
            }


            catch
            {
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Addre Addr = ogsd.Addres.FirstOrDefault(i => i.Customerid == id);
            return View(Addr);
        }

        [HttpPost]

        public ActionResult Delete(Addre obj)
        {
            try
            {
                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                Addre adr = ogsd.Addres.FirstOrDefault(i => i.Customerid == obj.Customerid);
                ogsd.Addres.Remove(adr);
                ogsd.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
        
    }

    

