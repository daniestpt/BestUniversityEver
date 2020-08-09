app.controller("courseListController",
     ['$scope', 'CourseService', '$window', '$routeParams',
        function ($scope, CourseService, $window, $routeParams) {

        GetAllCourses();

        //Get All Courses
        function GetAllCourses() {
            var getData = CourseService.getCourses();
            getData.then(function (pst) {
                $scope.courses = pst.data;
            }, function () {
                $scope.message = 'Unable to load Course data: ' + error.message;
            });
        }

        //Delete Course
        $scope.deleteCourse = function (CourseID) {
            var getData = CourseService.Delete(CourseID);            
            getData.then(function (msg) {
                $scope.message = 'Course Successfully Deleted.';
                CourseService.getCourses();
            }, function () {
                $scope.message = 'Unable to delete Course: ' + error.message;
            });
        }
    }]);

app.controller("courseController",
     ['$scope', 'CourseService', '$window', '$routeParams',
    function ($scope, CourseService, $window, $routeParams) {

        //Get Course by CourseId
        $scope.course = {};
        if ($routeParams.id) {
            var getData = CourseService.getCourse($routeParams.id);
            getData.then(function (pst) {
                $scope.course = pst.data;
                $scope.CourseID = pst.data.CourseID;
                $scope.Title = pst.data.Title;
                $scope.TeachersCount = pst.data.TeachersCount;
            }, function () {
                $scope.message = 'Unable to load course data: ' + error.message;
            });
        }
        //Add or Update Course
        $scope.AddUpdateCourse = function () {
            var Course = {
                Title: $scope.Title,          
                CourseID: $scope.CourseID
            };
            if (Course.CourseID != null) { //Update Course
                var getData = CourseService.updateCourse(Course);
                getData.then(function (msg) {
                    $window.location = "#/course";
                    $scope.message = 'Course Successfully Updated.';
                }, function () {
                        $scope.message = 'Unable to update Course: ' + error.message;
                });
            } else { //Add Course
                var getData = CourseService.newCourse(Course);
                getData.then(function (msg) {
                    $window.location = "#/course";
                    $scope.message = 'Course Successfully Created.';
                }, function () {
                        $scope.message = 'Unable to create new Course: ' + error.message;
                });
            }
        }

    }]);

app.controller("tagsController", function ($scope, TagsService) {
    GetAllTags();
    //Get All Tags  
    function GetAllTags() {
        var getData = TagsService.getPosts()
        getData.then(function (tags) {
            $scope.tags = tags.data;
        }, function () {
            $scope.message = 'Unable to load tags: ' + error.message;
        });
    }
});