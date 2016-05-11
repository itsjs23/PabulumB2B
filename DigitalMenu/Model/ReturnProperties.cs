using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalMenu.Model
{
    public class ReturnProperties
    {
    }
    //Admin SignUp Return 
    public class RPR_SignUp
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    // customer Login Return 
    public class RPR_CustLogin
    {
        [JsonProperty("RestId")]
        public string RestId { get; set; }
        [JsonProperty("PosId")]
        public string PosId { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Key")]
        public string Key { get; set; }
        [JsonProperty("TotalAmount")]
        public string TotalAmount { get; set; }
        [JsonProperty("WaitorId")]
        public string WaitorId { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("CusId")]
        public string CusId { get; set; }
        [JsonProperty("RestName")]
        public string RestName { get; set; }
        [JsonProperty("DeviceMac")]
        public string DeviceMac { get; set; }
        [JsonProperty("tableNumber")]
        public string tableNumber { get; set; }
        public string RestAddress { get; set; }
        public string SupportEmail { get; set; }
        public string SupportEmailPwd { get; set; }
    }




    //Admin Login Return
    public class RPR_AdminLogin
    {
        [JsonProperty("RestId")]
        public string RestId { get; set; }
        [JsonProperty("PosId")]
        public string PosId { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Key")]
        public string Key { get; set; }
        [JsonProperty("TotalAmount")]
        public string TotalAmount { get; set; }
        [JsonProperty("WaitorId")]
        public string WaitorId { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("CusId")]
        public string CusId { get; set; }
        [JsonProperty("RestName")]
        public string RestName { get; set; }
        [JsonProperty("DeviceMac")]
        public string DeviceMac { get; set; }
        [JsonProperty("tableNumber")]
        public string tableNumber { get; set; }
        public string RestAddress { get; set; }

        public string SupportEmail {get;set;}
        public string SupportEmailPwd {get;set;}
            

    }

    // Return Admin Forgot Passsword And Email Id
    public class RPR_AdminForgotPwd
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }

    }
    //Return ADmin Change Password 
    public class RPR_AdminChangePwd
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    //Return AddReserVation
    public class RPR_AddReserVation
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    // Return View ReserVatiom
    public class RPR_ViewReserVation
    {
        [JsonProperty("CustName")]
        public string CustName { get; set; }
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("StartTime")]
        public string StartTime { get; set; }
        [JsonProperty("EndTime")]
        public string EndTime { get; set; }
        [JsonProperty("TableNum")]
        public string TableNum { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("ReservationId")]
        public string ReservationId { get; set; }
    }

    // update reservation 
    public class RPR_UpdateReserVationStatus
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

    }



    //Return New Delivery 
    public class RPR_NewDelivery
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

    }

    //update delivery status

    public class RPR_UpdateDelivery
    {


        [JsonProperty("Status")]
        public string Status { get; set; }

    }

    //return Deliveries
    public class RPR_ViewDeliveries
    {
        [JsonProperty("CusName")]
        public string CusName { get; set; }
        [JsonProperty("TotalAmount")]
        public string TotalAmount { get; set; }
        [JsonProperty("DeliveryId")]
        public string DeliveryId { get; set; }
        [JsonProperty("Mobile")]
        public string Mobile { get; set; }
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }

    }
    //Return Delivery Info
    public class RPR_GetDeliveryInfo
    {
        [JsonProperty("CategoryName")]
        public string CategoryName { get; set; }
        [JsonProperty("ItemName")]
        public string ItemName { get; set; }
        [JsonProperty("ItemQuantity")]
        public string ItemQuantity { get; set; }
        [JsonProperty("TotalAmount")]
        public string TotalAmount { get; set; }

    }

    // update Delivery Status

    public class RPR_UpdateDeliveryStatus
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }


    // Add new Item
    public class RPR_AddNewItem
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

    }

    //Edit Item
    public class RPR_EditItem
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }


    //View Items
    public class RPR_ViewItems
    {

        public string ItemDesc { get; set; }
        public string ItemImage { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string CategoryName { get; set; }
        //public string CategoryId { get; set; }

        public string ItemId { get; set; }

    }

    // view nutrionus 

    public class RPR_ViewNutrition
    {
        public string Nutrition { get; set; }

    }

    // update nutrionus 

    public class RPR_UpdateNutrition
    {
        public string Status { get; set; }

    }


    //delete Item 
    public class RPR_DeleteItem
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    //Assign table
    public class RPR_AssignTable
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    //View Table Status
    public class RPR_ViewtableStatus
    {
        public string CusName { get; set; }
        public string TableNum { get; set; }
        public string WaitorId { get; set; }
        public string DeviceMac { get; set; }
    }

    //Add Happy hours
    public class RPR_AddHappyHours
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    //Get happy Hours
    public class RPR_GetHappyHours
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Name { get; set; }

        public string sysTime { get; set; }


    }


    // happy hour per Item Discount 

    public class RPR_AddPerItemDiscount
    {

        [JsonProperty("Status")]
        public string Status { get; set; }

    }

    //delete per item Discount 
    public class RPR_DeletePerItemDiscount
    {

        [JsonProperty("Status")]
        public string Status { get; set; }



    }


    // add combo discount 
    public class RPR_ComboDiscount
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

    }

    //delete combo discount form happy hour 

    public class RPR_DeleteComboDiscount
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

    }



    // get per Item dicount from happy hours 

    public class RPR_GetPerItemDiscount
    {
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string Addedon { get; set; }
    }

    //get combo disocunt from happy hour table 

    public class RPR_GetComboDiscount
    {
        public string ComboName { get; set; }
        public string ItemName { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string Addedon { get; set; }


    }


    //add Waitor 
    public class RPR_AddWaitor
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    // View Waitor
    public class RPR_ViewWaitor
    {
        [JsonProperty("WaiterId")]
        public string WaiterId { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Mobile")]
        public string Mobile { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("TotalAmount")]
        public string TotalAmount { get; set; }

        [JsonProperty("MonthlyAmount")]
        public string MonthlyAmount { get; set; }

    }

    // Add Category

    public class RPR_AddCategory
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    // delete Category
    public class RPR_DeleteCategory
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

    }

    // update Category 
    public class RPR_UpdateCategory
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

    }



    // View Categories
    public class RPR_ViewCategories
    {
        [JsonProperty("CategoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("CategoryDesc")]
        public string CategoryDesc { get; set; }

        [JsonProperty("itemCount")]
        public string itemCount { get; set; }


    }

    //View Total Sale
    public class RPR_ViewTotalSale
    {
        public string WaiterName { get; set; }
        public string TableId { get; set; }
        public string BillNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        
        public string Discount { get; set; }
        public string TotalAmount { get; set; }
        // public string PaymentMode { get; set; }
        // public string NumberOFperson { get; set; }
    }


    //View All Cus Sale
    public class RPR_ViewAllCusSale
    {
        public string CusName { get; set; }
        public string CusMobile { get; set; }
        public string CusEmail { get; set; }
        public string TotalAmount { get; set; }
        public string TotalCount { get; set; }
    }


    // view Customer Details 

    public class RPR_ViewCusDetails
    {
        public string date { get; set; }
        public string amount { get; set; }
        public string BillNo { get; set; }

    }

    // Add to Delivery Cart 
    public class RPR_AddToDevCart
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    public class RPR_GetListItems
    {
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }

        public string ItemId { get; set; }
    }

    // Update Delivery Cart 
    public class RPR_UpdateDeliveryCart
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    //delete Delivert cart Items 
    public class RPR_DeleteDeliveryCartItems
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    //clear  Cart 
    public class RPR_ClearCart
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
    }

    //show Avail tables 
    public class RPR_ShowAvailTables
    {
        public string TableNum { get; set; }
    }

    // Waitor List
    public class RPR_WaitorList
    {
        public string Name { get; set; }
        public string WaiterId { get; set; }
    }

    //View Delivery Cart

    public class RPR_ViewDeliverCart
    {
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public string ItemQuantity { get; set; }
        public string TotalAmount { get; set; }
        public string ItemPrice { get; set; }
    }

    // Thought of the Day 

    public class RPR_ThoughtOfTheDay
    {
        public string Status { get; set; }
    }

    //  View  Thought of the Day 
    public class RPR_ViewThoughtOfTheDay
    {
        public string Message { get; set; }
    }

    // add Restaurants
    public class RPR_Restaurants
    {
        public string Status { get; set; }
    }

    // view RPR_ViewRestaurants

    public class RPR_ViewRestaurants
    {
        public string RestName { get; set; }
        public string RestImage { get; set; }


    }
    // GCM RPR_Registration
    public class RPR_Registration
    {
        public string Status { get; set; }
    }

    public class RPR_TransFilter
    {
        public string TableId { get; set; }
        public string BillNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        //public string Discount { get; set; }
        public string TotalAmount { get; set; }
        //public string PaymentMode { get; set; }
        //public string NumberOFperson { get; set; }
        public string ItemName { get; set; }
        public string WaitorId { get; set; }

        public string @Qunatity { get; set; }
    }

    // Customer Total AMount 

    public class RPR_CusTotalAmount
    {
        public string TotalAmount { get; set; }
    }

    //Add Customer FeedBack

    public class RPR_AddFeedBackQuestion
    {
        public string Status { get; set; }
    }

    // upload image 

    public class RPR_UploadImage
    {

        public string Status { get; set; }
    }



    // get bill details 

    public class RPR_ViewBillDetails
    {
        public string ItemName { get; set; }
        public string ItemQunatity { get; set; }
        public string TotalAmount { get; set; }

    }

    // manage staff

    public class RPR_DeleteStaff
    {
        public string Status { get; set; }
    }

    // admin view Tables 

    public class RPR_AdminViewTable
    {

        public string tableNum { get; set; }
        public string waiterName { get; set; }
        public string CustName { get; set; }
        public string custTotalAmount { get; set;}
        public string orderQunatity { get; set; }
        public string orderAmount { get; set; }
    }

    // show customer Feedback
    public class RPR_ShowCustFeedBack
    {
        public string CusName { get; set; }
        public string Feedback { get; set; }
        public string WaiterName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string RatingForTest { get; set; }
        public string RatingForService { get; set; }

    }

    // cutomer Feed Back Filter 

    public class RPR_CustFeedBackFilter
    {

        public string CusName { get; set; }
        public string CusMobile { get; set; }
        public string Amount { get; set; }

    }

    // view Customer FeedBack

    public class RPR_ViewCustFeedBack
    {
        public string Feedback { get; set; }
        public string WaiterName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public string RatingForTest { get; set; }

        public string RatingForService { get; set; }
    }
    // show view item sale 
    public class RPR_ViewItemSale
    {
        public string ItemName { get; set; }
        public string quantity { get; set; }
        public string UnitPrice { get; set; }

        public string MonthlyQuantity { get; set; }

     

    }


    // get all Customer 

    public class RPR_GetAllCustomer
    {
        public string CusName { get; set; }
        public string CusMobile { get; set; }
        public string Amount { get; set; }

    }




    //// Add Health Category Status ////
    public class RPR_AddHealthCategory
    {
        // 1-success , 2- already exist 3- failed
        public string Status { get; set; }
    
    }


    ///  View Health Category 

    public class RPR_ViewHealthCategory
    {
        public string HealthCatId { get; set; }
        public string CategoryName { get; set; }
    }


    //// Add Health Tips Status ////
    public class RPR_AddHealthTips
    {
        // 1-success , 2- already exist 3- failed
        public string Status { get; set; }
    
    }

    /// View Health Tips //// 

    public class RPR_ViewHealthTips
    {
        public string HealthTipTitle { get; set; }
        public string HealthTipDetails { get; set; }
        public string AddedOn { get; set; }

    }







}