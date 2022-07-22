using AutoMapper;
using MediatR;
using UMS.Domain.Models;
using UMS.Persistence;

namespace UMS.Application.Student.Command.EnrollStudent;

public class EnrollstudentCommandHandler : IRequestHandler<EnrollStudentCommand, ClassEnrollment>
{
    private readonly UmsContext _umsContext;
    private readonly IMapper _mapper;

    public EnrollstudentCommandHandler(UmsContext umsContext, IMapper mapper)
    {
        _umsContext = umsContext;
        _mapper = mapper;
    }

    public async Task<ClassEnrollment> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Models.ClassEnrollment enrollment = new Domain.Models.ClassEnrollment();
            enrollment.ClassId = request.CourseId;
            enrollment.StudentId = request.StudentId;
            await _umsContext.ClassEnrollments.AddAsync(enrollment, cancellationToken);
            await _umsContext.SaveChangesAsync(cancellationToken);
            return enrollment;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}