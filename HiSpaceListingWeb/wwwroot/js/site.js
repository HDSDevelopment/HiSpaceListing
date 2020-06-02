// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$('#DOJ, #DOR, #FromDate, #ToDate').datetimepicker({
//	//debug: true,
//	format: 'YYYY-MM-DD',
//	//daysOfWeekDisabled: [1, 2, 3, 4, 5],
//});

//add padding to the top for scrolling
//$(window).on('scroll', function () {
//	if ($(".navbar").hasClass("is-sticky")) {
//		$('.scroll-padding').css({ "padding-top": "150px" });
//	} else {
//		$('.scroll-padding').css({ "padding-top": "0" });
//	}
//});
$('#BuildYear, #RecentInnovation, #BuildYearDiv, #RecentInnovationDiv').datetimepicker({
	//viewMode: 'years',
	format: 'YYYY/MM/DD',
	//debug: true,
});
$(document).ready(function () {

	$("#cartBtn-1, #cartBtn-2, #cartBtn-3").click(function () {
		var sec = $(this).attr('cart-section');
		console.log(sec);
		$('html, body').animate({
			scrollTop: $("#card-"+sec).offset().top-50
		}, 1000);
	});

	//$('#datetimepicker-01, #datetimepicker-02, #RecentInnovation,#datetimepicker-recent-cw, #BuildYear,#datetimepicker-builtyear-cw').datetimepicker({
	//	format: 'L'
	//});
	//$('#datetimepicker-03, #datetimepicker-04').datetimepicker({
	//	format: 'LT'
	//});

	$('#example').DataTable();

		//$('#example tbody').on('click', 'tr', function () {
		//	var data = table.row(this).data();
		//	alert('You clicked on ' + data[0] + '\'s row');
		//});
	//tab navigation section
	if ($('.hi-tab .active.show').attr('data-id')) {
		$('.tab-back-btn, .tab-submit').css('display', 'none');
	}

	//type selection
	$('#ListingType').on('change', function () {
		var value = $(this).val();
		var coWorkingValue = $('#CoworkingType').val();
			//alert(value)
		//if (coWorkingValue == "Cafe") {
		//	$('.type-2-sub__input').addClass('d-none');
		//}
		//else if (coWorkingValue == "Office") {
		//	$('.type-2-sub__input').removeClass('d-none');
		//}
		if (value == "Commercial") {
			$('.form-type').removeClass('type-2');
			$('.form-type').removeClass('type-3');
			$('.form-type').addClass('type-1');
			$('.type-2__input, .type-3, .type-style.type-2, .type-style.type-3, .type-2-sub__input').addClass('d-none');
			$('.type-1__input, .type-style.type-1, .form-type.type-1, .input-occupancy').removeClass('d-none');
			}
		else if (value == "Co-Working") {
			$('.form-type').removeClass('type-1');
			$('.form-type').removeClass('type-3');
			$('.form-type').addClass('type-2');
			$('.type-1__input, .type-3, .type-style.type-1, .type-style.type-3').addClass('d-none');
			$('.type-2__input, .type-style.type-2, .form-type.type-2, .type-2-sub__input, .input-occupancy').removeClass('d-none');
			}
		else if (value == "RE-Professional") {
				$('.type-3').removeClass('d-none');
			$('.form-type.type-1, .form-type.type-2, .type-style.type-1, .type-style.type-2').addClass('d-none');
		}
		
		});
	$('#CoworkingType').on('change', function () {
		var value = $(this).val();
		//alert(value)
		if (value == "Office") {
			$('.type-2-sub__input, .input-occupancy').removeClass('d-none');
		}
		else if (value == "Cafe"){
			$('.type-2-sub__input, .input-occupancy').addClass('d-none');
		}
	});
	//checkbox conditon to show
	$('.type-2-sub input[type="checkbox"]').click(function () {
		if ($(this).prop("checked") == true) {
			//console.log("Checkbox is checked.");
			$(this).parent().parent().siblings('.check-view').removeClass('d-none');
		}
		else if ($(this).prop("checked") == false) {
			//console.log("Checkbox is unchecked.");
			$(this).parent().parent().siblings('.check-view').addClass('d-none');
		}
	});
	//amenities section price
	$(document).on('change','.am-option', function () {
		var value = $(this).val();
		//alert(value)
		if (value == 1) {
			$(this).closest('.amenities-upload__row').children('.am-price, .am-partial').addClass('d-none');
		}
		else if (value == 2) {
			//$('.am-price').removeClass('d-none');
			//$('.am-partial').addClass('d-none');
			$(this).closest('.amenities-upload__row').children('.am-price').removeClass('d-none');
			$(this).closest('.amenities-upload__row').children('.am-partial').addClass('d-none');
		}
		else if (value == 3) {
			//$('.am-partial').removeClass('d-none');
			//$('.am-price, .am-price').addClass('d-none');
			$(this).closest('.amenities-upload__row').children('.am-partial').removeClass('d-none');
			$(this).closest('.amenities-upload__row').children('.am-price').removeClass('d-none');
		}
	});


});
////map section
//// Initialize and add the map
//function initMapLatLon() {
//	// The location of Uluru
//	var uluru = { lat: -25.344, lng: 131.036 };
//	// The map, centered at Uluru
//	var map = new google.maps.Map(
//		document.getElementById('map'), { zoom: 4, center: uluru });
//	console.log(map);
//	// The marker, positioned at Uluru
//	var marker = new google.maps.Marker({ position: uluru, map: map });
//}
//initMapLatLon();

/*********tab navigation section start*********/

//on focus input
$('.required-input').focus(function () {
	$(this).parents('.form-group').siblings('.hi-error').addClass('d-none');
});

//on blur input
$('.required-input').blur(function () {
	if ($(this).val() == "") {
		$(this).parents('.form-group').siblings('.hi-error').removeClass('d-none');
	}
});

function tabNavigation(nav) {
	var tabLength = parseInt($('.hi-tab').find('.nav-link').length);
	var currentTab = parseInt($('.hi-tab .active').attr('data-id'));

	//disable the back btn on first tab
	//if (currentTab == 2) {
	//	//alert('a')
	//	$('.tab-back-btn').css('display', 'none');
	//}
	//else {
	//	$('.tab-next-btn').css('display', 'inline-block');
	//	$('.tab-submit').css('display', 'none');
	//}

	//click back button
	if (nav == 0) {
		$("[data-id='" + (currentTab - 1) + "']").click();
	}
	//click next button
	else if (nav == 1) {
		checkRequiredInput(currentTab);

		//to show submit button on the last tab
		if ((currentTab) == (tabLength - 1)) {
			//alert('a')
			$('.tab-next-btn').css('display', 'none');
			$('.tab-submit').css('display', 'inline-block');
		}
	}
	//click submit button
	else if (nav == 2) {
		//event.preventDefault();
		if ($('input:visible').hasClass('required-input')) {
			//each condition to find the empty inputs
			$('.required-input:visible').each(function (i) {
				if ($(this).val() == "") {
					$(this).parents('.form-group').siblings('.hi-error').removeClass('d-none');
					event.preventDefault();
				}
			});
		}
	}
};

function checkRequiredInput(currentTab) {
	var dataId = $("[data-id='" + (currentTab + 1) + "']");
	//check required class in input
	if ($('input:visible').hasClass('required-input')) {
		//each condition to find the empty inputs
		$('.required-input:visible').each(function (i) {
			if ($(this).val() == "") {
				$(this).parents('.form-group').siblings('.hi-error').removeClass('d-none');
			}
			else {
				$('.tab-back-btn').css('display', 'inline-block');
				dataId.click();
				dataId.removeClass('pointer-event-none');
				dataId.parents('.nav-item').removeClass('cursor-no-drop');
			}
		});
	}
	else {
		$('.tab-back-btn').css('display', 'inline-block');
		dataId.click();
		dataId.removeClass('pointer-event-none');
		dataId.parents('.nav-item').removeClass('cursor-no-drop');
	}
};

$('.hi-tab .nav-link').on('click', function () {
	var tabLength = parseInt($('.hi-tab').find('.nav-link').length);
	var currentTab = parseInt($(this).attr('data-id'));
	if (currentTab == 1) {
		$('.tab-back-btn').css('display', 'none');
		$('.tab-next-btn').css('display', 'inline-block');
		$('.tab-submit').css('display', 'none');
	}
	else if (currentTab == tabLength) {
		$('.tab-back-btn').css('display', 'inline-block');
		$('.tab-next-btn').css('display', 'none');
		$('.tab-submit').css('display', 'inline-block');
	}
	else {
		$('.tab-back-btn').css('display', 'inline-block');
		$('.tab-next-btn').css('display', 'inline-block');
		$('.tab-submit').css('display', 'none');
	}
});

//***********************user section end****************************//

//$('input[name="workingHours.Is24"]').click(function () {
$('body').on('click','input[name="WorkingHours.Is24"]', function () {
	//alert('a');
	//$('input[name="AllTimeCheck"], input[name="MonToFriCheck"], input[name="MonToSatCheck"], input[name="CustomCheck"]').click(function () {
	//console.log($('#AllTimeCheck option:selected').text());
	$('#AllTimeCheck').val("false");
	$('#MonToFriCheck').val("false");
	$('#MonToSatCheck').val("false");
	$('#CustomCheck').val("false");
	if ($(this).prop("checked")) {
		$(this).siblings('select').val("true");
		//console.log($('#AllTimeCheck option:selected').text());
	}

	//alert($(this).attr('radio-attr'))
	$('.form-radio label').removeClass('radio-active');
	$(this).parents('label').addClass('radio-active');
	if ($(this).attr('radio-attr') == "24/7") {
		$('.sch-custom, .sch-weekdays, .sch-weeksaturday').addClass('cursor-no-drop');
		$('.sch-custom > div, .sch-weekdays > div, .sch-weeksaturday > div').addClass('pointer-event-none');
	}
	else if ($(this).attr('radio-attr') == "weekdays") {
		$('.sch-weekdays').removeClass('cursor-no-drop');
		$('.sch-weekdays > div').removeClass('pointer-event-none');

		$('.sch-custom, .sch-weeksaturday').addClass('cursor-no-drop');
		$('.sch-custom > div, .sch-weeksaturday > div').addClass('pointer-event-none');
	}
	else if ($(this).attr('radio-attr') == "weeksaturday") {
		$('.sch-weeksaturday').removeClass('cursor-no-drop');
		$('.sch-weeksaturday > div').removeClass('pointer-event-none');

		$('.sch-custom, .sch-weekdays').addClass('cursor-no-drop');
		$('.sch-custom > div, .sch-weekdays > div').addClass('pointer-event-none');
	}
	else if ($(this).attr('radio-attr') == "custom") {
		$('.sch-custom').removeClass('cursor-no-drop');
		$('.sch-custom > div').removeClass('pointer-event-none');

		$('.sch-weekdays, .sch-weeksaturday').addClass('cursor-no-drop');
		$('.sch-weekdays > div, .sch-weeksaturday > div').addClass('pointer-event-none');
	}
});

$('body').on('click','.sch-status', function () {
	if ($(this).prop("checked") == true) {
		$(this).parents('.sch-checkbox').siblings('.sch-time').css('display', 'block');
		$(this).siblings('strong').html('Open');
	}
	else if ($(this).prop("checked") == false) {
		$(this).parents('.sch-checkbox').siblings('.sch-time').css('display', 'none');
		$(this).siblings('strong').html('Closed');
	}
});
//schedular section end
//image upload section start
function addImage() {
	$('.image-upload').append(
		'<div class="row image-upload__row">'+
		'<div class=" col-md-4 col-sm-6 ">' +
		'<div class="form-group">'+
				'<input type="text" class="form-control imageName" placeholder="Image Name">'+
			'<label for="input" class="control-label">Image Name</label><i class="bar"></i>'+
'</div>	'+
							'</div>'+
		'<div class=" col-md-4 col-sm-6">' +
		'<div class="form-group">'+
			'<input type="file" class="form-control imageFilePath" accept="image/*">'+
				'<label for="input" class="control-label">Upload Image</label><i class="bar"></i>'+
							'</div>'+
			'</div>'+
			'<div class="col-md-2 col-sm-6 m-b--15 align-self-center">'+
				'<div class="checkbox m-0">'+
					'<label>'+
						'<input type="checkbox" class="imageCheck" /><i class="helper"></i> Active'+
									'</label>'+
				'</div>'+
			'</div>'+
			'<div class="col-md-2 col-sm-6">'+
				'<span class="delete-btn" onclick="deleteRowImage(this)"><i class="fas fa-trash-alt btn-icon text-danger"></i></span>'+
			'</div>'+
		'</div>'
	);
};
function deleteRowImage(that) {
	$(that).closest('.image-upload__row').remove();
	//console.log($(that).parents().find('.image-upload__row').html());
};
//image upload section end
//project upload section start
function addProject() {
	$('.project-upload').append(
		'<div class="row project-upload__row">'+
		'<div class=" col-md-3 col-sm-6  align-self-center">' +
		'<div class="form-group">'+
				'<input type="text" class="form-control" placeholder="project Name">'+
					'<label for="input" class="control-label">project Name</label><i class="bar"></i>'+
									'</div>'+
			'</div>'+
				'<div class=" col-md-3 col-sm-6 align-self-center">' +
				'<div class="form-group">'+
					'<input type="file" class="form-control" accept="project/*">'+
						'<label for="input" class="control-label">Upload project</label><i class="bar"></i>'+
									'</div>'+
					'</div>'+
					'<div class=" col-md-3 col-sm-6 align-self-center">' +
					'<div class="form-group">'+
		'<textarea type="text" class="form-control" rows="3" placeholder="Enter your text..."></textarea>' +
						'<label for="input" class="control-label">Description</label><i class="bar"></i>'+
					'</div>'+
					'</div>'+
					'<div class="col-md-2 col-sm-6 m-b--15 align-self-center">'+
						'<div class="checkbox m-0">'+
							'<label>'+
								'<input type="checkbox" /><i class="helper"></i> Active'+
											'</label>'+
						'</div>'+
					'</div>'+
					'<div class="col-md-1 col-sm-6">'+
		'<span class="delete-btn" onclick="deleteRowProject(this)"><i class="fas fa-trash-alt btn-icon text-danger"></i></span>' +
					'</div>'+
				'</div>'
	);
}
function deleteRowProject(that) {
	$(that).closest('.project-upload__row').remove();
};
//project upload section end
//amenities upload section start
function addAmenities() {
	$('.amenities-upload').append(
		'<div class="row amenities-upload__row ">'+
		'<div class=" col-md-3 col-sm-4">' +
		'<div class="form-group">'+
				'<input type="text" class="form-control" placeholder="Name">'+
					'<label for="input" class="control-label">Amenity</label><i class="bar"></i>'+
									'</div>'+
			'</div>'+
				'<div class="col-lg-3 col-md-3 col-sm-4 col-6 ">'+
					'<div class="form-group">'+
						'<select class="form-control basic-select am-option" id="">'+
							'<option value="1">Free</option>'+
							'<option value="2">Paid</option>'+
							'<option value="3">Partially Paid</option>'+
						'</select>'+
						'<label for="" class="control-label">Cost</label>'+
						'<i class="bar"></i>'+
					'</div>'+
				'</div>'+
		'<div class=" am-price col-md-2 col-sm-3  d-none">' +
		'<div class="form-group">' +
		'<input type="number" class="form-control" placeholder="00">' +
		'<label for="input" class="control-label">Price/Usage</label><i class="bar"></i>' +
		'</div>' +
		'</div>' +
									'<div class=" am-partial col-md-2 col-sm-3  d-none">' +
									'<div class="form-group">'+
						'<input type="number" class="form-control" placeholder="00">'+
							'<label for="input" class="control-label">Free Count</label><i class="bar"></i>'+
									'</div>'+
'</div>	'+
						

							'<div class="col-md-1 col-sm-6 m-b--15 align-self-center">'+
								'<div class="checkbox m-0">'+
									'<label>'+
										'<input type="checkbox" /><i class="helper"></i> Active'+
											'</label>'+
								'</div>'+
							'</div>'+
							'<div class="col-md-1 col-sm-6">'+
								'<span class="delete-btn" onclick="deleteRowAmenities(this)"><i class="fas fa-trash-alt btn-icon text-danger"></i></span>'+
							'</div>'+
						'</div>'
	);
}
function deleteRowAmenities(that) {
	$(that).closest('.amenities-upload__row').remove();
};
//amenities upload section end
//facilities upload section start
function addFacilities() {
	$('.facilities-upload').append(
		'<div class="row facilities-upload__row">'+
			'<div class=" col-md-3 col-sm-4 ">'+
				'<div class="form-group">'+
					'<input type="text" class="form-control" placeholder="Name">'+
						'<label for="input" class="control-label">Facility</label><i class="bar"></i>'+
									'	</div>'+
				'</div>'+
				'<div class="col-lg-3 col-md-3 col-sm-4 col-6 ">'+
					'<div class="form-group">'+
						'<select class="form-control am-option" id="">'+
							'<option value="1">0 to .5KM</option>'+
							'<option value="2">.5KM to 1KM</option>'+
							'<option value="3">1KM to 2KM</option>'+
							'<option value="4">2KM to 3KM</option>'+
							'<option value="5">3KM to 4KM</option>'+
							'<option value="6">4KM to 5KM</option>'+
							'<option value="7">5KM to 6KM</option>'+
							'<option value="8">6KM to 7KM</option>'+
							'<option value="9">7KM to 8KM</option>'+
							'<option value="10">8KM to 9KM</option>'+
							'<option value="11">9KM to 10KM</option>'+
							'<option value="12">Above 10KM</option>'+
						'</select>'+
						'<label for="" class="control-label">Distance</label>'+
						'<i class="bar"></i>'+
					'</div>'+
				'</div>'+
				'<div class="col-md-2 col-sm-6 m-b--15 align-self-center">'+
					'<div class="checkbox m-0">'+
						'<label>'+
							'<input type="checkbox" /><i class="helper"></i> Active'+
											'</label>'+
					'</div>'+
				'</div>'+
				'<div class="col-md-1 col-sm-6">'+
					'<span class="delete-btn" onclick="deleteRowFacilities(this)"><i class="fas fa-trash-alt btn-icon text-danger"></i></span>'+
				'</div>'+
			'</div>'
	);
}
function deleteRowFacilities(that) {
	$(that).closest('.facilities-upload__row').remove();
};
//facilities upload section end

$(function () {

	//model open for the login section
	$('body').on('click', '.modal-link__login', function (e) {
		e.preventDefault();

		$("#modal-container__login").remove();

		$.get($(this).data("targeturl"), function (data) {

			$('<div id="modal-container__login" class="modal login fade modal-try" tabindex="-1" role="dialog" aria-labelledby="loginModalLabel" aria-hidden="true">' +
				'<div id="modalbody" class="modal-dialog modal-content" role="document"' +
				data + '</div></div>').modal();

		});

	});

	//model open for the signup section
	$('body').on('click', '.modal-link__signup', function (e) {
		e.preventDefault();

		$("#modal-container__signup").remove();

		$.get($(this).data("targeturl"), function (data) {

			$('<div id="modal-container__signup" class="modal signup fade modal-try" tabindex="-1" role="dialog" aria-labelledby="signupModalLabel" aria-hidden="true">' +
				'<div id="modalbody" class="modal-dialog modal-content" role="document"' +
				data + '</div></div>').modal();

		});
	});

	//model open for the list image section
	$('body').on('click', '.modal-link__image', function (e) {
		e.preventDefault();

		$("#modal-container__image").remove();

		$.get($(this).data("targeturl"), function (data) {

			$('<div id="modal-container__image" class="modal image fade modal-try" tabindex="-1" role="dialog" aria-labelledby="imageModalLabel" aria-hidden="true">' +
				'<div id="modalbody" class="modal-dialog modal-lg modal-content" role="document"' +
				data + '</div></div>').modal();

		});
	});

	//model open for the list hours section
	$('body').on('click', '.modal-link__hours', function (e) {
		e.preventDefault();

		$("#modal-container__hours").remove();

		$.get($(this).data("targeturl"), function (data) {

			$('<div id="modal-container__hours" class="modal hours fade modal-try" tabindex="-1" role="dialog" aria-labelledby="imageModalLabel" aria-hidden="true">' +
				'<div id="modalbody" class="modal-dialog modal-lg modal-content" role="document"' +
				data + '</div></div>').modal();

		});
		setTimeout(function () {
			//console.log($('#AllTimeCheck').html())
			//console.log($('#MonToFriCheck option:selected').val())
			//console.log($('#MonToSatCheck option:selected').val())
			//console.log($('#CustomCheck option:selected').val())
		if ($('#AllTimeCheck option:selected').text() == "True") {
			$('#AllTimeCheck').parents('label').find('[type=radio]').prop("checked", true);
			$('#AllTimeCheck').parents('label').addClass('radio-active');
		}
		else if ($('#MonToFriCheck option:selected').text() == "True") {
			$('#MonToFriCheck').parents('label').find('[type=radio]').prop("checked", true);
			$('#MonToFriCheck').parents('.radio').siblings().removeClass('cursor-no-drop');
			$('#MonToFriCheck').parents('.radio').siblings().children().removeClass('pointer-event-none');
			$('#MonToFriCheck').parents('.radio').siblings().find('input').prop("checked", true);
			$('#MonToFriCheck').parents('.radio').siblings().find('input').parents('.sch-checkbox').siblings('.sch-time').css('display', 'block');
			$('#MonToFriCheck').parents('.radio').siblings().find('input').siblings('strong').html('Open');
			$('#MonToFriCheck').parents('label').addClass('radio-active');
		}
		else if ($('#MonToSatCheck option:selected').text() == "True") {
			$('#MonToSatCheck').parents('label').find('[type=radio]').prop("checked", true);
			$('#MonToSatCheck').parents('.radio').siblings().removeClass('cursor-no-drop');
			$('#MonToSatCheck').parents('.radio').siblings().children().removeClass('pointer-event-none');
			$('#MonToSatCheck').parents('.radio').siblings().find('input').prop("checked", true);
			$('#MonToSatCheck').parents('.radio').siblings().find('input').parents('.sch-checkbox').siblings('.sch-time').css('display', 'block');
			$('#MonToSatCheck').parents('.radio').siblings().find('input').siblings('strong').html('Open');
			$('#MonToSatCheck').parents('label').addClass('radio-active');
		}
		else if ($('#CustomCheck option:selected').text() == "True") {
			$('#CustomCheck').parents('label').find('[type=radio]').prop("checked", true);
			$('#CustomCheck').parents('.radio').siblings().removeClass('cursor-no-drop');
			$('#CustomCheck').parents('.radio').siblings().children().removeClass('pointer-event-none');
			$('#CustomCheck').parents('.radio').siblings().find('input').prop("checked", true);
			$('#CustomCheck').parents('.radio').siblings().find('input').parents('.sch-checkbox').siblings('.sch-time').css('display', 'block');
			$('#CustomCheck').parents('.radio').siblings().find('input').siblings('strong').html('Open');
			$('#CustomCheck').parents('label').addClass('radio-active');
		}

		//display view in the scheduler section
		if ($('#Display_view #AllTimeCheck option:selected').text() == "True") {
			$('.sch-2, .sch-3, .sch-4').css('display', 'none');
			$('.sch-1').css('display', 'block');
		}
		else if ($('#Display_view #MonToFriCheck option:selected').text() == "True") {
			$('.sch-1, .sch-3, .sch-4').css('display', 'none');
			$('.sch-2').css('display', 'block');
		}
		else if ($('#Display_view #MonToSatCheck option:selected').text() == "True") {
			$('.sch-1, .sch-2, .sch-4').css('display', 'none');
			$('.sch-3').css('display', 'block');
		}
		else if ($('#Display_view #CustomCheck option:selected').text() == "True") {
			$('.sch-1, .sch-2, .sch-3').css('display', 'none');
			$('.sch-4').css('display', 'block');
			}
		}, 1000);
	});

	//model open for the list project section
	$('body').on('click', '.modal-link__project', function (e) {
		e.preventDefault();

		$("#modal-container__project").remove();

		$.get($(this).data("targeturl"), function (data) {

			$('<div id="modal-container__project" class="modal project fade modal-info" tabindex="-1" role="dialog" aria-labelledby="imageModalLabel" aria-hidden="true">' +
				'<div id="modalbody" class="modal-dialog modal-xl modal-content" role="document"' +
				data + '</div></div>').modal();

		});
	});

	//model open for the list amenities section
	$('body').on('click', '.modal-link__amenities', function (e) {
		e.preventDefault();

		$("#modal-container__amenities").remove();

		$.get($(this).data("targeturl"), function (data) {

			$('<div id="modal-container__amenities" class="modal amenities fade modal-try" tabindex="-1" role="dialog" aria-labelledby="imageModalLabel" aria-hidden="true">' +
				'<div id="modalbody" class="modal-dialog modal-xl modal-content" role="document"' +
				data + '</div></div>').modal();

		});
	});

	//model open for the list facilities section
	$('body').on('click', '.modal-link__facilities', function (e) {
		e.preventDefault();

		$("#modal-container__facilities").remove();

		$.get($(this).data("targeturl"), function (data) {

			$('<div id="modal-container__facilities" class="modal facilities fade modal-sec" tabindex="-1" role="dialog" aria-labelledby="imageModalLabel" aria-hidden="true">' +
				'<div id="modalbody" class="modal-dialog modal-lg modal-content" role="document"' +
				data + '</div></div>').modal();

		});
	});


	//ajax call section for image upload
	$('body').on('click', '#SubmitImage', function (e) {
		//alert('a');
		var test = new Array();
		$('.image-upload__row').each(function () {
			var name = $(this).find('.imageName').val();
			var path = $(this).find('.imageFilePath').val();
			//var status = $(this).find('.imageCheck').val();
			if ($(this).find('.imageCheck').is(':checked')) {
				var status = true
			} else {
				var status = false
			};
			//alert(name + ' ,' + path +' , ' + status);
		})
	})
});
