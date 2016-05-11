using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalMenu.Model.ModelClasses
{
    //public class CustomerReturn
    //{
    //}

    // Select Table 
    public class RPR_SelectTable
    {
        public string WaitorId { get; set; }
    }

    // Select Category 
    public class RPR_SelectCategory
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public string CategoryId { get; set; }
        public string ItemDesc { get; set; }
        public string ItemPrice { get; set; }
    }

    // SElect Item 
    public class RPR_SelectItem
    {
      //  public string ItemName { get; set; }
      //  public string ItemPrice { get; set; }
       // public string ItemImage { get; set; }
        //public string ItemDesc { get; set; }
        public string Nutrition { get; set; }
    }

    //addded To Cart

    public class RPR_AddedToCart
    {
        public string Status { get; set; }

    }

    // View cart 
    public class RPR_ViewCart
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string ItemQunatity { get; set; }
        public string TotalAmount { get; set; }
    }
    //Update Cart

    public class RPR_UpdateCart
    {
        public string Status { get; set; }
    }

    //Delete Cart 
    public class RPR_DeleteCart
    {
        public string Status { get; set; }
    }


    // Order Item 
    public class RPR_OrderItem
    {
        public string Status { get; set; }
    }
    //Customer CheckOut 

    public class RPR_CustomerCheckout
    {
        public string Status { get; set; }
    }



    // Customer order  histroy  

    public class RPR_CustomerOrderHistroy
    {
        public string  Price {get;set;}
        public string  ItemQuantity {get;set;}
        public string  ItemName {get;set;}
        public string  totalAmount {get;set;}
        public string  Status {get;set;}
	}






    // Customer Pay Mode
    public class RPR_CustomerPayMode
    {
        public string Status { get; set; }
    }

    // Email Validation
    public class RPR_EmailValidation
    { 
    public string  Mobile {get;set;}
    public string Password { get; set; }
    }

    // View Category 

    public class RPR_ViewCategory
    { 
    public string CategoryName {get;set;}
    public string CategoryDesc {get; set;}
    public string CategoryImage {get; set;}
        
    }
    //Join Table
    public class RPR_JoinTable
    {
        public string GCMRegId { get; set; }
    }


    // Check Join Status 
    public class RPR_CheckJoinStatus
    {
        public string Status {get;set;}
    }

    // customer transaction 

    public class RPR_CustomerTransaction
    {

        public string date { get; set; }

        public string amount { get; set; }

        public string BillNo { get; set; }
    }

    // customer trans date wise details 
    public class RPR_CustomerTransactionDetails
    {
        public string ItemName { get; set; }
        public string qunatity { get; set; }
        public string amount { get; set; }
    }

    // customer call for waiter 
    public class RPR_CustomerCallWaiter
    {
        public string Status { get; set; }

    }



}









