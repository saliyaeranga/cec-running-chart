using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace CECRunningChart.Services
{
    public static class ConversionHelper
    {
        public static object ConvertToValueType(object valueToConvert, Type newType)
        {
            if (valueToConvert == null || valueToConvert == DBNull.Value)
                return null;

            return Convert.ChangeType(valueToConvert, newType, CultureInfo.InvariantCulture);
        }

        /*
         * 
        public static Collection<T> GetObjectCollection<T>(DataSet ds, string elementName)
        {
            Collection<T> list = new Collection<T>();
            string xml = ds.GetXml();
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            var nodes = doc.SelectNodes(elementName);
            foreach (XmlNode item in nodes)
            {
                T t = ConvertToObject<T>(item.OuterXml);
                list.Add(t);
            }

            return list;
        }

        public static T ConvertToObject<T>(string xml)
        {
            Type type = typeof(T);
            StringReader reader = new StringReader(xml);
            XmlSerializer serializer = new XmlSerializer(type);
            T t = (T)serializer.Deserialize(reader);
            return t;
        }

        */

        public static List<T> ConvertToList<T>(DataSet dataSet) where T : new()
        {
            return ConvertToList<T>(dataSet.Tables[0]);
        }

        public static List<T> ConvertToList<T>(DataSet dataSet, string tableName) where T : new()
        {
            return ConvertToList<T>(dataSet.Tables[tableName]);
        }

        public static List<T> ConvertToList<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T newObject = ConvertToObject<T>(row);
                list.Add(newObject);
            }
            return list;
        }

        public static T ConvertToObject<T>(DataRow row) where T : new()
        {
            Type type = typeof(T);

            T newObject = new T();
            foreach (var property in type.GetProperties())
            {
                XmlElementAttribute[] attrbutes = (XmlElementAttribute[])property.GetCustomAttributes(typeof(XmlElementAttribute), true);
                if (attrbutes.Length > 0)
                {
                    string columnName = attrbutes[0].ElementName;
                    if (row.Table.Columns.Contains(columnName) &&
                          !row.IsNull(columnName))
                    {
                        object columnValue = row[columnName];
                        if (columnValue.GetType() == property.PropertyType)
                        {
                            property.SetValue(newObject, columnValue, null);
                        }
                        else
                        {
                            object convertedValue = ConvertToValueType(columnValue, property.PropertyType);
                            property.SetValue(newObject, convertedValue, null);
                        }
                    }
                }
            }

            return newObject;
        }
        //public static T ConvertToObject<T>(DataRow row) where T : new()
        //{
        //    Type type = typeof(T);
        //    T newObject = new T();

        //    foreach (var property in type.GetProperties())
        //    {
        //        System.Xml.Serialization.XmlElementAttribute[] attributes = (XmlElementAttribute[])property.GetCustomAttributes(typeof(T), true);
        //        if (attributes.Length > 0)
        //        {
        //            string columnName = attributes[0].ElementName;
        //            if (row.Table.Columns.Contains(columnName) && !row.IsNull(columnName))
        //            {
        //                object columnValue = row[columnName];
        //                if (columnValue.GetType() == property.PropertyType)
        //                {
        //                    property.SetValue(newObject, columnValue, null);
        //                }
        //                else
        //                {
        //                    object convertedValue = ConvertToValueType(columnValue, property.PropertyType);
        //                    property.SetValue(newObject, convertedValue, null);
        //                }
        //            }
        //        }
        //    }

        //    return newObject;
        //}
    }
}
