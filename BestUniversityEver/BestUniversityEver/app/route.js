app.config(['$routeProvider', function ($routeProvider) {
    
    $routeProvider.when('/', {
        templateUrl: "/app/home/home.html"
    }),

    $routeProvider.when('/course', {
        templateUrl: "/app/course/CourseList.html",
        controller: "courseListController"
    }),

    $routeProvider.when('/course/new', {
        templateUrl: "/app/course/Course.html",
        controller: "courseController"
    }),

    $routeProvider.when('/course/:id', {
        templateUrl: "/app/course/Course.html",
        controller: "courseController"
    }),



    $routeProvider.when('/subject', {
        templateUrl: "/app/subject/SubjectList.html",
        controller: "subjectListController"
    }),

    $routeProvider.when('/subject/new', {
        templateUrl: "/app/subject/Subject.html",
        controller: "subjectController"
    }),

    $routeProvider.when('/subject/:id', {
        templateUrl: "/app/subject/Subject.html",
        controller: "subjectController"
    }),



    $routeProvider.when('/student', {
        templateUrl: "/app/student/StudentList.html",
        controller: "studentListController"
    }),

    $routeProvider.when('/student/new', {
        templateUrl: "/app/student/Student.html",
        controller: "studentController"
    }),

    $routeProvider.when('/student/:id', {
        templateUrl: "/app/student/Student.html",
        controller: "studentController"
    }),


    $routeProvider.when('/teacher', {
        templateUrl: "/app/teacher/TeacherList.html",
        controller: "teacherListController"
    }),

    $routeProvider.when('/teacher/new', {
        templateUrl: "/app/teacher/Teacher.html",
        controller: "teacherController"
    }),

    $routeProvider.when('/teacher/:id', {
        templateUrl: "/app/teacher/Teacher.html",
        controller: "teacherController"
    }),


    $routeProvider.otherwise({
        redirectTo: '/'
    });

}]);
