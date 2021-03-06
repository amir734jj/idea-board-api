using Newtonsoft.Json;
using static Models.Constants.ApplicationConstants;

namespace Dal.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNull(this object source)
        {
            return source == null;
        }
        
        public static byte[] ObjectToByteArray<T>(this T data)
        {
            var json = JsonConvert.SerializeObject(data);
            
            return DefaultEncoding.GetBytes(json);
        }

        public static T DeepClone<T>(this T data)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(data));
        }
    }
}