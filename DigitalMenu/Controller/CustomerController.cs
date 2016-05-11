using DigitalMenu.Common;
using DigitalMenu.Model;
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


    public class CustomerController : ApiController
    {


        //// Customer Social Media Login 

        [Route("DigitalMenu/CustLogin")]
        [HttpPost]
        public HttpResponseMessage CustLogin(HttpRequestMessage req, RP_CustLogin rpCustLogin)
        {
            if (rpCustLogin != null)
            {
                RM_CustLogin rmCustLogin = new RM_CustLogin();
                List<RPR_CustLogin> rprCustLogin = rmCustLogin.CustLogin(rpCustLogin);

                if (rmCustLogin._IsSuccess)
                    return req.CreateResponse<List<RPR_CustLogin>>(HttpStatusCode.Created, rprCustLogin);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }
        
        
        // Cancel Order 
        [Route("DigitalMenu/CustomerSignUp")]
        [HttpPost]
        public HttpResponseMessage CustomerSignUp(HttpRequestMessage req, RP_CustomerSignUp rpCustomerSignUp)
        {
            if (rpCustomerSignUp != null)
            {
                RM_CustomerSignUp rmCustomerSignUp = new RM_CustomerSignUp();
                List<RPR_SignUp> rprSignUp = rmCustomerSignUp.CustomerSignUp(rpCustomerSignUp);

                if (rmCustomerSignUp._IsSuccess)
                    return req.CreateResponse<List<RPR_SignUp>>(HttpStatusCode.Created, rprSignUp);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        ////// social Media Login 
        //[Route("DigitalMenu/SocialCusLogin")]
        //[HttpPost]
        //public HttpResponseMessage CustomerSignUp(HttpRequestMessage req, RP_SocialCusLogin rpSocialCusLogin)
        //{
        //    if (rpSocialCusLogin != null)
        //    {
        //        RM_SocialCusLogin rmSocialCusLogin = new RM_SocialCusLogin();
        //        List<RPR_SocialCusLogin> rprSocialCusLogin = rmSocialCusLogin.SocialCusLogin(rpSocialCusLogin);

        //        if (rmSocialCusLogin._IsSuccess)
        //            return req.CreateResponse<List<RPR_SocialCusLogin>>(HttpStatusCode.Created, rprSocialCusLogin);

        //        return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
        //    }

        //    return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        //}




        // Select Table Number

        [Route("DigitalMenu/SelectTable")]
        [HttpPost]
        public HttpResponseMessage SelectTable(HttpRequestMessage req, RP_SelectTable rpSelectTable)
        {
            if (rpSelectTable != null)
            {
                RM_SelectTable rmSelectTable = new RM_SelectTable();
                List<RPR_SelectTable> rprSelectTable = rmSelectTable.SelectTable(rpSelectTable);

                if (rmSelectTable._IsSuccess)
                    return req.CreateResponse<List<RPR_SelectTable>>(HttpStatusCode.Created, rprSelectTable);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


    // Select Category 

        [Route("DigitalMenu/SelectCategory")]
        [HttpPost]
        public HttpResponseMessage SelectCategory(HttpRequestMessage req, RP_SelectCategory rpSelectCategory)
        {
            if (rpSelectCategory != null)
            {
                RM_SelectCategory rmSelectCategory = new RM_SelectCategory();
                List<RPR_SelectCategory> rprSelectCategory = rmSelectCategory.SelectCategory(rpSelectCategory);

                if (rmSelectCategory._IsSuccess)
                    return req.CreateResponse<List<RPR_SelectCategory>>(HttpStatusCode.Created, rprSelectCategory);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        //Select Item 

        [Route("DigitalMenu/SelectItem")]
        [HttpPost]
        public HttpResponseMessage SelectItem(HttpRequestMessage req, RP_SelectItem rpSelectItem)
        {
            if (rpSelectItem != null)
            {
                RM_SelectItem rmSelectItem = new RM_SelectItem();
                List<RPR_SelectItem> rprSelectItem = rmSelectItem.SelectItem(rpSelectItem);

                if (rmSelectItem._IsSuccess)
                    return req.CreateResponse<List<RPR_SelectItem>>(HttpStatusCode.Created, rprSelectItem);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }



        //Added TO Cart 

        [Route("DigitalMenu/AddedToCart")]
        [HttpPost]
        public HttpResponseMessage AddedToCart(HttpRequestMessage req, RP_AddedToCart rpAddedToCart)
        {
            if (rpAddedToCart != null)
            {
                RM_AddedToCart rmAddedToCart = new RM_AddedToCart();
                List<RPR_AddedToCart> rprAddedToCart = rmAddedToCart.AddedToCart(rpAddedToCart);

                if (rmAddedToCart._IsSuccess)
                    return req.CreateResponse<List<RPR_AddedToCart>>(HttpStatusCode.Created, rprAddedToCart);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }



        // View Cart 
        [Route("DigitalMenu/ViewCart")]
        [HttpPost]
        public HttpResponseMessage ViewCart(HttpRequestMessage req, RP_ViewCart rpViewCart)
        {
            if (rpViewCart != null)
            {
                RM_ViewCart rmViewCart = new RM_ViewCart();
                List<RPR_ViewCart> rprViewCart = rmViewCart.ViewCart(rpViewCart);

                if (rmViewCart._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewCart>>(HttpStatusCode.Created, rprViewCart);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        // Update Cart 
        [Route("DigitalMenu/UpdateCart")]
        [HttpPost]
        public HttpResponseMessage UpdateCart(HttpRequestMessage req, RP_UpdateCart rpUpdateCart)
        {
            if (rpUpdateCart != null)
            {
                RM_UpdateCart rmUpdateCart = new RM_UpdateCart();
                List<RPR_UpdateCart> rprUpdateCart = rmUpdateCart.UpdateCart(rpUpdateCart);

                if (rmUpdateCart._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateCart>>(HttpStatusCode.Created, rprUpdateCart);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        //Delete cart

        [Route("DigitalMenu/DeleteCart")]
        [HttpPost]
        public HttpResponseMessage UpdateCart(HttpRequestMessage req, RP_DeleteCart rpDeleteCart)
        {
            if (rpDeleteCart != null)
            {
                RM_DeleteCart rmDeleteCart = new RM_DeleteCart();
                List<RPR_DeleteCart> rprDeleteCart = rmDeleteCart.DeleteCart(rpDeleteCart);

                if (rmDeleteCart._IsSuccess)
                    return req.CreateResponse<List<RPR_DeleteCart>>(HttpStatusCode.Created, rprDeleteCart);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        //Order Item 
        [Route("DigitalMenu/OrderItem")]
        [HttpPost]
        public HttpResponseMessage OrderItem(HttpRequestMessage req, RP_OrderItem rpOrderItem)
        {
            if (rpOrderItem != null)
            {
                RM_OrderItem rmOrderItem = new RM_OrderItem();
                List<RPR_OrderItem> rprOrderItem = rmOrderItem.OrderItem(rpOrderItem);
                if (rmOrderItem._IsSuccess)
                    return req.CreateResponse<List<RPR_OrderItem>>(HttpStatusCode.Created, rprOrderItem);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

       

        //Customer CheckOut

        [Route("DigitalMenu/CustomerOrderHistroy")]
        [HttpPost]
        public HttpResponseMessage CustomerOrderHistroy(HttpRequestMessage req, RP_CustomerOrderHistroy rpCustomerOrderHistroy)
        {
            if (rpCustomerOrderHistroy != null)
            {
                RM_CustomerOrderHistroy rmCustomerOrderHistroy = new RM_CustomerOrderHistroy();
                List<RPR_CustomerOrderHistroy> rprCustomerOrderHistroy = rmCustomerOrderHistroy.CustomerOrderHistroy(rpCustomerOrderHistroy);

                if (rmCustomerOrderHistroy._IsSuccess)
                    return req.CreateResponse<List<RPR_CustomerOrderHistroy>>(HttpStatusCode.Created, rprCustomerOrderHistroy);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }






        //Customer CheckOut

        [Route("DigitalMenu/CustomerCheckout")]
        [HttpPost]
        public HttpResponseMessage CustomerCheckout(HttpRequestMessage req, RP_CustomerCheckout rpCustomerCheckout)
        {
            if (rpCustomerCheckout != null)
            {
                RM_CustomerCheckout rmCustomerCheckout = new RM_CustomerCheckout();
                List<RPR_CustomerCheckout> rprCustomerCheckout = rmCustomerCheckout.OrderItem(rpCustomerCheckout);

                if (rmCustomerCheckout._IsSuccess)
                    return req.CreateResponse<List<RPR_CustomerCheckout>>(HttpStatusCode.Created, rprCustomerCheckout);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }




        //Customer Pay Mode
        [Route("DigitalMenu/CustomerPayMode")]
        [HttpPost]
        public HttpResponseMessage CustomerPayMode(HttpRequestMessage req,RP_CustomerPayMode rpCustomerPayMode)
        {
            if (rpCustomerPayMode != null)
            {
                RM_CustomerPayMode rmCustomerPayMode = new RM_CustomerPayMode();
                List<RPR_CustomerPayMode> rprCustomerPayMode = rmCustomerPayMode.PayMode(rpCustomerPayMode);

                if (rmCustomerPayMode._IsSuccess)
                    return req.CreateResponse<List<RPR_CustomerPayMode>>(HttpStatusCode.Created, rprCustomerPayMode);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }


        // Eamil Validation 

        [Route("DigitalMenu/EmailValidation")]
        [HttpPost]
        public HttpResponseMessage EmailValidation(HttpRequestMessage req, RP_EmailValidation rpEmailValidation)
        {
            if (rpEmailValidation != null)
            {
                RM_EmailValidation rmEmailValidation = new RM_EmailValidation();
                List<RPR_EmailValidation> rprEmailValidation = rmEmailValidation.EmailValidation(rpEmailValidation);

                if (rmEmailValidation._IsSuccess)
                    return req.CreateResponse<List<RPR_EmailValidation>>(HttpStatusCode.Created, rprEmailValidation);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }



        // View Category


[Route("DigitalMenu/ViewCategory")]
        [HttpPost]
        public HttpResponseMessage ViewCategory(HttpRequestMessage req, RP_ViewCategory rpViewCategory)
        {
            if (rpViewCategory != null)
            {
                RM_ViewCategory rmViewCategory = new RM_ViewCategory();
                List<RPR_ViewCategory> rprViewCategory = rmViewCategory.ViewCategory(rpViewCategory);

                if (rmViewCategory._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewCategory>>(HttpStatusCode.Created, rprViewCategory);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        // Join Table 

[Route("DigitalMenu/JoinTable")]
[HttpPost]
public HttpResponseMessage JoinTable(HttpRequestMessage req, Rp_JoinTable rpJoinTable)
{
    if (rpJoinTable != null)
    {
        RM_JoinTable rmJoinTable = new RM_JoinTable();
        List<RPR_JoinTable> rprJoinTable = rmJoinTable.JoinTable(rpJoinTable);

        if (rmJoinTable._IsSuccess)
            return req.CreateResponse<List<RPR_JoinTable>>(HttpStatusCode.Created, rprJoinTable);

        return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
    }

    return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
}


        // Check Status 

[Route("DigitalMenu/CheckJoinStatus")]
[HttpPost]
public HttpResponseMessage CheckJoinStatus(HttpRequestMessage req, RP_CheckJoinStatus rpCheckJoinStatus)
{
    if (rpCheckJoinStatus != null)
    {
        RM_CheckJoinStatus rmCheckJoinStatus = new RM_CheckJoinStatus();
        List<RPR_CheckJoinStatus> rprCheckJoinStatus = rmCheckJoinStatus.CheckJoinStatus(rpCheckJoinStatus);

        if (rmCheckJoinStatus._IsSuccess)
            return req.CreateResponse<List<RPR_CheckJoinStatus>>(HttpStatusCode.Created, rprCheckJoinStatus);

        return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
    }

    return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
}



// customer Transaction histroy 

[Route("DigitalMenu/CustomerTransaction")]
[HttpPost]
public HttpResponseMessage CustomerTransaction(HttpRequestMessage req, RP_CustomerTransaction rpCustomerTransaction)
{
    if (rpCustomerTransaction != null)
    {
        RM_CustomerTransaction rmCustomerTransaction = new RM_CustomerTransaction();
        List<RPR_CustomerTransaction> rprCustomerTransaction = rmCustomerTransaction.CustomerTransaction(rpCustomerTransaction);

        if (rmCustomerTransaction._IsSuccess)
            return req.CreateResponse<List<RPR_CustomerTransaction>>(HttpStatusCode.Created, rprCustomerTransaction);

        return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
    }

    return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
}




// customer date Wise  Transaction histroy 

[Route("DigitalMenu/CustomerTransactionDetails")]
[HttpPost]
public HttpResponseMessage CustomerTransactionDetails(HttpRequestMessage req, RP_CustomerTransactionDetails rpCustomerTransactionDetails)
{
    if (rpCustomerTransactionDetails != null)
    {
        RM_CustomerTransactionDetails rmCustomerTransactionDetails = new RM_CustomerTransactionDetails();
        List<RPR_CustomerTransactionDetails> rprCustomerTransactionDetails = rmCustomerTransactionDetails.CustomerTransactionDetails(rpCustomerTransactionDetails);

        if (rmCustomerTransactionDetails._IsSuccess)
            return req.CreateResponse<List<RPR_CustomerTransactionDetails>>(HttpStatusCode.Created, rprCustomerTransactionDetails);

        return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
    }

    return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
}
  


        //////// Customer Call For waiter for spoon and call-waiter 
    
    [Route("DigitalMenu/CustomerCallWaiter")]
    [HttpPost]
    public HttpResponseMessage CustomerCallWaiter(HttpRequestMessage req, RP_CustomerCallWaiter rpCustomerCallWaiter)
    {
        if (rpCustomerCallWaiter != null)
    {
        RM_CustomerCallWaiter rmCustomerCallWaiter = new RM_CustomerCallWaiter();
        List<RPR_CustomerCallWaiter> rprCustomerCallWaiter = rmCustomerCallWaiter.CustomerCallWaiter(rpCustomerCallWaiter);

        if (rmCustomerCallWaiter._IsSuccess)
            return req.CreateResponse<List<RPR_CustomerCallWaiter>>(HttpStatusCode.Created, rprCustomerCallWaiter);

        return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
    }

    return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
   }










        ///////////////////////////---THE END ---//////////////////////

    }
}