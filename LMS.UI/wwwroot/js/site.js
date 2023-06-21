(function ($) {

	"use strict";

	var fullHeight = function () {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function () {
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
		$('#sidebar').toggleClass('active');
	});

})(jQuery);

toastr.options = {
	"closeButton": true,
	"debug": false,
	"newestOnTop": false,
	"progressBar": true,
	"positionClass": "toast-bottom-right",
	"preventDuplicates": false,
	"onclick": null,
	"showDuration": "300",
	"hideDuration": "1000",
	"timeOut": "1000",
	"extendedTimeOut": "1500",
	"showEasing": "swing",
	"hideEasing": "linear",
	"showMethod": "fadeIn",
	"hideMethod": "fadeOut"
};

window.addEventListener('offline', () => {
	toastr.error('Network disconnected');
})
window.addEventListener('online', () => {
	toastr.info('Network Connected');
});

function jQueryModalGet(url, title) {
	$.ajax({
		method: 'GET',
		url: url,
		success: (data) => {
			if (data.isValid) {
				$('#form-modal .modal-body').html(data.html);
				$('#form-modal .modal-title').html(title);
				$('#form-modal').modal('show');
			}
			console.log(data);
		}
	})
}
function deleteData(url) {
	swal({
		title: "Are you sure?",
		text: "Once deleted, you will not be able to recover this imaginary file!",
		icon: "warning",
		buttons: true,
		dangerMode: true,
	})
		.then((willDelete) => {
			if (willDelete) {
				$.ajax({
					method: 'POST',
					url: url,
					success: res => {
						if (res.isValid) {
							swal("Deleted", {
								icon: "success",
							});
							$('#viewAll').html(res.html);
						}
					}
				})

			}
		});
}