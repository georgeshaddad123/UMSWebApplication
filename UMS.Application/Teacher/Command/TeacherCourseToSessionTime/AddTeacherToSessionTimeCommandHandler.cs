using AutoMapper;
using MediatR;
using UMS.Domain.Models;
using UMS.Infrastructure.Abstraction.MailServices;
using UMS.Persistence;

namespace UMS.Application.Teacher.Command.TeacherCourseToSessionTime;

public class AddTeacherToSessionTimeCommandHandler : IRequestHandler<AddTeacherToSessionTimeCommand, TeacherPerCoursePerSessionTime>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;
    private readonly IMailServicess _mailServicess;

    public AddTeacherToSessionTimeCommandHandler(UmsContext umsContext, IMapper mapper, IMailServicess mailServicess)
    {
        _umsContext = umsContext;
        _mapper = mapper;
        _mailServicess = mailServicess;
    }

    public async Task<TeacherPerCoursePerSessionTime> Handle(AddTeacherToSessionTimeCommand request, CancellationToken cancellationToken)
    {
        TeacherPerCoursePerSessionTime teacherPerCoursePerSessionTime = new TeacherPerCoursePerSessionTime();
        teacherPerCoursePerSessionTime.TeacherPerCourseId = request.TeacherPerCId;
        teacherPerCoursePerSessionTime.SessionTimeId = request.SessionTId;
        await _umsContext.TeacherPerCoursePerSessionTimes.AddAsync(teacherPerCoursePerSessionTime, cancellationToken);
        await _umsContext.SaveChangesAsync(cancellationToken);
        var subscribers = _umsContext.Users.Where(obj => obj.Subscribe == true).ToList();
        foreach (var subscriber in subscribers)
        {
            await _mailServicess.SendEmailAsync(new MailRequest()
            {
                ToEmail = subscriber.Email,
                Subject = $"New Schedule for the course",
                Body = $"Dear {subscriber.Name}, \n" +
                       $"Kindly note that this course has a new schedule. \n" +
                       $"Thank you."
            });
        }
        return teacherPerCoursePerSessionTime;
    }
}