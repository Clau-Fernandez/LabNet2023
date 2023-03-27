using LabNetPractica3.EF.Logic;
using LabNetPractica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabNetPractica6_MVC.Models;
using System.Web.UI.WebControls;

namespace LabNetPractica6_MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic shippersLogic = new ShippersLogic();

        public ActionResult Index()
        {
            List<Shippers> listOfShippers = shippersLogic.GetAll();

            List<ShipperView> shipperViews = listOfShippers.Select(s => new ShipperView
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();

            return View(shipperViews);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ShipperView shipperView)
        {
            try
            {
                Shippers shipperEntity = new Shippers
                {
                    CompanyName = shipperView.CompanyName,
                    Phone = shipperView.Phone
                };
                shippersLogic.Add(shipperEntity);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Error", new { errorMessage = "Se ha producido un error" });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                shippersLogic.Delete(id);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Error", new { errorMessage = "No se pueden borrar elementos originales de la base de datos" });
            }
        }

        public ActionResult Update(int id)
        {
            var shipperToUpdate = shippersLogic.GetById(id);

            if (shipperToUpdate == null)
            {
                return RedirectToAction("Index");
            }

            ShipperView shipperView = new ShipperView
            {
                ShipperID = shipperToUpdate.ShipperID,
                CompanyName = shipperToUpdate.CompanyName,
                Phone = shipperToUpdate.Phone,
            };

            return View(shipperView);
        }

        [HttpPost]
        public ActionResult Update(ShipperView shipperView)
        {
            try
            {
                Shippers shipperEntity = new Shippers
                {
                    ShipperID = shipperView.ShipperID,
                    CompanyName = shipperView.CompanyName,
                    Phone = shipperView.Phone
                };

                shippersLogic.Update(shipperEntity);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Error", new { errorMessage = "Se ha producido un error" });
            }
        }

        public ActionResult ShippersContainingUnited()
        {
            List<Shippers> shippersContainingUnited = shippersLogic.ShippersQuery();

            List<ShipperView> shipperViews = shippersContainingUnited.Select(s => new ShipperView
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();

            return View("ShippersContainingUnited", shipperViews);
        }


    }
}
