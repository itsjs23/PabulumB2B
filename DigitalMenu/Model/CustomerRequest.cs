using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalMenu.Model.ModelClasses
{
    //public class CustomerRequest
    //{
    //}

    //Customer SignUp
    public class RP_CustomerSignUp
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RestId { get; set; }
        public string DeviceMac { get; set; }
    }


    // customer Sign up Using Social Media 

    public class RP_CustLogin
    {
        public string Mobile { get; set; }
        public string password { get; set; }
        public string DeviceMac { get; set; }
        public string CusEmailId { get; set; }
        public string CusName { get; set; }

    }


    // cus Social Media Login

    //public class RP_SocialCusLogin
    //{
    //    public string mobile { get; set; }
    //    public string cusEmail { get; set; }
    //    public string cusName { get; set; }
    //    public string Devicemac { get; set; }
    //}



    //Select Table
    public class RP_SelectTable
    {
        public string RestId { get; set; }
        public string key { get; set; }
        public string CusId { get; set; }
        public string DeviceMac { get; set; }
        public string TableNo { get; set; }
    }

    //select Category 

    public class RP_SelectCategory
    {
        public string CusId { get; set; }
        public string RestId { get; set; }
        public string key { get; set; }
        public string CategoryName { get; set; }
    }

    //select Item 
    public class RP_SelectItem
    {
        public string RestId { get; set; }
        public string ItemId { get; set; }
        public string CategoryId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        //public string categoryName { get; set; }
    }

    //Added To Cart 
    public class RP_AddedToCart
    {
        public string RestId { get; set; }
        public string ItemId { get; set; }
        public string TableId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string WaitorId { get; set; }
    }

    //view cart

    public class RP_ViewCart
    {
        public string RestId { get; set; }
        public string TableId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string WaitorId { get; set; }

    }

    //Update Cart
    public class RP_UpdateCart
    {
        public string RestId { get; set; }
        public string TableId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string WaitorId { get; set; }
        public string ItemQuantity { get; set; }
        public string TotalAmount { get; set; }
        public string ItemId { get; set; }
    }

    //Delete Cart

    public class RP_DeleteCart
    {
        public string RestId { get; set; }
        public string TableId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string WaitorId { get; set; }
        public string ItemId { get; set; }
    }

    //order item
    public class RP_OrderItem
    {
        public string RestId { get; set; }
        public string TableId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string WaiterId { get; set; }
        public string ItemDetails { get; set; }
    }


    //Customer Checkout 
    public class RP_CustomerCheckout
    {
        public string RestId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string CusFeeBack { get; set; }
        public string WaiterId { get; set; }
        public string RatingForService {get;set;}
        public string RatingForTest { get; set; }

    }

    // cutomer Order Histroy 

    public class RP_CustomerOrderHistroy
    {
        public string RestId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string WaiterId { get; set; }

    }



    //Customer Pay Mode
    public class RP_CustomerPayMode
    {
        public string RestId { get; set; }
        public string TableId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string WaitorId { get; set; }
        public string ItemId { get; set; }
        public string PayMode { get; set; }
    }

    // Email Validation
    public class RP_EmailValidation
    {
        public string EmailAdd { get; set; }
    
    }

    // view Category 

    public class RP_ViewCategory
    {
        public string RestId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }

        public string isHappyHourTime { get; set; }
    }

    //join table
    public class Rp_JoinTable
    {
        public string TableNumber { get; set; }
        public string Mobile { get; set; }
        public string RestId { get; set; }
        public string key { get; set; }
    }

    // Check Join Status 
    public class RP_CheckJoinStatus
    {
        public string TableNumber { get; set; }
        public string Mobile { get; set; }
        public string RestId { get; set; }
        public string key { get; set; }
    
    }


    // customer transaction 
    public class RP_CustomerTransaction
    {

        public string RestId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }


    }

    // customer date wise tran Details 

    public class RP_CustomerTransactionDetails
    {
        public string RestId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string date { get; set; }

        public string BillNo { get; set; }

    }



    // customer Call for CustomerCallWaiter

    public class RP_CustomerCallWaiter
    {
        public string RestId { get; set; }
        public string CusId { get; set; }
        public string key { get; set; }
        public string WaiterId { get; set; }
        public string NotificationMsg { get; set; }
        public string TableNum { get; set; }

    }





 }   //// main block end 















