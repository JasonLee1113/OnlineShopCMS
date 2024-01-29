﻿using Newtonsoft.Json;

namespace OnlineShopCMS.Helpers
{
    public static class SessionHelper
    {
        //設定Session 內容
        public static void SetObjectAsJson(this ISession session, string key, object value )
        {
            session.SetString(key , JsonConvert.SerializeObject(value));

        }

        //取得Session內容
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        //移除Session
        public static void Remove(this ISession session, string key)
        {
            session.Remove(key);
        }
    }
}
