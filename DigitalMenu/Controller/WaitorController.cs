using DigitalMenu.Model.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DigitalMenu.Controller
{
    public class WaitorController : ApiController
    {
        //View Table Order
        [Route("DigitalMenu/ViewTableOrder")]
        [HttpPost]
        public HttpResponseMessage ViewTableOrder(HttpRequestMessage req, RP_ViewTableOrder rpViewTableOrder)
        {
            if (rpViewTableOrder != null)
            {
                RM_ViewTableOrder rmViewTableOrder = new RM_ViewTableOrder();
                List<RPR_ViewTableOrder> rprViewTableOrder = rmViewTableOrder.ViewTableOrder(rpViewTableOrder);

                if (rmViewTableOrder._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewTableOrder>>(HttpStatusCode.Created, rprViewTableOrder);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Confirm Order 
        [Route("DigitalMenu/ConfirmOrder")]
        [HttpPost]
        public HttpResponseMessage ConfirmOrder(HttpRequestMessage req, RP_ConfirmOrder rpConfirmOrder)
        {
            if (rpConfirmOrder != null)
            {
                RM_ConfirmOrder rmConfirmOrder = new RM_ConfirmOrder();
                List<RPR_ConfirmOrder> rprConfirmOrder = rmConfirmOrder.ConfirmOrder(rpConfirmOrder);

                if (rmConfirmOrder._IsSuccess)
                    return req.CreateResponse<List<RPR_ConfirmOrder>>(HttpStatusCode.Created, rprConfirmOrder);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //View All Table Bills
        [Route("DigitalMenu/ViewAllTableBills")]
        [HttpPost]
        public HttpResponseMessage ViewAllTableBills(HttpRequestMessage req, RP_ViewAllTableBills rpViewAllTableBills)
        {
            if (rpViewAllTableBills != null)
            {
                RM_ViewAllTableBills rmViewAllTableBills = new RM_ViewAllTableBills();
                List<RPR_ViewAllTableBills> rprViewAllTableBills = rmViewAllTableBills.ViewAllTableBills(rpViewAllTableBills);

                if (rmViewAllTableBills._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewAllTableBills>>(HttpStatusCode.Created, rprViewAllTableBills);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }



        // View table Bill
        [Route("DigitalMenu/ViewTableBill")]
        [HttpPost]
        public HttpResponseMessage ViewTableBill(HttpRequestMessage req, RP_ConfirmOrder rpConfirmOrder)
        {
            if (rpConfirmOrder != null)
            {
                RM_ViewTableBill rmViewTableBill = new RM_ViewTableBill();
                List<RPR_ViewTableBill> rprViewTableBill = rmViewTableBill.ViewTableBill(rpConfirmOrder);

                if (rmViewTableBill._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewTableBill>>(HttpStatusCode.Created, rprViewTableBill);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        // Table Check Out 
        [Route("DigitalMenu/TableCheckOut")]
        [HttpPost]
        public HttpResponseMessage TableCheckOut(HttpRequestMessage req, RP_ConfirmOrder rpConfirmOrder)
        {
            if (rpConfirmOrder != null)
            {
                RM_TableCheckOut rmTableCheckOut = new RM_TableCheckOut();
                List<RPR_TableCheckOut> rprTableCheckOut = rmTableCheckOut.TableCheckOut(rpConfirmOrder);

                if (rmTableCheckOut._IsSuccess)
                    return req.CreateResponse<List<RPR_TableCheckOut>>(HttpStatusCode.Created, rprTableCheckOut);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }



        // Cancel Order 
        [Route("DigitalMenu/CancelOrder")]
        [HttpPost]
        public HttpResponseMessage CancelOrder(HttpRequestMessage req, RP_CancelOrder rpCancelOrder)
        {
            if (rpCancelOrder != null)
            {
                RM_CancelOrder rmCancelOrder = new RM_CancelOrder();
                List<RPR_CancelOrder> rprCancelOrder = rmCancelOrder.CancelOrder(rpCancelOrder);

                if (rmCancelOrder._IsSuccess)
                    return req.CreateResponse<List<RPR_CancelOrder>>(HttpStatusCode.Created, rprCancelOrder);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        //View All table Order
        [Route("DigitalMenu/ViewAllTableOrder")]
        [HttpPost]
        public HttpResponseMessage ViewAllTableOrder(HttpRequestMessage req, RP_ViewAllTableOrder rpViewAllTableOrder)
        {
            if (rpViewAllTableOrder != null)
            {
                RM_ViewAllTableOrder rmViewAllTableOrder = new RM_ViewAllTableOrder();
                List<RPR_ViewAllTableOrder> rprViewAllTableOrder = rmViewAllTableOrder.ViewAllTableOrder(rpViewAllTableOrder);

                if (rmViewAllTableOrder._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewAllTableOrder>>(HttpStatusCode.Created, rprViewAllTableOrder);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        //View Current Order
        [Route("DigitalMenu/ViewCurrentOrder")]
        [HttpPost]
        public HttpResponseMessage ViewAllTableOrder(HttpRequestMessage req, RP_ViewCurrentOrder rpViewCurrentOrder)
        {
            if (rpViewCurrentOrder != null)
            {
                RM_ViewCurrentOrder rmViewCurrentOrder = new RM_ViewCurrentOrder();
                List<RPR_ViewCurrentOrder> rprViewCurrentOrder = rmViewCurrentOrder.ViewAllTableOrder(rpViewCurrentOrder);

                if (rmViewCurrentOrder._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewCurrentOrder>>(HttpStatusCode.Created, rprViewCurrentOrder);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        // View Current Table Order 
        [Route("DigitalMenu/ViewCurrentTableOrder")]
        [HttpPost]
        public HttpResponseMessage ViewCurrentTableOrder(HttpRequestMessage req, RP_ViewCurrentTableOrder rpViewCurrentTableOrder)
        {
            if (rpViewCurrentTableOrder != null)
            {
                RM_ViewCurrentTableOrder rmViewCurrentTableOrder = new RM_ViewCurrentTableOrder();
                List<RPR_ViewCurrentTableOrder> rprViewCurrentTableOrder = rmViewCurrentTableOrder.ViewCurrentTableOrder(rpViewCurrentTableOrder);

                if (rmViewCurrentTableOrder._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewCurrentTableOrder>>(HttpStatusCode.Created, rprViewCurrentTableOrder);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        //View Join Tables 
        [Route("DigitalMenu/ViewJoinTable")]
        [HttpPost]
        public HttpResponseMessage ViewJoinTable(HttpRequestMessage req, RP_ViewJoinTable rpViewJoinTable)
        {
            if (rpViewJoinTable != null)
            {
                RM_ViewJoinTable rmViewJoinTable = new RM_ViewJoinTable();
                List<RPR_ViewJoinTable> rprViewJoinTable = rmViewJoinTable.ViewJoinTable(rpViewJoinTable);

                if (rmViewJoinTable._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewJoinTable>>(HttpStatusCode.Created, rprViewJoinTable);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        //Change Status of Join Table
        [Route("DigitalMenu/AllowToJoinTable")]
        [HttpPost]
        public HttpResponseMessage AllowToJoinTable(HttpRequestMessage req, RP_AllowToJoinTable rpAllowToJoinTable)
        {
            if (rpAllowToJoinTable != null)
            {
                RM_AllowToJoinTable rmAllowToJoinTable = new RM_AllowToJoinTable();
                List<RPR_AllowToJoinTable> rprAllowToJoinTable = rmAllowToJoinTable.AllowToJoinTable(rpAllowToJoinTable);

                if (rmAllowToJoinTable._IsSuccess)
                    return req.CreateResponse<List<RPR_AllowToJoinTable>>(HttpStatusCode.Created, rprAllowToJoinTable);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }



        // change order Status 
        [Route("DigitalMenu/ChangeOrderStatus")]
        [HttpPost]
        public HttpResponseMessage ChangeOrderStatus(HttpRequestMessage req, RP_ChangeOrderStatus rpChangeOrderStatus)
        {
            if (rpChangeOrderStatus != null)
            {
                RM_ChangeOrderStatus rmChangeOrderStatus = new RM_ChangeOrderStatus();
                List<RPR_ChangeOrderStatus> rprChangeOrderStatus = rmChangeOrderStatus.ChangeOrderStatus(rpChangeOrderStatus);

                if (rmChangeOrderStatus._IsSuccess)
                    return req.CreateResponse<List<RPR_ChangeOrderStatus>>(HttpStatusCode.Created, rprChangeOrderStatus);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        // delete Order Item 
        [Route("DigitalMenu/DeleteOrderItem")]
        [HttpPost]
        public HttpResponseMessage DeleteOrderItem(HttpRequestMessage req, RP_DeleteOrderItem rpDeleteOrderItem)
        {
            if (rpDeleteOrderItem != null)
            {
                RM_DeleteOrderItem rmDeleteOrderItem = new RM_DeleteOrderItem();
                List<RPR_DeleteOrderItem> rprDeleteOrderItem = rmDeleteOrderItem.DeleteOrderItem(rpDeleteOrderItem);

                if (rmDeleteOrderItem._IsSuccess)
                    return req.CreateResponse<List<RPR_DeleteOrderItem>>(HttpStatusCode.Created, rprDeleteOrderItem);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }



        // update Delivery Quantity 
        [Route("DigitalMenu/UpdateDeliveryQunatity")]
        [HttpPost]
        public HttpResponseMessage UpdateDeliveryQunatity(HttpRequestMessage req, RP_UpdateDeliveryQunatity rpUpdateDeliveryQunatity)
        {
            if (rpUpdateDeliveryQunatity != null)
            {
                RM_UpdateDeliveryQunatity rmUpdateDeliveryQunatity = new RM_UpdateDeliveryQunatity();
                List<RPR_UpdateDeliveryQunatity> rprUpdateDeliveryQunatity = rmUpdateDeliveryQunatity.UpdateDeliveryQunatity(rpUpdateDeliveryQunatity);

                if (rmUpdateDeliveryQunatity._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateDeliveryQunatity>>(HttpStatusCode.Created, rprUpdateDeliveryQunatity);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }



        // waiter profile 
        
        [Route("DigitalMenu/WaiterProfile")]
        [HttpPost]
        public HttpResponseMessage WaiterProfile(HttpRequestMessage req, RP_WaiterProfile rpWaiterProfile)
        {
            if (rpWaiterProfile != null)
            {
                RM_WaiterProfile rmWaiterProfile = new RM_WaiterProfile();
                List<RPR_WaiterProfile> rprWaiterProfile = rmWaiterProfile.WaiterProfile(rpWaiterProfile);

                if (rmWaiterProfile._IsSuccess)
                    return req.CreateResponse<List<RPR_WaiterProfile>>(HttpStatusCode.Created, rprWaiterProfile);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        // update Waiter Profile 

        [Route("DigitalMenu/UpdateWaiterProfile")]
        [HttpPost]
        public HttpResponseMessage UpdateWaiterProfile(HttpRequestMessage req, RP_UpdateWaiterProfile rpUpdateWaiterProfile)
        {
            if (rpUpdateWaiterProfile != null)
            {
                RM_UpdateWaiterProfile rmUpdateWaiterProfile = new RM_UpdateWaiterProfile();
                List<RPR_UpdateWaiterProfile> rprUpdateWaiterProfile = rmUpdateWaiterProfile.UpdateWaiterProfile(rpUpdateWaiterProfile);

                if (rmUpdateWaiterProfile._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateWaiterProfile>>(HttpStatusCode.Created, rprUpdateWaiterProfile);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        // waiter change Password 
       
            [Route("DigitalMenu/WaiterChangePwd")]
        [HttpPost]
        public HttpResponseMessage WaiterChangePwd(HttpRequestMessage req, RP_WaiterChangePwd rpWaiterChangePwd)
        {
            if (rpWaiterChangePwd != null)
            {
                RM_WaiterChangePwd rmWaiterChangePwd = new RM_WaiterChangePwd();
                List<RPR_WaiterChangePwd> rprWaiterChangePwd = rmWaiterChangePwd.WaiterChangePwd(rpWaiterChangePwd);

                if (rmWaiterChangePwd._IsSuccess)
                    return req.CreateResponse<List<RPR_WaiterChangePwd>>(HttpStatusCode.Created, rprWaiterChangePwd);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }




        // Get Table Number 
        [Route("DigitalMenu/GetTableNumber")]
        [HttpPost]
            public HttpResponseMessage GetTableNumber(HttpRequestMessage req, RP_GetTableNumber rpGetTableNumber)
        {
            if (rpGetTableNumber != null)
            {
                RM_GetTableNumber rmGetTableNumber = new RM_GetTableNumber();
                List<RPR_GetTableNumber> rprGetTableNumber = rmGetTableNumber.GetTableNumber(rpGetTableNumber);

                if (rmGetTableNumber._IsSuccess)
                    return req.CreateResponse<List<RPR_GetTableNumber>>(HttpStatusCode.Created, rprGetTableNumber);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        // waiter Trans Filter 
        
        [Route("DigitalMenu/WaiterTransactionFilter")]
        [HttpPost]
        public HttpResponseMessage WaiterTransactionFilter(HttpRequestMessage req, RP_WaiterTransactionFilter rpWaiterTransactionFilter)
        {
            if (rpWaiterTransactionFilter != null)
            {
                RM_WaiterTransactionFilter rmWaiterTransactionFilter = new RM_WaiterTransactionFilter();
                List<RPR_WaiterTransactionFilter> rprWaiterTransactionFilter = rmWaiterTransactionFilter.WaiterTransactionFilter(rpWaiterTransactionFilter);

                if (rmWaiterTransactionFilter._IsSuccess)
                    return req.CreateResponse<List<RPR_WaiterTransactionFilter>>(HttpStatusCode.Created, rprWaiterTransactionFilter);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        // waiter Chek out Customer 

        [Route("DigitalMenu/WaiterChekoutCus")]
        [HttpPost]
        public HttpResponseMessage WaiterChekoutCus(HttpRequestMessage req, RP_WaiterChekoutCus rpWaiterChekoutCus)
        {
            if (rpWaiterChekoutCus != null)
            {
                RM_WaiterChekoutCus rmWaiterChekoutCus = new RM_WaiterChekoutCus();
                List<RPR_WaiterChekoutCus> rprWaiterChekoutCus = rmWaiterChekoutCus.WaiterChekoutCus(rpWaiterChekoutCus);

                if (rmWaiterChekoutCus._IsSuccess)
                    return req.CreateResponse<List<RPR_WaiterChekoutCus>>(HttpStatusCode.Created, rprWaiterChekoutCus);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        //// waiter add item for customer 

        [Route("DigitalMenu/WaiterAddItemForCus")]
        [HttpPost]
        public HttpResponseMessage WaiterAddItemForCus(HttpRequestMessage req, RP_WaiterAddItemForCus rpWaiterAddItemForCus)
        {
            if (rpWaiterAddItemForCus != null)
            {
                RM_WaiterAddItemForCus rmWaiterAddItemForCus = new RM_WaiterAddItemForCus();
                List<RPR_WaiterAddItemForCus> rprWaiterAddItemForCus = rmWaiterAddItemForCus.WaiterAddItemForCus(rpWaiterAddItemForCus);

                if (rmWaiterAddItemForCus._IsSuccess)
                    return req.CreateResponse<List<RPR_WaiterAddItemForCus>>(HttpStatusCode.Created, rprWaiterAddItemForCus);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }




        //// show customer food History  

        [Route("DigitalMenu/CustFoodHistroy")]
        [HttpPost]
        public HttpResponseMessage CustFoodHistroy(HttpRequestMessage req, RP_CustFoodHistroy rpCustFoodHistroy)
        {
            if (rpCustFoodHistroy != null)
            {
                RM_CustFoodHistroy rmCustFoodHistroy = new RM_CustFoodHistroy();
                List<RPR_CustFoodHistroy> rprCustFoodHistroy = rmCustFoodHistroy.CustFoodHistroy(rpCustFoodHistroy);

                if (rmCustFoodHistroy._IsSuccess)
                    return req.CreateResponse<List<RPR_CustFoodHistroy>>(HttpStatusCode.Created, rprCustFoodHistroy);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }





        


        ///////////////////////////---THE END ---//////////////////////
    }
}