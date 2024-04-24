using System;
using RaptUx.Entities.ChallengeEntities;
using RaptUx.Permissions.Challenges;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Challenges;

public class ChallengeAppService
    : CrudAppService<
        ChallengeEntity, 
        ChallengeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateChallengeDto
    >, IChallengeAppService
{
    public ChallengeAppService(IRepository<ChallengeEntity, Guid> repository) : base(repository)
    {
        CreatePolicyName = ChallengePermission.Challenges.Create;
        UpdatePolicyName = ChallengePermission.Challenges.Edit;
        DeletePolicyName = ChallengePermission.Challenges.Delete;
    }
}