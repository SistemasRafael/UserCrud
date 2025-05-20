const studentService = new StudentService();

var $ListStudentBodyId = $("#List-Student-Body-Id");

function LoadListStudent() {
    studentService.getAllStudentInformation(function (result) {
        PrintTable(result.d);
    });
};

function PrintTable(data) {
    var content = "";
    $ListStudentBodyId.html(content);
    for (i = 0; i < data.length; i++) {
        content += "<tr>";
        content += '<td>' + data[i].First_Name + '</td>';
        content += '<td>' + data[i].Last_Name + '</td>';
        content += '<td>' + data[i].Middle_Name + '</td>';
        content += '<td>' + data[i].Gender + '</td>';

        if (data[i].Email !== null) {
            content += '<td>' + data[i].Email.Email_Name + '</td>';
            content += '<td>' + data[i].Email.Email_Type + '</td>';
        }
        else {
            content += '<td>---</td>';
            content += '<td>---</td>';
        }

        if (data[i].Address !== null) {
            content += '<td>' + data[i].Address.Address_Line + '</td>';
            content += '<td>' + data[i].Address.City + '</td>';
            content += '<td>' + data[i].Address.State + '</td>';
            content += '<td>' + data[i].Address.Zip_Codepost + '</td>';
        }
        else {
            content += '<td>---</td>';
            content += '<td>---</td>';
            content += '<td>---</td>';
            content += '<td>---</td>';
        }

        if (data[i].Phone !== null) {
            content += '<td>' + data[i].Phone.Area_Code + '</td>';
            content += '<td>' + data[i].Phone.Country_Code + '</td>';
            content += '<td>' + data[i].Phone.Phone_Number + '</td>';
            content += '<td>' + data[i].Phone.Phone_Type + '</td>';
        }
        else {
            content += '<td>---</td>';
            content += '<td>---</td>';
            content += '<td>---</td>';
            content += '<td>---</td>';
        }

        content += '<td><button type="button" id="btn-Edit" class="btn btn-primary">Edit</button><button type="button" data-id="' + data[i].Student_Id + '" class="btn btn-danger btn-Delete">Delete</button></td>';
        content += "</tr>"
    }

    $ListStudentBodyId.html(content);

    $(".btn-Delete").off("click"); 
    $(".btn-Delete").on("click", function () {
        const studentId = $(this).data("id");
        let isBoss = confirm("Delete Student?");
        if (isBoss) {
            studentService.DeleteStudent({ Student_Id: studentId }, function (result) {
                console.log(result);
                LoadListStudent();
            });
        }
    });
};

LoadListStudent();