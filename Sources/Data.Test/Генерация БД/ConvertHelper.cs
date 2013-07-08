using System;

namespace Data.Test.Генерация_БД
{
    public static class ConvertHelper
    {
        public static Nullable<DateTime> ToNullableDateTime(this string value)
        {
            value = value.Trim();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return Convert.ToDateTime(value);
        }
    }
}
