namespace WorkShopGL.Shared.Results
{
    public static class ObjectMapper
    {
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            if (source == null)
                return default!;

            var target = new TTarget();

            var sourceProps = typeof(TSource).GetProperties();
            var targetProps = typeof(TTarget).GetProperties();

            foreach (var tProp in targetProps)
            {
                var sProp = sourceProps.FirstOrDefault(x =>
                    x.Name.Equals(tProp.Name, StringComparison.OrdinalIgnoreCase) &&
                    x.PropertyType == tProp.PropertyType);

                if (sProp == null)
                    continue;

                var value = sProp.GetValue(source);
                tProp.SetValue(target, value);
            }

            return target;
        }

        public static List<TTarget> MapList<TSource, TTarget>(IEnumerable<TSource> source) where TTarget : new()
        {
            if (source == null)
                return new List<TTarget>();

            return source.Select(item => Map<TSource, TTarget>(item)).ToList();
        }

    }

}
