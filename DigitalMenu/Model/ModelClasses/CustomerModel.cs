using DigitalMenu.Common;
using DigitalMenu.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace DigitalMenu.Model.ModelClasses
{
    //public class CustomerModel
    //{
    //}

    // Customer SignUp


    public class GcmPushNotification
    {
        public string SpName { get; set; }
        protected string RegId { get; set; }

        DataBase db = new DataBase();
        DataSet ds = null;

        protected string GcmPushNotificationfn(string waiterId, string msg, string restId, string tableNum)
        {
            //this.SpName = "DigitalMenu_GetGCMRegId"; //Sp Name

            this.SpName = "[DigitalMenu_GetGCM_RegID]";
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@WaitorId", waiterId);
                param[1] = new SqlParameter("@RestId", int.Parse(restId));
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRowCollection drc = ds.Tables[0].Rows;
                    foreach (DataRow item in drc)
                    {
                        RegId = "" + item["RegID"].ToString();

                    }

                    AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();
                    string deviceId = RegId;
                    //   string deviceId = "APA91bFKgxQBZve4dlbt-x20GE45PI9FyH3O3r80CwGpsZu3K3wem860wg4rHtf35hc3v-v4zyoyUSKCzNgce-fKTKE-is3nixMyMTxWW5TRwvnxc5ukvX51sySYeZ5kiEKR84uqq-Z_";
                    string message = msg;
                    string tickerText = tableNum; //"example test GCM";
                    string contentTitle = "content title GCM";
                    string ApiKey = "AIzaSyCclEA_Gbb70InvtsV9CXPQLGRjVesl1NA";// -- jaydev
                    // string ApiKey = "AIzaSyDFky610kEk8Q8crJqSvJgs9GhI60jvdFs";
                    string postData =
                    "{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
                      "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
                                 "\"contentTitle\":\"" + contentTitle + "\", " +
                                 "\"message\": \"" + message + "\"}}";

                    string response = apnGCM.SendGCMNotification(ApiKey, postData);

                    if (response == "error")
                    {
                        return "2";

                    }
                    else
                    {

                        string[] x = response.Split(',');
                        string success = x[1].Split(':')[1];
                        if (success == "1")
                        {
                            return "1";

                        }


                    }

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(LogLevelL4N.ERROR, " Unable To Send Notification: | Exception : " + ex.Message);
            }

            return "2";

        }


    }


    // Customer Login with Social media 

    public class RM_CustLogin
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CustLogin> rprCustLogin = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_CustLogin> CustLogin(RP_CustLogin rpCustLogin)
        {
            this.SpName = "DigitalMenu_CustLogin"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Mobile", rpCustLogin.Mobile);
                param[1] = new SqlParameter("@Password", rpCustLogin.password);
                param[2] = new SqlParameter("@Key", GenerateRandomSession());
                param[3] = new SqlParameter("@DeviceMacAdd", rpCustLogin.DeviceMac);
                param[4] = new SqlParameter("@CusEmailId", string.IsNullOrEmpty(rpCustLogin.CusEmailId) ? Convert.DBNull : rpCustLogin.CusEmailId);
                param[5] = new SqlParameter("@CusName", string.IsNullOrEmpty(rpCustLogin.CusName) ? Convert.DBNull : rpCustLogin.CusName);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCustLogin = SerializeData.SerializeMultiValue<RPR_CustLogin>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " cus Login | Exception : " + ex.Message);
            }
            return rprCustLogin;
        }
        //Generate random number
        private string GenerateRandomSession()
        {
            string t = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJLKMNOPQRTUVWXYZ0123456789";
            char[] chars = t.ToCharArray();
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                char c = chars[random.Next(chars.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }

    }



    public class RM_CustomerSignUp
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_SignUp> rprSignUp = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_SignUp> CustomerSignUp(RP_CustomerSignUp rpCustomerSignUp)
        {
            this.SpName = "DigitalMenu_CustomerSignUp"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Name", rpCustomerSignUp.Name);
                param[1] = new SqlParameter("@Mobile", rpCustomerSignUp.Mobile);
                param[2] = new SqlParameter("@Email", string.IsNullOrEmpty(rpCustomerSignUp.Email) ? Convert.DBNull : rpCustomerSignUp.Email);
                param[3] = new SqlParameter("@Password", rpCustomerSignUp.Password);
                param[4] = new SqlParameter("@RestId", string.IsNullOrEmpty(rpCustomerSignUp.RestId) ? Convert.DBNull : int.Parse(rpCustomerSignUp.RestId));
                param[5] = new SqlParameter("@DeviceMac", string.IsNullOrEmpty(rpCustomerSignUp.DeviceMac) ? Convert.DBNull : rpCustomerSignUp.DeviceMac);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprSignUp = SerializeData.SerializeMultiValue<RPR_SignUp>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Customer SignUp | Exception : " + ex.Message);
            }
            return rprSignUp;
        }


    }




    // social Media Login 
    //public class RM_SocialCusLogin
    //{
    //    [JsonIgnore]
    //    public bool _IsSuccess { get; set; }
    //    private string SpName { get; set; }
    //    public List<RPR_SocialCusLogin> rprSocialCusLogin = null;
    //    DataBase db = new DataBase();
    //    DataSet ds = null;

    //    public List<RPR_SocialCusLogin> SocialCusLogin(RP_SocialCusLogin rpSocialCusLogin)
    //    {
    //        this.SpName = ""; //Sp Name
    //        _IsSuccess = true;
    //        try
    //        {
    //            SqlParameter[] param = new SqlParameter[4];
    //            param[0] = new SqlParameter("@CusName", rpSocialCusLogin.cusName);
    //            param[1] = new SqlParameter("@CusMobile", string.IsNullOrEmpty(rpSocialCusLogin.mobile) ? Convert.DBNull : rpSocialCusLogin.mobile);
    //            param[2] = new SqlParameter("@CusEmail", string.IsNullOrEmpty(rpSocialCusLogin.cusEmail) ? Convert.DBNull : rpSocialCusLogin.cusEmail);
    //            param[3] = new SqlParameter("@CusDeviceMac", string.IsNullOrEmpty(rpSocialCusLogin.Devicemac) ? Convert.DBNull : rpSocialCusLogin.Devicemac);

    //            ds = db.GetDataSet(this.SpName, param);

    //            if (ds != null && ds.Tables.Count > 0)
    //            {
    //                rprSocialCusLogin = SerializeData.SerializeMultiValue<RPR_SocialCusLogin>(ds.Tables[0]);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _IsSuccess = false;
    //            Logger.WriteLog(LogLevelL4N.ERROR, " Customer  SignUp and Login  | Exception : " + ex.Message);
    //        }
    //        return rprSocialCusLogin;
    //    }


    //}


    // Select table 
    public class RM_SelectTable
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_SelectTable> rprSelectTable = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_SelectTable> SelectTable(RP_SelectTable rpSelectTable)
        {
            this.SpName = "DigitalMenu_SelectTable"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@CusId", rpSelectTable.CusId);
                param[1] = new SqlParameter("@DeviceMac", rpSelectTable.DeviceMac.Trim());
                param[2] = new SqlParameter("@key", rpSelectTable.key);
                param[3] = new SqlParameter("@RestId", int.Parse(rpSelectTable.RestId));
                param[4] = new SqlParameter("@TableNo", rpSelectTable.TableNo.Trim());
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprSelectTable = SerializeData.SerializeMultiValue<RPR_SelectTable>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Select table | Exception : " + ex.Message);
            }
            return rprSelectTable;
        }


    }


    //Select Category 
    public class RM_SelectCategory
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_SelectCategory> rprSelectCategory = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_SelectCategory> SelectCategory(RP_SelectCategory rpSelectCategory)
        {
            this.SpName = "DigitalMenu_SelectCategory"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@CategoryName", rpSelectCategory.CategoryName);
                param[1] = new SqlParameter("@key", rpSelectCategory.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpSelectCategory.RestId));
                param[3] = new SqlParameter("@CusId", int.Parse(rpSelectCategory.CusId));

                string catName = rpSelectCategory.CategoryName;

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    // used data set and data table 

                    DataTable Tables = new DataTable("items");
                    Tables.Columns.Add("ItemId");
                    Tables.Columns.Add("ItemName");
                    Tables.Columns.Add("ItemImage");
                    Tables.Columns.Add("CategoryId");
                    Tables.Columns.Add("ItemDesc");
                    Tables.Columns.Add("ItemPrice");

                    // loop through category  
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string ItemId = "" + dr["ItemId"].ToString();
                        string ItemName = "" + dr["ItemName"].ToString();
                        string CategoryId = "" + dr["CategoryId"].ToString();
                        string ItemDesc = "" + dr["ItemDesc"].ToString();
                        string ItemPrice = "" + dr["ItemPrice"].ToString();
                        string ItemImage = "";

                        if (catName != "") //chk catName
                        {
                            string absolutePath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                            absolutePath += catName + "\\";
                            absolutePath += ItemName + ".jpg";

                            // Path Used For Happy Hour Only 
                            if (File.Exists(absolutePath))
                            {
                                ItemImage = ConfigurationManager.AppSettings["BaseImageUrl"].ToString() + "/img/items/" + catName + "/" + ItemName + ".jpg"; 
                            }
                            else
                            {
                                // for Happy Hour Category 
                                string HappyHourCatPath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\category\\";
                                HappyHourCatPath += catName + ".jpg";

                                if (File.Exists(HappyHourCatPath))
                                {
                                    ItemImage = ConfigurationManager.AppSettings["BaseImageUrl"].ToString() + "/img/category/" + catName  + ".jpg"; 
                                }
                                else
                                {
                                    ItemImage = "";
                                }

                            }

                            Tables.Rows.Add(ItemId, ItemName, ItemImage, CategoryId, ItemDesc, ItemPrice);
                        }
                        else
                        {
                            Tables.Rows.Add(ItemId, ItemName, "", CategoryId, ItemDesc, ItemPrice);

                        }
                    }  // foreach end 

                    DataSet dsNew = new DataSet("dataset");
                    dsNew.Tables.Add(Tables);

                    rprSelectCategory = SerializeData.SerializeMultiValue<RPR_SelectCategory>(dsNew.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Select Category | Exception : " + ex.Message);
            }
            return rprSelectCategory;
        }


    }

    //select Item 
    public class RM_SelectItem
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_SelectItem> rprSelectItem = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_SelectItem> SelectItem(RP_SelectItem rpSelectItem)
        {
            this.SpName = "DigitalMenu_SelectItem"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@CategoryId", rpSelectItem.CategoryId.Trim());
                param[1] = new SqlParameter("@key", rpSelectItem.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpSelectItem.RestId));
                param[3] = new SqlParameter("@CusId", int.Parse(rpSelectItem.CusId));
                param[4] = new SqlParameter("@ItemId", rpSelectItem.ItemId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprSelectItem = SerializeData.SerializeMultiValue<RPR_SelectItem>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Select Category | Exception : " + ex.Message);
            }
            return rprSelectItem;
        }


    }

    //Added To Cart 
    public class RM_AddedToCart
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddedToCart> rprAddedToCart = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AddedToCart> AddedToCart(RP_AddedToCart rpAddedToCart)
        {
            this.SpName = "DigitalMenu_AddToCart"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@WaitorId", rpAddedToCart.WaitorId.Trim());
                param[1] = new SqlParameter("@key", rpAddedToCart.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpAddedToCart.RestId));
                param[3] = new SqlParameter("@CusId", int.Parse(rpAddedToCart.CusId));
                param[4] = new SqlParameter("@ItemId", rpAddedToCart.ItemId);
                param[5] = new SqlParameter("@TableId", rpAddedToCart.TableId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddedToCart = SerializeData.SerializeMultiValue<RPR_AddedToCart>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Add to Cart | Exception : " + ex.Message);
            }
            return rprAddedToCart;
        }


    }

    //View Cart
    public class RM_ViewCart
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewCart> rprViewCart = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_ViewCart> ViewCart(RP_ViewCart rpViewCart)
        {
            this.SpName = "DigitalMenu_ViewCart"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@WaitorId", rpViewCart.WaitorId.Trim());
                param[1] = new SqlParameter("@key", rpViewCart.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpViewCart.RestId));
                param[3] = new SqlParameter("@CusId", int.Parse(rpViewCart.CusId));
                param[4] = new SqlParameter("@TableId", rpViewCart.TableId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewCart = SerializeData.SerializeMultiValue<RPR_ViewCart>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " View Cart | Exception : " + ex.Message);
            }
            return rprViewCart;
        }


    }

    //Update Cart 
    public class RM_UpdateCart
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_UpdateCart> rprUpdateCart = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_UpdateCart> UpdateCart(RP_UpdateCart rpUpdateCart)
        {
            this.SpName = "DigitalMenu_UpdateCart"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@WaitorId", rpUpdateCart.WaitorId.Trim());
                param[1] = new SqlParameter("@key", rpUpdateCart.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpUpdateCart.RestId));
                param[3] = new SqlParameter("@CusId", int.Parse(rpUpdateCart.CusId));
                param[4] = new SqlParameter("@TableId", rpUpdateCart.TableId);
                param[5] = new SqlParameter("@ItemId", rpUpdateCart.ItemId);
                param[6] = new SqlParameter("@ItemQuantity", int.Parse(rpUpdateCart.ItemQuantity));
                param[7] = new SqlParameter("@TotalAmount", float.Parse(rpUpdateCart.TotalAmount));
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprUpdateCart = SerializeData.SerializeMultiValue<RPR_UpdateCart>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Update Cart | Exception : " + ex.Message);
            }
            return rprUpdateCart;
        }


    }

    // Delete cart 
    public class RM_DeleteCart
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_DeleteCart> rprDeleteCart = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_DeleteCart> DeleteCart(RP_DeleteCart rpDeleteCart)
        {
            this.SpName = "DigitalMenu_DeleteCart"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@WaitorId", rpDeleteCart.WaitorId.Trim());
                param[1] = new SqlParameter("@key", rpDeleteCart.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpDeleteCart.RestId));
                param[3] = new SqlParameter("@CusId", int.Parse(rpDeleteCart.CusId));
                param[4] = new SqlParameter("@TableId", rpDeleteCart.TableId);
                param[5] = new SqlParameter("@ItemId", rpDeleteCart.ItemId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprDeleteCart = SerializeData.SerializeMultiValue<RPR_DeleteCart>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Update Cart | Exception : " + ex.Message);
            }
            return rprDeleteCart;
        }


    }

    //Order Item 
    public class RM_OrderItem
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public string Status { get; set; }
        public List<RPR_OrderItem> rprOrderItem = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_OrderItem> OrderItem(RP_OrderItem rpOrderItem)
        {
            this.SpName = "DigitalMenu_OrderItem"; //Sp Name
            _IsSuccess = true;
            try
            {
                string[] categoryDetails = new string[4];
                JArray a = JArray.Parse(rpOrderItem.ItemDetails);
                int count = a.Count;
                int last_sp_call = 0; // to send Status to searlize json object
                foreach (JObject o in a.Children<JObject>())
                {
                    int i = 0;
                    foreach (JProperty p in o.Properties())
                    {
                        categoryDetails[i] = p.Value.ToString();
                        i++;
                    }
                    SqlParameter[] param = new SqlParameter[9];
                    param[0] = new SqlParameter("@RestId", int.Parse(rpOrderItem.RestId));
                    param[1] = new SqlParameter("@cusId", int.Parse(rpOrderItem.CusId));
                    param[2] = new SqlParameter("@key", rpOrderItem.key);
                    param[3] = new SqlParameter("@waiterId", rpOrderItem.WaiterId);
                    param[4] = new SqlParameter("@tableNum", rpOrderItem.TableId);
                    param[5] = new SqlParameter("@itemId", categoryDetails[0]);
                    param[6] = new SqlParameter("@qunatity", int.Parse(categoryDetails[2]));
                    param[7] = new SqlParameter("@price", float.Parse(categoryDetails[1]));
                    param[8] = new SqlParameter("@amount", float.Parse(categoryDetails[3]));

                    ds = db.GetDataSet(this.SpName, param);
                    last_sp_call++;
                    if (last_sp_call == count)
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            rprOrderItem = SerializeData.SerializeMultiValue<RPR_OrderItem>(ds.Tables[0]);
                        }
                    } //if end 


                } //foreach end 


            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Order Item | Exception : " + ex.Message);
            }

            return rprOrderItem;
        }


        //GCM Notify Waitor
        protected void NotifyWaitor(RP_OrderItem rpOrderItem, string status)
        {

            if (Status.Equals('1'))
            {
                this.SpName = "DigitalMenu_GetGCMRegId"; //Sp Name
                try
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@WaitorId", rpOrderItem.WaiterId);
                    param[1] = new SqlParameter("@RestId", int.Parse(rpOrderItem.RestId));
                    // param[2] = new SqlParameter("@TableId", rpOrderItem.TableId);

                    ds = db.GetDataSet(this.SpName, param);
                    string RegId = "";
                    string msg = "";
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataRowCollection drc = ds.Tables[0].Rows;
                        foreach (DataRow item in drc)
                        {
                            RegId = "" + item["RegID"];

                        }
                        msg = "Order From Table" + rpOrderItem.TableId;
                        AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();
                        //apnGCM.SendNotification(RegId, msg);

                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(LogLevelL4N.ERROR, " Unable To Send Notification: | Exception : " + ex.Message);
                }

            }
        }
    }



    //Customer Checkout 
    public class RM_CustomerCheckout : GcmPushNotification
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CustomerCheckout> rprCustomerCheckout = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_CustomerCheckout> OrderItem(RP_CustomerCheckout rpCustomerCheckout)
        {
            this.SpName = "DigitalMenu_CustomerCheckOut"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@key", rpCustomerCheckout.key);
                param[1] = new SqlParameter("@RestId", int.Parse(rpCustomerCheckout.RestId));
                param[2] = new SqlParameter("@CusId", int.Parse(rpCustomerCheckout.CusId));
                param[3] = new SqlParameter("@cusFeedback", rpCustomerCheckout.CusFeeBack);
                param[4] = new SqlParameter("@WaiterId", rpCustomerCheckout.WaiterId);
                param[5] = new SqlParameter("@RatingForService", rpCustomerCheckout.RatingForService);
                param[6] = new SqlParameter("@RatingForTaste", rpCustomerCheckout.RatingForTest);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCustomerCheckout = SerializeData.SerializeMultiValue<RPR_CustomerCheckout>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Customer CheckOut | Exception : " + ex.Message);
            }
            return rprCustomerCheckout;
        }




    }




    /// cutomer order histroy 
    public class RM_CustomerOrderHistroy
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CustomerOrderHistroy> rprCustomerOrderHistroy = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_CustomerOrderHistroy> CustomerOrderHistroy(RP_CustomerOrderHistroy rpCustomerOrderHistroy)
        {
            this.SpName = "DigitalMenu_CustomerOrderHistroy"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@WaiterId", rpCustomerOrderHistroy.WaiterId);
                param[1] = new SqlParameter("@key", rpCustomerOrderHistroy.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpCustomerOrderHistroy.RestId));
                param[3] = new SqlParameter("@CusId", int.Parse(rpCustomerOrderHistroy.CusId));
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCustomerOrderHistroy = SerializeData.SerializeMultiValue<RPR_CustomerOrderHistroy>(ds.Tables[0]);
                    //NotifyCheckout(rpCustomerCheckout);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Customer order Histroy | Exception : " + ex.Message);
            }
            return rprCustomerOrderHistroy;
        }

        protected void NotifyCheckout(RP_CustomerCheckout rpCustomerCheckout)
        {
            this.SpName = "DigitalMenu_GetGCMRegId"; //Sp Name
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@WaitorId", rpCustomerCheckout.WaiterId);
                param[1] = new SqlParameter("@RestId", int.Parse(rpCustomerCheckout.RestId));
                // param[2] = new SqlParameter("@TableId", rpCustomerCheckout.TableId);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRowCollection drc = ds.Tables[0].Rows;
                    foreach (DataRow item in drc)
                    {
                        // RegId = "" + item["RegID"];

                    }
                    //msg = "Customer Checkout  From Table" + rpCustomerCheckout.TableId;

                    // GCM STart 
                    string RegId = "APA91bHuM_dbxRqmWdV_mnlEg5KmjyVSki7LgnxVkIzF8FC7h6RHcD-0ujawEpzT-Ywugm5h7S-VZHxqVogmWpmJdkM5N6ifTfmPjVILmzEBaMbcqii0QOErl55T-8joDHIubpxxc8b-L_PF8uew2D9oMHydpZJl0Q";
                    string msg = "hello";

                    AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();
                    //apnGCM.SendNotification(RegId, msg);
                    string deviceId = RegId;// "DEVICE_REGISTRATION_ID";
                    string message = "some test message";
                    string tickerText = "example test GCM";
                    string contentTitle = "content title GCM";
                    string ApiKey = "AIzaSyBjNFw_1Y6W59gTvVaGIrb50NAKwN-LKwQ";
                    string postData =
                    "{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
                      "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
                                 "\"contentTitle\":\"" + contentTitle + "\", " +
                                 "\"message\": \"" + message + "\"}}";

                    string response = apnGCM.SendGCMNotification(ApiKey, postData);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(LogLevelL4N.ERROR, " Unable To Send Notification: | Exception : " + ex.Message);
            }

        }
    }



    //Customer Pay Mode 
    public class RM_CustomerPayMode
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CustomerPayMode> rprCustomerPayMode = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_CustomerPayMode> PayMode(RP_CustomerPayMode rpCustomerPayMode)
        {
            this.SpName = "DigitalMenu_CustomerPayMode"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@WaitorId", rpCustomerPayMode.WaitorId.Trim());
                param[1] = new SqlParameter("@key", rpCustomerPayMode.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpCustomerPayMode.RestId));
                param[3] = new SqlParameter("@CusId", int.Parse(rpCustomerPayMode.CusId));
                param[4] = new SqlParameter("@TableId", rpCustomerPayMode.TableId);
                param[5] = new SqlParameter("@ItemId", rpCustomerPayMode.ItemId);
                param[6] = new SqlParameter("@PayMode", rpCustomerPayMode.PayMode);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCustomerPayMode = SerializeData.SerializeMultiValue<RPR_CustomerPayMode>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Customer Pay Mode | Exception : " + ex.Message);
            }
            return rprCustomerPayMode;
        }


    }

    // Email Validation 
    public class RM_EmailValidation
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_EmailValidation> rprEmailValidation = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_EmailValidation> EmailValidation(RP_EmailValidation rpEmailValidation)
        {
            this.SpName = "DigitalMenu_EmailValidation"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@EmailAdd", rpEmailValidation.EmailAdd);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprEmailValidation = SerializeData.SerializeMultiValue<RPR_EmailValidation>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Eamil Validation | Exception : " + ex.Message);
            }
            return rprEmailValidation;
        }


    }


    //View Category
    public class RM_ViewCategory
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewCategory> rprViewCategory = null;
        DataBase db = new DataBase();
        DataSet ds = null;



        public List<RPR_ViewCategory> ViewCategory(RP_ViewCategory rpViewCategory)
        {
            this.SpName = "DigitalMenu_ViewCat"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@CusId", int.Parse(rpViewCategory.CusId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpViewCategory.RestId));
                param[2] = new SqlParameter("@key", rpViewCategory.key);
                //param[3] = new SqlParameter("@isHappyHourTime", rpViewCategory.isHappyHourTime);

                ds = db.GetDataSet(this.SpName, param);



                if (ds != null && ds.Tables.Count > 0)
                {
                    // used data set and data table 

                    DataTable Tables = new DataTable("category");
                    Tables.Columns.Add("CategoryName");
                    Tables.Columns.Add("CategoryDesc");
                    Tables.Columns.Add("CategoryImage");

                    // loop through category  
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string catName = "" + dr["CategoryName"].ToString();
                        string catDesc = "" + dr["CategoryDesc"].ToString();

                        //  if (catName != "" && catName != "Happy Hour") //chk catName
                        if (catName != "") //chk catName
                        {
                            //string absolutePath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\category\\";
                            ////string absolutePath = @"C:\inetpub\PabulumLatest\img\category\";
                            //absolutePath += catName + ".jpg";
                            string catImages = "";
                            //if (File.Exists(absolutePath))
                            //{
                                catImages = ConfigurationManager.AppSettings["BaseImageUrl"].ToString() + "/img/category/" + catName + ".jpg"; 
                            //}
                            Tables.Rows.Add(catName, catDesc, catImages);
                        }
                        else
                        {
                            Tables.Rows.Add(catName, catDesc, "");

                        }
                    }  // foreach end 

                    DataSet dsNew = new DataSet("dataset");
                    dsNew.Tables.Add(Tables);
                    rprViewCategory = SerializeData.SerializeMultiValue<RPR_ViewCategory>(dsNew.Tables[0]);
                }

            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " View Category | Exception : " + ex.Message);
            }
            return rprViewCategory;
        }


    }

    // Join Table
    public class RM_JoinTable
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_JoinTable> rprJoinTable = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_JoinTable> JoinTable(Rp_JoinTable rpJoinTable)
        {
            this.SpName = "DigitalMenu_JoinTable"; //Sp Name
            _IsSuccess = true;
            string RegId = "";
            string msg = "";
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@TableNumber", int.Parse(rpJoinTable.TableNumber));
                param[1] = new SqlParameter("@RestId", int.Parse(rpJoinTable.RestId));
                param[2] = new SqlParameter("@key", rpJoinTable.key);
                param[3] = new SqlParameter("@Mobile", rpJoinTable.Mobile);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRowCollection drc = ds.Tables[0].Rows;
                    foreach (DataRow item in drc)
                    {
                        RegId = "" + item["GCMRegId"];
                    }
                    msg = "Join Request From Table" + rpJoinTable.TableNumber;
                    AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();
                    //apnGCM.SendNotification(RegId, msg);

                    //rprJoinTable = SerializeData.SerializeMultiValue<RPR_JoinTable>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Join Table | Exception : " + ex.Message);
            }
            return rprJoinTable;
        }


    }

    //Check Join Status 
    public class RM_CheckJoinStatus
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CheckJoinStatus> rprCheckJoinStatus = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_CheckJoinStatus> CheckJoinStatus(RP_CheckJoinStatus rpCheckJoinStatus)
        {
            this.SpName = "DigitalMenu_CheckJoinTableStatus"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@TableNumber", int.Parse(rpCheckJoinStatus.TableNumber));
                param[1] = new SqlParameter("@RestId", int.Parse(rpCheckJoinStatus.RestId));
                param[2] = new SqlParameter("@key", rpCheckJoinStatus.key);
                param[3] = new SqlParameter("@Mobile", rpCheckJoinStatus.Mobile);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCheckJoinStatus = SerializeData.SerializeMultiValue<RPR_CheckJoinStatus>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Check Join Status  | Exception : " + ex.Message);
            }
            return rprCheckJoinStatus;
        }


    }


    // cutomer Transaction 

    public class RM_CustomerTransaction
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CustomerTransaction> rprCustomerTransaction = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_CustomerTransaction> CustomerTransaction(RP_CustomerTransaction rpCustomerTransaction)
        {
            this.SpName = "DigitalMenu_CustomerTrans"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@CusId", int.Parse(rpCustomerTransaction.CusId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpCustomerTransaction.RestId));
                param[2] = new SqlParameter("@key", rpCustomerTransaction.key);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCustomerTransaction = SerializeData.SerializeMultiValue<RPR_CustomerTransaction>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Customer Transaction  | Exception : " + ex.Message);
            }
            return rprCustomerTransaction;
        }


    }


    // view Date Wise Cutomer Transaction 
    public class RM_CustomerTransactionDetails
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CustomerTransactionDetails> rprCustomerTransactionDetails = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_CustomerTransactionDetails> CustomerTransactionDetails(RP_CustomerTransactionDetails rpCustomerTransactionDetails)
        {
            this.SpName = "DigitalMenu_CustomerTransDetails"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@CusId", int.Parse(rpCustomerTransactionDetails.CusId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpCustomerTransactionDetails.RestId));
                param[2] = new SqlParameter("@key", rpCustomerTransactionDetails.key);
                param[3] = new SqlParameter("@date", string.IsNullOrEmpty(rpCustomerTransactionDetails.date) ? Convert.DBNull : Convert.ToDateTime(rpCustomerTransactionDetails.date).Date);
                param[4] = new SqlParameter("@BillNo", rpCustomerTransactionDetails.BillNo);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCustomerTransactionDetails = SerializeData.SerializeMultiValue<RPR_CustomerTransactionDetails>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Customer date wise  Transaction  | Exception : " + ex.Message);
            }
            return rprCustomerTransactionDetails;
        }


    }

    //  customer call waiter 


    public class RM_CustomerCallWaiter : GcmPushNotification
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CustomerCallWaiter> rprCustomerCallWaiter = null;
        // DataBase db = new DataBase();
        // DataSet ds = null;

        public List<RPR_CustomerCallWaiter> CustomerCallWaiter(RP_CustomerCallWaiter rpCustomerCallWaiter)
        {
            // this.SpName = "DigitalMenu_CustomerCallWaiter"; //Sp Name
            _IsSuccess = true;
            try
            {
                string status = GcmPushNotificationfn(rpCustomerCallWaiter.WaiterId, rpCustomerCallWaiter.NotificationMsg, rpCustomerCallWaiter.RestId, rpCustomerCallWaiter.TableNum);

                // used data set and data table 

                DataTable Tables = new DataTable("call Waiter");
                Tables.Columns.Add("Status");
                Tables.Rows.Add(status);

                DataSet ds = new DataSet("dataset");
                ds.Tables.Add(Tables);

                rprCustomerCallWaiter = SerializeData.SerializeMultiValue<RPR_CustomerCallWaiter>(ds.Tables[0]);
                //   return rprCustomerCallWaiter;
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " cus call Waiter  | Exception : " + ex.Message);
            }
            return rprCustomerCallWaiter;
        }


    }




} // end of main block 