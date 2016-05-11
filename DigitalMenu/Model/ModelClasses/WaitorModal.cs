using DigitalMenu.Common;
using DigitalMenu.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace DigitalMenu.Model.ModelClasses
{
    //public class WaitorModal
    //{
    //}


    // View Table Order
    public class RM_ViewTableOrder
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewTableOrder> rprViewTableOrder = null;
        DataBase db = new DataBase();
        DataSet ds = null;
         public List<RPR_ViewTableOrder> ViewTableOrder(RP_ViewTableOrder rpViewTableOrder)
        {
            this.SpName = "DigitalMenu_ViewTableOrder"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@key", rpViewTableOrder.key);
                param[1] = new SqlParameter("@PosId", int.Parse(rpViewTableOrder.PosId));
                param[2] = new SqlParameter("@RestId", int.Parse(rpViewTableOrder.RestId));
                param[3] = new SqlParameter("@TableNo", rpViewTableOrder.TableNo);
                param[4] = new SqlParameter("@WaitorId", rpViewTableOrder.WaitorId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewTableOrder = SerializeData.SerializeMultiValue<RPR_ViewTableOrder>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " View Table Order | Exception : " + ex.Message);
            }
            return rprViewTableOrder;
        }
     
     

    }

    //Confirm Order 
    public class RM_ConfirmOrder
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ConfirmOrder> rprConfirmOrder = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ConfirmOrder> ConfirmOrder(RP_ConfirmOrder rpConfirmOrder)
        {
            this.SpName = "DigitalMenu_ConfirmOrder"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@key", rpConfirmOrder.key);
                param[1] = new SqlParameter("@PosId",int.Parse(rpConfirmOrder.PosId));
                param[2] = new SqlParameter("@RestId", int.Parse(rpConfirmOrder.RestId));
                param[3] = new SqlParameter("@TableNo", rpConfirmOrder.TableNo);
                param[4] = new SqlParameter("@WaitorId", rpConfirmOrder.WaitorId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprConfirmOrder = SerializeData.SerializeMultiValue<RPR_ConfirmOrder>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Confirm Order | Exception : " + ex.Message);
            }
            return rprConfirmOrder;
        }












        ///////////////////////////---THE END ---//////////////////////
    }

    //View All Table Bills 
    public class RM_ViewAllTableBills
    {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewAllTableBills> rprViewAllTableBills = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewAllTableBills> ViewAllTableBills(RP_ViewAllTableBills rpViewAllTableBills)
        {
            this.SpName = "DigitalMenu_ViewAllTableBills"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@key", rpViewAllTableBills.key);
                param[1] = new SqlParameter("@PosId", int.Parse(rpViewAllTableBills.PosId));
                param[2] = new SqlParameter("@RestId", int.Parse(rpViewAllTableBills.RestId));
                param[3] = new SqlParameter("@WaitorId", string.IsNullOrEmpty(rpViewAllTableBills.WaitorId) ? Convert.DBNull : rpViewAllTableBills.WaitorId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewAllTableBills = SerializeData.SerializeMultiValue<RPR_ViewAllTableBills>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Confirm Order | Exception : " + ex.Message);
            }
            return rprViewAllTableBills;
        }
    }

        //View table bill
        public class RM_ViewTableBill
      {
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public List<RPR_ViewTableBill> rprViewTableBill = null;
        DataBase db = new DataBase();
        DataSet ds = null;
        public List<RPR_ViewTableBill> ViewTableBill(RP_ConfirmOrder rpConfirmOrder)
        {
            this.SpName = "DigitalMenu_ViewTableBill"; //Sp Name
            _IsSuccess = true;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@key", rpConfirmOrder.key);
                param[1] = new SqlParameter("@PosId",int.Parse(rpConfirmOrder.PosId));
                param[2] = new SqlParameter("@RestId", int.Parse(rpConfirmOrder.RestId));
                param[3] = new SqlParameter("@TableNo", rpConfirmOrder.TableNo);
                param[4] = new SqlParameter("@WaitorId", string.IsNullOrEmpty(rpConfirmOrder.WaitorId)?Convert.DBNull:rpConfirmOrder.WaitorId);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rprViewTableBill = SerializeData.SerializeMultiValue<RPR_ViewTableBill>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " Confirm Order | Exception : " + ex.Message);
            }
            return rprViewTableBill;
        }
      }


        // Table CheckOut 
        public class RM_TableCheckOut
        {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_TableCheckOut> rprTableCheckOut = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_TableCheckOut> TableCheckOut(RP_ConfirmOrder rpConfirmOrder)
            {
                this.SpName = "DigitalMenu_TableCheckOut"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[9];
                    param[0] = new SqlParameter("@key", rpConfirmOrder.key);
                    param[1] = new SqlParameter("@PosId", int.Parse(rpConfirmOrder.PosId));
                    param[2] = new SqlParameter("@RestId", int.Parse(rpConfirmOrder.RestId));
                    param[3] = new SqlParameter("@TableNo", rpConfirmOrder.TableNo);
                    param[4] = new SqlParameter("@WaitorId", rpConfirmOrder.WaitorId);
                    param[5] = new SqlParameter("@Paymode", rpConfirmOrder.Paymode);
                    param[6] = new SqlParameter("@NumOfPerson", rpConfirmOrder.NumOfPerson);
                    param[7] = new SqlParameter("@BillNo", rpConfirmOrder.BillNo);
                    param[8] = new SqlParameter("@TotalAmount", rpConfirmOrder.TotalAmount);

                    
                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprTableCheckOut = SerializeData.SerializeMultiValue<RPR_TableCheckOut>(ds.Tables[0]);
                        NotifyCheckout(rpConfirmOrder);
                    }

                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " Table Check Out | Exception : " + ex.Message);
                }
                return rprTableCheckOut;
            }

            protected void NotifyCheckout(RP_ConfirmOrder rpConfirmOrder)
            {
                this.SpName = "DigitalMenu_GetManager_GCM_RegID"; //Sp Name
                try
                {
                    SqlParameter[] param = new SqlParameter[1];
                   // param[0] = new SqlParameter("@WaitorId", rpConfirmOrder.WaitorId.Trim());
                    param[0] = new SqlParameter("@RestId", int.Parse(rpConfirmOrder.RestId));
                   // param[2] = new SqlParameter("@TableId", rpConfirmOrder.TableNo);

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
                        msg = "Customer Checkout  From Table" + rpConfirmOrder.TableNo;
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


        //Cancel Order 
        public class RM_CancelOrder
        {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_CancelOrder> rprCancelOrder = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_CancelOrder> CancelOrder(RP_CancelOrder rpCancelOrder)
            {
                this.SpName = "DigitalMenu_CancelOrder"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@key", rpCancelOrder.key);
                    param[1] = new SqlParameter("@PosId", int.Parse(rpCancelOrder.PosId));
                    param[2] = new SqlParameter("@RestId", int.Parse(rpCancelOrder.RestId));
                    param[3] = new SqlParameter("@TableNo", rpCancelOrder.TableNo);
                    param[4] = new SqlParameter("@WaitorId", string.IsNullOrEmpty(rpCancelOrder.WaitorId)?Convert.DBNull:rpCancelOrder.WaitorId);
                    param[5] = new SqlParameter("@ItemId", rpCancelOrder.ItemId);
                    param[6] = new SqlParameter("@CancelReason", string.IsNullOrEmpty(rpCancelOrder.CancelReason)?Convert.DBNull:rpCancelOrder.CancelReason);

                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprCancelOrder = SerializeData.SerializeMultiValue<RPR_CancelOrder>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " Cancel Order | Exception : " + ex.Message);
                }
                return rprCancelOrder;
            }
        }

    // View All Table Order
        public class RM_ViewAllTableOrder
        {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_ViewAllTableOrder> rprViewAllTableOrder = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_ViewAllTableOrder> ViewAllTableOrder(RP_ViewAllTableOrder rpViewAllTableOrder)
            {
                this.SpName = "DigitalMenu_ViewAllTableOrder"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@key", rpViewAllTableOrder.key);
                    param[1] = new SqlParameter("@WaiterId", rpViewAllTableOrder.WaiterId);
                    param[2] = new SqlParameter("@RestId", int.Parse(rpViewAllTableOrder.RestId));

                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprViewAllTableOrder = SerializeData.SerializeMultiValue<RPR_ViewAllTableOrder>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " View All Table Order | Exception : " + ex.Message);
                }
                return rprViewAllTableOrder;
            }
        }


    // View Current Order 
        public class RM_ViewCurrentOrder
        {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_ViewCurrentOrder> rprViewCurrentOrder = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_ViewCurrentOrder> ViewAllTableOrder(RP_ViewCurrentOrder rpViewCurrentOrder)
            {
                this.SpName = "DigitalMenu_ViewCurrentOrder"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@key", rpViewCurrentOrder.key);
                    param[1] = new SqlParameter("@WaitorId", rpViewCurrentOrder.WaiterId);
                    param[2] = new SqlParameter("@RestId", int.Parse(rpViewCurrentOrder.RestId));

                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprViewCurrentOrder = SerializeData.SerializeMultiValue<RPR_ViewCurrentOrder>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " View All Current Order | Exception : " + ex.Message);
                }
                return rprViewCurrentOrder;
            }
        }



    // View Current Table Order 
        public class RM_ViewCurrentTableOrder
        {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_ViewCurrentTableOrder> rprViewCurrentTableOrder = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_ViewCurrentTableOrder> ViewCurrentTableOrder(RP_ViewCurrentTableOrder rpViewCurrentTableOrder)
            {
                this.SpName = "DigitalMenu_ViewCurrentTableOrder"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@key", rpViewCurrentTableOrder.key);
                    param[1] = new SqlParameter("@WaitorId", rpViewCurrentTableOrder.WaiterId);
                    param[2] = new SqlParameter("@RestId", int.Parse(rpViewCurrentTableOrder.RestId));
                    param[3] = new SqlParameter("@TableNumber",rpViewCurrentTableOrder.TableNumber);

                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprViewCurrentTableOrder = SerializeData.SerializeMultiValue<RPR_ViewCurrentTableOrder>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " View  Current Table Order | Exception : " + ex.Message);
                }
                return rprViewCurrentTableOrder;
            }
        }


       //View Join Table
         public class RM_ViewJoinTable
        {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_ViewJoinTable> rprViewJoinTable = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_ViewJoinTable> ViewJoinTable(RP_ViewJoinTable rpViewJoinTable)
            {
                this.SpName = "DigitalMenu_ViewJoinTable"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@key", rpViewJoinTable.key);
                    param[1] = new SqlParameter("@WaitorId", rpViewJoinTable.WaiterId);
                    param[2] = new SqlParameter("@RestId", int.Parse(rpViewJoinTable.RestId));
                   // param[3] = new SqlParameter("@TableNumber",rpViewCurrentTableOrder.TableNumber);

                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprViewJoinTable = SerializeData.SerializeMultiValue<RPR_ViewJoinTable>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " View  Current Table Order | Exception : " + ex.Message);
                }
                return rprViewJoinTable;
            }
        }

    //Allow To JOin Table
      public class RM_AllowToJoinTable
        {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_AllowToJoinTable> rprAllowToJoinTable = null;
            DataBase db = new DataBase();
            DataSet ds = null;

            public List<RPR_AllowToJoinTable> AllowToJoinTable(RP_AllowToJoinTable rpAllowToJoinTable)
            {
                this.SpName = "DigitalMenu_AllowToJoinTable"; //Sp Name
                _IsSuccess = true;
                 string CusRegId="";
                 string msg = "";
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@key", rpAllowToJoinTable.key);
                    param[1] = new SqlParameter("@WaitorId", rpAllowToJoinTable.WaiterId);
                    param[2] = new SqlParameter("@RestId", int.Parse(rpAllowToJoinTable.RestId));
                    param[3] = new SqlParameter("@TableNumber", int.Parse(rpAllowToJoinTable.TableNumber));

                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataRowCollection drc = ds.Tables[0].Rows;
                        foreach (DataRow item in drc)
                        {
                            CusRegId = "" + item["CusRegId"];
                        }
                        msg = "Order From Table" + rpAllowToJoinTable.TableNumber;
                        AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();
                        //apnGCM.SendNotification(CusRegId, msg);
                        //rprAllowToJoinTable = SerializeData.SerializeMultiValue<RPR_AllowToJoinTable>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " Allow To Join Table | Exception : " + ex.Message);
                }
                return rprAllowToJoinTable;
            }
        }

    // change Order Status 
      public class RM_ChangeOrderStatus
    { 
        [JsonIgnore]
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public string DevId { get; set; }
        public List<RPR_ChangeOrderStatus> rprNewDelivery = null;
        DataBase db = new DataBase();
        DataSet ds = null;
       
        public List<RPR_ChangeOrderStatus> ChangeOrderStatus(RP_ChangeOrderStatus rpChangeOrderStatus)
        {

            this.SpName = "DigitalMenu_WaiterchangeOrderStatus"; //Sp Name
            _IsSuccess = true;
            try
            {

                // update Delievery qunatity
                if (rpChangeOrderStatus.UpdatedItemDetails != "" || rpChangeOrderStatus.Status == "Kitchen")
                {
                    string[] categoryDetails = new string[4];
                    JArray a = JArray.Parse(rpChangeOrderStatus.UpdatedItemDetails);
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
                        param[0] = new SqlParameter("@key", rpChangeOrderStatus.key);
                        param[1] = new SqlParameter("@RestId", int.Parse(rpChangeOrderStatus.RestId));
                        param[2] = new SqlParameter("@WaiterId", rpChangeOrderStatus.WaitorId);
                        param[3] = new SqlParameter("@ItemId", categoryDetails[1]);
                        param[4] = new SqlParameter("@quantity", int.Parse(categoryDetails[2]));
                        param[5] = new SqlParameter("amount", float.Parse(categoryDetails[3]));
                        param[6] = new SqlParameter("@Status", rpChangeOrderStatus.Status);
                        param[7] = new SqlParameter("@tableNum", rpChangeOrderStatus.TableNo);
                        param[8] = new SqlParameter("@cartId", int.Parse(categoryDetails[0]));
                        ds = db.GetDataSet(this.SpName, param);
                        last_sp_call++;
                        if (last_sp_call == count)
                        {
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                rprNewDelivery = SerializeData.SerializeMultiValue<RPR_ChangeOrderStatus>(ds.Tables[0]);
                            }
                        }

                    } // loop end 
                } // update Delivery Quantity End 

                else
                {

                    SqlParameter[] param = new SqlParameter[9];
                    param[0] = new SqlParameter("@key", rpChangeOrderStatus.key);
                    param[1] = new SqlParameter("@RestId", int.Parse(rpChangeOrderStatus.RestId));
                    param[2] = new SqlParameter("@WaiterId", rpChangeOrderStatus.WaitorId);
                    param[3] = new SqlParameter("@ItemId", "-1");
                    param[4] = new SqlParameter("@quantity", int.Parse("-1"));
                    param[5] = new SqlParameter("amount", float.Parse("-1"));
                    param[6] = new SqlParameter("@Status", rpChangeOrderStatus.Status);
                    param[7] = new SqlParameter("@tableNum", rpChangeOrderStatus.TableNo);
                    param[8] = new SqlParameter("@cartId", "-1");
                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprNewDelivery = SerializeData.SerializeMultiValue<RPR_ChangeOrderStatus>(ds.Tables[0]);
                    }
                        
                }

            }
            catch (Exception ex)
            {
                _IsSuccess = false;
                Logger.WriteLog(LogLevelL4N.ERROR, " change Order status | Exception : " + ex.Message);
            }
            return rprNewDelivery;
        }

    }


    // delte order Item 
      public class RM_DeleteOrderItem
          {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_DeleteOrderItem> rprDeleteOrderItem = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_DeleteOrderItem> DeleteOrderItem(RP_DeleteOrderItem rpDeleteOrderItem)
            {
                this.SpName = "DigitalMenu_DeleteOrderItem"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@key", rpDeleteOrderItem.key);
                    param[1] = new SqlParameter("@WaiterId", rpDeleteOrderItem.WaitorId);
                    param[2] = new SqlParameter("@RestId", int.Parse(rpDeleteOrderItem.RestId));
                    param[3] = new SqlParameter("@TableNo", rpDeleteOrderItem.TableNo);
                    param[4] = new SqlParameter("@ItemId", rpDeleteOrderItem.ItemID);
                    param[5] = new SqlParameter("@cartId", int.Parse(rpDeleteOrderItem.cartId));


                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprDeleteOrderItem = SerializeData.SerializeMultiValue<RPR_DeleteOrderItem>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " View  Current Table Order | Exception : " + ex.Message);
                }
                return rprDeleteOrderItem;
            }
        }
    

    // Update Delivery Qunatity 
      public class RM_UpdateDeliveryQunatity
          {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_UpdateDeliveryQunatity> rprUpdateDeliveryQunatity = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_UpdateDeliveryQunatity> UpdateDeliveryQunatity( RP_UpdateDeliveryQunatity rpUpdateDeliveryQunatity)
            {
                this.SpName = "DigitalMenu_UpdateDeliveryQunatity"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@key", rpUpdateDeliveryQunatity.key);
                    param[1] = new SqlParameter("@WaiterId", rpUpdateDeliveryQunatity.WaitorId);
                    param[2] = new SqlParameter("@RestId", int.Parse(rpUpdateDeliveryQunatity.RestId));
                    param[3] = new SqlParameter("@TableNo", rpUpdateDeliveryQunatity.TableNo);
                    param[4] = new SqlParameter("@ItemId", rpUpdateDeliveryQunatity.ItemID);
                    param[5] = new SqlParameter("@quantity", int.Parse(rpUpdateDeliveryQunatity.Quantity));
                    param[6] = new SqlParameter("@cartId", int.Parse(rpUpdateDeliveryQunatity.cartId));

                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprUpdateDeliveryQunatity = SerializeData.SerializeMultiValue<RPR_UpdateDeliveryQunatity>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " update Delievry Qunatity | Exception : " + ex.Message);
                }
                return rprUpdateDeliveryQunatity;
            }
        }


    // waiter profile 
          public class RM_WaiterProfile
          {
            [JsonIgnore]
            public bool _IsSuccess { get; set; }
            private string SpName { get; set; }
            public List<RPR_WaiterProfile> rprWaiterProfile = null;
            DataBase db = new DataBase();
            DataSet ds = null;
            public List<RPR_WaiterProfile> WaiterProfile(RP_WaiterProfile rpWaiterProfile)
            {
                this.SpName = "DigitalMenu_WaiterProfile"; //Sp Name
                _IsSuccess = true;
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@key", rpWaiterProfile.key);
                    param[1] = new SqlParameter("@WaiterId", rpWaiterProfile.WaiterId);
                    param[2] = new SqlParameter("@RestId", int.Parse(rpWaiterProfile.RestId));
                   
                    ds = db.GetDataSet(this.SpName, param);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        rprWaiterProfile = SerializeData.SerializeMultiValue<RPR_WaiterProfile>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {
                    _IsSuccess = false;
                    Logger.WriteLog(LogLevelL4N.ERROR, " waiter profile  | Exception : " + ex.Message);
                }
                return rprWaiterProfile;
            }
        }


    // update waiter Profile 
          public class RM_UpdateWaiterProfile
          {
              [JsonIgnore]
              public bool _IsSuccess { get; set; }
              private string SpName { get; set; }
              public List<RPR_UpdateWaiterProfile> rprUpdateWaiterProfile = null;
              DataBase db = new DataBase();
              DataSet ds = null;
              public List<RPR_UpdateWaiterProfile> UpdateWaiterProfile(RP_UpdateWaiterProfile rpUpdateWaiterProfile)
              {
                  this.SpName = "DigitalMenu_UpdateWaiterProfile"; //Sp Name
                  _IsSuccess = true;
                  try
                  {
                      SqlParameter[] param = new SqlParameter[4];
                      param[0] = new SqlParameter("@key", rpUpdateWaiterProfile.key);
                      param[1] = new SqlParameter("@WaiterId", rpUpdateWaiterProfile.WaiterId);
                      param[2] = new SqlParameter("@RestId", int.Parse(rpUpdateWaiterProfile.RestId));
                      param[3] = new SqlParameter("@Email", rpUpdateWaiterProfile.Email);

                      ds = db.GetDataSet(this.SpName, param);
                      if (ds != null && ds.Tables.Count > 0)
                      {
                          rprUpdateWaiterProfile = SerializeData.SerializeMultiValue<RPR_UpdateWaiterProfile>(ds.Tables[0]);
                      }
                  }
                  catch (Exception ex)
                  {
                      _IsSuccess = false;
                      Logger.WriteLog(LogLevelL4N.ERROR, " update  waiter profile  | Exception : " + ex.Message);
                  }
                  return rprUpdateWaiterProfile;
              }
          }


    // waiter chnage Password 
      public class RM_WaiterChangePwd
          {
              [JsonIgnore]
              public bool _IsSuccess { get; set; }
              private string SpName { get; set; }
              public List<RPR_WaiterChangePwd> rprUpdateWaiterProfile = null;
              DataBase db = new DataBase();
              DataSet ds = null;
              public List<RPR_WaiterChangePwd> WaiterChangePwd(RP_WaiterChangePwd rpWaiterChangePwd)
              {
                  this.SpName = "DigitalMenu_ChangeWaiterPwd"; //Sp Name
                  _IsSuccess = true;
                  try
                  {
                      SqlParameter[] param = new SqlParameter[5];
                      param[0] = new SqlParameter("@key", rpWaiterChangePwd.key);
                      param[1] = new SqlParameter("@WaiterId", rpWaiterChangePwd.WaiterId);
                      param[2] = new SqlParameter("@RestId", int.Parse(rpWaiterChangePwd.RestId));
                      param[3] = new SqlParameter("@NewPwd", rpWaiterChangePwd.NewPwd);
                      param[4] = new SqlParameter("@OldPwd", rpWaiterChangePwd.OldPwd);

                      ds = db.GetDataSet(this.SpName, param);
                      if (ds != null && ds.Tables.Count > 0)
                      {
                          rprUpdateWaiterProfile = SerializeData.SerializeMultiValue<RPR_WaiterChangePwd>(ds.Tables[0]);
                      }
                  }
                  catch (Exception ex)
                  {
                      _IsSuccess = false;
                      Logger.WriteLog(LogLevelL4N.ERROR, " update  waiter profile  | Exception : " + ex.Message);
                  }
                  return rprUpdateWaiterProfile;
              }
          }


    // Get Table Number 
      public class RM_GetTableNumber
          {
              [JsonIgnore]
              public bool _IsSuccess { get; set; }
              private string SpName { get; set; }
              public List<RPR_GetTableNumber> rprGetTableNumber = null;
              DataBase db = new DataBase();
              DataSet ds = null;
              public List<RPR_GetTableNumber> GetTableNumber(RP_GetTableNumber rpGetTableNumber)
              {
                  this.SpName = "DigitalMenu_GetTableNumber"; //Sp Name
                  _IsSuccess = true;
                  try
                  {
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@key", rpGetTableNumber.key);
                      param[1] = new SqlParameter("@WaiterId", rpGetTableNumber.WaiterId);
                      param[2] = new SqlParameter("@RestId", int.Parse(rpGetTableNumber.RestId));
                     
                      ds = db.GetDataSet(this.SpName, param);
                      if (ds != null && ds.Tables.Count > 0)
                      {
                          rprGetTableNumber = SerializeData.SerializeMultiValue<RPR_GetTableNumber>(ds.Tables[0]);
                      }
                  }
                  catch (Exception ex)
                  {
                      _IsSuccess = false;
                      Logger.WriteLog(LogLevelL4N.ERROR, " get table Number   | Exception : " + ex.Message);
                  }
                  return rprGetTableNumber;
              }
          }

    // waiter Trans Filter 
      public class RM_WaiterTransactionFilter
          {
              [JsonIgnore]
              public bool _IsSuccess { get; set; }
              private string SpName { get; set; }
              public List<RPR_WaiterTransactionFilter> rprWaiterTransactionFilter = null;
              DataBase db = new DataBase();
              DataSet ds = null;
              public List<RPR_WaiterTransactionFilter> WaiterTransactionFilter(RP_WaiterTransactionFilter rpWaiterTransactionFilter)
              {
                  this.SpName = "DigitalMenu_waiterTransactionFilter"; //Sp Name
                  _IsSuccess = true;
                  try
                  {
                      SqlParameter[] param = new SqlParameter[6];
                      param[0] = new SqlParameter("@key", rpWaiterTransactionFilter.key);
                      param[1] = new SqlParameter("@WaiterId", rpWaiterTransactionFilter.WaiterId);
                      param[2] = new SqlParameter("@RestId", int.Parse(rpWaiterTransactionFilter.RestId));
                      param[3] = new SqlParameter("@FromDate", string.IsNullOrEmpty(rpWaiterTransactionFilter.FromDate) ? Convert.DBNull : Convert.ToDateTime(rpWaiterTransactionFilter.FromDate).Date);
                      param[4] = new SqlParameter("@ToDate", string.IsNullOrEmpty(rpWaiterTransactionFilter.ToDate) ? Convert.DBNull : Convert.ToDateTime(rpWaiterTransactionFilter.ToDate).Date);
                      param[5] = new SqlParameter("@TableNo", string.IsNullOrEmpty(rpWaiterTransactionFilter.TableNo)?Convert.DBNull:rpWaiterTransactionFilter.TableNo);
                     
                      ds = db.GetDataSet(this.SpName, param);
                      if (ds != null && ds.Tables.Count > 0)
                      {
                          rprWaiterTransactionFilter = SerializeData.SerializeMultiValue<RPR_WaiterTransactionFilter>(ds.Tables[0]);
                      }
                  }
                  catch (Exception ex)
                  {
                      _IsSuccess = false;
                      Logger.WriteLog(LogLevelL4N.ERROR, " waiter tran filter   | Exception : " + ex.Message);
                  }
                  return rprWaiterTransactionFilter;
              }
          }



    // Customer checkout by waiter 
      public class RM_WaiterChekoutCus
          {
              [JsonIgnore]
              public bool _IsSuccess { get; set; }
              private string SpName { get; set; }
              public List<RPR_WaiterChekoutCus> rprWaiterChekoutCus = null;
              DataBase db = new DataBase();
              DataSet ds = null;
              public List<RPR_WaiterChekoutCus> WaiterChekoutCus(RP_WaiterChekoutCus rpWaiterChekoutCus)
              {
                  this.SpName = "DigitalMenu_WaiterChekoutCus"; //Sp Name
                  _IsSuccess = true;
                  try
                  {
                      SqlParameter[] param = new SqlParameter[11];
                      param[0] = new SqlParameter("@key", rpWaiterChekoutCus.key);
                      param[1] = new SqlParameter("@WaitorId", rpWaiterChekoutCus.WaiterId);
                      param[2] = new SqlParameter("@RestId", int.Parse(rpWaiterChekoutCus.RestId));
                      param[3] = new SqlParameter("@PosId", int.Parse(rpWaiterChekoutCus.PosId));
                      param[4] = new SqlParameter("@TableNo", rpWaiterChekoutCus.TableNo);
                      //// ====   New Added   ==== ////
                      param[5] =new SqlParameter("@totalAmount",float.Parse(rpWaiterChekoutCus.totalAmount));
                      param[6] = new SqlParameter("@discount", rpWaiterChekoutCus.discount);
                      param[7] = new SqlParameter("@discountType", rpWaiterChekoutCus.discountType);
                      param[8] = new SqlParameter("@netAmount", rpWaiterChekoutCus.netAmount);
                      param[9] = new SqlParameter("@paymentMode", rpWaiterChekoutCus.paymentMode);
                      param[10] = new SqlParameter("@waiterRemark", rpWaiterChekoutCus.waiterRemark);
                          

                      ds = db.GetDataSet(this.SpName, param);
                      if (ds != null && ds.Tables.Count > 0)
                      {
                          rprWaiterChekoutCus = SerializeData.SerializeMultiValue<RPR_WaiterChekoutCus>(ds.Tables[0]);
                      }
                  }
                  catch (Exception ex)
                  {
                      _IsSuccess = false;
                      Logger.WriteLog(LogLevelL4N.ERROR, " waiter chk out customer    | Exception : " + ex.Message);
                  }
                  return rprWaiterChekoutCus;
              }
          }


   //  waiter add item for cus 

      public class RM_WaiterAddItemForCus
      {
          [JsonIgnore]
          public bool _IsSuccess { get; set; }
          private string SpName { get; set; }
          public string Status { get; set; }
          public List<RPR_WaiterAddItemForCus> rprWaiterAddItemForCus = null;
          DataBase db = new DataBase();
          DataSet ds = null;

          public List<RPR_WaiterAddItemForCus> WaiterAddItemForCus(RP_WaiterAddItemForCus rpWaiterAddItemForCus)
          {
              this.SpName = "DigitalMenu_WaiterAddItemForCus"; //Sp Name
              _IsSuccess = true;
              try
              {
                  string[] categoryDetails = new string[4];
                  JArray a = JArray.Parse(rpWaiterAddItemForCus.ItemDetails);
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
                      SqlParameter[] param = new SqlParameter[8];
                      param[0] = new SqlParameter("@RestId", int.Parse(rpWaiterAddItemForCus.RestId));
                      param[1] = new SqlParameter("@key", rpWaiterAddItemForCus.key);
                      param[2] = new SqlParameter("@waiterId", rpWaiterAddItemForCus.WaiterId);
                      param[3] = new SqlParameter("@tableNum", rpWaiterAddItemForCus.TableId);
                      param[4] = new SqlParameter("@itemId", categoryDetails[0]);
                      param[5] = new SqlParameter("@price", float.Parse(categoryDetails[1]));
                      param[6] = new SqlParameter("@qunatity", int.Parse(categoryDetails[2]));
                      param[7] = new SqlParameter("@amount", float.Parse(categoryDetails[3]));
                    

                      ds = db.GetDataSet(this.SpName, param);
                      last_sp_call++;
                      if (last_sp_call == count)
                      {
                          if (ds != null && ds.Tables.Count > 0)
                          {
                              rprWaiterAddItemForCus = SerializeData.SerializeMultiValue<RPR_WaiterAddItemForCus>(ds.Tables[0]);
                          }
                      } //if end 


                  } //foreach end 


              }
              catch (Exception ex)
              {
                  _IsSuccess = false;
                  Logger.WriteLog(LogLevelL4N.ERROR, " waiter Order Item | Exception : " + ex.Message);
              }

              return rprWaiterAddItemForCus;
          }

      }




    // waiter see Food Histroy of Customer 

    //

      public class RM_CustFoodHistroy
      {
          [JsonIgnore]
          public bool _IsSuccess { get; set; }
          private string SpName { get; set; }
          public string Status { get; set; }
          public List<RPR_CustFoodHistroy> rprCustFoodHistroy = null;
          DataBase db = new DataBase();
          DataSet ds = null;

          public List<RPR_CustFoodHistroy> CustFoodHistroy(RP_CustFoodHistroy rpCustFoodHistroy)
          {
              this.SpName = "DigitalMenu_CustFoodHistroy"; //Sp Name
              _IsSuccess = true;
              try
              {
                      SqlParameter[] param = new SqlParameter[5];
                      param[0] = new SqlParameter("@RestId", int.Parse(rpCustFoodHistroy.RestId));
                      param[1] = new SqlParameter("@key", rpCustFoodHistroy.key);
                      param[2] = new SqlParameter("@waiterId", rpCustFoodHistroy.WaiterId);
                      param[3] = new SqlParameter("@TableId", rpCustFoodHistroy.TableId);
                      param[4] = new SqlParameter("@PosId", rpCustFoodHistroy.PosId);
                    
                      ds = db.GetDataSet(this.SpName, param);
                     if (ds != null && ds.Tables.Count > 0)
                          {
                              rprCustFoodHistroy = SerializeData.SerializeMultiValue<RPR_CustFoodHistroy>(ds.Tables[0]);
                          }
                  } 
              catch (Exception ex)
              {
                  _IsSuccess = false;
                  Logger.WriteLog(LogLevelL4N.ERROR, " waiter see Order Of customer | Exception : " + ex.Message);
              }

              return rprCustFoodHistroy;
          }

      }




    ///////////////////////---THE END ---//////////////////////
    
}