using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using HealthChecker.Entities;

namespace HealthChecker.GraphQL
{


    public class ServerType1 : ObjectGraphType<Server>
    {
        public ServerType1()
        {
            Name = "Server";
            Description = "A server to monitor";

            Field(h => h.Id);
            Field(h => h.Name);
            Field(h => h.HealthCheckUri);

            Field<StringGraphType>(
                "status",
                // TODO: replace with health check code
                resolve: context => "OFFLINE"
            );
        }
    }

    public class HealthCheckerQuery : ObjectGraphType<object>
    {
        private List<Server> servers = new List<Server>{
            new Server{
                Id = "1",
                Name = "stackworx.io",
                HealthCheckUri = "https://www.stackworx.io",
            },
            new Server{
                Id = "2",
                Name = "prima.run",
                HealthCheckUri = "https://prima.run",
            },
            new Server{
                Id = "3",
                Name = "google",
                HealthCheckUri = "https://www.google.com",
            },
        };

        private List<ServerError> errors = new List<ServerError>
        {
            new ServerError
            {
                Id = "1",
                ServerId = "1"
            },
            new ServerError
            {
                Id = "2",
                ServerId = "2"
            },
            new ServerError
            {
                Id = "3",
                ServerId = "3"
            },
        };

        public HealthCheckerQuery()
        {
            Name = "Query";


            Func<ResolveFieldContext, string, object> serverResolver = (context, id) => this.servers;

            FieldDelegate<ListGraphType<ServerType1>>(
                "servers",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id", Description = "id of server" }
                ),
                resolve: serverResolver
            );

            Field<StringGraphType>(
                "hello",
                resolve: context => "world"
            );
        }
    }

    public class HealthCheckerSchema : Schema
    {
        public HealthCheckerSchema(IServiceProvider provider) : base(provider)
        {
            Query = new HealthCheckerQuery();
        }
    }
}
