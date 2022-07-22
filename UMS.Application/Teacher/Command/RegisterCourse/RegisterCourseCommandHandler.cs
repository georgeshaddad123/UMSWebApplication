using AutoMapper;
using MediatR;
using UMS.Application.DTO;
using UMS.Domain.Models;
using UMS.Infrastructure.Abstraction.MailServices;
using UMS.Persistence;

namespace UMS.Application.Teacher.Command.RegisterCourse;

public class RegisterCourseCommandHandler : IRequestHandler<RegisterCourseCommand, TeacherDTO>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;
    private readonly IMailServicess _mailService;

    public RegisterCourseCommandHandler(UmsContext umsContext, IMapper mapper, IMailServicess mailService)
    {
        _umsContext = umsContext;
        _mapper = mapper;
        _mailService = mailService;
    }

    public async Task<TeacherDTO> Handle(RegisterCourseCommand request, CancellationToken cancellationToken)
    {
        TeacherPerCourse newTeacherPerCourse = new TeacherPerCourse()
        {
            TeacherId = request.TeacherId,
            CourseId = request.CourseId
        };
        try
        {
            await _umsContext.TeacherPerCourses.AddAsync(newTeacherPerCourse, cancellationToken);
            await _umsContext.SaveChangesAsync(cancellationToken);
            var course = _umsContext.Courses.FirstOrDefault(obj => obj.Id == newTeacherPerCourse.CourseId);
            var subscribers = _umsContext.Users.Where(obj => obj.Subscribe == true).ToList();
            foreach (var subscriber in subscribers)
            {
                await _mailService.SendEmailAsync(new MailRequest()
                {
                    ToEmail = subscriber.Email,
                    Subject = $"New Teacher for the course {course.Name}",
                    Body = $"Dear {subscriber.Name}, \n" +
                           $"Kindly note that a new teacher gives this course. \n" +
                           $"Thank you."
                });
            }

            return _mapper.Map<TeacherDTO>(newTeacherPerCourse);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}