class StudentService {

    addStudent(data, success, error) {
        $.ajax({
            type: "POST",
            url: "/Default.aspx/AddStudent",
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