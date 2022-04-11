using GraphQL.Types;
using HealthChecker.Contracts;
using HealthChecker.GraphQL.GraphQLTypes;

namespace HealthChecker.GraphQL.GraphQLQueries
{
    public class AppQuery: ObjectGraphType
    {
        public AppQuery(IServerRepository repository)
        {
            Field<ListGraphType<ServerType>>(
                "servers",
                resolve: context => repository.GetAll()
            );
        }
    }
}
