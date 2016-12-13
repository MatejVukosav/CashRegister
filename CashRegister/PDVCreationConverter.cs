using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CashRegister
{

    public abstract class JsonCreationConverterPDV<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jsonObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(objectType, jsonObject);
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


    class PDVCreationConverter : JsonCreationConverter<PDV>
    {
        protected override PDV Create(Type objectType, JObject jsonObject)
        {
            int typeName = Int32.Parse((jsonObject["type"]).ToString());
            switch (typeName)
            {
                case 1:
                    return CroatianPDV.getInstance();
                default:
                    return null;
            }
        }
    }
}
