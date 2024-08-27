using Sapphire.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service
{
    public class DataShaper<T> : IDataShaper<T> where T : class
    {
        public PropertyInfo[] Props {  get; set; }
        public DataShaper() { 
            Props  = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entity, string fieldsString)
        {
            var requiredProps = GetRequiredProps(fieldsString);

            return FetchData(entity, requiredProps);
        }

        public ExpandoObject ShapeData(T entity, string fieldsString)
        {
            var requiredProps = GetRequiredProps(fieldsString);

            return FetchDataForEntity(entity, requiredProps);
        }
        private IEnumerable<PropertyInfo> GetRequiredProps(string fieldsString) { 
            var requiredProp = new List<PropertyInfo>();

            if (!string.IsNullOrWhiteSpace(fieldsString))
            {
                var field = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in field)
                {
                    var prop = Props.FirstOrDefault(el => el.Name.Equals(item.Trim(), StringComparison.InvariantCultureIgnoreCase));

                    if (prop is null)
                        continue;

                    requiredProp.Add(prop);
                }
            }
            else
            {
                requiredProp = Props.ToList();
            }
            return requiredProp;
        }
        private IEnumerable<ExpandoObject>  FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProps)
        {
            var shapedField = new List<ExpandoObject>();

            foreach(var a in entities)
            {
                var shapedObj = FetchDataForEntity(a, requiredProps);
                shapedField.Add(shapedObj);
            }
            return shapedField;
        }
        private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProps)
        {
            var shapedObject = new ExpandoObject();
            foreach(var prop in requiredProps)
            {
                var objectPropValue = prop.GetValue(entity);
                shapedObject.TryAdd(prop.Name, objectPropValue);
            }
            return shapedObject;
        }

    }
}
