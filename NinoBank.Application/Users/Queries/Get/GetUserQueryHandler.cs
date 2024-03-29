using AutoMapper;
using MediatR;
using NinoBank.Application.Models;
using NinoBank.Application.ResultWrappers.Generic;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;

namespace NinoBank.Application.Users.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ResultWrapper<GetUserDTO>>
    {
        IUserReadRepository _userReadRepository;
        IMapper _mapper;

        public GetUserQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userReadRepository = userReadRepository;
        }

        public async Task<ResultWrapper<GetUserDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            var user = await _userReadRepository.GetDetailsAsync(request.Id);

            var result = _mapper.Map<GetUserDTO>(user);

            return ResultWrapper<GetUserDTO>.Ok(result);
        }
    }
}
