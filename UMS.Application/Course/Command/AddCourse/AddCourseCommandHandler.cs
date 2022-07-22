using AutoMapper;
using MediatR;
using NpgsqlTypes;
using UMS.Application.DTO;
using UMS.Domain.Models;
using UMS.Infrastructure.Abstraction.MailServices;
using UMS.Persistence;

namespace UMS.Application.Course.Command.AddCourse;

public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, CourseDTO>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;
    private readonly IMailServicess _mailService;

    public AddCourseCommandHandler(UmsContext umsContext, IMapper mapper, IMailServicess mailService)
    {
        _umsContext = umsContext;
        _mapper = mapper;
        _mailService = mailService;
    }

    public async Task<CourseDTO> Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        NpgsqlRange<DateOnly>? enrolmentDateRange = new NpgsqlRange<DateOnly>(
            DateOnly.FromDateTime(request.EnrolmentDateRangeL), DateOnly.FromDateTime(request.EnrolmentDateRangeU));
        Domain.Models.Course course = new Domain.Models.Course();
        {
            course.Name = request.Name;
            course.MaxStudentsNumber = request.MaxStudentsNumber;
            course.EnrolmentDateRange = enrolmentDateRange;
        };
        try
        {
            _umsContext.Courses.Add(course);
            await _umsContext.SaveChangesAsync(cancellationToken);
            var subscribers = _umsContext.Users.Where(obj => obj.Subscribe == true).ToList();
            foreach (var subscriber in subscribers)
            {
                await _mailService.SendEmailAsync(new MailRequest()
                {
                    ToEmail = subscriber.Email,
                    Subject = "New Course Available",
                    Body = $"Dear {subscriber.Name}," +
                           $"\n" +
                           $"Kindly note that a new course has been added and it's available for registration." +
                           $"\n" +
                           $"Thank you."
                });
            }

            return _mapper.Map<CourseDTO>(course);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}