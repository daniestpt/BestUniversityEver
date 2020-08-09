using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BestUniversityEver.Hubs.Course
{
    [HubName("courseHub")]
    public class CourseHub : Hub<ICourseCallbacks>
    {
        public async Task AddCourse(Models.Course newCourse)
        {
            // All connected clients will receive this call
            await Clients.All.BroadcastNewCourse(newCourse);
        }

        public async Task RemoveCourse(int courseId)
        {            
            // All connected clients will receive this call
            await Clients.All.BroadcastRemoveCourse(courseId);
            
        }
    }


}