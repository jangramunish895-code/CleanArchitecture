using Application.Commons.Mappings.Commons;
using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.Users;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Features.Users.Commands;

public class CreateUserCommand:IRequest<Result<int>>,ICreateMapFrom<User>
{
    [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
    public string Name { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }
    [Required]
    public long MobileNo { get; set; }
}

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ITokenDecodeService _tokenDecodeService;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenDecodeService tokenDecodeService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _tokenDecodeService = tokenDecodeService;
    }

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        int userId = _tokenDecodeService.GetUserId();

        var user = _mapper.Map<User>(request);

        await _unitOfWork.Repository<User>().CreateAsync(user);
        await _unitOfWork.Save(cancellationToken);

        return Result<int>.Success(user.Id, "User Created Successfully");
    }
}