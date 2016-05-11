using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using DigitalMenu.Model;
using DigitalMenu.Model.ModelClasses;
using System.Web.Http;
using System;
using System.IO;
using DigitalMenu.Common;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;

namespace DigitalMenu.Controller
{

    public class AdminController : ApiController
    {
         // Admin SignUp
        [Route("DigitalMenu/AdminSignUp")]
        [HttpPost]

        public HttpResponseMessage AdminSignUp(HttpRequestMessage req, RP_SignUp rpSignup)
        {
            if (rpSignup != null)
            {
                RM_SignUp rmSignUp = new RM_SignUp();
                List<RPR_SignUp> rprSignUp = rmSignUp.SignUp(rpSignup);

                if (rmSignUp._IsSuccess)
                    return req.CreateResponse<List<RPR_SignUp>>(HttpStatusCode.Created, rprSignUp);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        //Admin Login
        [Route("DigitalMenu/AdminLogin")]
        [HttpPost]
        public HttpResponseMessage AdminLogin(HttpRequestMessage req, RP_AdminLogin rpAdminLogin)
        {
            if (rpAdminLogin != null)
            {
                RM_AdminLogin rmAdminLogin = new RM_AdminLogin();
                List<RPR_AdminLogin> rprAdminLogin = rmAdminLogin.AdminLogin(rpAdminLogin);

                if (rmAdminLogin._IsSuccess)
                    return req.CreateResponse<List<RPR_AdminLogin>>(HttpStatusCode.Created, rprAdminLogin);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        
        //Admin  Forgot Password 
        [Route("DigitalMenu/AdminForgotPwd")]
        [HttpPost]

        public HttpResponseMessage AdminForgotPwd(HttpRequestMessage req, RP_AdminForgotPwd rpAdminForgotPwd)
        {
            if (rpAdminForgotPwd != null)
            {
                RM_AdminForgotPwd rmAdminForgotPwd = new RM_AdminForgotPwd();
                List<RPR_AdminForgotPwd> rprAdminForgotPwd = rmAdminForgotPwd.GetAdminForgotPwd(rpAdminForgotPwd);

                if (rmAdminForgotPwd._IsSuccess)
                    return req.CreateResponse<List<RPR_AdminForgotPwd>>(HttpStatusCode.Created, rprAdminForgotPwd);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Admin Change Password 

        [Route("DigitalMenu/AdminChangePwd")]
        [HttpPost]

        public HttpResponseMessage AdminForgotPwd(HttpRequestMessage req, RP_AdminChangePwd rpAdminChangePwd)
        {
            if (rpAdminChangePwd != null)
            {
                RM_AdminChangePwd rmAdminChangePwd = new RM_AdminChangePwd();
                List<RPR_AdminChangePwd> rprAdminChangePwd = rmAdminChangePwd.AdminChnagePwd(rpAdminChangePwd);

                if (rmAdminChangePwd._IsSuccess)
                    return req.CreateResponse<List<RPR_AdminChangePwd>>(HttpStatusCode.Created, rprAdminChangePwd);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        //Add Reservation 
        [Route("DigitalMenu/AddReserVation")]
        [HttpPost]

        public HttpResponseMessage AddReserVation(HttpRequestMessage req, RP_AddReserVation rpAddReserVation)
        {
            if (rpAddReserVation != null)
            {
                RM_AddReserVation rmAddReserVation = new RM_AddReserVation();
                List<RPR_AddReserVation> rprAddReserVation = rmAddReserVation.AddReserVation(rpAddReserVation);

                if (rmAddReserVation._IsSuccess)
                    return req.CreateResponse<List<RPR_AddReserVation>>(HttpStatusCode.Created, rprAddReserVation);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // View ReserVation 
        [Route("DigitalMenu/ViewReserVation")]
        [HttpPost]

        public HttpResponseMessage ViewReserVation(HttpRequestMessage req, RP_ViewReserVation rpViewReserVation)
        {
            if (rpViewReserVation != null)
            {
                RM_ViewReserVation rmViewReserVation = new RM_ViewReserVation();
                List<RPR_ViewReserVation> rprViewReserVation = rmViewReserVation.ViewReserVation(rpViewReserVation);

                if (rmViewReserVation._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewReserVation>>(HttpStatusCode.Created, rprViewReserVation);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // UpdateReservationStatus

        [Route("DigitalMenu/UpdateReservationStatus")]
        [HttpPost]

        public HttpResponseMessage ViewReserVation(HttpRequestMessage req, RP_UpdateReserVationStatus rpUpdateReserVationStatus)
        {
            if (rpUpdateReserVationStatus != null)
            {
                RM_UpdateReserVationStatus rmUpdateReserVationStatus = new RM_UpdateReserVationStatus();
                List<RPR_UpdateReserVationStatus> rprUpdateReserVationStatus = rmUpdateReserVationStatus.UpdateReserVationStatus(rpUpdateReserVationStatus);

                if (rmUpdateReserVationStatus._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateReserVationStatus>>(HttpStatusCode.Created, rprUpdateReserVationStatus);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }
        
        
        // New Delivery
        [Route("DigitalMenu/NewDelivery")]
        [HttpPost]

        public HttpResponseMessage NewDelivery(HttpRequestMessage req, RP_NewDelivery rpNewDelivery)
        {
            if (rpNewDelivery != null)
            {
                RM_NewDelivery rmNewDelivery = new RM_NewDelivery();
                List<RPR_NewDelivery> rprNewDelivery = rmNewDelivery.Delivery(rpNewDelivery);

                if (rmNewDelivery._IsSuccess)
                    return req.CreateResponse<List<RPR_NewDelivery>>(HttpStatusCode.Created, rprNewDelivery);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }



        //Update Delivery 
        [Route("DigitalMenu/UpdateDelivery")]
        [HttpPost]

        public HttpResponseMessage UpdateDelivery(HttpRequestMessage req, RP_UpdateDelivery rpUpdateDelivery)
        {
            if (rpUpdateDelivery != null)
            {
                RM_UpdateDelivery rmUpdateDelivery = new RM_UpdateDelivery();
                List<RPR_UpdateDelivery> rprUpdateDelivery = rmUpdateDelivery.UpdateDelivery(rpUpdateDelivery);

                if (rmUpdateDelivery._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateDelivery>>(HttpStatusCode.Created, rprUpdateDelivery);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // View Deliveries
        [Route("DigitalMenu/ViewDeliveries")]
        [HttpPost]

        public HttpResponseMessage ViewDeliveries(HttpRequestMessage req, RP_ViewDeliveries rpViewDeliveries)
        {
            if (rpViewDeliveries != null)
            {
                RM_ViewDeliveries rmViewDeliveries = new RM_ViewDeliveries();
                List<RPR_ViewDeliveries> rprViewDeliveries = rmViewDeliveries.ViewDeliveries(rpViewDeliveries);

                if (rmViewDeliveries._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewDeliveries>>(HttpStatusCode.Created, rprViewDeliveries);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Get Delivery Info 

        [Route("DigitalMenu/GetDeliveryInfo")]
        [HttpPost]

        public HttpResponseMessage GetDeliveryInfo(HttpRequestMessage req, RP_GetDeliveryInfo rpGetDeliveryInfo)
        {
            if (rpGetDeliveryInfo != null)
            {
                RM_GetDeliveryInfo rmGetDeliveryInfo = new RM_GetDeliveryInfo();
                List<RPR_GetDeliveryInfo> rprGetDeliveryInfo = rmGetDeliveryInfo.GetDeliveryInfo(rpGetDeliveryInfo);

                if (rmGetDeliveryInfo._IsSuccess)
                    return req.CreateResponse<List<RPR_GetDeliveryInfo>>(HttpStatusCode.Created, rprGetDeliveryInfo);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }



        //Update Delievry Status 

        [Route("DigitalMenu/UpdateDeliveryStatus")]
        [HttpPost]

        public HttpResponseMessage UpdateDeliveryStatus(HttpRequestMessage req, RP_UpdateDeliveryStatus rpUpdateDeliveryStatus)
        {
            if (rpUpdateDeliveryStatus != null)
            {
                RM_UpdateDeliveryStatus rmUpdateDeliveryStatus = new RM_UpdateDeliveryStatus();
                List<RPR_UpdateDeliveryStatus> rprUpdateDeliveryStatus = rmUpdateDeliveryStatus.UpdateDeliveryStatus(rpUpdateDeliveryStatus);

                if (rmUpdateDeliveryStatus._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateDeliveryStatus>>(HttpStatusCode.Created, rprUpdateDeliveryStatus);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }




        // Add New Item
        [Route("DigitalMenu/AddNewItem")]
        [HttpPost]

        public HttpResponseMessage AddNewItem(HttpRequestMessage req, RP_AddNewItem rpAddNewItem)
        {
            if (rpAddNewItem != null)
            {
                RM_AddNewItem rmAddNewItem = new RM_AddNewItem();
                List<RPR_AddNewItem> rprAddNewItem = rmAddNewItem.AddNewItem(rpAddNewItem);

                if (rmAddNewItem._IsSuccess)
                    return req.CreateResponse<List<RPR_AddNewItem>>(HttpStatusCode.Created, rprAddNewItem);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

          //Edit Items
        [Route("DigitalMenu/EditItem")]
        [HttpPost]

        public HttpResponseMessage EditItem(HttpRequestMessage req, RP_EditItem rpEditItem)
        {
            if (rpEditItem != null)
            {
                RM_EditItem rmEditItem = new RM_EditItem();
                List<RPR_EditItem> rprEditItem = rmEditItem.EditItem(rpEditItem);

                if (rmEditItem._IsSuccess)
                    return req.CreateResponse<List<RPR_EditItem>>(HttpStatusCode.Created, rprEditItem);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //View Items

        [Route("DigitalMenu/ViewItems")]
        [HttpPost]

        public HttpResponseMessage ViewItems(HttpRequestMessage req, RP_ViewItems rpViewItems)
        {
            if (rpViewItems != null)
            {
                RM_ViewItems rmViewItems = new RM_ViewItems();
                List<RPR_ViewItems> rprViewItems = rmViewItems.ViewItem(rpViewItems);

                if (rmViewItems._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewItems>>(HttpStatusCode.Created, rprViewItems);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // view Nutrition

        [Route("DigitalMenu/ViewNutrition")]
        [HttpPost]

        public HttpResponseMessage ViewNutrition(HttpRequestMessage req, RP_ViewNutrition rpViewNutrition)
        {
            if (rpViewNutrition != null)
            {
                RM_ViewNutrition rmViewNutrition = new RM_ViewNutrition();
                List<RPR_ViewNutrition> rprViewNutrition = rmViewNutrition.ViewNutrition(rpViewNutrition);

                if (rmViewNutrition._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewNutrition>>(HttpStatusCode.Created, rprViewNutrition);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        /// update nutriouns 

        [Route("DigitalMenu/UpdateNutrition")]
        [HttpPost]

        public HttpResponseMessage UpdateNutrition(HttpRequestMessage req, RP_UpdateNutrition rpUpdateNutrition)
        {
            if (rpUpdateNutrition != null)
            {
                RM_UpdateNutrition rmUpdateNutrition = new RM_UpdateNutrition();
                List<RPR_UpdateNutrition> rprUpdateNutrition = rmUpdateNutrition.UpdateNutrition(rpUpdateNutrition);

                if (rmUpdateNutrition._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateNutrition>>(HttpStatusCode.Created, rprUpdateNutrition);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }





        //Delete item

        [Route("DigitalMenu/DeleteItem")]
        [HttpPost]

        public HttpResponseMessage ViewItems(HttpRequestMessage req, RP_DeleteItem rpDeleteItem)
        {
            if (rpDeleteItem != null)
            {
                RM_DeleteItem rmDeleteItem = new RM_DeleteItem();
                List<RPR_DeleteItem> rprDeleteItem = rmDeleteItem.DeleteItem(rpDeleteItem);

                if (rmDeleteItem._IsSuccess)
                    return req.CreateResponse<List<RPR_DeleteItem>>(HttpStatusCode.Created, rprDeleteItem);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Assign Table 
        [Route("DigitalMenu/AssignTable")]
        [HttpPost]

        public HttpResponseMessage AssignTable(HttpRequestMessage req, RP_AssignTable rpAssignTable)
        {
            if (rpAssignTable != null)
            {
                RM_AssignTable rmAssignTable = new RM_AssignTable();
                List<RPR_AssignTable> rprAssignTable = rmAssignTable.AssignTable(rpAssignTable);

                if (rmAssignTable._IsSuccess)
                    return req.CreateResponse<List<RPR_AssignTable>>(HttpStatusCode.Created, rprAssignTable);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        //View Table Status
        [Route("DigitalMenu/ViewtableStatus")]
        [HttpPost]

        public HttpResponseMessage ViewtableStatus(HttpRequestMessage req,Rp_ViewtableStatus rpViewtableStatus)
        {
            if (rpViewtableStatus != null)
            {
                RM_ViewtableStatus rmViewtableStatus = new RM_ViewtableStatus();
                List<RPR_ViewtableStatus> rprViewtableStatus = rmViewtableStatus.AssignTable(rpViewtableStatus);

                if (rmViewtableStatus._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewtableStatus>>(HttpStatusCode.Created, rprViewtableStatus);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Add Happy hour Timing 
        [Route("DigitalMenu/AddHappyHours")]
        [HttpPost]

        public HttpResponseMessage AddHappyHours(HttpRequestMessage req, Rp_AddHappyHours rpAddHappyHours)
        {
            if (rpAddHappyHours != null)
            {
                RM_AddHappyHours rmAddHappyHours = new RM_AddHappyHours();
                List<RPR_AddHappyHours> rprAddHappyHours = rmAddHappyHours.AddHappyHours(rpAddHappyHours);

                if (rmAddHappyHours._IsSuccess)
                    return req.CreateResponse<List<RPR_AddHappyHours>>(HttpStatusCode.Created, rprAddHappyHours);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Get Happy Hours 
        [Route("DigitalMenu/GetHappyHours")]
        [HttpPost]

        public HttpResponseMessage GetHappyHours(HttpRequestMessage req, RP_GetHappyHours rpGetHappyHours)
        {
            if (rpGetHappyHours != null)
            {
                RM_GetHappyHours rmGetHappyHours = new RM_GetHappyHours();
                List<RPR_GetHappyHours> rprGetHappyHours = rmGetHappyHours.GetHappyHours(rpGetHappyHours);

                if (rmGetHappyHours._IsSuccess)
                    return req.CreateResponse<List<RPR_GetHappyHours>>(HttpStatusCode.Created, rprGetHappyHours);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // Happy Hour Add Per Item Discount 

        [Route("DigitalMenu/Add_Per_Item_Discount")]
        [HttpPost]

        public HttpResponseMessage AddPerItemDiscount(HttpRequestMessage req, RP_AddPerItemDiscount rpAddPerItemDiscount)
        {
            if (rpAddPerItemDiscount != null)
            {
                RM_AddPerItemDiscount rmAddPerItemDiscount = new RM_AddPerItemDiscount();
                List<RPR_AddPerItemDiscount> rprAddPerItemDiscount = rmAddPerItemDiscount.AddPerItemDiscount(rpAddPerItemDiscount);

                if (rmAddPerItemDiscount._IsSuccess)
                    return req.CreateResponse<List<RPR_AddPerItemDiscount>>(HttpStatusCode.Created, rprAddPerItemDiscount);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //delete Per Item Discount  iN Happy hour

        
        [Route("DigitalMenu/Delete_Per_Item_Discount")]
        [HttpPost]

        public HttpResponseMessage DeletePerItemDiscount(HttpRequestMessage req, RP_DeletePerItemDiscount rpDeletePerItemDiscount)
        {
            if (rpDeletePerItemDiscount != null)
            {
                RM_DeletePerItemDiscount rmDeletePerItemDiscount = new RM_DeletePerItemDiscount();
                List<RPR_DeletePerItemDiscount> rprDeletePerItemDiscount = rmDeletePerItemDiscount.DeletePerItemDiscount(rpDeletePerItemDiscount);

                if (rmDeletePerItemDiscount._IsSuccess)
                    return req.CreateResponse<List<RPR_DeletePerItemDiscount>>(HttpStatusCode.Created, rprDeletePerItemDiscount);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }







        // add Combo Discount in Happy hour 

        [Route("DigitalMenu/Add_Combo_Discount")]
        [HttpPost]

        public HttpResponseMessage ComboDiscount(HttpRequestMessage req, RP_ComboDiscount rpComboDiscount)
        {
            if (rpComboDiscount != null)
            {
                RM_ComboDiscount rmComboDiscount = new RM_ComboDiscount();
                List<RPR_ComboDiscount> rprComboDiscount = rmComboDiscount.ComboDiscount(rpComboDiscount);

                if (rmComboDiscount._IsSuccess)
                    return req.CreateResponse<List<RPR_ComboDiscount>>(HttpStatusCode.Created, rprComboDiscount);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        // Delete  Combo Discount in Happy hour 

        [Route("DigitalMenu/Delete_Combo_Discount")]
        [HttpPost]

        public HttpResponseMessage DeleteComboDiscount(HttpRequestMessage req, RP_DeleteComboDiscount rpDeleteComboDiscount)
        {
            if (rpDeleteComboDiscount != null)
            {
                RM_DeleteComboDiscount rmDeleteComboDiscount = new RM_DeleteComboDiscount();
                List<RPR_DeleteComboDiscount> rprDeleteComboDiscount = rmDeleteComboDiscount.DeleteComboDiscount(rpDeleteComboDiscount);

                if (rmDeleteComboDiscount._IsSuccess)
                    return req.CreateResponse<List<RPR_DeleteComboDiscount>>(HttpStatusCode.Created, rprDeleteComboDiscount);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

      
        
        
        // get per Item Discount in Happy Hour 
        [Route("DigitalMenu/View_Per_Item_Discount")]
        [HttpPost]

        public HttpResponseMessage GetPerItemDiscount(HttpRequestMessage req, RP_GetPerItemDiscount rpGetPerItemDiscount)
        {
            if (rpGetPerItemDiscount != null)
            {
                RM_GetPerItemDiscount rmGetPerItemDiscount = new RM_GetPerItemDiscount();
                List<RPR_GetPerItemDiscount> rprGetPerItemDiscount = rmGetPerItemDiscount.GetPerItemDiscount(rpGetPerItemDiscount);

                if (rmGetPerItemDiscount._IsSuccess)
                    return req.CreateResponse<List<RPR_GetPerItemDiscount>>(HttpStatusCode.Created, rprGetPerItemDiscount);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // Get Combo Discount from Happy Hour 

        [Route("DigitalMenu/View_Combo_Discount")]
        [HttpPost]

        public HttpResponseMessage GetComboDiscount(HttpRequestMessage req, RP_GetComboDiscount rpGetComboDiscount)
        {
            if (rpGetComboDiscount != null)
            {
                RM_GetComboDiscount rmGetComboDiscount = new RM_GetComboDiscount();
                List<RPR_GetComboDiscount> rprGetComboDiscount = rmGetComboDiscount.GetComboDiscount(rpGetComboDiscount);

                if (rmGetComboDiscount._IsSuccess)
                    return req.CreateResponse<List<RPR_GetComboDiscount>>(HttpStatusCode.Created, rprGetComboDiscount);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }




      // Add Waiter 
        // Add New Item
        [Route("DigitalMenu/AddWaitor")]
        [HttpPost]

        public HttpResponseMessage AddWaitor(HttpRequestMessage req, RP_AddWaitor rpAddWaitor)
        {
            if (rpAddWaitor != null)
            {
                RM_AddWaitor rmAddWaitor = new RM_AddWaitor();
                List<RPR_AddWaitor> rprAddWaitor = rmAddWaitor.AddWaitor(rpAddWaitor);

                if (rmAddWaitor._IsSuccess)
                    return req.CreateResponse<List<RPR_AddWaitor>>(HttpStatusCode.Created, rprAddWaitor);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        






        // View Waitor 
        [Route("DigitalMenu/ViewWaitor")]
        [HttpPost]

        public HttpResponseMessage ViewWaitor(HttpRequestMessage req, RP_ViewWaitor rpViewWaitor)
        {
            if (rpViewWaitor != null)
            {
                RM_ViewWaitor rmViewWaitor = new RM_ViewWaitor();
                List<RPR_ViewWaitor> rprViewWaitor = rmViewWaitor.ViewWaitor(rpViewWaitor);

                if (rmViewWaitor._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewWaitor>>(HttpStatusCode.Created, rprViewWaitor);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // Add Category 
        [Route("DigitalMenu/AddCategory")]
        [HttpPost]

        public HttpResponseMessage AddCategory(HttpRequestMessage req, RP_AddCategory rpAddCategory)
        {
            if (rpAddCategory != null)
            {
                RM_AddCategory rmAddCategory = new RM_AddCategory();
                List<RPR_AddCategory> rprAddCategory = rmAddCategory.AddCategory(rpAddCategory);

                if (rmAddCategory._IsSuccess)
                    return req.CreateResponse<List<RPR_AddCategory>>(HttpStatusCode.Created, rprAddCategory);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // delete category 

        [Route("DigitalMenu/DeleteCategory")]
        [HttpPost]

        public HttpResponseMessage DeleteCategory(HttpRequestMessage req, RP_DeleteCategory rpDeleteCategory)
        {
            if (rpDeleteCategory != null)
            {
                RM_DeleteCategory rmDeleteCategory = new RM_DeleteCategory();
                List<RPR_DeleteCategory> rprDeleteCategory = rmDeleteCategory.DeleteCategory(rpDeleteCategory);

                if (rmDeleteCategory._IsSuccess)
                    return req.CreateResponse<List<RPR_DeleteCategory>>(HttpStatusCode.Created, rprDeleteCategory);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // update category 
    
        [Route("DigitalMenu/UpdateCategory")]
        [HttpPost]
        public HttpResponseMessage UpdateCategory(HttpRequestMessage req, RP_UpdateCategory rpUpdateCategory)
        {
            if (rpUpdateCategory != null)
            {
                RM_UpdateCategory rmUpdateCategory = new RM_UpdateCategory();
                List<RPR_UpdateCategory> rprUpdateCategory = rmUpdateCategory.UpdateCategory(rpUpdateCategory);

                if (rmUpdateCategory._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateCategory>>(HttpStatusCode.Created, rprUpdateCategory);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // View Categories


        [Route("DigitalMenu/ViewCategories")]
        [HttpPost]

        public HttpResponseMessage ViewCategories(HttpRequestMessage req, RP_ViewCategories rpViewCategories)
        {
            if (rpViewCategories != null)
            {
                RM_ViewCategories rmViewCategories = new RM_ViewCategories();
                List<RPR_ViewCategories> rprViewCategories = rmViewCategories.ViewCategories(rpViewCategories);

                if (rmViewCategories._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewCategories>>(HttpStatusCode.Created, rprViewCategories);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //View Total Sale
        [Route("DigitalMenu/ViewTotalSale")]
        [HttpPost]

        public HttpResponseMessage ViewTotalSale(HttpRequestMessage req, RP_ViewTotalSale rpViewTotalSale)
        {
            if (rpViewTotalSale != null)
            {
                RM_ViewTotalSale rmViewTotalSale = new RM_ViewTotalSale();
                List<RPR_ViewTotalSale> rprViewTotalSale = rmViewTotalSale.ViewTotalSale(rpViewTotalSale);

                if (rmViewTotalSale._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewTotalSale>>(HttpStatusCode.Created, rprViewTotalSale);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //View All Csutomersales

        [Route("DigitalMenu/ViewAllCusSale")]
        [HttpPost]

        public HttpResponseMessage ViewAllCusSale(HttpRequestMessage req, RP_ViewAllCusSale rpViewAllCusSale)
        {
            if (rpViewAllCusSale != null)
            {
                RM_ViewAllCusSale rmViewAllCusSale = new RM_ViewAllCusSale();
                List<RPR_ViewAllCusSale> rprViewAllCusSale = rmViewAllCusSale.ViewAllCusSale(rpViewAllCusSale);

                if (rmViewAllCusSale._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewAllCusSale>>(HttpStatusCode.Created, rprViewAllCusSale);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // customer Details  DigitalMenu/ViewCusDetails

        [Route("DigitalMenu/ViewCusDetails")]
        [HttpPost]

        public HttpResponseMessage ViewAllCusSale(HttpRequestMessage req, RP_ViewCusDetails rpViewCusDetails)
        {
            if (rpViewCusDetails != null)
            {
                RM_ViewCusDetails rmViewCusDetails = new RM_ViewCusDetails();
                List<RPR_ViewCusDetails> rprViewCusDetails = rmViewCusDetails.ViewCusDetails(rpViewCusDetails);

                if (rmViewCusDetails._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewCusDetails>>(HttpStatusCode.Created, rprViewCusDetails);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }










        //Add To Delivery Cart 

        [Route("DigitalMenu/AddToDevCart")]
        [HttpPost]

        public HttpResponseMessage AddToDevCart(HttpRequestMessage req, RP_AddToDevCart rpAddToDevCart)
        {
            if (rpAddToDevCart != null)
            {
                RM_AddToDevCart rmAddToDevCart = new RM_AddToDevCart();
                List<RPR_AddToDevCart> rprAddToDevCart = rmAddToDevCart.AddToDevCart(rpAddToDevCart);

                if (rmAddToDevCart._IsSuccess)
                    return req.CreateResponse<List<RPR_AddToDevCart>>(HttpStatusCode.Created, rprAddToDevCart);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Get List Items 

        [Route("DigitalMenu/GetListItems")]
        [HttpPost]

        public HttpResponseMessage GetListItems(HttpRequestMessage req, RP_GetListItems rpGetListItems)
        {
            if (rpGetListItems != null)
            {
                RM_GetListItems rmGetListItems = new RM_GetListItems();
                List<RPR_GetListItems> rprGetListItems = rmGetListItems.GetListItems(rpGetListItems);

                if (rmGetListItems._IsSuccess)
                    return req.CreateResponse<List<RPR_GetListItems>>(HttpStatusCode.Created, rprGetListItems);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Update Delivery Cart
             [Route("DigitalMenu/UpdateDeliveryCart")]
        [HttpPost]

        public HttpResponseMessage UpdateDeliveryCart(HttpRequestMessage req, RP_UpdateDeliveryCart rpUpdateDeliveryCart)
        {
            if (rpUpdateDeliveryCart != null)
            {
                RM_UpdateDeliveryCart rmUpdateDeliveryCart = new RM_UpdateDeliveryCart();
                List<RPR_UpdateDeliveryCart> rprUpdateDeliveryCart = rmUpdateDeliveryCart.UpdateDeliveryCart(rpUpdateDeliveryCart);

                if (rmUpdateDeliveryCart._IsSuccess)
                    return req.CreateResponse<List<RPR_UpdateDeliveryCart>>(HttpStatusCode.Created, rprUpdateDeliveryCart);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Delete Delivery cart  Items 
        [Route("DigitalMenu/DeleteDeliveryCartItems")]
        [HttpPost]

        public HttpResponseMessage DeleteDeliveryCartItems(HttpRequestMessage req, RP_DeleteDeliveryCartItems rpDeleteDeliveryCartItems)
        {
            if (rpDeleteDeliveryCartItems != null)
            {
                RM_DeleteDeliveryCartItems rmDeleteDeliveryCartItems=new RM_DeleteDeliveryCartItems();
                List<RPR_DeleteDeliveryCartItems> rprDeleteDeliveryCartItems = rmDeleteDeliveryCartItems.DeleteDeliveryCartItems(rpDeleteDeliveryCartItems);

                if (rmDeleteDeliveryCartItems._IsSuccess)
                    return req.CreateResponse<List<RPR_DeleteDeliveryCartItems>>(HttpStatusCode.Created, rprDeleteDeliveryCartItems);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // Clear Cart 
        [Route("DigitalMenu/ClearCart")]
        [HttpPost]

        public HttpResponseMessage ClearCart(HttpRequestMessage req, RP_ClearCart rpClearCart)
        {
            if (rpClearCart != null)
            {
                RM_ClearCart rmClearCart = new RM_ClearCart();
                List<RPR_ClearCart> rprClearCart = rmClearCart.ClearCart(rpClearCart);

                if (rmClearCart._IsSuccess)
                    return req.CreateResponse<List<RPR_ClearCart>>(HttpStatusCode.Created, rprClearCart);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //Show Avail Tables 
        [Route("DigitalMenu/ShowAvailTables")]
        [HttpPost]

        public HttpResponseMessage ShowAvailTables(HttpRequestMessage req, RP_ShowAvailTables rpShowAvailTables)
        {
            if (rpShowAvailTables != null)
            {
                RM_ShowAvailTables rmShowAvailTables = new RM_ShowAvailTables();
                List<RPR_ShowAvailTables> rprShowAvailTables = rmShowAvailTables.ShowAvailTables(rpShowAvailTables);

                if (rmShowAvailTables._IsSuccess)
                    return req.CreateResponse<List<RPR_ShowAvailTables>>(HttpStatusCode.Created, rprShowAvailTables);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // Waitor List 
        [Route("DigitalMenu/WaitorList")]
        [HttpPost]

        public HttpResponseMessage WaitorList(HttpRequestMessage req, RP_WaitorList rpWaitorList)
        {
            if (rpWaitorList != null)
            {
                RM_WaitorList rmWaitorList = new RM_WaitorList();
                List<RPR_WaitorList> rprWaitorList = rmWaitorList.WaitorList(rpWaitorList);

                if (rmWaitorList._IsSuccess)
                    return req.CreateResponse<List<RPR_WaitorList>>(HttpStatusCode.Created, rprWaitorList);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }



        // View Delivery Cart 
        [Route("DigitalMenu/ViewDeliverCart")]
        [HttpPost]

        public HttpResponseMessage ViewDeliverCart(HttpRequestMessage req, RP_ViewDeliverCart rpViewDeliverCart)
        {
            if (rpViewDeliverCart != null)
            {
                RM_ViewDeliverCart rmViewDeliverCart = new RM_ViewDeliverCart();
                List<RPR_ViewDeliverCart> rprViewDeliverCart = rmViewDeliverCart.ViewDeliverCart(rpViewDeliverCart);

                if (rmViewDeliverCart._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewDeliverCart>>(HttpStatusCode.Created, rprViewDeliverCart);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // thought of the Day 

        [Route("DigitalMenu/ThoughtOfTheDay")]
        [HttpPost]

        public HttpResponseMessage ThoughtOfTheDay(HttpRequestMessage req, RP_ThoughtOfTheDay rpThoughtOfTheDay)
        {
            if (rpThoughtOfTheDay != null)
            {
                RM_ThoughtOfTheDay rmThoughtOfTheDay = new RM_ThoughtOfTheDay();
                List<RPR_ThoughtOfTheDay> rprThoughtOfTheDay = rmThoughtOfTheDay.ThoughtOfTheDay(rpThoughtOfTheDay);

                if (rmThoughtOfTheDay._IsSuccess)
                    return req.CreateResponse<List<RPR_ThoughtOfTheDay>>(HttpStatusCode.Created, rprThoughtOfTheDay);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // thought of the Day 

        [Route("DigitalMenu/ViewThoughtOfTheDay")]
        [HttpPost]

        public HttpResponseMessage ViewThoughtOfTheDay(HttpRequestMessage req, RP_ViewThoughtOfTheDay rpViewThoughtOfTheDay)
        {
            if (rpViewThoughtOfTheDay != null)
            {
                RM_ViewThoughtOfTheDay rmViewThoughtOfTheDay = new RM_ViewThoughtOfTheDay();
                List<RPR_ViewThoughtOfTheDay> rprViewThoughtOfTheDay = rmViewThoughtOfTheDay.ViewThoughtOfTheDay(rpViewThoughtOfTheDay);

                if (rmViewThoughtOfTheDay._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewThoughtOfTheDay>>(HttpStatusCode.Created, rprViewThoughtOfTheDay);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // Add Restaurants 

        [Route("DigitalMenu/Restaurants")]
        [HttpPost]

        public HttpResponseMessage Restaurants(HttpRequestMessage req, RP_Restaurants rpRestaurants)
        {
            if (rpRestaurants != null)
            {
                RM_Restaurants rmRestaurants = new RM_Restaurants();
                List<RPR_Restaurants> rprRestaurants = rmRestaurants.AddRestaurant(rpRestaurants);

                if (rmRestaurants._IsSuccess)
                    return req.CreateResponse<List<RPR_Restaurants>>(HttpStatusCode.Created, rprRestaurants);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // View Restaurant

        [Route("DigitalMenu/ViewRestaurants")]
        [HttpPost]

        public HttpResponseMessage ViewRestaurants(HttpRequestMessage req, RP_ViewRestaurants rpViewRestaurants)
        {
            if (rpViewRestaurants != null)
            {
                RM_ViewRestaurants rmViewRestaurants = new RM_ViewRestaurants();
                List<RPR_ViewRestaurants> rprViewRestaurants = rmViewRestaurants.ViewRestaurant(rpViewRestaurants);

                if (rmViewRestaurants._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewRestaurants>>(HttpStatusCode.Created, rprViewRestaurants);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // Register Device

        [Route("DigitalMenu/Registration")]
        [HttpPost]

        public HttpResponseMessage Registration(HttpRequestMessage req, RP_Registration rpRegistration)
        {
            if (rpRegistration != null)
            {
                RM_Registration rmRegistration = new RM_Registration();
                List<RPR_Registration> rprRegistration = rmRegistration.Registration(rpRegistration);

                if (rmRegistration._IsSuccess)
                    return req.CreateResponse<List<RPR_Registration>>(HttpStatusCode.Created, rprRegistration);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // Transaction Filter By Waitor Id and Item Name 
        [Route("DigitalMenu/TransFilter")]
        [HttpPost]

        public HttpResponseMessage TransFilter(HttpRequestMessage req, RP_TransFilter rpTransFilter)
        {
            if (rpTransFilter != null)
            {
                RM_TransFilter rmTransFilter = new RM_TransFilter();
                List<RPR_TransFilter> rprTransFilter = rmTransFilter.TransFilter(rpTransFilter);

                if (rmTransFilter._IsSuccess)
                    return req.CreateResponse<List<RPR_TransFilter>>(HttpStatusCode.Created, rprTransFilter);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // Customer  total Amount 
        [Route("DigitalMenu/CusTotalAmount")]
        [HttpPost]

        public HttpResponseMessage CusTotalAmount(HttpRequestMessage req, RP_CusTotalAmount rpCusTotalAmount)
        {
            if (rpCusTotalAmount != null)
            {
                RM_CusTotalAmount rmCusTotalAmount = new RM_CusTotalAmount();

                List<RPR_CusTotalAmount> rprCusTotalAmount = rmCusTotalAmount.CusTotalAmount(rpCusTotalAmount);

                if (rmCusTotalAmount._IsSuccess)
                    return req.CreateResponse<List<RPR_CusTotalAmount>>(HttpStatusCode.Created, rprCusTotalAmount);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // Add Feed Back Question 

        [Route("DigitalMenu/AddFeedBackQuestion")]
        [HttpPost]

        public HttpResponseMessage AddFeedBackQuestion(HttpRequestMessage req, RP_AddFeedBackQuestion rpAddFeedBackQuestion)
        {
            if (rpAddFeedBackQuestion != null)
            {
                RM_AddFeedBackQuestion rmAddFeedBackQuestion = new RM_AddFeedBackQuestion();

                List<RPR_AddFeedBackQuestion> rprAddFeedBackQuestion = rmAddFeedBackQuestion.AddFeedBackQuestion(rpAddFeedBackQuestion);

                if (rmAddFeedBackQuestion._IsSuccess)
                    return req.CreateResponse<List<RPR_AddFeedBackQuestion>>(HttpStatusCode.Created, rprAddFeedBackQuestion);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }

        // UploadImage category and menu Item images 

        [Route("DigitalMenu/UploadImage")]
        [HttpPost]

        public HttpResponseMessage UploadImage(HttpRequestMessage req, RP_UploadImage rpUploadImage)
        {
            if (rpUploadImage != null)
            {
                RM_UploadImage rmUploadImage = new RM_UploadImage();

                List<RPR_UploadImage> rprUploadImage = rmUploadImage.UploadImage(rpUploadImage);

                if (rmUploadImage._IsSuccess)
                    return req.CreateResponse<List<RPR_UploadImage>>(HttpStatusCode.Created, rprUploadImage);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // View Bill Details 
        [Route("DigitalMenu/ViewBillDetails")]
        [HttpPost]

        public HttpResponseMessage ViewBillDetails(HttpRequestMessage req, RP_ViewBillDetails rpViewBillDetails)
        {
            if (rpViewBillDetails != null)
            {
                RM_ViewBillDetails rmViewBillDetails = new RM_ViewBillDetails();

                List<RPR_ViewBillDetails> rprViewBillDetails = rmViewBillDetails.ViewBillDetails(rpViewBillDetails);

                if (rmViewBillDetails._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewBillDetails>>(HttpStatusCode.Created, rprViewBillDetails);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }




        
        
        // Delete Staff 
        [Route("DigitalMenu/DeleteStaff")]
        [HttpPost]

        public HttpResponseMessage DeleteStaff(HttpRequestMessage req, RP_DeleteStaff rpDeleteStaff)
        {
            if (rpDeleteStaff != null)
            {
                RM_DeleteStaff rmDeleteStaff = new RM_DeleteStaff();

                List<RPR_DeleteStaff> rprDeleteStaff = rmDeleteStaff.DeleteStaff(rpDeleteStaff);

                if (rmDeleteStaff._IsSuccess)
                    return req.CreateResponse<List<RPR_DeleteStaff>>(HttpStatusCode.Created, rprDeleteStaff);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }



        // admin View Table 

        [Route("DigitalMenu/AdminViewTable")]
        [HttpPost]

        public HttpResponseMessage AdminViewTable(HttpRequestMessage req, RP_AdminViewTable rpAdminViewTable)
        {
            if (rpAdminViewTable != null)
            {
                RM_AdminViewTable rmAdminViewTable = new RM_AdminViewTable();

                List<RPR_AdminViewTable> rprAdminViewTable = rmAdminViewTable.AdminViewTable(rpAdminViewTable);

                if (rmAdminViewTable._IsSuccess)
                    return req.CreateResponse<List<RPR_AdminViewTable>>(HttpStatusCode.Created, rprAdminViewTable);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }





      // SHOW CUSTOMER FEEDBACK 

        [Route("DigitalMenu/ShowCustFeedBack")]
        [HttpPost]

        public HttpResponseMessage ShowCustFeedBack(HttpRequestMessage req, RP_ShowCustFeedBack rpShowCustFeedBack)
        {
            if (rpShowCustFeedBack != null)
            {
                RM_ShowCustFeedBack rmShowCustFeedBack = new RM_ShowCustFeedBack();

                List<RPR_ShowCustFeedBack> rprShowCustFeedBack = rmShowCustFeedBack.ShowCustFeedBack(rpShowCustFeedBack);

                if (rmShowCustFeedBack._IsSuccess)
                    return req.CreateResponse<List<RPR_ShowCustFeedBack>>(HttpStatusCode.Created, rprShowCustFeedBack);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }



        



        // Admin View Customer Feedback order by admount 

        [Route("DigitalMenu/CustFeedBackFilter")]
        [HttpPost]

        public HttpResponseMessage CustFeedBackFilter(HttpRequestMessage req, RP_CustFeedBackFilter rpCustFeedBackFilter)
        {
            if (rpCustFeedBackFilter != null)
            {
                RM_CustFeedBackFilter rmCustFeedBackFilter = new RM_CustFeedBackFilter();

                List<RPR_CustFeedBackFilter> rprCustFeedBackFilter = rmCustFeedBackFilter.CustFeedBackFilter(rpCustFeedBackFilter);

                if (rmCustFeedBackFilter._IsSuccess)
                    return req.CreateResponse<List<RPR_CustFeedBackFilter>>(HttpStatusCode.Created, rprCustFeedBackFilter);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        // SHOW CUSTOMER FEEDBACK 

        [Route("DigitalMenu/ViewCustFeedBack")]
        [HttpPost]

        public HttpResponseMessage ViewCustFeedBack(HttpRequestMessage req, RP_ViewCustFeedBack rpViewCustFeedBack)
        {
            if (rpViewCustFeedBack != null)
            {
                RM_ViewCustFeedBack rmViewCustFeedBack = new RM_ViewCustFeedBack();

                List<RPR_ViewCustFeedBack> rprViewCustFeedBack = rmViewCustFeedBack.ViewCustFeedBack(rpViewCustFeedBack);

                if (rmViewCustFeedBack._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewCustFeedBack>>(HttpStatusCode.Created, rprViewCustFeedBack);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }




        // admin view item sale quantity


        [Route("DigitalMenu/ViewItemSale")]
        [HttpPost]

        public HttpResponseMessage ViewItemSale(HttpRequestMessage req, RP_ViewItemSale rpViewItemSale)
        {
            if (rpViewItemSale != null)
            {
                RM_ViewItemSale rmViewItemSale = new RM_ViewItemSale();

                List<RPR_ViewItemSale> rprViewItemSale = rmViewItemSale.ViewItemSale(rpViewItemSale);

                if (rmViewItemSale._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewItemSale>>(HttpStatusCode.Created, rprViewItemSale);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }




        // View All Customer 


        [Route("DigitalMenu/GetAllCustomer")]
        [HttpPost]

        public HttpResponseMessage GetAllCustomer(HttpRequestMessage req, RP_GetAllCustomer rpGetAllCustomer)
        {
            if (rpGetAllCustomer != null)
            {
                RM_GetAllCustomer rmGetAllCustomer = new RM_GetAllCustomer();

                List<RPR_GetAllCustomer> rprGetAllCustomer = rmGetAllCustomer.GetAllCustomer(rpGetAllCustomer);

                if (rmGetAllCustomer._IsSuccess)
                    return req.CreateResponse<List<RPR_GetAllCustomer>>(HttpStatusCode.Created, rprGetAllCustomer);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }



        //////  ADD HEALTH CATEGORY ///////

        [Route("DigitalMenu/AddHealthCategory")]
        [HttpPost]

        public HttpResponseMessage AddHealthCategory(HttpRequestMessage req, RP_AddHealthCategory rpAddHealthCategory)
        {
            if (rpAddHealthCategory != null)
            {
                RM_AddHealthCategory rmAddHealthCategory = new RM_AddHealthCategory();
                List<RPR_AddHealthCategory> rprAddHealthCategory = rmAddHealthCategory.AddHealthCategory(rpAddHealthCategory);

                if (rmAddHealthCategory._IsSuccess)
                    return req.CreateResponse<List<RPR_AddHealthCategory>>(HttpStatusCode.Created, rprAddHealthCategory);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }


        //////  View HEALTH CATEGORY ///////

        [Route("DigitalMenu/ViewHealthCategory")]
        [HttpPost]

        public HttpResponseMessage ViewHealthCategory(HttpRequestMessage req, RP_ViewHealthCategory rpViewHealthCategory)
        {
            if (rpViewHealthCategory != null)
            {
                RM_ViewHealthCategory rmViewHealthCategory = new RM_ViewHealthCategory();
                List<RPR_ViewHealthCategory> rprViewHealthCategory = rmViewHealthCategory.ViewHealthCategory(rpViewHealthCategory);

                if (rmViewHealthCategory._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewHealthCategory>>(HttpStatusCode.Created, rprViewHealthCategory);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }




        //////  ADD HEALTH Tips ///////

        [Route("DigitalMenu/AddHealthTips")]
        [HttpPost]

        public HttpResponseMessage AddHealthTips(HttpRequestMessage req, RP_AddHealthTips rpAddHealthTips)
        {
            if (rpAddHealthTips != null)
            {
                RM_AddHealthTips rmAddHealthTips = new RM_AddHealthTips();
                List<RPR_AddHealthTips> rprAddHealthTips = rmAddHealthTips.AddHealthTips(rpAddHealthTips);

                if (rmAddHealthTips._IsSuccess)
                    return req.CreateResponse<List<RPR_AddHealthTips>>(HttpStatusCode.Created, rprAddHealthTips);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }




        /// View Health Tips /// 

        [Route("DigitalMenu/ViewHealthTips")]
        [HttpPost]

        public HttpResponseMessage ViewHealthTips(HttpRequestMessage req, RP_ViewHealthTips rpViewHealthTips)
        {
            if (rpViewHealthTips != null)
            {
                RM_ViewHealthTips rmViewHealthTips = new RM_ViewHealthTips();
                List<RPR_ViewHealthTips> rprViewHealthTips = rmViewHealthTips.ViewHealthTips(rpViewHealthTips);

                if (rmViewHealthTips._IsSuccess)
                    return req.CreateResponse<List<RPR_ViewHealthTips>>(HttpStatusCode.Created, rprViewHealthTips);

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
            }

            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");

        }













        //// demo api 

        //[Route("DigitalMenu/Pathcheker")]
        //[HttpPost]

        //public HttpResponseMessage AdminViewTable(HttpRequestMessage req)
        //{

        //    string q = AppDomain.CurrentDomain.BaseDirectory;
        //    var w = Environment.CurrentDirectory;
        //    string e = Environment.CurrentDirectory;
        //    string r = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        //    string[] arr = new string[4];
        //    arr[0] = q;
        //    arr[1] = w;
        //    arr[2] = e;
        //    arr[3] = r;
        //   // string x = q + "--" + w + "--" + e + "--" + r;

        //    return req.CreateResponse(HttpStatusCode.Created, arr);

        //}

        // Image Test for Byte Array  


        //[Route("DigitalMenu/TestImageByte")]
        //[HttpPost]

        //public HttpResponseMessage GetAllCustomer(HttpRequestMessage req, RP_TESTIMAGE rpx)
        //{
        //    //string absolutePath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\category\a.jpg";
        //    string absolutePath = @" " + ConfigurationManager.AppSettings["BaseImagePath"].ToString() + "img\\category\\a.jpg";


        //    byte[] bytes = Convert.FromBase64String(rpx.imgae);

        //    Image image;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = Image.FromStream(ms);
        //        image.Save(absolutePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    }


        //    // Image originalImage = Image.FromFile(imagePath);
        //    // string filePath = AppDomain.CurrentDomain.BaseDirectory + savedName;


        //    //        image.Save(absolutePath);

        //    return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");

        //}





        // Delete Staff 
        [Route("DigitalMenu/DeleteStaffNew")]
        [HttpPost]

        public HttpResponseMessage DeleteStaffNew(HttpRequestMessage req, RP_DeleteStaff rpDeleteStaff)
        {
            string error = "";
            if (rpDeleteStaff != null)
            {
               
                DataBase db = new DataBase();
                DataSet ds = null;
                try
                {
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@RestId", int.Parse(rpDeleteStaff.RestId));
                    param[1] = new SqlParameter("@posId", rpDeleteStaff.posId);
                    param[2] = new SqlParameter("@key", rpDeleteStaff.key);
                    param[3] = new SqlParameter("@waiterId", rpDeleteStaff.DeletedStaffID);

                    ds = db.GetDataSet("DigitalMenu_DeleteStaff", param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        error += "we are cool";

                    }
                }
                catch (Exception ex)
                {
                    error += ex.Message;
                }
                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
            }
            else
            {

                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
            }

        }




        ///////////////////////////---THE END ---//////////////////////



    }
}