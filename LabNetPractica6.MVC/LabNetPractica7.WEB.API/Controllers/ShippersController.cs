using LabNetPractica3.EF.Logic;
using LabNetPractica7.WEB.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LabNetPractica3.EF.Entities;

namespace LabNetPractica7.WEB.API.Controllers
{
    public class ShippersController : ApiController
    {
        private ShippersLogic shippersLogic;

        public ShippersController()
        {
            shippersLogic = new ShippersLogic();
        }

        public IHttpActionResult Get()
        {
            try
            {
                var shippers = shippersLogic.GetAll();
                var shipperModels = new List<ShipperModel>();

                foreach (var shipper in shippers)
                {
                    var shipperModel = new ShipperModel
                    {
                        ShipperID = shipper.ShipperID,
                        CompanyName = shipper.CompanyName,
                        Phone = shipper.Phone
                    };
                    shipperModels.Add(shipperModel);
                }

                return Ok(shipperModels);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var shipper = shippersLogic.GetById(id);

                if (shipper == null)
                {
                    return NotFound();
                }

                var shipperModel = new ShipperModel
                {
                    ShipperID = shipper.ShipperID,
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                };

                return Ok(shipperModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Post([FromBody] ShipperModel shipperModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var shipper = new Shippers
                {
                    CompanyName = shipperModel.CompanyName,
                    Phone = shipperModel.Phone
                };

                shippersLogic.Add(shipper);

                shipperModel.ShipperID = shipper.ShipperID;

                return CreatedAtRoute("DefaultApi", new { id = shipper.ShipperID }, shipperModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Put(int id, [FromBody] ShipperModel shipperModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingShipper = shippersLogic.GetById(id);

                if (existingShipper == null)
                {
                    return NotFound();
                }

                var shipper = new Shippers
                {
                    ShipperID = id,
                    CompanyName = shipperModel.CompanyName,
                    Phone = shipperModel.Phone
                };

                shippersLogic.Update(shipper);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var shipperToDelete = shippersLogic.GetById(id);

                if (shipperToDelete == null)
                {
                    return NotFound();
                }

                shippersLogic.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
