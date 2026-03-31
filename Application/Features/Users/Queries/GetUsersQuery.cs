using Application.Dtos.Users;
using Application.Interfaces.Respositories;
using Domain.Entities.Users;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries;

public class GetUsersQuery:IRequest<Result<List<GetUserDto>>>
{

}

internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<List<GetUserDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUsersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<GetUserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.Repository<User>().GetAllAsync();

        var result = users.Select(x => new GetUserDto
        {
            Id = x.Id,
            Name=x.Name,
            Email=x.Email,
            MobileNo=x.MobileNo,
            CreatedDate=x.CreatedDate,
            UpdatedDate=x.UpdatedDate,
        }).ToList();

        return Result<List<GetUserDto>>.Success(result, "Users");
    }
}