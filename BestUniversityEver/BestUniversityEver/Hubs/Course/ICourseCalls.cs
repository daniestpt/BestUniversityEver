using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestUniversityEver.Hubs.Course
{
    // Client calls
    public interface ICourseCalls
    {
        // Add note
        Task AddCourse(Models.Course course);
     
        // Remove note
        Task RemoveCourse(int courseId);
    }
}