using Application.Dtos.Users;
using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.Users;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries;

public class GetUsersQuery:IRequest<Result<List<GetUserDto>>>
{

}

internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<List<GetUserDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetUserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users =await _unitOfWork.Repository<User>().Entities
                            .ToListAsync();

        var result = _mapper.Map<List<GetUserDto>>(users);

        return Result<List<GetUserDto>>.Success(result, "Users");
    }
}