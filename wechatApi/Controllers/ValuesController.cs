using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using wechatApi.Models;

namespace wechatApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private wxHelper helper;
        private IMemoryCache cache;

        public ValuesController(IMemoryCache cache)
        {
            this.cache = cache;
            this.helper = new wxHelper();
            dbHelper db = new dbHelper();
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("{code}")]
        public string OnLogin(string code)
        {
            
            string data = "";
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                data = sr.ReadToEnd();
            }
            AppSession appSession = JsonConvert.DeserializeObject<AppSession>(data);
            string enData = appSession.encryptedData;
            string iv = appSession.iv;
            string key = appSession.sessionKey;
            string res = helper.AES_decrypt(enData,key,iv);
            return res;
                //if (string.IsNullOrEmpty(code) == false)
                //{
                //    cache.Set(code, );
                //}
                //return WritingFailed("登录失败");
        }

        public IActionResult Decrypt()
        {
            //string code = Request["code"];
            //string iv = Request["iv"];
            //string encryptedData = Request["encryptedData"];
            //string sessionKey = CacheHelper.Get(code); //取出OnLogin的sessionKey
            //string rawData = WxAppHelper.AES_decrypt(encryptedData, sessionKey, iv);
            //if (string.IsNullOrEmpty(rawData) == false)
            //{
            //    return WritingSuccess("解密成功", rawData);
            //}
            //return WritingFailed("解密失败");
            return null;
        }

        
    }

    public class AppSession
    {
        public string encryptedData;
        public string iv;
        public string sessionKey;
    }

}
