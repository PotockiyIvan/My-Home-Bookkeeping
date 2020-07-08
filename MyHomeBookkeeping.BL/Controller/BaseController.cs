using MyHomeBookkeeping.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MyHomeBookkeeping.BL.Controller
{
    public abstract class BaseController
    {
        /// <summary>
        /// Базовая Сериализация.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="item"></param>
        protected void  Save<T>(string fileName,List<T> item) where T : class
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        /// <summary>
        /// Базовая десериализация.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
        /// <param name="fileName">Имя файла.</param>
        /// <returns></returns>
        protected T Load<T>(string fileName) 
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T item)
                    return item;
                else
                    return default(T);
            }
        }
    }
}
