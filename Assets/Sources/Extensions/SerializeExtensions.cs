using Newtonsoft.Json;

namespace Game.Extensions
{
    public static class SerializeExtensions
    {
        public static string Serialize(this object obj) => JsonConvert.SerializeObject(obj);
    }
}