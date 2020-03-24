
using System;
using System.Linq;
using System.Reflection;


namespace OF.BasicMapper
{
    public class BasicMapper : IBasicMapper
    {

        public T MapFields<T>(object from, object to)
        {
            Type fromType = from.GetType(); PropertyInfo[] fromProps = fromType.GetProperties();
            Type toType = to.GetType(); PropertyInfo[] toProps = toType.GetProperties();

            string[] common = toProps.Select(x => x.Name).Intersect(fromProps.Select(x => x.Name)).ToArray();

            foreach (string prop in common)
            {
                var val = fromType.GetProperty(prop).GetValue(from);
                toType.GetProperty(prop).SetValue(to, val);
            }
            return (T)to;
        }

        public T MapFields<T>(object from, object to, System.Collections.Generic.List<string> skip)
        {
            Type fromType = from.GetType(); PropertyInfo[] fromProps = fromType.GetProperties();
            Type toType = to.GetType(); PropertyInfo[] toProps = toType.GetProperties();

            string[] common = toProps.Select(x => x.Name).Intersect(fromProps.Select(x => x.Name)).Except(skip).ToArray();

            foreach (string prop in common)
            {
                var val = fromType.GetProperty(prop).GetValue(from);
                toType.GetProperty(prop).SetValue(to, val);
            }
            return (T)to;
        }
        public T MapFields<T>(object from)
        {
            var to = Activator.CreateInstance(typeof(T));
            return MapFields<T>(from, to);
        }

        public T MapFields<T>(object from, System.Collections.Generic.List<string> skip)
        {
            var to = Activator.CreateInstance(typeof(T));
            return MapFields<T>(from, to, skip);
        }
    }
}