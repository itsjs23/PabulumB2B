using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalMenu.Model.ModelClasses
{
    //public class WaitorReturnProperties
    //{
    //}


    // Return View Table Order 
    public class RPR_ViewTableOrder
    {
        //public string ItemId { get; set; }
        //public string ItemName { get; set; }
        //public string ItemPrice { get; set; }
        //public string Quantity { get; set; }
        //public string TotalAmount { get; set; }


        public string cartId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemQunatity { get; set; }
        public string Price { get; set; }
        public string TotalAmount { get; set; }
        public string deliverItemCount { get; set; }
        public string Status { get; set; }
    }

    // Confirm Order
    public class RPR_ConfirmOrder
    {
        public string Status { get; set; }
    }

    //ViewAllTablebill
    public class RPR_ViewAllTableBills
    {
        public string TableNo { get; set; }
        public string TotalBill { get; set; }
        public string PayMode { get; set; }
    }

    // View table Bill 
    public class RPR_ViewTableBill
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string Quantity { get; set; }
        public string TotalAmount { get; set; }
    }
    //Table CheckOut 
    public class RPR_TableCheckOut
    {
        public string Status { get; set; }
    }

    //Cancel Order 

    public class RPR_CancelOrder
    {
        public string Status { get; set; }
    }

    // View All Table Order 

    public class RPR_ViewAllTableOrder
    {
      //  public string ItemCount { get; set; }
        //public string TableId { get; set; }
        public string Quantity { get; set; }
        public string PendingQunatity { get; set; }
        public string tableNumber { get; set; }

        public string TableStatus { get; set; }

    }

    // View Current Order
    public class RPR_ViewCurrentOrder
    {
        public string ItemCount { get; set; }
        public string TableId { get; set; }
    }

    // View Current Table Order
    public class RPR_ViewCurrentTableOrder
    {
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string ItemId { get; set; }
        public string ItemQunatity { get; set; }
        public string TotalAmount { get; set; }
    }

    //View Table
    public class RPR_ViewJoinTable
    {
        public string TableNum { get; set; }
        public string Mobile { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
    //Allow To Join Table
    public class RPR_AllowToJoinTable
    {
        public string CusRegId { get; set; }
    }


    // chnage Order Status 

    public class RPR_ChangeOrderStatus
    {
        public string Status { get; set; }
       
    }

    // delte Order Item 
    public class RPR_DeleteOrderItem
    {
        public string Status { get; set; }

    }

    // update Delivery Quantity 
    public class RPR_UpdateDeliveryQunatity
    {
        public string Status { get; set; }
    }

    // waiter profile 
    public class RPR_WaiterProfile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string JoiningDate { get; set; }
    }

    // update waiter profile 

    public class RPR_UpdateWaiterProfile
    {
        public string Status { get; set; }
    }

    // waiter change Password 

    public class RPR_WaiterChangePwd
    {
        public string Status { get; set; } 
    }

    // get Table Number 
    public class RPR_GetTableNumber
    {
        public string TableNumber { get; set; }

    }

    // waiter trans filter 
    public class RPR_WaiterTransactionFilter
    {
        public string TableNumber { get; set; }
        public string TotalAmount { get; set; }

    }

    // waiter chkout customer 

    public class RPR_WaiterChekoutCus
    {

        public string Status { get; set; }
        public string billNumber { get; set; }
    }

    public class RPR_WaiterAddItemForCus
    {
        public string Status { get; set; }

    }

    // customer food   histroy 

    public class RPR_CustFoodHistroy
    {

        public string ItemName { get; set; }
        public string qunatity { get; set; }
    }


} // end