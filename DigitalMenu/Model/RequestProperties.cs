using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DigitalMenu.Model
{
    public class RequestProperties
    {
    }

    //admin SignUp 
    public class RP_SignUp
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RestName { get; set; }
    }
    //Admin Login
    public class RP_AdminLogin
    {
        public string Mobile { get; set; }
        public string password { get; set; }
        public string DeviceMac { get; set; }

        public string CusEmailId { get; set; }

        public string CusName { get; set; }

    }

    //Admin Forgot Password 
    public class RP_AdminForgotPwd
    {
        public string Mobile { get; set; }
    }

    //Admin Change Password 

    public class RP_AdminChangePwd
    {
        public string Mobile { get; set; }
        public string OldPwd { get; set; }
        public string NewPwd { get; set; }
        public string type { get; set; }


    }

    //Add ReserVation

    public class RP_AddReserVation
    {
        public string RestId { get; set; }
        public string CusName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string NoOfPerson { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TableNo { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }
    }

    //View ReserVation 
    public class RP_ViewReserVation
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string CusMobile { get; set; }
        public string CusName { get; set; }
    }


    //Update Reservation 

    public class RP_UpdateReserVationStatus
    {
        public string PosId { get; set; }
        public string RestId { get; set; }
        public string ReservationId { get; set; }
        public string key { get; set; }
        public string Status { get; set; }
    }


    //new Delivery
    public class RP_NewDelivery
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string CusName { get; set; }
        public string CusMobile { get; set; }
        public string CusEmail { get; set; }
        public string CusAddress { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string key { get; set; }
        public string DelivertID { get; set; }
        public string DeliveryType { get; set; }
        public string ItemDetails { get; set; }

        //        public string CategoryName { get; set; }
        //      public string ItemName { get; set; }
        //    public string ItemQunatity { get; set; }
        //  public string Amount { get; set; }


    }

    //update Delivery 
    public class RP_UpdateDelivery
    {

        public string RestId { get; set; }
        public string posId { get; set; }
        //public string CusName { get; set; }
        //public string CusMobile { get; set; }
        //public string CusEmail { get; set; }
        //public string CusAddress { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string key { get; set; }
        public string DeliveryID { get; set; }
        //public string DeliveryType { get; set; }
        public string ItemDetails { get; set; }


    }



    /// insert Delivery Items details 
    public class DeliveryItems
    {

        public string catName { get; set; }
        public string itemName { get; set; }
        public string Qunatity { get; set; }
        public string Amount { get; set; }

    }




    // View Deliverires 
    public class RP_ViewDeliveries
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string mobile { get; set; }
        public string status { get; set; }
        public string key { get; set; }
    }

    //Get Delivery Info
    public class RP_GetDeliveryInfo
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        // public string ItemId { get; set; }
        public string DeliveryId { get; set; }
        public string key { get; set; }
    }

    // update Delivery Status 

    public class RP_UpdateDeliveryStatus
    {

        public string RestId { get; set; }
        public string posId { get; set; }
        public string Status { get; set; }
        public string DeliveryId { get; set; }
        public string key { get; set; }

    }



    // Add New Items 
    public class RP_AddNewItem
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Addedon { get; set; }
        public string Nutrion { get; set; }
        public string key { get; set; }
    }

    // Edit Items 

    public class RP_EditItem
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string OldItemName { get; set; }
        public string ItemPrice { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        //public string Addedon { get; set; }
        //public string Nutrion { get; set; }
        public string key { get; set; }
    }

    //view Items

    public class RP_ViewItems
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string CategoryName { get; set; }
        public string key { get; set; }
    }

    // view Nutriouns 
    public class RP_ViewNutrition
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string ItemId { get; set; }
        public string key { get; set; }

    }

    // update nutriouns 

    public class RP_UpdateNutrition
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string ItemId { get; set; }
        public string key { get; set; }
        public string Nutrition { get; set; }


    }



    //Delete Item
    public class RP_DeleteItem
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public string key { get; set; }
    }

    //Assign Table
    public class RP_AssignTable
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string TableNo { get; set; }
        public string WaitorId { get; set; }
        public string DeviceMac { get; set; }
        public string key { get; set; }
        public string CusName { get; set; }
        public string CusMobile { get; set; }

        public string TableAction { get; set; }
    }

    //view Table Status
    public class Rp_ViewtableStatus
    {
        //RestId,posId
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
    }
    // Add happy hours 
    public class Rp_AddHappyHours
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Name { get; set; }
        public string OldName { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }

    }

    //Get happy hours 
    public class RP_GetHappyHours
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
    }


    // add per Item Discount in Happy Hour

    public class RP_AddPerItemDiscount
    {

        public string RestId { get; set; }
        public string posId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string Addedon { get; set; }
        public string key { get; set; }
    }

    //delete per Item Discount 

    public class RP_DeletePerItemDiscount
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string ItemName { get; set; }
        public string key { get; set; }


    }




    // add combo Discount 


    public class RP_ComboDiscount
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string ComboName { get; set; }
        public string ItemName { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string Addedon { get; set; }
        public string key { get; set; }
    }

    //delete combo discount from happy hour 

    public class RP_DeleteComboDiscount
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string ItemName { get; set; }
        public string key { get; set; }


    }




    // get per Item discount happy hours 

    public class RP_GetPerItemDiscount
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }

    }

    // get combo discount from Happy hour 

    public class RP_GetComboDiscount
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }

    }


    // Add Waitor
    public class RP_AddWaitor
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string JoinDate { get; set; }
        public string key { get; set; }
        public string WalitorId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }


    //View Waitors

    public class RP_ViewWaitor
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }

    }

    //Add Category
    public class RP_AddCategory
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public string key { get; set; }
        public string CategoryDesc { get; set; }
        public string CategoryImage { get; set; }



    }

    // category Json Var  Type

    public class RP_CategoryImage
    {
        public string categoryImage { get; set; }
        public string categoryName { get; set; }
    }

    //delete category 

    public class RP_DeleteCategory
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string CategoryName { get; set; }
        public string key { get; set; }
    }

    // update category 

    public class RP_UpdateCategory
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string oldCategoryName { get; set; }
        public string newCategoryName { get; set; }
        public string key { get; set; }
        public string CategoryDesc { get; set; }
        public string CategoryImage { get; set; }

    }







    // View Categories
    public class RP_ViewCategories
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }

       // public string isHappyHourTime { get; set; }
    }

    // View Total Sale 

    public class RP_ViewTotalSale
    {
        //RestId,PosID,FromDate ,toDate, 
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

    //View All Customer Sales 
    public class RP_ViewAllCusSale
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
        public string CusMobile { get; set; }
        public string CusName { get; set; }
    }



    // view Customer details 

    public class RP_ViewCusDetails
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
        public string CusMobile { get; set; }

    }



    //Add to Delivery Cart
    public class RP_AddToDevCart
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public string ItemQunatity { get; set; }
        public string key { get; set; }
        public string CusMobile { get; set; }
        public string CusAddress { get; set; }
    }

    //Get List Items
    public class RP_GetListItems
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string CategoryName { get; set; }
        public string key { get; set; }
    }

    //Update Delivery Cart 
    public class RP_UpdateDeliveryCart
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public string ItemQunatity { get; set; }
        public string key { get; set; }
        public string CusMobile { get; set; }
        public string CusAddress { get; set; }
    }

    //Delete Delivert Cart Items
    public class RP_DeleteDeliveryCartItems
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public string key { get; set; }
    }

    //clear Cart
    public class RP_ClearCart
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        //public string CategoryName { get; set; }
        //public string ItemName { get; set; }
        public string key { get; set; }
        public string CusMobile { get; set; }
    }

    //shows Avail Tables 

    public class RP_ShowAvailTables
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
    }

    //Waitor List 

    public class RP_WaitorList
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
    }


    // View Delivery Cart 
    public class RP_ViewDeliverCart
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
    }
    //Thought of the Day 
    public class RP_ThoughtOfTheDay
    {
        public string RestId { get; set; }
        public string Message { get; set; }
        public string key { get; set; }
        public string feedbackQuestion { get; set; }

    }

    // view thought of the Day 

    public class RP_ViewThoughtOfTheDay
    {
        public string RestId { get; set; }
        public string key { get; set; }

    }

    // Add Restaurants
    public class RP_Restaurants
    {
        public string RestId { get; set; }
        public string key { get; set; }
        public string PosId { get; set; }

        public string oldRestName { get; set; }
        public string RestName { get; set; }
        public string RestImage { get; set; }
        public string RestAddress { get; set; }

    }

    // view ViewRestaurants

    public class RP_ViewRestaurants
    {
        public string RestId { get; set; }
        public string key { get; set; }
    }

    // GCM Registration
    public class RP_Registration
    {
        public string RestId { get; set; }
        public string MacAddress { get; set; }
        public string Mobile { get; set; }
        public string RegId { get; set; }
    }


    // Transaction  Filter by waiter Id and Item Name
    public class RP_TransFilter
    {
        public string RestId { get; set; }
        public string WaiterId { get; set; }
        public string ItemName { get; set; }
        public string key { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }


    }

    // Customer Total Amount 
    public class RP_CusTotalAmount
    {
        public string RestId { get; set; }
        public string Mobile { get; set; }
        public string key { get; set; }

    }

    // Add Customer FeedBack 
    public class RP_AddFeedBackQuestion
    {
        public string RestId { get; set; }
        public string FeedbackQuestions { get; set; }
        public string key { get; set; }
    }

    // upload image 

    public class RP_UploadImage
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public string key { get; set; }
        public string CategoryDesc { get; set; }
        public string CategoryImage { get; set; }

    }

    // view bill Details 

    public class RP_ViewBillDetails
    {
        public string RestId { get; set; }
        public string PosId { get; set; }
        public string key { get; set; }
        public string BillNum { get; set; }

    }


    // manage Staff 

    // Delete Staff 

    public class RP_DeleteStaff
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
        public string DeletedStaffID { get; set; }

    }

    // Admin view Table 

    public class RP_AdminViewTable
    {

        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
    }



    // admin view customer Feedback

    public class RP_ShowCustFeedBack
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }


    // customer FeedBack Filter By Name 
    public class RP_CustFeedBackFilter
    {

        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }

    }

    // view Specific Cust FeedBack
    public class RP_ViewCustFeedBack
    {

        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
        public string CusMobile { get; set; }
    }

    

    // view item sale
    public class RP_ViewItemSale
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }

    }



    // get all Customer 

    public class RP_GetAllCustomer
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }

    }

    
    
    
    ///     Add Health Category /// 
    public class RP_AddHealthCategory
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string CategoryName { get; set; }
        public string key { get; set; }
    }



    // view Health Category 

    public class RP_ViewHealthCategory
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string key { get; set; }
    }



    ///     Add Health Category /// 
    public class RP_AddHealthTips
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string HealthCatId { get; set; }
        public string HealthTipTitle { get; set; }
        public string HealthTipDetails { get; set; }
        public string key { get; set; }
    }
    
    
    /// View Health Tips 
    public class RP_ViewHealthTips
    {
        public string RestId { get; set; }
        public string posId { get; set; }
        public string HealthCatId { get; set; }
        public string key { get; set; }

    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // test image Byte Array 

    public class RP_TESTIMAGE
    {
        public string imgae { get; set; }

    }





}