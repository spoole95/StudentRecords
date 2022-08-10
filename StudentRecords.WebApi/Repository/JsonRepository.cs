using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StudentRecords.WebApi.Repository
{

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
    }
}
