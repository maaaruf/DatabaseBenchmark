using DatabaseBenchmark.Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Web.Models
{
    public class JsonObjectModel : BaseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IList<JsonObject> Jsons { get; set; }


        public void generateJsonData(int count)
        {
            Jsons = new List<JsonObject>();

            while (count > 0)
            {
                string data = ObjectToJsonConverter.JsonConverter(
                    randomDataGenerator.generate50Products()
                    );

                JsonObject jsonObject = new JsonObject { Key = "Key - " + Guid.NewGuid(), Value = data };
                Jsons.Add(jsonObject);
                count--;
            }
        }
    }
}
