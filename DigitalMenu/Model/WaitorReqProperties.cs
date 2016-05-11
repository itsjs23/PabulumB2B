using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalMenu.Model.ModelClasses
{
    //public class WaitorReqProperties
    //{
    //}

    // View Table Order
    public class RP_ViewTableOrder
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string WaitorId { get; set; }
        public string TableNo { get; set; }
        public string key { get; set; }
    }

    //Confirm order
    public class RP_ConfirmOrder
    {
        public string cartId { get; set; }
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string WaitorId { get; set; }
        public string TableNo { get; set; }
        public string Paymode { get; set; }
        public string key { get; set; }
        public string NumOfPerson { get; set; }
        public string BillNo { get; set; }
        public string TotalAmount { get; set; }

        
    }

    //View 
    public class RP_ViewAllTableBills
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string WaitorId { get; set; }
        public string key { get; set; }
    }

    // Cancel Order 
    public class RP_CancelOrder
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string WaitorId { get; set; }
        public string TableNo { get; set; }
        public string key { get; set; }
        public string ItemId { get; set; }
        public string CancelReason { get; set; }
    }


    // View All Table Order
    public class RP_ViewAllTableOrder
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
    }

    //View  Current Order
    public class RP_ViewCurrentOrder
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
    }

    //View Current Table Order 
    public class RP_ViewCurrentTableOrder
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
        public string TableNumber { get; set; }
    }

    //View Join Table
    public class RP_ViewJoinTable
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
    }

    //Allow TO Join Table
    public class RP_AllowToJoinTable
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
        public string TableNumber { get; set; }
    }


    // chnage Order Status 

    public class RP_ChangeOrderStatus
    {
       
        public string RestId { get; set; }
        public string WaitorId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
        public string TableNo { get; set; }
        public string UpdatedItemDetails { get; set; }
        public string Status { get; set; }


    }


    // delte order Item 

    public class RP_DeleteOrderItem
    {
        public string cartId { get; set; }

        public string RestId { get; set; }
        public string WaitorId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
        public string TableNo { get; set; }
        public string ItemID { get; set; }
    }

    // update delivery Qunatity
    public class RP_UpdateDeliveryQunatity
    {
        public string cartId { get; set; }
        public string RestId { get; set; }
        public string WaitorId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
        public string TableNo { get; set; }
        public string ItemID { get; set; }
        public string Quantity { get; set; }

    }


    // waiter profile 

    public class RP_WaiterProfile
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
    }


    // update waiter profile

    public class RP_UpdateWaiterProfile
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
        public string Email { get; set; }

    }


    // waiter Change password 
    public class RP_WaiterChangePwd
    {

        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
        public string OldPwd { get; set; }
        public string NewPwd { get; set; }
    }


    // Get Table Number 

    public class RP_GetTableNumber
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
       

    }


    // waiter trans filter 

    public class RP_WaiterTransactionFilter
    {

        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
        public string TableNo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

    // waiter Cus Checkout 

    public class RP_WaiterChekoutCus
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string WaiterId { get; set; }
        public string key { get; set; }
        public string TableNo { get; set; }
       // public string cusId { get; set; }

        // Add Filed For Discount 

        public string totalAmount { get; set; }
        public string discountType { get; set; }

        public string discount { get; set; }
        public string netAmount { get; set; }

        public string paymentMode { get; set; }

        public string waiterRemark { get; set; }


    }



    public class RP_WaiterAddItemForCus
    {
        public string RestId { get; set; }
        public string TableId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
        public string WaiterId { get; set; }
        public string ItemDetails { get; set; }
    }



    // waiter see customer Food Histroy 
    public  class RP_CustFoodHistroy{
        public string RestId { get; set; }
        public string TableId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
        public string WaiterId { get; set; }
        
    }
    


} // end 