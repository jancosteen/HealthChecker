using GraphQL;
using GraphQL.Types;
using HealthChecker.Contracts;
using HealthChecker.GraphQL.GraphQLTypes;
using System.Collections.Generic;

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

            Field<ServerType>(
                "server",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    return repository.GetByName(name);
                }
                );

            Field<ListGraphType<ServerType>>(
                "serversByStatus",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "status" }),
                resolve: context =>
                {
                    var status = context.GetArgument<string>("status");
                    return repository.GetServersByStatus(status);
                });
        }
    }
}
