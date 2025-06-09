using MediatR;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Common.Models.Pagination;
using Dapper;
using System.Data;

namespace NoobGGApp.Application.Features.Games.Queries.GetAllDapper;

public sealed class GetAllGamesDapperQueryHandler : IRequestHandler<GetAllGamesDapperQuery, PaginatedList<GetAllGamesDapperDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAllGamesDapperQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<PaginatedList<GetAllGamesDapperDto>> Handle(GetAllGamesDapperQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("search_keyword", request.SearchKeyword);
        parameters.Add("page_number", request.PageNumber);
        parameters.Add("page_size", request.PageSize);
        parameters.Add("is_ascending", request.IsAscending);

        var totalCount = await connection.QueryFirstOrDefaultAsync<int>(
            "get_games_total_count",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        var items = await connection.QueryAsync<GetAllGamesDapperDto>(
            "get_all_games",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return new PaginatedList<GetAllGamesDapperDto>(items.ToList(), totalCount, request.PageNumber, request.PageSize);
    }
}


