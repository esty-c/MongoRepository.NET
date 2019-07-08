using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository.Infrastructure.Model
{
    public class Hierarchies2<T> where T : class
    {

        public List<string> GrandChilds()
        {
            List<string> list = new List<string>();
            Type parentType = typeof(T);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> subclasses = types.Where(t => t.IsSubclassOf(parentType));
            //with grand child
            foreach (Type type in subclasses)
            {
                list.Add(type.Name);
            }
            return list;
        }


        public List<string> Childs()
        {
            List<string> list = new List<string>();
            Type parentType = typeof(T);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> subclasses = types.Where(t => t.BaseType == parentType);
            //with grand child
            foreach (Type type in subclasses)
            {
                //var ss=  type.BaseType.Name;
                Console.WriteLine(type.Name);
                list.Add(type.Name);
            }

            return list;
        }
    }
}
