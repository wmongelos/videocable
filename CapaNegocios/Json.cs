using Newtonsoft.Json;
using System;
using System.Text;

namespace CapaNegocios
{
    public class Json<T>
    {
        private T obj;

        public Json(T obj)
        {
            this.obj = obj;
        }

        public string GetJsonEnBase64()
        {
            string json = JsonConvert.SerializeObject(obj);
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            return base64;
        }
    }
}
