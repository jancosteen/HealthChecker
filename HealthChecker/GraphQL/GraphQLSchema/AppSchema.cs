using GraphQL.Types;
using GraphQL.Utilities;
using HealthChecker.GraphQL.GraphQLQueries;
using System;

namespace HealthChecker.GraphQL.GraphQLSchema
{
    public class AppSchema: Schema
    {
        public AppSchema(IServiceProvider provider): base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();

        }
    }
}
