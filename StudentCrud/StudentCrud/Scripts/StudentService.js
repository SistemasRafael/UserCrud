class StudentService {

    addStudent(data, success, faild) {
        $.ajax({
            type: "POST",
            url: "/AddStudent.aspx/Add_Student",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (success !== undefined) {
                    success(result);
                }
            },
            error: function (req, status, error) {
                if (faild !== undefined) {
                    faild(req, status, error);
                }
            }
        });
    }

    getAllStudentInformation(success, faild) {
        $.ajax({
            type: "POST",
            url: "/ListStudent.aspx/GetAll_Student",
            data: JSON.stringify({}),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (success !== undefined) {
                    success(result);
                }
            },
            error: function (req, status, error) {
                if (error !== undefined) {
                    error(req, status, error);
                }
            }
        });
    }

    DeleteStudent(data, success, faild) {
        $.ajax({
            type: "POST",
            url: "/ListStudent.aspx/Delete_Student",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (success !== undefined) {
                    success(result);
                }
            },
            error: function (req, status, error) {
                if (error !== undefined) {
                    error(req, status, error);
                }
            }
        });
    }
}