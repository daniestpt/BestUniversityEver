app.controller("subjectListController",
     ['$scope', 'SubjectService', '$window', '$routeParams',
    function ($scope, SubjectService, $window, $routeParams) {

        GetAllSubjects();

        //Get All Subjects
        function GetAllSubjects() {
            var getData = SubjectService.getSubjects();
            getData.then(function (pst) {
                $scope.subjects = pst.data;
            }, function () {
                $scope.message = 'Unable to load subjects data: ' + error.message;
            });
        }

        //Delete Subject
        $scope.deleteSubject = function (subjectId) {
            var getData = SubjectService.Delete(subjectId);            
            getData.then(function (msg) {
                $scope.message = 'Subject Successfully Deleted.';                
            }, function () {
                $scope.message = 'Unable to delete subject: ' + error.message;
            });
        }
    }]);

app.controller("subjectController",
     ['$scope', 'SubjectService', '$window', '$routeParams',
    function ($scope, SubjectService, $window, $routeParams) {

        //Get Subject by SubjectId
        $scope.subject = {};
        if ($routeParams.id) {
            var getData = SubjectService.getSubject($routeParams.id);
            getData.then(function (pst) {
                $scope.subject = pst.data;
                $scope.SubjectId = pst.data.SubjectId;
                $scope.SubjectName = pst.data.SubjectName;
                $scope.TeacherName = pst.data.TeacherName;
            }, function () {
                    $scope
                        .message = 'Unable to load Subject data: ' + error.message;
            });
        }
        //Add or Update Subject
        $scope.AddUpdateSubject = function () {
            var Subject = {
                SubjectId: $scope.SubjectId,
                SubjectName: $scope.SubjectName,
                TeacherName: $scope.TeacherName
            };
            if (Subject.SubjectId != null) { //Update Subject
                var getData = SubjectService.updateSubject(Subject);
                getData.then(function (msg) {
                    $window.location = "#/subject";
                    $scope.message = 'Subject Successfully Updated.';
                }, function () {
                        $scope.message = 'Unable to update Subject: ' + error.message;
                });
            } else { //Add Subject
                var getData = SubjectService.newSubject(Subject);
                getData.then(function (msg) {
                    $window.location = "#/subject";
                    $scope.message = 'Subject Successfully Created.';
                }, function () {
                        $scope.message = 'Unable to create new Subject: ' + error.message;
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