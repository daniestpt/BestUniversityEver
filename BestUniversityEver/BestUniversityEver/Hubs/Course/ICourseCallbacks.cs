using System.Threading.Tasks;

namespace BestUniversityEver.Hubs.Course
{
    // Client callbacks
    public interface ICourseCallbacks
    {
        // Notify note added
        Task BroadcastNewCourse(Models.Course newCourse);
        // Notify note removed
        Task BroadcastRemoveCourse(int courseId);
    }
}