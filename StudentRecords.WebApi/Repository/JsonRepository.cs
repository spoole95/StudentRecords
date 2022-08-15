using System.IO;
using System.Text.Json;

namespace StudentRecords.WebApi.Repository
{
    //Don't like having to read/write whole files, but it is the simplest option.
    //https://www.c-sharpcorner.com/article/crud-operation-with-json-file-data-in-c-sharp/


    /// <summary>
    /// Base class of json file based repository
    /// </summary>
    public abstract class JsonRepository
    {
        private readonly string filePath;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Path to the repository file</param>
        public JsonRepository(string filePath)
        {
            this.filePath = filePath;
        }


        /// <summary>
        /// Gets all T from the repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T Get<T>()
        {
            string fileString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(fileString);
        }

        protected void UpdateList<T>(T list)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(list, new JsonSerializerOptions
            {
                WriteIndented = true, //Write indented otherwise humans stand no chance of reading again.
                IgnoreNullValues = true, //Null values not needed to be stored
            }));
        }
    }
}
