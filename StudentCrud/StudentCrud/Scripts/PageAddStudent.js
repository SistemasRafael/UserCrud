const studentService = new StudentService();
const addressService = new AddressService();
const emailService = new EmailService();
const phoneService = new PhoneService();

var $inputFirstName = $("#MainContent_FirstNameId");
var $inputLastName = $("#MainContent_LastNameId");
var $inputMiddleName = $("#MainContent_MiddleNameId");
var $inputGender = $("#MainContent_GenderId");
var $inputState = $("#MainContent_StateId");
var $inputCity = $("#MainContent_CityId");
var $inputZipCode = $("#MainContent_ZipCodeId");
var $inputAddress = $("#MainContent_AddressId");
var $inputEmail = $("#MainContent_EmailId");
var $inputTypeEmail = $("#MainContent_TypeEmailId");
var $inputPhoneNumber = $("#MainContent_PhoneNumberId");
var $inputTypePhoneNumber = $("#MainContent_PhoneTypeId");
var $inputCountryCode = $("#MainContent_CountryCodeId");
var $inputAreaCode = $("#MainContent_AreaCodeId");
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