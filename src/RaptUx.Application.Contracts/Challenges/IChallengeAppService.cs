using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RaptUx.Challenges;

public interface IChallengeAppService
    : ICrudAppService<
        ChallengeDto, 
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateChallengeDto
    >
{
    
}