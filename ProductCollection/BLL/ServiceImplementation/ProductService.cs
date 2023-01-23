using System.Dynamic;

namespace BLL.ServiceImplementation;

public class ProductService<T> : List<ExpandoObject>
{
    public ProductService(IEnumerable<T> source, params string[] properties)
    {
        if (properties.Length == 0)
        {
            properties = typeof(T).GetProperties().Select(p => p.Name).ToArray();
        }

        foreach (var item in source)
        {
            var expando = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)expando;

            foreach (var property in properties)
            {
                var value = item.GetType().GetProperty(property)?.GetValue(item);
                if (value != null)
                {
                    dictionary.Add(property, value);
                }
            }

            Add(expando);
        }
    }
}
