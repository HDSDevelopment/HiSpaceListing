
/*on focus and blur error on all section*/
function errShow(a, b, c) {
	if (a == '') {
		$("#" + b + "").html('<span>The field is required</span>');
	}
};

function errHide(a, b) {
	$("#" + b + "").html('');
};

function loginValidate(e) {
	var email = $('#Email').val();
	var password = $('#Password').val();
	if (email == "") {
		$('#error_Email').html('<span>Please enter your Email</span>');
	}
	if (password == "") {
		$('#error_Password').html('<span>Please enter your Password</span>');
	}
	if (email = "" || password == "") {
		event.preventDefault();
	}
}