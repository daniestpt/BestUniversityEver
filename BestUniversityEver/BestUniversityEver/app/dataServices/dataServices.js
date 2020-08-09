
app.service("TagsService", function ($http) {

    //get All Tags
    this.getPosts = function () {
        return $http.get("Tags/TagsList");
    };
});

app.service("CourseService", function ($http) {

    // get All Course
    this.getCourses = function () {
        return $http.get("Course/CourseList");
    };

    //get new Course
    this.getNewCourse = function () {
        return $http.get("Course/New");
    };

    // get Course By Id
    this.getCourse = function (id) {
        var response = $http({
            method: "post",
            url: "Course/Edit",
            params: {
                id: id
            }
        });
        return response;
    }

    // Update Course
    this.updateCourse = function (Course) {
        var response = $http({
            method: "post",
            url: "Course/EditCourse",
            data: JSON.stringify(Course),
            dataType: "json"
        });
        return response;
    }

    // New Course
    this.newCourse = function (Course) {
        var response = $http({
            method: "post",
            url: "Course/NewCourse",
            data: JSON.stringify(Course),
            dataType: "json"
        });
        return response;
    }

    //Delete Course
    this.Delete = function (CourseID) {
        var response = $http({
            method: "post",
            url: "Course/Delete",
            params: {
                CourseID: JSON.stringify(CourseID)
            }
        });
        return response;
    }
});

app.service("SubjectService", function ($http) {

    // get All Subject
    this.getSubjects = function () {
        return $http.get("Subject/SubjectList");
    };

    //get new Subject
    this.getNewSubject = function () {
        return $http.get("Subject/New");
    };

    // get Subject By Id
    this.getSubject = function (id) {
        var response = $http({
            method: "post",
            url: "Subject/Edit",
            params: {
                id: id
            }
        });
        return response;
    }

    // Update Subject
    this.updateSubject = function (Subject) {
        var response = $http({
            method: "post",
            url: "Subject/EditSubject",
            data: JSON.stringify(Subject),
            dataType: "json"
        });
        return response;
    }

    // New Subject
    this.newSubject = function (Subject) {
        var response = $http({
            method: "post",
            url: "Subject/NewSubject",
            data: JSON.stringify(Subject),
            dataType: "json"
        });
        return response;
    }

    //Delete Subject
    this.Delete = function (SubjectId) {
        var response = $http({
            method: "post",
            url: "Subject/Delete",
            params: {
                SubjectId: JSON.stringify(SubjectId)
            }
        });
        return response;
    }
});

app.service("StudentService", function ($http) {

    // get All Student
    this.getStudents = function () {
        return $http.get("Student/StudentList");
    };

    //get new Student
    this.getNewStudent = function () {
        return $http.get("Student/New");
    };

    // get Student By Id
    this.getStudent = function (id) {
        var response = $http({
            method: "post",
            url: "Student/Edit",
            params: {
                id: id
            }
        });
        return response;
    }

    // Update Student
    this.updateStudent = function (Student) {
        var response = $http({
            method: "post",
            url: "Student/EditStudent",
            data: JSON.stringify(Student),
            dataType: "json"
        });
        return response;
    }

    // New Student
    this.newStudent = function (Student) {
        var response = $http({
            method: "post",
            url: "Student/NewStudent",
            data: JSON.stringify(Student),
            dataType: "json"
        });
        return response;
    }

    //Delete Student
    this.Delete = function (StudentID) {
        var response = $http({
            method: "post",
            url: "Student/Delete",
            params: {
                StudentID: JSON.stringify(StudentID)
            }
        });
        return response;
    }
});

app.service("TeacherService", function ($http) {

    // get All Teacher
    this.getTeachers = function () {
        return $http.get("Teacher/TeacherList");
    };

    //get new Teacher
    this.getNewTeacher = function () {
        return $http.get("Teacher/New");
    };

    // get Teacher By Id
    this.getTeacher = function (id) {
        var response = $http({
            method: "post",
            url: "Teacher/Edit",
            params: {
                id: id
            }
        });
        return response;
    }

    // Update Teacher
    this.updateTeacher = function (Teacher) {
        var response = $http({
            method: "post",
            url: "Teacher/EditTeacher",
            data: JSON.stringify(Teacher),
            dataType: "json"
        });
        return response;
    }

    // New Teacher
    this.newTeacher = function (Teacher) {
        var response = $http({
            method: "post",
            url: "Teacher/NewTeacher",
            data: JSON.stringify(Teacher),
            dataType: "json"
        });
        return response;
    }

    //Delete Teacher
    this.Delete = function (TeacherID) {
        var response = $http({
            method: "post",
            url: "Teacher/Delete",
            params: {
                TeacherID: JSON.stringify(TeacherID)
            }
        });
        return response;
    }
});