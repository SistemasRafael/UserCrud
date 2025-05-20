const studentService = new StudentService();
const addressService = new AddressService();
const emailService = new EmailService();
const phoneService = new PhoneService();

var $inputFirstName = $("#First-Name-Id");
var $inputLastName = $("#Last-Name-Id");
var $inputMiddleName = $("#Middle-Name-Id");
var $inputGender = $("#Gender-Id");
var $inputState = $("#State-Id");
var $inputCity = $("#City-Id");
var $inputZipCode = $("#Zip-Code-Id");
var $inputAddress = $("#Address-Id");
var $inputEmail = $("#Email-Id");
var $inputTypeEmail = $("#Type-Email-Id");
var $inputPhoneNumber = $("#Phone-Number-Id");
var $inputTypePhoneNumber = $("#Phone-Type-Id");
var $inputCountryCode = $("#Country-Code-Id");
var $inputAreaCode = $("#Area-Code-Id");
var $buttonSave = $("#btn-save");

const getValuesFromForm = function () {
    return {
        student: {
            Last_Name : $inputLastName.val(),
            Middle_Name : $inputMiddleName.val(),
            First_Name : $inputFirstName.val(),
            Gender : $inputGender.val()
        },
        address: {
            Student_Id: undefined,
            Address_Line : $inputAddress.val(),
            City : $inputCity.val(),
            Zip_Codepost : $inputZipCode.val(),
            State : $inputState.val(),
        },
        email: {
            Student_Id: undefined,
            Email_Name : $inputEmail.val(),
            Email_Type : $inputTypeEmail.val(),
        },
        phone: {
            Student_Id: undefined,
            Phone_Number: $inputPhoneNumber.val(),
            Phone_Type: $inputTypePhoneNumber.val(),
            Country_Code: $inputCountryCode.val(),
            Area_Code: $inputAreaCode.val(),
        }
    }
}

function validateEmail(email) {
    var regex = /^[\w.-]+@[\w.-]+\.\w+$/;
    return regex.test(email);
}

$inputEmail.keypress(function () {
    var email = $(this).val();
    console.log(email);
    if (validateEmail(email)) {
        $(this).removeClass("is-invalid");
    } else {
        $(this).addClass("is-invalid");
    }
});

$inputCountryCode.keypress(function () {
    if ($(this).val().length > 4) {
        return false;
    }
    else {
        return true;
    }
});

$inputAreaCode.keypress(function () {
    if ($(this).val().length > 4) {
        return false;
    }
    else {
        return true;
    }
});

$buttonSave.on("click", function () {
    const data = getValuesFromForm();
    studentService.addStudent({ student : data.student }, function (result) {
        var Student_Id = result.d;

        data.address["Student_Id"] = Student_Id;
        addressService.addAddress({ address: data.address }, function (result) {
            console.log(result);
        });

        data.email["Student_Id"] = Student_Id;
        emailService.addEmail({ email : data.email }, function (result) {
            console.log(result);
        });

        data.phone["Student_Id"] = Student_Id;
        phoneService.addPhone({ phone : data.phone }, function (result) {
            console.log(result);
        });
    });
});