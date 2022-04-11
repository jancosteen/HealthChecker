using GraphQL.Types;
using HealthChecker.Contracts;
using HealthChecker.Entities;
using System;

namespace HealthChecker.GraphQL.GraphQLTypes
{
    public class ServerType: ObjectGraphType<Server>
    {
        public ServerType(IServerErrorRepository repository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property of server");
            Field(x => x.Name).Description("Name property of server");
            Field(x => x.HealthCheckUri).Description("HealthCheckUri property of server");
            Field(x => x.LastTimeUp, nullable: true).Description("Last Time the server was up");
            Field(x => x.Status).Description("HealtCheck status of server");
            Field<ListGraphType<ServerErrorType>>(
                "errors",
                resolve: context => repository.GetAllServerErrorsPerServer(context.Source)
                );
        }
    }
}
