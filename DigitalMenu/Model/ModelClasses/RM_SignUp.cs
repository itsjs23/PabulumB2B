using DigitalMenu.Common;
using DigitalMenu.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
namespace DigitalMenu.Model.ModelClasses
{

    //  admin SignUp 
    public class RM_SignUp
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_SignUp> rprSignUp = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_SignUp> SignUp(RP_SignUp rpSignup)
        {
            this.SpName = "DigitalMenu_AdminSignUp"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Name", rpSignup.Name);
                param[1] = new SqlParameter("@Mobile", rpSignup.Mobile);
                param[2] = new SqlParameter("@Email", rpSignup.Email);
                param[3] = new SqlParameter("@Password", rpSignup.Password);
                param[4] = new SqlParameter("@RestName", rpSignup.RestName);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprSignUp = SerializeData.SerializeMultiValue<RPR_SignUp>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "SignUp | Exception : " + ex.Message);
            }
            return rprSignUp;
        }


    }


    //admin Login 
    public class RM_AdminLogin
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AdminLogin> rprAdminLogin = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AdminLogin> AdminLogin(RP_AdminLogin rpAdminLogin)
        {
            this.SpName = "DigitalMenu_AdminLogin"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Mobile", rpAdminLogin.Mobile);
                param[1] = new SqlParameter("@Password", rpAdminLogin.password);
                param[2] = new SqlParameter("@Key", GenerateRandomSession());
                param[3] = new SqlParameter("@DeviceMacAdd", rpAdminLogin.DeviceMac);
                param[4] = new SqlParameter("@CusEmailId", string.IsNullOrEmpty(rpAdminLogin.CusEmailId) ? Convert.DBNull : rpAdminLogin.CusEmailId);
                param[5] = new SqlParameter("@CusName", string.IsNullOrEmpty(rpAdminLogin.CusName) ? Convert.DBNull : rpAdminLogin.CusName);


                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAdminLogin = SerializeData.SerializeMultiValue<RPR_AdminLogin>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Login | Exception : " + ex.Message);
            }
            return rprAdminLogin;
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


    // Admin Forgot Password Return 
    public class RM_AdminForgotPwd
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AdminForgotPwd> rprAdminForgotPwd = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_AdminForgotPwd> GetAdminForgotPwd(RP_AdminForgotPwd rpAdminForgotPwd)
        {
            this.SpName = "DigitalMenu_AdminForgotPwd"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Mobile", rpAdminForgotPwd.Mobile);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAdminForgotPwd = SerializeData.SerializeMultiValue<RPR_AdminForgotPwd>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Admin Forgot PAssword | Exception : " + ex.Message);
            }
            return rprAdminForgotPwd;
        }


    }


    //ADmin Password Change
    public class RM_AdminChangePwd
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AdminChangePwd> rprAdminChangePwd = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AdminChangePwd> AdminChnagePwd(RP_AdminChangePwd rpAdminChangePwd)
        {
            this.SpName = "DigitalMenu_AdminChangePwd"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Mobile", rpAdminChangePwd.Mobile);
                param[1] = new SqlParameter("@OldPwd", rpAdminChangePwd.OldPwd);
                param[2] = new SqlParameter("@NewPwd", rpAdminChangePwd.NewPwd);
                param[3] = new SqlParameter("@type", rpAdminChangePwd.type);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAdminChangePwd = SerializeData.SerializeMultiValue<RPR_AdminChangePwd>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Admin Change Password | Exception : " + ex.Message);
            }
            return rprAdminChangePwd;
        }


    }


    // Add ReserVation 
    public class RM_AddReserVation
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddReserVation> rprAddReserVation = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AddReserVation> AddReserVation(RP_AddReserVation rpAddReserVation)
        {
            this.SpName = "DigitalMenu_AddReserVation"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@Address", rpAddReserVation.Address);
                param[1] = new SqlParameter("@CusName", rpAddReserVation.CusName);
                param[2] = new SqlParameter("@Date", string.IsNullOrEmpty(rpAddReserVation.Date) ? Convert.DBNull : Convert.ToDateTime(rpAddReserVation.Date).Date);
                param[3] = new SqlParameter("@Email", rpAddReserVation.Email.Trim());
                param[4] = new SqlParameter("@EndTime", string.IsNullOrEmpty(rpAddReserVation.EndTime) ? Convert.DBNull : Convert.ToDateTime(rpAddReserVation.EndTime).TimeOfDay);
                param[5] = new SqlParameter("@key", rpAddReserVation.key);
                param[6] = new SqlParameter("@Mobile", rpAddReserVation.Mobile.Trim());
                param[7] = new SqlParameter("@NoOfPerson", rpAddReserVation.NoOfPerson);
                param[8] = new SqlParameter("@RestId", int.Parse(rpAddReserVation.RestId));
                param[9] = new SqlParameter("@StartTime", string.IsNullOrEmpty(rpAddReserVation.StartTime) ? Convert.DBNull : Convert.ToDateTime(rpAddReserVation.StartTime).TimeOfDay);
                param[10] = new SqlParameter("@TableNo", rpAddReserVation.TableNo);
                param[11] = new SqlParameter("@PosId", int.Parse(rpAddReserVation.PosId));
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddReserVation = SerializeData.SerializeMultiValue<RPR_AddReserVation>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Add ReserVation| Exception : " + ex.Message);
            }
            return rprAddReserVation;
        }


    }

    // View ReserVation 
    public class RM_ViewReserVation
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewReserVation> rprViewReserVation = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_ViewReserVation> ViewReserVation(RP_ViewReserVation rpViewReserVation)
        {
            this.SpName = "DigitalMenu_ViewReserVation"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Date", string.IsNullOrEmpty(rpViewReserVation.Date) ? Convert.DBNull : Convert.ToDateTime(rpViewReserVation.Date).Date);
                param[1] = new SqlParameter("@StartTime", string.IsNullOrEmpty(rpViewReserVation.StartTime) ? Convert.DBNull : Convert.ToDateTime(rpViewReserVation.StartTime).TimeOfDay);
                param[2] = new SqlParameter("@EndTime", string.IsNullOrEmpty(rpViewReserVation.EndTime) ? Convert.DBNull : Convert.ToDateTime(rpViewReserVation.EndTime).TimeOfDay);
                param[3] = new SqlParameter("@key", rpViewReserVation.key);
                param[4] = new SqlParameter("@RestId", int.Parse(rpViewReserVation.RestId));
                param[5] = new SqlParameter("@PosId", int.Parse(rpViewReserVation.posId));
                param[6] = new SqlParameter("@CusMobile", string.IsNullOrEmpty(rpViewReserVation.CusMobile) ? Convert.DBNull : rpViewReserVation.CusMobile);
                param[7] = new SqlParameter("@CusName", string.IsNullOrEmpty(rpViewReserVation.CusName) ? Convert.DBNull : rpViewReserVation.CusName);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewReserVation = SerializeData.SerializeMultiValue<RPR_ViewReserVation>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View  ReserVation| Exception : " + ex.Message);
            }
            return rprViewReserVation;
        }


    }



    // Update Delivery 
    public class RM_UpdateReserVationStatus
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_UpdateReserVationStatus> rprUpdateReserVationStatus = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_UpdateReserVationStatus> UpdateReserVationStatus(RP_UpdateReserVationStatus rpUpdateReserVationStatus)
        {
            this.SpName = "DigitalMenu_UpdateReserVationStatus"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@key", rpUpdateReserVationStatus.key);
                param[1] = new SqlParameter("@RestId", int.Parse(rpUpdateReserVationStatus.RestId));
                param[2] = new SqlParameter("@PosId", int.Parse(rpUpdateReserVationStatus.PosId));
                param[3] = new SqlParameter("@ReservationId", rpUpdateReserVationStatus.ReservationId);
                param[4] = new SqlParameter("@Status", rpUpdateReserVationStatus.Status);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprUpdateReserVationStatus = SerializeData.SerializeMultiValue<RPR_UpdateReserVationStatus>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View  ReserVation| Exception : " + ex.Message);
            }
            return rprUpdateReserVationStatus;
        }


    }





    //New Delivery 
    public class RM_NewDelivery
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public string DevId { get; set; }
        public List<RPR_NewDelivery> rprNewDelivery = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        DataBase db2 = new DataBase();
        DataSet ds2 = null;

        public List<RPR_NewDelivery> Delivery(RP_NewDelivery rpNewDelivery)
        {

            this.SpName = "DigitalMenu_NewDelivery"; //Sp Name
            _IsSuccess = true;
            try
            {
                string spName = "DigitalMenu_getDeliveryId";
                // get last Dleivery Id from DeliveryId table
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@RestId", int.Parse(rpNewDelivery.RestId));
                para[1] = new SqlParameter("@key", rpNewDelivery.key.Trim());
                ds2 = db2.GetDataSet(spName, para);
                if (ds2 != null && ds2.Tables.Count > 0)
                {
                    DataRow dr = ds2.Tables[0].Rows[0];
                    DevId = dr["devId"].ToString();
                }


                string[] categoryDetails = new string[4];
                JArray a = JArray.Parse(rpNewDelivery.ItemDetails);
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
                    SqlParameter[] param = new SqlParameter[15];
                    param[0] = new SqlParameter("@CategoryName", categoryDetails[0].Trim());
                    param[1] = new SqlParameter("@CusAddress", rpNewDelivery.CusAddress);
                    param[2] = new SqlParameter("@CusEmail", rpNewDelivery.CusEmail.Trim());
                    param[3] = new SqlParameter("@CusMobile", rpNewDelivery.CusMobile);
                    param[4] = new SqlParameter("@CusName", rpNewDelivery.CusName);
                    param[5] = new SqlParameter("@ItemName", categoryDetails[1].Trim());
                    param[6] = new SqlParameter("@ItemQunatity", int.Parse(categoryDetails[2]));
                    param[7] = new SqlParameter("@posId", int.Parse(rpNewDelivery.posId));
                    param[8] = new SqlParameter("@RestId", int.Parse(rpNewDelivery.RestId));
                    param[9] = new SqlParameter("@Amount", float.Parse(categoryDetails[3]));
                    param[10] = new SqlParameter("@Date", rpNewDelivery.Date.Trim());
                    param[11] = new SqlParameter("@Time", rpNewDelivery.Time.Trim());
                    param[12] = new SqlParameter("@key", rpNewDelivery.key.Trim());
                    param[13] = new SqlParameter("@DelivertID", string.IsNullOrEmpty(DevId) ? Convert.DBNull : DevId);
                    param[14] = new SqlParameter("@DelivertType", (rpNewDelivery.DeliveryType));
                    ds = db.GetDataSet(this.SpName, param);
                    last_sp_call++;
                    if (last_sp_call == count)
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            rprNewDelivery = SerializeData.SerializeMultiValue<RPR_NewDelivery>(ds.Tables[0]);
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "New ReserVation| Exception : " + ex.Message);
            }
            return rprNewDelivery;
        }



    }


    // update delivery 

    public class RM_UpdateDelivery
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }

        public string CusName { get; set; }
        public string CusMobile { get; set; }
        public string CusEmail { get; set; }
        public string CusAddress { get; set; }
        public string DelivertType { get; set; }

        //  public int counter { get; set; }




        public List<RPR_UpdateDelivery> rprUpdateDelivery = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        DataBase db2 = new DataBase();
        DataSet ds2 = null;

        public List<RPR_UpdateDelivery> UpdateDelivery(RP_UpdateDelivery rpUpdateDelivery)
        {

            // if (type == "InsertDelivery")
            // this.SpName = "DigitalMenu_NewDelivery"; //Sp Name
            //else
            this.SpName = "DigitalMenu_UpdateDelivery";//sp Name
            _IsSuccess = true;
            try
            {

                string spName = "DigitalMenu_CusDetailsFromDevId";
                // get last Dleivery Id from DeliveryId table
                SqlParameter[] para = new SqlParameter[3];
                para[0] = new SqlParameter("@RestId", int.Parse(rpUpdateDelivery.RestId));
                para[1] = new SqlParameter("@key", rpUpdateDelivery.key.Trim());
                para[2] = new SqlParameter("@DelivertID", rpUpdateDelivery.DeliveryID);
                ds2 = db2.GetDataSet(spName, para);

                if (ds2 != null && ds2.Tables.Count > 0)
                {
                    DataRow dr = ds2.Tables[0].Rows[0];

                    CusName = dr["CusName"].ToString();
                    CusMobile = dr["CusMobile"].ToString();
                    CusEmail = dr["CusEmail"].ToString();
                    CusAddress = dr["CusAddress"].ToString();
                    DelivertType = dr["DelivertType"].ToString();
                }


                string[] categoryDetails = new string[4];
                JArray a = JArray.Parse(rpUpdateDelivery.ItemDetails);
                int count = a.Count;
                int last_sp_call = 0; // to send Status to searlize json object
                int k = 0;
                foreach (JObject o in a.Children<JObject>())
                {
                    int i = 0;

                    foreach (JProperty p in o.Properties())
                    {
                        categoryDetails[i] = p.Value.ToString();
                        i++;
                    }


                    SqlParameter[] param = new SqlParameter[16];
                    param[0] = new SqlParameter("@CategoryName", categoryDetails[0].Trim());
                    param[1] = new SqlParameter("@CusAddress", CusAddress);
                    param[2] = new SqlParameter("@CusEmail", CusEmail);
                    param[3] = new SqlParameter("@CusMobile", CusMobile);
                    param[4] = new SqlParameter("@CusName", CusName);
                    param[5] = new SqlParameter("@ItemName", categoryDetails[1].Trim());
                    param[6] = new SqlParameter("@ItemQunatity", int.Parse(categoryDetails[2]));
                    param[7] = new SqlParameter("@posId", int.Parse(rpUpdateDelivery.posId));
                    param[8] = new SqlParameter("@RestId", int.Parse(rpUpdateDelivery.RestId));
                    param[9] = new SqlParameter("@Amount", float.Parse(categoryDetails[3]));
                    param[10] = new SqlParameter("@Date", rpUpdateDelivery.Date.Trim());
                    param[11] = new SqlParameter("@Time", rpUpdateDelivery.Time.Trim());
                    param[12] = new SqlParameter("@key", rpUpdateDelivery.key.Trim());
                    param[13] = new SqlParameter("@DelivertID", rpUpdateDelivery.DeliveryID);
                    param[14] = new SqlParameter("@DelivertType", DelivertType);
                    param[15] = new SqlParameter("@counter", k);

                    ds = db.GetDataSet(this.SpName, param);
                    k++;
                    last_sp_call++;
                    if (last_sp_call == count)
                    {
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            rprUpdateDelivery = SerializeData.SerializeMultiValue<RPR_UpdateDelivery>(ds.Tables[0]);
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Update  ReserVation| Exception : " + ex.Message);
            }
            return rprUpdateDelivery;
        }



    }



    //view deliveries
    public class RM_ViewDeliveries
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewDeliveries> rprViewDeliveries = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_ViewDeliveries> ViewDeliveries(RP_ViewDeliveries rpViewDeliveries)
        {
            this.SpName = "DigitalMenu_ViewDeliveries"; //Sp Name
            _IsSuccess = true;
            try
            {

                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@fromDate", string.IsNullOrEmpty(rpViewDeliveries.fromDate.Trim()) ? Convert.DBNull : rpViewDeliveries.fromDate);
                param[1] = new SqlParameter("@key", rpViewDeliveries.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpViewDeliveries.RestId));
                param[3] = new SqlParameter("@PosId", int.Parse(rpViewDeliveries.posId));
                param[4] = new SqlParameter("@toDate", string.IsNullOrEmpty(rpViewDeliveries.toDate.Trim()) ? Convert.DBNull : rpViewDeliveries.toDate);
                param[5] = new SqlParameter("@mobile", string.IsNullOrEmpty(rpViewDeliveries.mobile) ? Convert.DBNull : rpViewDeliveries.mobile);
                param[6] = new SqlParameter("@status", string.IsNullOrEmpty(rpViewDeliveries.status) ? Convert.DBNull : rpViewDeliveries.status);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewDeliveries = SerializeData.SerializeMultiValue<RPR_ViewDeliveries>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View  ReserVation| Exception : " + ex.Message);
            }
            return rprViewDeliveries;
        }


    }


    //Get Delivery Info
    public class RM_GetDeliveryInfo
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_GetDeliveryInfo> rprGetDeliveryInfo = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_GetDeliveryInfo> GetDeliveryInfo(RP_GetDeliveryInfo rpGetDeliveryInfo)
        {
            this.SpName = "DigitalMenu_GetDeliveryInfo"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@DeliveryId", rpGetDeliveryInfo.DeliveryId);
                param[1] = new SqlParameter("@key", rpGetDeliveryInfo.key);
                //param[1] = new SqlParameter("@ItemId", rpGetDeliveryInfo.ItemId);
                param[2] = new SqlParameter("@RestId", int.Parse(rpGetDeliveryInfo.RestId));
                param[3] = new SqlParameter("@PosId", int.Parse(rpGetDeliveryInfo.posId));

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprGetDeliveryInfo = SerializeData.SerializeMultiValue<RPR_GetDeliveryInfo>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Get Delivery Info| Exception : " + ex.Message);
            }
            return rprGetDeliveryInfo;
        }


    }

    public class RM_UpdateDeliveryStatus
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_UpdateDeliveryStatus> rprGetDeliveryInfo = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_UpdateDeliveryStatus> UpdateDeliveryStatus(RP_UpdateDeliveryStatus rpUpdateDeliveryStatus)
        {
            this.SpName = "DigitalMenu_updateDeliveryStatus"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@DeliveryId", rpUpdateDeliveryStatus.DeliveryId);
                param[1] = new SqlParameter("@key", rpUpdateDeliveryStatus.key);
                param[2] = new SqlParameter("@RestId", int.Parse(rpUpdateDeliveryStatus.RestId));
                param[3] = new SqlParameter("@PosId", int.Parse(rpUpdateDeliveryStatus.posId));
                param[4] = new SqlParameter("@Status", rpUpdateDeliveryStatus.Status);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprGetDeliveryInfo = SerializeData.SerializeMultiValue<RPR_UpdateDeliveryStatus>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Get Update Delivery Status | Exception : " + ex.Message);
            }
            return rprGetDeliveryInfo;
        }


    }



    // Add New Items 
    public class RM_AddNewItem
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddNewItem> rprAddNewItem = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AddNewItem> AddNewItem(RP_AddNewItem rpAddNewItem)
        {
            this.SpName = "DigitalMenu_AddNewItem"; //Sp Name
            _IsSuccess = true;
            try
            {
                // store New Item in Category Folder if it Exist
                string catName = rpAddNewItem.CategoryName.Trim();
                string iteName = rpAddNewItem.ItemName.Trim();

                string absolutePath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                // string absolutePath = @"C:\inetpub\PabulumLatest\img\items\";
                absolutePath += catName + "\\" + iteName + ".jpg";

                if (!File.Exists(absolutePath))
                {

                    byte[] bytes = Convert.FromBase64String(rpAddNewItem.Image);
                    Image image;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        image = Image.FromStream(ms);
                        image.Save(absolutePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }



                    //File.WriteAllText(absolutePath, rpAddNewItem.Image);
                }

                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@Addedon", rpAddNewItem.Addedon);
                param[1] = new SqlParameter("@CategoryName", rpAddNewItem.CategoryName);
                param[2] = new SqlParameter("@Description", rpAddNewItem.Description);
                param[3] = new SqlParameter("@Image", string.IsNullOrEmpty("") ? Convert.DBNull : rpAddNewItem.Image);
                param[4] = new SqlParameter("@ItemId", rpAddNewItem.ItemId);
                param[5] = new SqlParameter("@ItemName", rpAddNewItem.ItemName);
                param[6] = new SqlParameter("@ItemPrice", float.Parse(rpAddNewItem.ItemPrice));
                param[7] = new SqlParameter("@Nutrion", rpAddNewItem.Nutrion);
                param[8] = new SqlParameter("@posId", int.Parse(rpAddNewItem.posId));
                param[9] = new SqlParameter("@RestId", int.Parse(rpAddNewItem.RestId));
                param[10] = new SqlParameter("@key", rpAddNewItem.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddNewItem = SerializeData.SerializeMultiValue<RPR_AddNewItem>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Add New Items| Exception : " + ex.Message);
            }
            return rprAddNewItem;
        }


    }

    //Edit Items
    public class RM_EditItem
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_EditItem> rprEditItem = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_EditItem> EditItem(RP_EditItem rpEditItem)
        {
            this.SpName = "DigitalMenu_EditItem"; //Sp Name
            _IsSuccess = true;
            try
            {
                // store Edit Item in Category Folder if it Exist
                string catName = rpEditItem.CategoryName.Trim();
                string iteName = rpEditItem.ItemName.Trim();
                string oldItemName = rpEditItem.OldItemName.Trim();

                // chk name changes or value chnages 
                string absolutePath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                absolutePath += catName + "\\" + iteName + ".jpg";
                string oldItemPath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                oldItemPath += catName + "\\" + oldItemName + ".jpg";


                // chk images is not "" 
                if (rpEditItem.Image != "")
                {
                    //drop older image 
                    if (File.Exists(oldItemPath))
                    {
                        File.Delete(oldItemPath);
                    }

                    // create new Image 
                    byte[] bytes = Convert.FromBase64String(rpEditItem.Image);
                    Image image;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        image = Image.FromStream(ms);
                        image.Save(absolutePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                }
                else
                {
                    if (oldItemName != iteName)
                    {
                        System.IO.File.Move(oldItemPath, absolutePath); // chnage File Name 
                    }

                }



                //    // chk image is given or not 
                //    if (rpEditItem.Image != "")
                //    {
                //        System.IO.File.Move(catOldName, catNewName); // chnage File Name 
                //        System.IO.Directory.Move(itemOldPath, itemnewPath);  // chnage Folder Name
                //        //File.WriteAllText(absolutePath, rpEditItem.Image); // write image 
                //    }
                //}


                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@key", rpEditItem.key);
                param[1] = new SqlParameter("@CategoryName", rpEditItem.CategoryName.Trim());
                param[2] = new SqlParameter("@Description", rpEditItem.Description);
                param[3] = new SqlParameter("@Image", string.IsNullOrEmpty("") ? Convert.DBNull : rpEditItem.Image);
                param[4] = new SqlParameter("@ItemId", rpEditItem.ItemId);
                param[5] = new SqlParameter("@ItemName", rpEditItem.ItemName);
                param[6] = new SqlParameter("@ItemPrice", float.Parse(rpEditItem.ItemPrice));
                param[7] = new SqlParameter("@posId", int.Parse(rpEditItem.posId));
                param[8] = new SqlParameter("@RestId", int.Parse(rpEditItem.RestId));
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprEditItem = SerializeData.SerializeMultiValue<RPR_EditItem>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Edit Items| Exception : " + ex.Message);
            }
            return rprEditItem;
        }


    }


    //View Items
    public class RM_ViewItems
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewItems> rprViewItems = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_ViewItems> ViewItem(RP_ViewItems rpViewItems)
        {
            this.SpName = "DigitalMenu_ViewItem"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@CategoryName", rpViewItems.CategoryName.Trim());
                param[1] = new SqlParameter("@posId", int.Parse(rpViewItems.posId));
                param[2] = new SqlParameter("@RestId", int.Parse(rpViewItems.RestId));
                param[3] = new SqlParameter("@key", rpViewItems.key);

                ds = db.GetDataSet(this.SpName, param);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // used data set and data table 

                    DataTable Tables = new DataTable("category");
                    Tables.Columns.Add("ItemDesc");
                    Tables.Columns.Add("ItemImage");
                    Tables.Columns.Add("ItemName");
                    Tables.Columns.Add("ItemPrice");
                    Tables.Columns.Add("CategoryName");
                    Tables.Columns.Add("ItemId");

                    // loop through category  
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string ItemDesc = "" + dr["ItemDesc"].ToString();
                        string ItemName = "" + dr["ItemName"].ToString();
                        string ItemPrice = "" + dr["ItemPrice"].ToString();
                        string CategoryName = "" + dr["CategoryName"].ToString();
                        string ItemId = "" + dr["ItemId"].ToString();

                        if (CategoryName != "") //chk catName
                        {
                            string absolutePath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                            absolutePath += CategoryName + "\\";
                            absolutePath += ItemName + ".jpg";

                            //chk for file exist or not 
                            string ItemImage = "";
                            if (File.Exists(absolutePath))
                            {

                                ItemImage = ConfigurationManager.AppSettings["BaseImageUrl"].ToString() + "/img/items/" + CategoryName + "/" + ItemName + ".jpg";
                                // ItemImage = File.ReadAllText(absolutePath);
                            }
                            else
                            {
                                ItemImage = "";
                            }

                            Tables.Rows.Add(ItemDesc, ItemImage, ItemName, ItemPrice, CategoryName, ItemId);
                        }
                        else
                        {
                            Tables.Rows.Add(ItemDesc, "", ItemName, ItemPrice, CategoryName, ItemId);

                        }
                    }  // foreach end 

                    DataSet dsNew = new DataSet("dataset");
                    dsNew.Tables.Add(Tables);
                    rprViewItems = SerializeData.SerializeMultiValue<RPR_ViewItems>(dsNew.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View  Items| Exception : " + ex.Message);
            }
            return rprViewItems;
        }


    }


    // view nutriouns 
    public class RM_ViewNutrition
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewNutrition> rprViewNutrition = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_ViewNutrition> ViewNutrition(RP_ViewNutrition rpViewNutrition)
        {
            this.SpName = "DigitalMenu_ViewNutrition"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ItemId", rpViewNutrition.ItemId);
                param[1] = new SqlParameter("@posId", int.Parse(rpViewNutrition.posId));
                param[2] = new SqlParameter("@RestId", int.Parse(rpViewNutrition.RestId));
                param[3] = new SqlParameter("@key", rpViewNutrition.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewNutrition = SerializeData.SerializeMultiValue<RPR_ViewNutrition>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View Nutriouns| Exception : " + ex.Message);
            }
            return rprViewNutrition;
        }


    }


    // update nutriouns 
    public class RM_UpdateNutrition
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_UpdateNutrition> rprUpdateNutrition = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_UpdateNutrition> UpdateNutrition(RP_UpdateNutrition rpUpdateNutrition)
        {
            this.SpName = "DigitalMenu_UpdateNutrition"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ItemId", rpUpdateNutrition.ItemId);
                param[1] = new SqlParameter("@posId", int.Parse(rpUpdateNutrition.posId));
                param[2] = new SqlParameter("@RestId", int.Parse(rpUpdateNutrition.RestId));
                param[3] = new SqlParameter("@key", rpUpdateNutrition.key);
                param[4] = new SqlParameter("@Nutrition", rpUpdateNutrition.Nutrition);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprUpdateNutrition = SerializeData.SerializeMultiValue<RPR_UpdateNutrition>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "update  Nutriouns| Exception : " + ex.Message);
            }
            return rprUpdateNutrition;
        }


    }

    //Delete Item
    public class RM_DeleteItem
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_DeleteItem> rprDeleteItem = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_DeleteItem> DeleteItem(RP_DeleteItem rpDeleteItem)
        {
            this.SpName = "DigitalMenu_DeleteItem"; //Sp Name
            _IsSuccess = true;
            try
            {
                // Remove Category txt file and Folder inside 
                string catName = rpDeleteItem.CategoryName.Trim();
                string itemName = rpDeleteItem.ItemName.Trim();
                string catFolder = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                //  string catFolder = @"C:\inetpub\PabulumLatest\img\items\";
                catFolder += catName + "\\" + itemName + ".txt";


                if (File.Exists(catFolder))
                {
                    File.Delete(catFolder);
                }
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@CategoryName", rpDeleteItem.CategoryName.Trim());
                param[1] = new SqlParameter("@ItemName", rpDeleteItem.ItemName);
                param[2] = new SqlParameter("@posId", int.Parse(rpDeleteItem.posId));
                param[3] = new SqlParameter("@RestId", int.Parse(rpDeleteItem.RestId));
                param[4] = new SqlParameter("@key", rpDeleteItem.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprDeleteItem = SerializeData.SerializeMultiValue<RPR_DeleteItem>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Delete  Items| Exception : " + ex.Message);
            }
            return rprDeleteItem;
        }


    }


    //Assign Table
    public class RM_AssignTable
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AssignTable> rprAssignTable = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AssignTable> AssignTable(RP_AssignTable rpAssignTable)
        {
            this.SpName = "DigitalMenu_AssignTable"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@DeviceMac", rpAssignTable.DeviceMac);
                param[1] = new SqlParameter("@TableNo", rpAssignTable.TableNo);
                param[2] = new SqlParameter("@posId", int.Parse(rpAssignTable.posId));
                param[3] = new SqlParameter("@RestId", int.Parse(rpAssignTable.RestId));
                param[4] = new SqlParameter("@key", rpAssignTable.key);
                param[5] = new SqlParameter("@WaitorId", rpAssignTable.WaitorId);
                param[6] = new SqlParameter("@CusName", string.IsNullOrEmpty(rpAssignTable.CusName) ? Convert.DBNull : rpAssignTable.CusName);
                param[7] = new SqlParameter("@CusMobile", string.IsNullOrEmpty(rpAssignTable.CusMobile) ? Convert.DBNull : rpAssignTable.CusMobile);
                param[8] = new SqlParameter("@TableAction", rpAssignTable.TableAction);
                param[9] = new SqlParameter("@RandomNumber", GenerateRandomNum());
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAssignTable = SerializeData.SerializeMultiValue<RPR_AssignTable>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Assign Table | Exception : " + ex.Message);
            }
            return rprAssignTable;
        }

        //Generate random number
        private string GenerateRandomNum()
        {
            string t = "123456789";
            char[] chars = t.ToCharArray();
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                char c = chars[random.Next(chars.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
        // random -genrator-end 
    }



    // View table Status
    public class RM_ViewtableStatus
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewtableStatus> rprViewtableStatus = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_ViewtableStatus> AssignTable(Rp_ViewtableStatus rpViewtableStatus)
        {
            this.SpName = "DigitalMenu_ViewtableStatus"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@posId", int.Parse(rpViewtableStatus.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpViewtableStatus.RestId));
                param[2] = new SqlParameter("@key", rpViewtableStatus.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewtableStatus = SerializeData.SerializeMultiValue<RPR_ViewtableStatus>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View Table Status | Exception : " + ex.Message);
            }
            return rprViewtableStatus;
        }


    }

    //ADD Happy Hours 
    public class RM_AddHappyHours
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddHappyHours> rprAddHappyHours = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AddHappyHours> AddHappyHours(Rp_AddHappyHours rpAddHappyHours)
        {
            this.SpName = "DigitalMenu_HappyHours"; //Sp Name
            _IsSuccess = true;
            try
            {

                ///==== HAPPY HOUR IMAGE SECTION START -======///

                // PATH FOR HAPPY HOUR IMAGE 
                string category_Name = rpAddHappyHours.Name.Trim();
                string old_name = rpAddHappyHours.OldName.Trim();

                string absolute_Path = @"" + ConfigurationManager.AppSettings["BaseImagePath"].ToString(); 
                absolute_Path += category_Name + ".jpg";
                string old_path = @"" + ConfigurationManager.AppSettings["BaseImagePath"].ToString(); 
                old_path += old_name + ".jpg";


                //  CHK  IMAGE EXIST OR NOT 
                if (File.Exists(absolute_Path))
                {
                    // CHK IMAGE UPDATED OR NOT 
                    if (rpAddHappyHours.Image != "")
                    {

                        // remove old image 
                        if (File.Exists(old_path))
                        {
                            File.Delete(old_path);
                        }


                        byte[] bytes = Convert.FromBase64String(rpAddHappyHours.Image);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                            image.Save(absolute_Path, System.Drawing.Imaging.ImageFormat.Jpeg);

                        }
                        // Update IaMge 
                        // File.WriteAllText(absolute_Path, rpAddHappyHours.Image);
                    }
                }
                else
                {

                    // CREATE A NEW ONE  AND REMOVE OLDER ONE IF IT EXIST
                    // if (rpAddHappyHours.Image != "")
                    //{
                    File.WriteAllText(absolute_Path, rpAddHappyHours.Image);
                    //}
                    // OLD IMAGE DELETE IF EXIST 

                    string OldcategoryName = rpAddHappyHours.OldName.Trim();
                    string OldabsolutePath = @"" + ConfigurationManager.AppSettings["BaseImagePath"].ToString(); 
                    OldabsolutePath += OldcategoryName + ".jpg";
                    if (File.Exists(OldabsolutePath))
                    {

                        byte[] bytes = Convert.FromBase64String(rpAddHappyHours.Image);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                            image.Save(absolute_Path, System.Drawing.Imaging.ImageFormat.Jpeg);

                        }

                        // Remove IT OLD FILE 
                        // File.Delete(OldabsolutePath);

                    }

                }

                ///==== HAPPY HOUR IMAGE SECTION END -======///

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@posId", string.IsNullOrEmpty(rpAddHappyHours.posId) ? Convert.DBNull : int.Parse(rpAddHappyHours.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpAddHappyHours.RestId));
                param[2] = new SqlParameter("@key", rpAddHappyHours.key);
                param[3] = new SqlParameter("@From", rpAddHappyHours.From);
                param[4] = new SqlParameter("@To", rpAddHappyHours.To);
                param[5] = new SqlParameter("@Name", rpAddHappyHours.Name);
                param[6] = new SqlParameter("@Description", rpAddHappyHours.Description);
                param[7] = new SqlParameter("@Image", "");
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddHappyHours = SerializeData.SerializeMultiValue<RPR_AddHappyHours>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Add Happy Hours | Exception : " + ex.Message);
            }
            return rprAddHappyHours;
        }


    }


    //Get happy Hours 
    public class RM_GetHappyHours
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_GetHappyHours> rprGetHappyHours = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_GetHappyHours> GetHappyHours(RP_GetHappyHours rpGetHappyHours)
        {
            this.SpName = "DigitalMenu_GetHappyHours"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@posId", string.IsNullOrEmpty(rpGetHappyHours.posId) ? Convert.DBNull : int.Parse(rpGetHappyHours.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpGetHappyHours.RestId));
                param[2] = new SqlParameter("@key", rpGetHappyHours.key);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprGetHappyHours = SerializeData.SerializeMultiValue<RPR_GetHappyHours>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "get Happy Hours | Exception : " + ex.Message);
            }
            return rprGetHappyHours;
        }


    }


    // add per Item Discount in Happy Hour 
    public class RM_AddPerItemDiscount
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddPerItemDiscount> rprAddPerItemDiscount = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AddPerItemDiscount> AddPerItemDiscount(RP_AddPerItemDiscount rpAddPerItemDiscount)
        {
            this.SpName = "DigitalMenu_AddPerItemDiscount"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@posId", string.IsNullOrEmpty(rpAddPerItemDiscount.posId) ? Convert.DBNull : int.Parse(rpAddPerItemDiscount.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpAddPerItemDiscount.RestId));
                param[2] = new SqlParameter("@key", rpAddPerItemDiscount.key);
                param[3] = new SqlParameter("@CategoryName", rpAddPerItemDiscount.CategoryName);
                param[4] = new SqlParameter("@ItemName", rpAddPerItemDiscount.ItemName);
                param[5] = new SqlParameter("@Amount", rpAddPerItemDiscount.Amount);
                param[6] = new SqlParameter("@Discount", rpAddPerItemDiscount.Discount);
                param[7] = new SqlParameter("@Addedon", string.IsNullOrEmpty(rpAddPerItemDiscount.Addedon) ? Convert.DBNull : Convert.ToDateTime(rpAddPerItemDiscount.Addedon).Date);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddPerItemDiscount = SerializeData.SerializeMultiValue<RPR_AddPerItemDiscount>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Add Per Item Discount | Exception : " + ex.Message);
            }
            return rprAddPerItemDiscount;
        }


    }


    // delete per item Discount  
    public class RM_DeletePerItemDiscount
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_DeletePerItemDiscount> rprDeletePerItemDiscount = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_DeletePerItemDiscount> DeletePerItemDiscount(RP_DeletePerItemDiscount rpDeletePerItemDiscount)
        {
            this.SpName = "DigitalMenu_DeletePerItemDiscount"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@posId", string.IsNullOrEmpty(rpDeletePerItemDiscount.posId) ? Convert.DBNull : int.Parse(rpDeletePerItemDiscount.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpDeletePerItemDiscount.RestId));
                param[2] = new SqlParameter("@key", rpDeletePerItemDiscount.key);
                param[3] = new SqlParameter("@ItemName", rpDeletePerItemDiscount.ItemName);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprDeletePerItemDiscount = SerializeData.SerializeMultiValue<RPR_DeletePerItemDiscount>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "delete Per Item Discount | Exception : " + ex.Message);
            }
            return rprDeletePerItemDiscount;
        }


    }


    // add Combo Discount in Happy Hour 
    public class RM_ComboDiscount
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ComboDiscount> rprComboDiscount = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_ComboDiscount> ComboDiscount(RP_ComboDiscount rpComboDiscount)
        {
            this.SpName = "DigitalMenu_ComboDiscount"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@posId", string.IsNullOrEmpty(rpComboDiscount.posId) ? Convert.DBNull : int.Parse(rpComboDiscount.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpComboDiscount.RestId));
                param[2] = new SqlParameter("@key", rpComboDiscount.key);
                param[3] = new SqlParameter("@ComboName", rpComboDiscount.ComboName);
                param[4] = new SqlParameter("@ItemName", rpComboDiscount.ItemName);
                param[5] = new SqlParameter("@Amount", rpComboDiscount.Amount);
                param[6] = new SqlParameter("@Discount", rpComboDiscount.Discount);
                param[7] = new SqlParameter("@Addedon", string.IsNullOrEmpty(rpComboDiscount.Addedon) ? Convert.DBNull : Convert.ToDateTime(rpComboDiscount.Addedon).Date);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprComboDiscount = SerializeData.SerializeMultiValue<RPR_ComboDiscount>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Combo Discount | Exception : " + ex.Message);
            }
            return rprComboDiscount;
        }


    }

    //delete combo discount  
    public class RM_DeleteComboDiscount
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_DeleteComboDiscount> rprDeleteComboDiscount = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_DeleteComboDiscount> DeleteComboDiscount(RP_DeleteComboDiscount rpDeleteComboDiscount)
        {
            this.SpName = "DigitalMenu_DeleteComboDiscount"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@posId", string.IsNullOrEmpty(rpDeleteComboDiscount.posId) ? Convert.DBNull : int.Parse(rpDeleteComboDiscount.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpDeleteComboDiscount.RestId));
                param[2] = new SqlParameter("@key", rpDeleteComboDiscount.key);
                param[3] = new SqlParameter("@ItemName", rpDeleteComboDiscount.ItemName);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprDeleteComboDiscount = SerializeData.SerializeMultiValue<RPR_DeleteComboDiscount>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "delete combo  Discount | Exception : " + ex.Message);
            }
            return rprDeleteComboDiscount;
        }


    }





    // get per Item Discount from Happy Hour 


    public class RM_GetPerItemDiscount
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_GetPerItemDiscount> rprGetPerItemDiscount = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_GetPerItemDiscount> GetPerItemDiscount(RP_GetPerItemDiscount rpGetPerItemDiscount)
        {
            this.SpName = "DigitalMenu_GetPerItemDiscount"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@posId", string.IsNullOrEmpty(rpGetPerItemDiscount.posId) ? Convert.DBNull : int.Parse(rpGetPerItemDiscount.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpGetPerItemDiscount.RestId));
                param[2] = new SqlParameter("@key", rpGetPerItemDiscount.key);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprGetPerItemDiscount = SerializeData.SerializeMultiValue<RPR_GetPerItemDiscount>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Get Per Item Discount | Exception : " + ex.Message);
            }
            return rprGetPerItemDiscount;
        }


    }

    //get combo item discount form happy hour 
    public class RM_GetComboDiscount
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_GetComboDiscount> rprGetComboDiscount = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_GetComboDiscount> GetComboDiscount(RP_GetComboDiscount rpGetComboDiscount)
        {
            this.SpName = "DigitalMenu_GetComboDiscount"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@posId", string.IsNullOrEmpty(rpGetComboDiscount.posId) ? Convert.DBNull : int.Parse(rpGetComboDiscount.posId));
                param[1] = new SqlParameter("@RestId", int.Parse(rpGetComboDiscount.RestId));
                param[2] = new SqlParameter("@key", rpGetComboDiscount.key);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprGetComboDiscount = SerializeData.SerializeMultiValue<RPR_GetComboDiscount>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Get Combo Discount | Exception : " + ex.Message);
            }
            return rprGetComboDiscount;
        }


    }

    // Add Waitor 
    public class RM_AddWaitor
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddWaitor> rprAddWaitor = null;
        DataBase db = new DataBase();
        DataSet ds = null;

        public List<RPR_AddWaitor> AddWaitor(RP_AddWaitor rpAddWaitor)
        {
            this.SpName = "DigitalMenu_AddWaitor"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@RestId", int.Parse(rpAddWaitor.RestId));
                param[1] = new SqlParameter("@JoinDate", string.IsNullOrEmpty(rpAddWaitor.JoinDate) ? Convert.DBNull : Convert.ToDateTime(rpAddWaitor.JoinDate).Date);
                param[2] = new SqlParameter("@key", rpAddWaitor.key);
                param[3] = new SqlParameter("@Mobile", rpAddWaitor.Mobile);
                param[4] = new SqlParameter("@Name", rpAddWaitor.Name);
                param[5] = new SqlParameter("@posId", int.Parse(rpAddWaitor.posId));
                param[6] = new SqlParameter("@WalitorId", rpAddWaitor.WalitorId);
                param[7] = new SqlParameter("@Password", rpAddWaitor.Password);
                param[8] = new SqlParameter("@Email", rpAddWaitor.Email);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddWaitor = SerializeData.SerializeMultiValue<RPR_AddWaitor>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Add Waitor| Exception : " + ex.Message);
            }
            return rprAddWaitor;
        }


    }


    // View Waitor 
    public class RM_ViewWaitor
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewWaitor> rprViewWaitor = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewWaitor> ViewWaitor(RP_ViewWaitor rpViewWaitor)
        {
            this.SpName = "DigitalMenu_ViewWaitor"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewWaitor.RestId));
                param[1] = new SqlParameter("@key", rpViewWaitor.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpViewWaitor.posId));
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewWaitor = SerializeData.SerializeMultiValue<RPR_ViewWaitor>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View Waitors| Exception : " + ex.Message);
            }
            return rprViewWaitor;
        }
    }


    // Add Category
    public class RM_AddCategory
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddCategory> rprAddCategory = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_AddCategory> AddCategory(RP_AddCategory rpAddCategory)
        {
            this.SpName = "DigitalMenu_Addcategory"; //Sp Name
            _IsSuccess = true;
            try
            {

                string categoryName = rpAddCategory.CategoryName.Trim();
                string absolutePath = @"" + ConfigurationManager.AppSettings["BaseImagePath"].ToString(); 
                absolutePath += categoryName + ".jpg";

                // create  category image file  and category folder
                if (!File.Exists(absolutePath))
                {
                    byte[] bytes = Convert.FromBase64String(rpAddCategory.CategoryImage);
                    Image image;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        image = Image.FromStream(ms);
                        image.Save(absolutePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                        //   create folder inside menu Item  for category
                        string absolutePathItem = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                        absolutePathItem += categoryName;
                        System.IO.Directory.CreateDirectory(absolutePathItem);
                    }
                }


                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@RestId", int.Parse(rpAddCategory.RestId));
                param[1] = new SqlParameter("@key", rpAddCategory.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpAddCategory.PosId));
                param[3] = new SqlParameter("@CategoryId", rpAddCategory.CategoryId.Trim());
                param[4] = new SqlParameter("@CategoryName", rpAddCategory.CategoryName.Trim());
                param[5] = new SqlParameter("@CategoryDesc", rpAddCategory.CategoryDesc);
                param[6] = new SqlParameter("@CategoryImage", "");
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddCategory = SerializeData.SerializeMultiValue<RPR_AddCategory>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View category | Exception : " + ex.Message);
            }
            return rprAddCategory;
        }
    }


    // delete Category 
    public class RM_DeleteCategory
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_DeleteCategory> rprDeleteCategory = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_DeleteCategory> DeleteCategory(RP_DeleteCategory rpDeleteCategory)
        {
            this.SpName = "DigitalMenu_Deletecategory"; //Sp Name
            _IsSuccess = true;
            try
            {

                // Remove Category image file and Folder inside 
                string catName = rpDeleteCategory.CategoryName.Trim();
                string catPath = @"" + ConfigurationManager.AppSettings["BaseImagePath"].ToString(); 
                catPath += catName + ".jpg";
                if (File.Exists(catPath))
                {
                    File.Delete(catPath);
                    string catFolder = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                    catFolder += catName;
                    // Change directory name 
                    if (Directory.Exists(catFolder))
                    {
                        new System.IO.DirectoryInfo(catFolder).Delete(true); // delete folder 
                    } 

                    
                }

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpDeleteCategory.RestId));
                param[1] = new SqlParameter("@key", rpDeleteCategory.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpDeleteCategory.PosId));
                param[3] = new SqlParameter("@CategoryName", rpDeleteCategory.CategoryName);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprDeleteCategory = SerializeData.SerializeMultiValue<RPR_DeleteCategory>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Delete Category| Exception : " + ex.Message);
            }
            return rprDeleteCategory;
        }
    }


    // update category 
    public class RM_UpdateCategory
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_UpdateCategory> rprUpdateCategory = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_UpdateCategory> UpdateCategory(RP_UpdateCategory rpUpdateCategory)
        {
            this.SpName = "DigitalMenu_Updatecategory"; //Sp Name
            _IsSuccess = true;
            try
            {

                // old  and New Category Name  
                string oldCatName = rpUpdateCategory.oldCategoryName.Trim();
                string newcatName = rpUpdateCategory.newCategoryName.Trim();

                // old and new category Path 
                string catPath = @"" + ConfigurationManager.AppSettings["BaseImagePath"].ToString(); 
                string oldCatPath = catPath + oldCatName + ".jpg";
                string newCatPath = catPath +newcatName + ".jpg";

                // item path
                string itemPath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\items\\";
                string oldItemPath = itemPath + oldCatName;
                string newItemPath = itemPath + newcatName;



                // Category Name Changes 
                if (oldCatName != newcatName)
                {
                    // Image Changes 
                    if (rpUpdateCategory.CategoryImage != "")
                    {
                        // found old image and Delete it 
                        if (File.Exists(oldCatPath))
                        {
                            File.Delete(oldCatPath);  // Delete Old Image
                        }
                        //create new Image 
                        byte[] bytes = Convert.FromBase64String(rpUpdateCategory.CategoryImage);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                            image.Save(newCatPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                        }
                        // Change directory name 
                        if (File.Exists(oldItemPath))
                        {
                            System.IO.Directory.Move(oldItemPath, newItemPath);  // chnage Folder Name
                        }
                        else
                        { // category Name Directory inside items not found create new One 
                            System.IO.Directory.CreateDirectory(newItemPath);
                        }

                    } // rename file only 
                    else
                    {

                        if (File.Exists(oldCatPath))
                        {
                            // chnage File Name
                            System.IO.File.Move(oldCatPath, newCatPath); // chnage File Name 
                        }
                        // Change directory name 
                        if (Directory.Exists(oldItemPath))
                        {
                            System.IO.Directory.Move(oldItemPath, newItemPath);  // chnage Folder Name
                        } 


                    }

                }
                // IMages Changes Only 
                else
                {
                    // Find Image File 
                    if (rpUpdateCategory.CategoryImage != "")
                    {
                        // found old image and Delete it 
                        if (File.Exists(oldCatPath))
                        {
                            File.Delete(oldCatPath);  // Delete Old Image
                        }
                        if (!File.Exists(newCatPath))
                        {
                            //create new Image 
                            byte[] bytes = Convert.FromBase64String(rpUpdateCategory.CategoryImage);
                            Image image;
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                image = Image.FromStream(ms);
                                image.Save(newCatPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                            }
                        }

                    }
                }


                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@RestId", int.Parse(rpUpdateCategory.RestId));
                param[1] = new SqlParameter("@key", rpUpdateCategory.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpUpdateCategory.PosId));
                param[3] = new SqlParameter("@oldCategoryName", rpUpdateCategory.oldCategoryName);
                param[4] = new SqlParameter("@CategoryDesc", rpUpdateCategory.CategoryDesc);
                param[5] = new SqlParameter("@CategoryImage", string.IsNullOrEmpty("") ? Convert.DBNull : rpUpdateCategory.CategoryImage);
                param[6] = new SqlParameter("@newCategoryName", rpUpdateCategory.newCategoryName.Trim());
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprUpdateCategory = SerializeData.SerializeMultiValue<RPR_UpdateCategory>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "update category | Exception : " + ex.Message);
            }
            return rprUpdateCategory;
        }


    }





    // View Categories
    public class RM_ViewCategories
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewCategories> rprViewCategories = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewCategories> ViewCategories(RP_ViewCategories rpViewCategories)
        {
            this.SpName = "DigitalMenu_Viewcategory"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewCategories.RestId));
                param[1] = new SqlParameter("@key", rpViewCategories.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpViewCategories.PosId));
                //  param[3] = new SqlParameter("@isHappyHourTime", rpViewCategories.isHappyHourTime);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewCategories = SerializeData.SerializeMultiValue<RPR_ViewCategories>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View Categories| Exception : " + ex.Message);
            }
            return rprViewCategories;
        }
    }

    // View total Sale 
    public class RM_ViewTotalSale
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewTotalSale> rprViewTotalSale = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewTotalSale> ViewTotalSale(RP_ViewTotalSale rpViewTotalSale)
        {
            this.SpName = "DigitalMenu_ViewtotalSale"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewTotalSale.RestId));
                param[1] = new SqlParameter("@key", rpViewTotalSale.key);
                param[2] = new SqlParameter("@posId", string.IsNullOrEmpty(rpViewTotalSale.PosId) ? Convert.DBNull : int.Parse(rpViewTotalSale.PosId));
                param[3] = new SqlParameter("@FromDate", string.IsNullOrEmpty(rpViewTotalSale.FromDate) ? Convert.DBNull : Convert.ToDateTime(rpViewTotalSale.FromDate).Date);
                param[4] = new SqlParameter("@ToDate", string.IsNullOrEmpty(rpViewTotalSale.ToDate) ? Convert.DBNull : Convert.ToDateTime(rpViewTotalSale.ToDate).Date);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewTotalSale = SerializeData.SerializeMultiValue<RPR_ViewTotalSale>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View total Sale| Exception : " + ex.Message);
            }
            return rprViewTotalSale;
        }
    }

    //View All Customer Sales 
    public class RM_ViewAllCusSale
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewAllCusSale> rprViewAllCusSale = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewAllCusSale> ViewAllCusSale(RP_ViewAllCusSale rpViewAllCusSale)
        {
            this.SpName = "DigitalMenu_ViewAllCusSale"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewAllCusSale.RestId));
                param[1] = new SqlParameter("@key", rpViewAllCusSale.key);
                param[2] = new SqlParameter("@posId", string.IsNullOrEmpty(rpViewAllCusSale.PosId) ? Convert.DBNull : int.Parse(rpViewAllCusSale.PosId));
                param[3] = new SqlParameter("@CusMobile", string.IsNullOrEmpty(rpViewAllCusSale.CusMobile) ? Convert.DBNull : rpViewAllCusSale.CusMobile);
                param[4] = new SqlParameter("@CusName", string.IsNullOrEmpty(rpViewAllCusSale.CusName) ? Convert.DBNull : rpViewAllCusSale.CusName);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewAllCusSale = SerializeData.SerializeMultiValue<RPR_ViewAllCusSale>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View total Sale| Exception : " + ex.Message);
            }
            return rprViewAllCusSale;
        }
    }




    // view Customer Details  
    public class RM_ViewCusDetails
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewCusDetails> rprViewCusDetails = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewCusDetails> ViewCusDetails(RP_ViewCusDetails rpViewCusDetails)
        {
            this.SpName = "DigitalMenu_ViewCusDetails"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewCusDetails.RestId));
                param[1] = new SqlParameter("@key", rpViewCusDetails.key);
                param[2] = new SqlParameter("@posId", string.IsNullOrEmpty(rpViewCusDetails.PosId) ? Convert.DBNull : int.Parse(rpViewCusDetails.PosId));
                param[3] = new SqlParameter("@CusMobile", string.IsNullOrEmpty(rpViewCusDetails.CusMobile) ? Convert.DBNull : rpViewCusDetails.CusMobile);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewCusDetails = SerializeData.SerializeMultiValue<RPR_ViewCusDetails>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View customer details| Exception : " + ex.Message);
            }
            return rprViewCusDetails;
        }
    }



    //Add to Delivery Cart
    public class RM_AddToDevCart
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddToDevCart> rprAddToDevCart = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_AddToDevCart> AddToDevCart(RP_AddToDevCart rpAddToDevCart)
        {
            this.SpName = "DigitalMenu_AddToDevCart"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@RestId", int.Parse(rpAddToDevCart.RestId));
                param[1] = new SqlParameter("@key", rpAddToDevCart.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpAddToDevCart.PosId));
                param[3] = new SqlParameter("@CategoryName", rpAddToDevCart.CategoryName);
                param[4] = new SqlParameter("@ItemName", rpAddToDevCart.ItemName);
                param[5] = new SqlParameter("@ItemQunatity", int.Parse(rpAddToDevCart.ItemQunatity));
                param[6] = new SqlParameter("@CusAddress", string.IsNullOrEmpty(rpAddToDevCart.CusAddress) ? Convert.DBNull : rpAddToDevCart.CusAddress);
                param[7] = new SqlParameter("@CusMobile", string.IsNullOrEmpty(rpAddToDevCart.CusMobile) ? Convert.DBNull : rpAddToDevCart.CusMobile);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddToDevCart = SerializeData.SerializeMultiValue<RPR_AddToDevCart>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Add to Delivery Cart| Exception : " + ex.Message);
            }
            return rprAddToDevCart;
        }
    }


    //Get List Items 
    public class RM_GetListItems
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_GetListItems> rprGetListItems = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_GetListItems> GetListItems(RP_GetListItems rpGetListItems)
        {
            this.SpName = "DigitalMenu_GetListItems"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpGetListItems.RestId));
                param[1] = new SqlParameter("@key", rpGetListItems.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpGetListItems.PosId));
                param[3] = new SqlParameter("@CategoryName", rpGetListItems.CategoryName);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprGetListItems = SerializeData.SerializeMultiValue<RPR_GetListItems>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Get List Items| Exception : " + ex.Message);
            }
            return rprGetListItems;
        }
    }


    //Update Delivery Cart 
    public class RM_UpdateDeliveryCart
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_UpdateDeliveryCart> rprUpdateDeliveryCart = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_UpdateDeliveryCart> UpdateDeliveryCart(RP_UpdateDeliveryCart rpUpdateDeliveryCart)
        {
            this.SpName = "DigitalMenu_UpdateDeliveryCart"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@RestId", int.Parse(rpUpdateDeliveryCart.RestId));
                param[1] = new SqlParameter("@key", rpUpdateDeliveryCart.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpUpdateDeliveryCart.PosId));
                param[3] = new SqlParameter("@CategoryName", rpUpdateDeliveryCart.CategoryName);
                param[4] = new SqlParameter("@ItemName", rpUpdateDeliveryCart.ItemName);
                param[5] = new SqlParameter("@ItemQunatity", int.Parse(rpUpdateDeliveryCart.ItemQunatity));
                param[6] = new SqlParameter("@CusAddress", rpUpdateDeliveryCart.CusAddress);
                param[7] = new SqlParameter("@CusMobile", rpUpdateDeliveryCart.CusMobile);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprUpdateDeliveryCart = SerializeData.SerializeMultiValue<RPR_UpdateDeliveryCart>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Add to Delivery Cart| Exception : " + ex.Message);
            }
            return rprUpdateDeliveryCart;
        }
    }

    //Delete Delivery Cart Items 
    public class RM_DeleteDeliveryCartItems
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_DeleteDeliveryCartItems> rprDeleteDeliveryCartItems = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_DeleteDeliveryCartItems> DeleteDeliveryCartItems(RP_DeleteDeliveryCartItems rpDeleteDeliveryCartItems)
        {
            this.SpName = "DigitalMenu_DeleteDeliveryCartItems"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@RestId", int.Parse(rpDeleteDeliveryCartItems.RestId));
                param[1] = new SqlParameter("@key", rpDeleteDeliveryCartItems.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpDeleteDeliveryCartItems.PosId));
                param[3] = new SqlParameter("@CategoryName", rpDeleteDeliveryCartItems.CategoryName);
                param[4] = new SqlParameter("@ItemName", rpDeleteDeliveryCartItems.ItemName);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprDeleteDeliveryCartItems = SerializeData.SerializeMultiValue<RPR_DeleteDeliveryCartItems>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Delete  Delivery Cart Items| Exception : " + ex.Message);
            }
            return rprDeleteDeliveryCartItems;
        }
    }


    //Clear Cart 
    public class RM_ClearCart
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ClearCart> rprClearCart = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ClearCart> ClearCart(RP_ClearCart rpClearCart)
        {
            this.SpName = "DigitalMenu_ClearCart"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpClearCart.RestId));
                param[1] = new SqlParameter("@key", rpClearCart.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpClearCart.PosId));
                //param[3] = new SqlParameter("@CategoryName", rpClearCart.CategoryName);
                //param[4] = new SqlParameter("@ItemName", rpClearCart.ItemName);
                param[3] = new SqlParameter("@CusMobile", rpClearCart.CusMobile);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprClearCart = SerializeData.SerializeMultiValue<RPR_ClearCart>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "clear Delivery Cart Items| Exception : " + ex.Message);
            }
            return rprClearCart;
        }
    }

    //Show Avail Tables 
    public class RM_ShowAvailTables
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ShowAvailTables> rprShowAvailTables = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ShowAvailTables> ShowAvailTables(RP_ShowAvailTables rpShowAvailTables)
        {
            this.SpName = "DigitalMenu_ShowAvailTables"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RestId", int.Parse(rpShowAvailTables.RestId));
                param[1] = new SqlParameter("@key", rpShowAvailTables.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpShowAvailTables.PosId));
                param[3] = new SqlParameter("@StartTime", string.IsNullOrEmpty(rpShowAvailTables.StartTime) ? Convert.DBNull : Convert.ToDateTime(rpShowAvailTables.StartTime).TimeOfDay);
                param[4] = new SqlParameter("@EndTime", string.IsNullOrEmpty(rpShowAvailTables.EndTime) ? Convert.DBNull : Convert.ToDateTime(rpShowAvailTables.EndTime).TimeOfDay);
                param[5] = new SqlParameter("@Date", string.IsNullOrEmpty(rpShowAvailTables.Date) ? Convert.DBNull : Convert.ToDateTime(rpShowAvailTables.Date).Date);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprShowAvailTables = SerializeData.SerializeMultiValue<RPR_ShowAvailTables>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "clear Delivery Cart Items| Exception : " + ex.Message);
            }
            return rprShowAvailTables;
        }
    }


    //WaitorList 
    public class RM_WaitorList
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_WaitorList> rprWaitorList = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_WaitorList> WaitorList(RP_WaitorList rpWaitorList)
        {
            this.SpName = "DigitalMenu_WaitorList"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpWaitorList.RestId));
                param[1] = new SqlParameter("@key", rpWaitorList.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpWaitorList.PosId));
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprWaitorList = SerializeData.SerializeMultiValue<RPR_WaitorList>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "Waitor List| Exception : " + ex.Message);
            }
            return rprWaitorList;
        }
    }



    //view Delivery Cart 
    public class RM_ViewDeliverCart
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewDeliverCart> rprViewDeliverCart = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewDeliverCart> ViewDeliverCart(RP_ViewDeliverCart rpViewDeliverCart)
        {
            this.SpName = "DigitalMenu_ViewDeliveryCart"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewDeliverCart.RestId));
                param[1] = new SqlParameter("@key", rpViewDeliverCart.key);
                param[2] = new SqlParameter("@posId", int.Parse(rpViewDeliverCart.PosId));
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewDeliverCart = SerializeData.SerializeMultiValue<RPR_ViewDeliverCart>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "View Delivery List| Exception : " + ex.Message);
            }
            return rprViewDeliverCart;
        }
    }

    // thought of the Day 
    public class RM_ThoughtOfTheDay
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ThoughtOfTheDay> rprThoughtOfTheDay = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ThoughtOfTheDay> ThoughtOfTheDay(RP_ThoughtOfTheDay rpThoughtOfTheDay)
        {
            this.SpName = "DigitalMenu_ThoughtOfTheDay"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpThoughtOfTheDay.RestId));
                param[1] = new SqlParameter("@key", rpThoughtOfTheDay.key);
                param[2] = new SqlParameter("@Message", rpThoughtOfTheDay.Message);


                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprThoughtOfTheDay = SerializeData.SerializeMultiValue<RPR_ThoughtOfTheDay>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "thought of the day | Exception : " + ex.Message);
            }
            return rprThoughtOfTheDay;
        }
    }

    // View  thought of the Day 
    public class RM_ViewThoughtOfTheDay
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewThoughtOfTheDay> rprViewThoughtOfTheDay = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewThoughtOfTheDay> ViewThoughtOfTheDay(RP_ViewThoughtOfTheDay rpViewThoughtOfTheDay)
        {
            this.SpName = "DigitalMenu_ViewThoughtOfTheDay"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewThoughtOfTheDay.RestId));
                param[1] = new SqlParameter("@key", rpViewThoughtOfTheDay.key);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewThoughtOfTheDay = SerializeData.SerializeMultiValue<RPR_ViewThoughtOfTheDay>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "add thought of the Day| Exception : " + ex.Message);
            }
            return rprViewThoughtOfTheDay;
        }
    }


    // add Restaurants
    public class RM_Restaurants
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_Restaurants> rprRestaurants = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_Restaurants> AddRestaurant(RP_Restaurants rpRestaurants)
        {
            this.SpName = "DigitalMenu_Restaurants"; //Sp Name
            _IsSuccess = true;
            try
            {

                string OldRestName = rpRestaurants.oldRestName.Trim();
                string OldRestPath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\RestImage\\";
                OldRestPath += OldRestName + ".jpg";

                string RestName = rpRestaurants.RestName.Trim();
                string RestImagePath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString() +"img\\RestImage\\";
                RestImagePath += RestName + ".jpg";

                if (File.Exists(OldRestPath))
                {
                    //change Image 
                    if (rpRestaurants.RestImage != "")
                    {
                        if (File.Exists(OldRestPath))
                        {
                            // Remove  OLD image
                            File.Delete(OldRestPath);

                        }
                        byte[] bytes = Convert.FromBase64String(rpRestaurants.RestImage);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                            image.Save(RestImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }


                    }

                    else // rename the file only 
                    {
                        if (File.Exists(OldRestPath))
                        {
                            if (OldRestName != RestName)
                            {
                                System.IO.File.Move(OldRestPath, RestImagePath); // chnage File Name 
                            }


                        }

                    }


                }


                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RestId", int.Parse(rpRestaurants.RestId));
                param[1] = new SqlParameter("@key", rpRestaurants.key);
                param[2] = new SqlParameter("@PosId", string.IsNullOrEmpty(rpRestaurants.PosId) ? Convert.DBNull : int.Parse(rpRestaurants.PosId));
                param[3] = new SqlParameter("@RestImage", "");//string.IsNullOrEmpty(rpRestaurants.RestImage) ? Convert.DBNull : rpRestaurants.RestImage);
                param[4] = new SqlParameter("@RestName", string.IsNullOrEmpty(rpRestaurants.RestName) ? Convert.DBNull : rpRestaurants.RestName.Trim());
                param[5] = new SqlParameter("@RestAddress", string.IsNullOrEmpty(rpRestaurants.RestAddress) ? Convert.DBNull : rpRestaurants.RestAddress);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprRestaurants = SerializeData.SerializeMultiValue<RPR_Restaurants>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Add  Restaurants| Exception : " + ex.Message);
            }
            return rprRestaurants;
        }
    }

    // View ViewRestaurants
    public class RM_ViewRestaurants
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewRestaurants> rprViewRestaurants = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewRestaurants> ViewRestaurant(RP_ViewRestaurants rpViewRestaurants)
        {
            this.SpName = "DigitalMenu_ViewRestaurants"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewRestaurants.RestId));
                param[1] = new SqlParameter("@key", rpViewRestaurants.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    // used data set and data table 

                    DataTable Tables = new DataTable("RestDetails");
                    Tables.Columns.Add("RestName");
                    Tables.Columns.Add("RestImage");
                    // loop through category  
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string RestName = "" + dr["RestName"].ToString();

                        if (RestName != "") //chk catName
                        {
                            string absolutePath = @" "+ConfigurationManager.AppSettings["BaseImagePath"].ToString()  + "img\\RestImage\\";
                            absolutePath += RestName + ".jpg";
                            string RestImage = "";
                            if (File.Exists(absolutePath))
                            {
                                //RestImage = File.ReadAllText(absolutePath);
                                RestImage = ConfigurationManager.AppSettings["BaseImageUrl"].ToString() + "/img/RestImage/" + RestName + ".jpg";
                            }
                            Tables.Rows.Add(RestName, RestImage);
                        }
                        else
                        {
                            Tables.Rows.Add(RestName, "");

                        }
                    }  // foreach end 

                    DataSet dsNew = new DataSet("dataset");
                    dsNew.Tables.Add(Tables);
                    rprViewRestaurants = SerializeData.SerializeMultiValue<RPR_ViewRestaurants>(dsNew.Tables[0]);
                }

            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " View  Restaurants| Exception : " + ex.Message);
            }
            return rprViewRestaurants;
        }
    }

    // GCM Registration
    public class RM_Registration
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_Registration> rprRegistration = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_Registration> Registration(RP_Registration rpRegistration)
        {
            this.SpName = "DigitalMenu_Registration"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpRegistration.RestId));
                param[1] = new SqlParameter("@MacAddress", rpRegistration.MacAddress);
                param[2] = new SqlParameter("@Mobile", rpRegistration.Mobile);
                param[3] = new SqlParameter("@RegId", rpRegistration.RegId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprRegistration = SerializeData.SerializeMultiValue<RPR_Registration>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Registration| Exception : " + ex.Message);
            }
            return rprRegistration;
        }
    }

    // Transaction Filter By Waiter Id and Item Name 
    public class RM_TransFilter
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_TransFilter> rprTransFilter = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_TransFilter> TransFilter(RP_TransFilter rpTransFilter)
        {
            this.SpName = "DigitalMenu_TransFilter"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RestId", int.Parse(rpTransFilter.RestId));
                param[1] = new SqlParameter("@ItemName", string.IsNullOrEmpty(rpTransFilter.ItemName) ? Convert.DBNull : rpTransFilter.ItemName);
                param[2] = new SqlParameter("@WaiterId", string.IsNullOrEmpty(rpTransFilter.WaiterId) ? Convert.DBNull : rpTransFilter.WaiterId);
                param[3] = new SqlParameter("@key", rpTransFilter.key);
                param[4] = new SqlParameter("@fromdate", string.IsNullOrEmpty(rpTransFilter.fromdate) ? Convert.DBNull : Convert.ToDateTime(rpTransFilter.fromdate).Date);
                param[5] = new SqlParameter("@todate", string.IsNullOrEmpty(rpTransFilter.todate) ? Convert.DBNull : Convert.ToDateTime(rpTransFilter.todate).Date);



                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprTransFilter = SerializeData.SerializeMultiValue<RPR_TransFilter>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Transaction Filter By Waiter Id And  | Exception : " + ex.Message);
            }
            return rprTransFilter;
        }
    }

    //Customer Total AMount 
    public class RM_CusTotalAmount
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CusTotalAmount> rprCusTotalAmount = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_CusTotalAmount> CusTotalAmount(RP_CusTotalAmount rpCusTotalAmount)
        {
            this.SpName = "DigitalMenu_CusTotalAmount"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpCusTotalAmount.RestId));
                param[1] = new SqlParameter("@Mobile", rpCusTotalAmount.Mobile);
                param[2] = new SqlParameter("@key", rpCusTotalAmount.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCusTotalAmount = SerializeData.SerializeMultiValue<RPR_CusTotalAmount>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Transaction Filter By Waiter Id And  | Exception : " + ex.Message);
            }
            return rprCusTotalAmount;
        }
    }

    // Add Customer FeedBack 
    public class RM_AddFeedBackQuestion
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddFeedBackQuestion> rprAddFeedBackQuestion = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_AddFeedBackQuestion> AddFeedBackQuestion(RP_AddFeedBackQuestion rpAddFeedBackQuestion)
        {
            this.SpName = ""; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpAddFeedBackQuestion.RestId));
                param[1] = new SqlParameter("@FeedbackQuestions", rpAddFeedBackQuestion.FeedbackQuestions);
                param[2] = new SqlParameter("@key", rpAddFeedBackQuestion.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddFeedBackQuestion = SerializeData.SerializeMultiValue<RPR_AddFeedBackQuestion>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Transaction Filter By Waiter Id And  | Exception : " + ex.Message);
            }
            return rprAddFeedBackQuestion;
        }
    }



    // upload image 

    public class RM_UploadImage
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_UploadImage> rprAddFeedBackQuestion = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_UploadImage> UploadImage(RP_UploadImage rpUploadImage)
        {
            _IsSuccess = true;
            try
            {
                /// image section start ///

                /// image section end ///







                if (ds != null && ds.Tables.Count > 0)
                {
                    //  rprAddFeedBackQuestion = SerializeData.SerializeMultiValue<RPR_AddFeedBackQuestion>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Upload Image | Exception : " + ex.Message);
            }
            return rprAddFeedBackQuestion;
        }
    }


    // Get Bill Details 

    public class RM_ViewBillDetails
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewBillDetails> rprViewBillDetails = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewBillDetails> ViewBillDetails(RP_ViewBillDetails rpViewBillDetails)
        {
            this.SpName = "DigitalMenu_ViewBillDetails"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewBillDetails.RestId));
                param[1] = new SqlParameter("@BillNum", rpViewBillDetails.BillNum);
                param[2] = new SqlParameter("@key", rpViewBillDetails.key);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewBillDetails = SerializeData.SerializeMultiValue<RPR_ViewBillDetails>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Git Bill Details  | Exception : " + ex.Message);
            }
            return rprViewBillDetails;
        }
    }



    // Manage Staff 

    public class RM_DeleteStaff
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_DeleteStaff> rprDeleteStaff = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_DeleteStaff> DeleteStaff(RP_DeleteStaff rpDeleteStaff)
        {
            this.SpName = "DigitalMenu_DeleteStaff"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpDeleteStaff.RestId));
                param[1] = new SqlParameter("@posId", rpDeleteStaff.posId);
                param[2] = new SqlParameter("@key", rpDeleteStaff.key);
                param[3] = new SqlParameter("@waiterId", rpDeleteStaff.DeletedStaffID);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprDeleteStaff = SerializeData.SerializeMultiValue<RPR_DeleteStaff>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Git Bill Details  | Exception : " + ex.Message);
            }
            return rprDeleteStaff;
        }
    }

    // admin view Tables 

    public class RM_AdminViewTable
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AdminViewTable> rprAdminViewTable = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_AdminViewTable> AdminViewTable(RP_AdminViewTable rpAdminViewTable)
        {
            this.SpName = "DigitalMenu_AdminViewTable"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpAdminViewTable.RestId));
                param[1] = new SqlParameter("@posId", rpAdminViewTable.posId);
                param[2] = new SqlParameter("@key", rpAdminViewTable.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAdminViewTable = SerializeData.SerializeMultiValue<RPR_AdminViewTable>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " admin View Table   | Exception : " + ex.Message);
            }
            return rprAdminViewTable;
        }
    }


    // Customer feed back view by admin

    public class RM_ShowCustFeedBack
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ShowCustFeedBack> rprShowCustFeedBack = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ShowCustFeedBack> ShowCustFeedBack(RP_ShowCustFeedBack rpShowCustFeedBack)
        {
            this.SpName = "DigitalMenu_ShowCustFeedBack"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@RestId", int.Parse(rpShowCustFeedBack.RestId));
                param[1] = new SqlParameter("@posId", rpShowCustFeedBack.posId);
                param[2] = new SqlParameter("@key", rpShowCustFeedBack.key);
                param[3] = new SqlParameter("@fromDate", string.IsNullOrEmpty(rpShowCustFeedBack.fromDate) ? Convert.DBNull : Convert.ToDateTime(rpShowCustFeedBack.fromDate).Date);
                param[4] = new SqlParameter("@toDate", string.IsNullOrEmpty(rpShowCustFeedBack.toDate) ? Convert.DBNull : Convert.ToDateTime(rpShowCustFeedBack.toDate).Date);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprShowCustFeedBack = SerializeData.SerializeMultiValue<RPR_ShowCustFeedBack>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " admin View Customer feedback   | Exception : " + ex.Message);
            }
            return rprShowCustFeedBack;
        }
    }


    // cutomer feedBack Filter 
    public class RM_CustFeedBackFilter
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_CustFeedBackFilter> rprCustFeedBackFilter = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_CustFeedBackFilter> CustFeedBackFilter(RP_CustFeedBackFilter rpCustFeedBackFilter)
        {
            this.SpName = "DigitalMenu_FilterCustFeedBack"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpCustFeedBackFilter.RestId));
                param[1] = new SqlParameter("@posId", rpCustFeedBackFilter.posId);
                param[2] = new SqlParameter("@key", rpCustFeedBackFilter.key);
                //param[3] = new SqlParameter("@name", string.IsNullOrEmpty(rpCustFeedBackFilter.name) ? Convert.DBNull : rpCustFeedBackFilter.name);
                param[3] = new SqlParameter("@mobile", string.IsNullOrEmpty(rpCustFeedBackFilter.mobile) ? Convert.DBNull : rpCustFeedBackFilter.mobile);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprCustFeedBackFilter = SerializeData.SerializeMultiValue<RPR_CustFeedBackFilter>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " admin  filter Customer feedback   | Exception : " + ex.Message);
            }
            return rprCustFeedBackFilter;
        }
    }

    // view customer Feedback 

    public class RM_ViewCustFeedBack
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewCustFeedBack> rprViewCustFeedBack = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewCustFeedBack> ViewCustFeedBack(RP_ViewCustFeedBack rpViewCustFeedBack)
        {
            this.SpName = "DigitalMenu_ViewCustFeedBack"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewCustFeedBack.RestId));
                param[1] = new SqlParameter("@posId", rpViewCustFeedBack.posId);
                param[2] = new SqlParameter("@key", rpViewCustFeedBack.key);
                param[3] = new SqlParameter("@CusMobile", rpViewCustFeedBack.CusMobile);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewCustFeedBack = SerializeData.SerializeMultiValue<RPR_ViewCustFeedBack>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " view Customer  feedback   | Exception : " + ex.Message);
            }
            return rprViewCustFeedBack;
        }
    }


    // view Item sale  
    public class RM_ViewItemSale
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewItemSale> rprViewItemSale = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewItemSale> ViewItemSale(RP_ViewItemSale rpViewItemSale)
        {
            this.SpName = "DigitalMenu_ViewItemSale"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewItemSale.RestId));
                param[1] = new SqlParameter("@posId", rpViewItemSale.posId);
                param[2] = new SqlParameter("@key", rpViewItemSale.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewItemSale = SerializeData.SerializeMultiValue<RPR_ViewItemSale>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "  View Item Sale   | Exception : " + ex.Message);
            }
            return rprViewItemSale;
        }
    }


    // get all customer 

    public class RM_GetAllCustomer
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_GetAllCustomer> rprGetAllCustomer = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_GetAllCustomer> GetAllCustomer(RP_GetAllCustomer rpGetAllCustomer)
        {
            this.SpName = "DigitalMenu_GetAllCustomer"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpGetAllCustomer.RestId));
                param[1] = new SqlParameter("@posId", rpGetAllCustomer.posId);
                param[2] = new SqlParameter("@key", rpGetAllCustomer.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprGetAllCustomer = SerializeData.SerializeMultiValue<RPR_GetAllCustomer>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "  Get All Customer | Exception : " + ex.Message);
            }
            return rprGetAllCustomer;
        }
    }




    /// add health Category 
    public class RM_AddHealthCategory
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddHealthCategory> rprAddHealthCategory = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_AddHealthCategory> AddHealthCategory(RP_AddHealthCategory rpAddHealthCategory)
        {
            this.SpName = "DigitalMenu_AddHealthcategory"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpAddHealthCategory.RestId));
                param[1] = new SqlParameter("@posId", rpAddHealthCategory.posId);
                param[2] = new SqlParameter("@key", rpAddHealthCategory.key);
                param[3] = new SqlParameter("@CategoryName", rpAddHealthCategory.CategoryName);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddHealthCategory = SerializeData.SerializeMultiValue<RPR_AddHealthCategory>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "  Add Health Category | Exception : " + ex.Message);
            }
            return rprAddHealthCategory;
        }
    }

    // View Health Category 
    public class RM_ViewHealthCategory
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewHealthCategory> rprViewHealthCategory = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewHealthCategory> ViewHealthCategory(RP_ViewHealthCategory rpViewHealthCategory)
        {
            this.SpName = "DigitalMenu_ViewHealthcategory"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewHealthCategory.RestId));
                param[1] = new SqlParameter("@posId", rpViewHealthCategory.posId);
                param[2] = new SqlParameter("@key", rpViewHealthCategory.key);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewHealthCategory = SerializeData.SerializeMultiValue<RPR_ViewHealthCategory>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "  View Health Category | Exception : " + ex.Message);
            }
            return rprViewHealthCategory;
        }
    }


    // Add Health Tips 
    public class RM_AddHealthTips
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_AddHealthTips> rprAddHealthTips = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_AddHealthTips> AddHealthTips(RP_AddHealthTips rpAddHealthTips)
        {
            this.SpName = "DigitalMenu_AddHealthTips"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RestId", int.Parse(rpAddHealthTips.RestId));
                param[1] = new SqlParameter("@posId", rpAddHealthTips.posId);
                param[2] = new SqlParameter("@key", rpAddHealthTips.key);
                param[3] = new SqlParameter("@HealthCatId", rpAddHealthTips.HealthCatId);
                param[4] = new SqlParameter("@HealthTipTitle", rpAddHealthTips.HealthTipTitle);
                param[5] = new SqlParameter("@HealthTipDetails", rpAddHealthTips.HealthTipDetails);

                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprAddHealthTips = SerializeData.SerializeMultiValue<RPR_AddHealthTips>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "  Add Health Tips | Exception : " + ex.Message);
            }
            return rprAddHealthTips;
        }
    }


    // View Health Tips 

    public class RM_ViewHealthTips
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewHealthTips> rprViewHealthTips = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewHealthTips> ViewHealthTips(RP_ViewHealthTips rpViewHealthTips)
        {
            this.SpName = "DigitalMenu_ViewHealthTips"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RestId", int.Parse(rpViewHealthTips.RestId));
                param[1] = new SqlParameter("@posId", rpViewHealthTips.posId);
                param[2] = new SqlParameter("@key", rpViewHealthTips.key);
                param[3] = new SqlParameter("@HealthCatId", rpViewHealthTips.HealthCatId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewHealthTips = SerializeData.SerializeMultiValue<RPR_ViewHealthTips>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, "  View Health Tips | Exception : " + ex.Message);
            }
            return rprViewHealthTips;
        }
    }


    





    ///////////////////////////---THE END ---//////////////////////

}