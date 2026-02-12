using Microsoft.Data.SqlClient;

namespace WorkShopGL.Shared.Results
{
    public static class DataReaderExtensions
    {
        public static T MapTo<T>(this SqlDataReader rd) where T : new()
        {
            var obj = new T();
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                if (!HasColumn(rd, prop.Name)) continue;

                var val = rd[prop.Name];

                if (val == DBNull.Value) continue;

                prop.SetValue(obj, Convert.ChangeType(val, prop.PropertyType));
            }

            return obj;
        }

        private static bool HasColumn(SqlDataReader rd, string name)
        {
            for (int i = 0; i < rd.FieldCount; i++)
                if (rd.GetName(i).Equals(name, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }
    }

}
