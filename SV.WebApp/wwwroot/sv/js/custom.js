		
		/************************
			Calls
		*************************/
    	$(".dropdown-toggle").dropdown();
		$(".sliding_menu").initMenu();
		$(".header a, button, .quick-buttons a, ul.sidebar-actions a, .table-actions a").tooltip();
		$(".chat-box .image a").tooltip();
		$(".tooltips-demo a").tooltip();
		$("a[rel=popover]").popover().click(function(e){e.preventDefault() });
		
		// File
		$("#file").customFileInput({
			button_position : 'right'
		});
		
		// Form Validation
		$("#validation").validationEngine({promptPosition : "topLeft", scroll: true}); 