using System;
using System.Threading.Tasks;
using RaptUx.Entities.ChallengeEntities;
using RaptUx.Entities.CoursesEntities;
using RaptUx.Entities.GradeEntities;
using RaptUx.Entities.ProjectEntities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Entities;

public class RaptUxDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<CourseEntity> _courseRepository;
    private readonly IRepository<GradeEntity> _gradeRepository;
    private readonly IRepository<ProjectEntity> _projectRepository;
    private readonly IRepository<ChallengeEntity> _challengeRepository;

    public RaptUxDataSeedContributor(IRepository<CourseEntity> courseRepository, IRepository<GradeEntity> gradeRepository, IRepository<ProjectEntity> projectRepository, IRepository<ChallengeEntity> challengeRepository)
    {
        _courseRepository = courseRepository;
        _gradeRepository = gradeRepository;
        _projectRepository = projectRepository;
        _challengeRepository = challengeRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var firstCourse = new CourseEntity
        {
            Title = "Course 1",
            Description = "Course 1 Description",
            Link = "https://www.course1.com",
            ImageUrl = "https://www.course1.com/image.jpg"
        };
        
        var secondCourse = new CourseEntity
        {
            Title = "Course 2",
            Description = "Course 2 Description",
            Link = "https://www.course2.com",
            ImageUrl = "https://www.course2.com/image.jpg"
        };
        
        var thirdCourse = new CourseEntity
        {
            Title = "Course 3",
            Description = "Course 3 Description",
            Link = "https://www.course3.com",
            ImageUrl = "https://www.course3.com/image.jpg"
        };
        
        var firstChallenge = new ChallengeEntity
        {
            Title = "Challenge 1",
            ImageUrl = "https://www.challenge1.com/image.jpg",
            Description = "Challenge 1 Description",
            Category = "Category 1",
            Context = "Context 1",
            Courses = [firstCourse, secondCourse, thirdCourse],
            Details = "Details 1",
            UserIds = [new Guid("3ff02ff4-1126-ff14-2d89-3a119259915f")]
        };
        
        var secondChallenge = new ChallengeEntity
        {
            Title = "Challenge 2",
            ImageUrl = "https://www.challenge2.com/image.jpg",
            Description = "Challenge 2 Description",
            Category = "Category 2",
            Context = "Context 2",
            Courses = [firstCourse, secondCourse],
            Details = "Details 2",
            UserIds = [new Guid("3ff02ff4-1126-ff14-2d89-3a119259915f")]
        };
        
        var thirdChallenge = new ChallengeEntity
        {
            Title = "Challenge 3",
            ImageUrl = "https://www.challenge3.com/image.jpg",
            Description = "Challenge 3 Description",
            Category = "Category 3",
            Context = "Context 3",
            Courses = [firstCourse],
            Details = "Details 3",
            UserIds = [new Guid("3ff02ff4-1126-ff14-2d89-3a119259915f")]
        };
        
        var firstProject = new ProjectEntity
        {
            OwnerId = new Guid("3ff02ff4-1126-ff14-2d89-3a119259915f"),
            Description = "Project 1 Description",
            Likes = 6543,
            Link = string.Empty,
            ImageBase64 = string.Empty,
            ChallengeId = firstChallenge.Id,
            Challenge = firstChallenge
        };
        
        var secondProject = new ProjectEntity
        {
            OwnerId = new Guid("3ff02ff4-1126-ff14-2d89-3a119259915f"),
            Description = "Project 2 Description",
            Likes = 0,
            Link = string.Empty,
            ImageBase64 = string.Empty,
            ChallengeId = secondChallenge.Id,
            Challenge = secondChallenge
        };
        
        var thirdProject = new ProjectEntity
        {
            OwnerId = new Guid("3ff02ff4-1126-ff14-2d89-3a119259915f"),
            Description = "Project 3 Description",
            Likes = 45,
            Link = string.Empty,
            ImageBase64 = string.Empty,
            ChallengeId = thirdChallenge.Id,
            Challenge = thirdChallenge
        };
        
        if (await _gradeRepository.GetCountAsync() <= 0)
        {
            await _gradeRepository.InsertAsync(
                new GradeEntity
                {
                    Title = "Grade 1",
                    Description = "Grade 1 Description"
                },
                autoSave: true
            );
            
            await _gradeRepository.InsertAsync(
                new GradeEntity
                {
                    Title = "Grade 2",
                    Description = "Grade 2 Description"
                },
                autoSave: true
            );
            
            await _gradeRepository.InsertAsync(
                new GradeEntity
                {
                    Title = "Grade 3",
                    Description = "Grade 3 Description"
                },
                autoSave: true
            );
            
            await _gradeRepository.InsertAsync(
                new GradeEntity
                {
                    Title = "Grade 4",
                    Description = "Grade 4 Description"
                },
                autoSave: true
            );
        }

        if (await _courseRepository.GetCountAsync() <= 0)
        {
            await _courseRepository.InsertAsync(firstCourse, autoSave: true);
            await _courseRepository.InsertAsync(secondCourse, autoSave: true);
            await _courseRepository.InsertAsync(thirdCourse, autoSave: true);
        }
        
        if (await _challengeRepository.GetCountAsync() <= 0)
        {
            await _challengeRepository.InsertAsync(firstChallenge, autoSave: true);
            await _challengeRepository.InsertAsync(secondChallenge, autoSave: true);
            await _challengeRepository.InsertAsync(thirdChallenge, autoSave: true);
        }
        
        if (await _projectRepository.GetCountAsync() <= 0)
        {
            await _projectRepository.InsertAsync(firstProject, autoSave: true);
            await _projectRepository.InsertAsync(secondProject, autoSave: true);
            await _projectRepository.InsertAsync(thirdProject, autoSave: true);
        }
    }
}