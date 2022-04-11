using GraphQL.Types;
using HealthChecker.Entities;

namespace HealthChecker.GraphQL.GraphQLTypes
{
    public class ServerErrorType: ObjectGraphType<ServerError>
    {
        public ServerErrorType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property of error oject");
            Field(x => x.Status).Description("Status property of error");
            Field(x => x.Body).Description("Body property of error");
            Field(x => x.ServerId, type: typeof(IdGraphType)).Description("ForeignKey property");
        }
    }
}
