using Newtonsoft.Json.Linq;

namespace GameStore.Models.IGDB
{
    public class IdentitiesOrValues<T> where T : class
    {
        public long[] Ids { get; private set; }

        public T[] Values { get; private set; }

        public IdentitiesOrValues()
        {
        }

        public IdentitiesOrValues(long[] ids)
        {
            Ids = ids;
        }

        public IdentitiesOrValues(object[] values)
        {
            var list = values.Select(value => (T)value).ToArray();
            Values = list;
        }
    }
}
