﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigitalMenu.Common
{
    public class SerializeData
    {
        public static T SerializeSingalValue<T>(DataTable dt) where T : class,new()
        {
            T t = null;
            if (dt != null)
            {
                //ds.Tables
                var Json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                t = JsonConvert.DeserializeObject<T>(Json);
            }
            return t;
        }

        public static List<T> SerializeMultiValue<T>(DataTable dt) where T : class,new()
        {
            List<T> tList = null;
            if (dt != null)
            {
                //ds.Tables
                var Json = JsonConvert.SerializeObject(dt, Formatting.None);
                tList = JsonConvert.DeserializeObject<List<T>>(Json);
            }
            return tList;
        }

    }
}