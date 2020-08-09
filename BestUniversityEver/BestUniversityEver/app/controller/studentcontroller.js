app.controller("studentListController",
    ['$scope', 'StudentService', '$window', '$routeParams',
        function ($scope, StudentService, $window, $routeParams) {

        GetAllStudents();

        //Get All students
        function GetAllStudents() {
            var getData = StudentService.getStudents();
            getData.then(function (pst) {
                $scope.students = pst.data;
            }, function () {
                $scope.message = 'Unable to load student data: ' + error.message;
            });
        }

        //Delete students
        $scope.deleteStudent = function (StudentID) {
            var getData = StudentService.Delete(StudentID);            
            getData.then(function (msg) {
                $scope.message = 'student Successfully Deleted.';                
            }, function () {
                $scope.message = 'Unable to delete student: ' + error.message;
            });
        }
    }]);

app.controller("studentController",
    ['$scope', 'StudentService', '$window', '$routeParams',
    function ($scope, StudentService, $window, $routeParams) {

        //Get student by studentId
        $scope.student = {};
        if ($routeParams.id) {
            var getData = StudentService.getStudent($routeParams.id);
            getData.then(function (pst) {
                $scope.student = pst.data;
                $scope.StudentID = pst.data.StudentID;
                $scope.FirstName = pst.data.FirstName;
                $scope.LastName = pst.data.LastName;
                $scope.Birthday = pst.data.Birthday;     
            }, function () {
                $scope.message = 'Unable to load Student data: ' + error.message;
            });
        }
        //Add or Update Student
        $scope.AddUpdateStudent = function () {
            var Student = {
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                Birthday: $scope.Birthday,                
                StudentID: $scope.StudentID
            };
            if (Student.StudentID != null) { //Update Student
                var getData = StudentService.updateStudent(Student);
                getData.then(function (msg) {
                    $window.location = "#/student";
                    $scope.message = 'Student Successfully Updated.';
                }, function () {
                    $scope.message = 'Unable to update Student: ' + error.message;
                });
            } else { //Add Student
                var getData = StudentService.newStudent(Student);
                getData.then(function (msg) {
                    $window.location = "#/student";
                    $scope.message = 'Student Successfully Created.';
                }, function () {
                    $scope.message = 'Unable to create new Student: ' + error.message;
                });
            }
        }

        //Adding Tags to Post Model
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