app.controller("teacherListController",
     ['$scope', 'TeacherService', '$window', '$routeParams',
    function ($scope, TeacherService, $window, $routeParams) {

        GetAllTeachers();

        //Get All Teacher
        function GetAllTeachers() {
            var getData = TeacherService.getTeachers();
            getData.then(function (pst) {
                $scope.teachers = pst.data;
            }, function () {
                $scope.message = 'Unable to load Teacher data: ' + error.message;
            });
        }

        //Delete Teacher
        $scope.deleteTeacher = function (TeacherID) {
            var getData = TeacherService.Delete(TeacherID);            
            getData.then(function (msg) {
                $scope.message = 'Teacher Successfully Deleted.';                
            }, function () {
                $scope.message = 'Unable to delete Teacher: ' + error.message;
            });
        }
    }]);

app.controller("teacherController",
     ['$scope', 'TeacherService', '$window', '$routeParams',
    function ($scope, TeacherService, $window, $routeParams) {

        //Get Teacher by TeacherId
        $scope.teacher = {};
        if ($routeParams.id) {
            var getData = TeacherService.getTeacher($routeParams.id);
            getData.then(function (pst) {
                $scope.teacher = pst.data;
                $scope.TeacherID = pst.data.TeacherID;
                $scope.Salary = pst.data.Salary;
                $scope.FirstName = pst.data.FirstName;    
                $scope.LastName = pst.data.LastName;     
                $scope.BirthDay = pst.data.BirthDay;     
            }, function () {
                $scope.message = 'Unable to load teacher data: ' + error.message;
            });
        }
        //Add or Update teacher
        $scope.AddUpdateTeacher = function () {
            var Teacher = {
                TeacherID: $scope.TeacherID,
                Salary: $scope.Salary,                
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                BirthDay: $scope.BirthDay
            };
            if (Teacher.TeacherID != null) { //Update teacher
                var getData = TeacherService.updateTeacher(Teacher);
                getData.then(function (msg) {
                    $window.location = "#/teacher";
                    $scope.message = 'teacher Successfully Updated.';
                }, function () {
                    $scope.message = 'Unable to update teacher: ' + error.message;
                });
            } else { //Add teacher
                var getData = TeacherService.newTeacher(Teacher);
                getData.then(function (msg) {
                    $window.location = "#/teacher";
                    $scope.message = 'Teacher Successfully Created.';
                }, function () {
                    $scope.message = 'Unable to create new Teacher: ' + error.message;
                });
            }
        }

        //Adding Tags to Teacher Model
        $scope.addtag = function (param) {
            if ($scope.Tags != null) {
                $scope.Tags = param + ';' + $scope.Tags;
            }
            else { $scope.Tags = param; }
        };

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