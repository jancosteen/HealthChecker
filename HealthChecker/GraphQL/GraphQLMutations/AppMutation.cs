using GraphQL;
using GraphQL.Types;
using HealthChecker.Contracts;
using HealthChecker.Entities;
using HealthChecker.GraphQL.GraphQLTypes;

namespace HealthChecker.GraphQL.GraphQLMutations
{
    public class AppMutation: ObjectGraphType
    {
        public AppMutation(IServerRepository repository)
        {
            Field<ServerType>(
                "updateVisibleFlg",
                arguments: new QueryArguments(
                        //new QueryArgument<NonNullGraphType<ServerInputType>> { Name = "server"},
                        new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "serverId"}
                    ),
                resolve: context =>
                {
                    //var server = context.GetArgument<Server>("server");
                    var serverId = context.GetArgument<string>("serverId");

                    var dbServer = repository.GetById(serverId);
                    if(dbServer == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find server in db"));
                        return null;
                    }

                    return repository.UpdateServer(dbServer);
                }
                ); ;
        }
    }
}
