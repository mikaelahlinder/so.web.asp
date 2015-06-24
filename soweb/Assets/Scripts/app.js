(function ($) {

    "use strict";

    $(document).ready(function () {

        var overlayMenu = $('#overlay-menu'),
            navbar = $('.navbar-custom'),
            worksgrid = $('.works-grid');

        var isNavbarTransparent = navbar.length > 0 && navbar.hasClass('navbar-transparent');
        $(window).scroll(function () {
            if (navbar.length > 0 && isNavbarTransparent !== false) {
                navbar.toggleClass('navbar-transparent', $(window).scrollTop() < 5);
            }
        }).scroll();


        $('#toggle-menu').on('click', function () {
            showMenu();
            $('body').addClass('aux-navigation-active');
            return false;
        });

        $('#overlay-menu-hide').on('click', function () {
            hideMenu();
            $('body').removeClass('aux-navigation-active');
            return false;
        });

        $(window).keydown(function (e) {
            if (overlayMenu.hasClass('active')) {
                if (e.which === 27) {
                    hideMenu();
                }
            }
        });

        function showMenu() {
            navbar.animate({ 'opacity': 0, 'top': -80 }, {
                duration: 150,
                easing: 'easeInOutQuart'
            });
            overlayMenu.addClass('active');
        }

        function hideMenu() {
            navbar.animate({ 'opacity': 1, 'top': 0 }, {
                duration: 150,
                easing: 'easeInOutQuart'
            });
            overlayMenu.removeClass('active');
        }

        $(window).on('resize', function () {

            var windowWidth = Math.max($(window).width(), window.innerWidth),
				itemWidht = $('.grid-sizer').width(),
				itemHeight = Math.floor(itemWidht * 0.95),
				itemTallHeight = itemHeight * 2;
            
            if (windowWidth > 500) {
                $('.work-item', worksgrid).each(function () {
                    if ($(this).hasClass('tall')) {
                        $(this).css({
                            height: itemTallHeight
                        });
                    } else if ($(this).hasClass('wide')) {
                        $(this).css({
                            height: itemHeight
                        });
                    } else if ($(this).hasClass('wide-tall')) {
                        $(this).css({
                            height: itemTallHeight
                        });
                    } else {
                        $(this).css({
                            height: itemHeight
                        });
                    }
                });
            } else {
                $('.work-item', worksgrid).each(function () {
                    if ($(this).hasClass('tall')) {
                        $(this).css({
                            height: itemTallHeight
                        });
                    } else if ($(this).hasClass('wide')) {
                        $(this).css({
                            height: itemHeight / 2
                        });
                    } else if ($(this).hasClass('wide-tall')) {
                        $(this).css({
                            height: itemHeight
                        });
                    } else {
                        $(this).css({
                            height: itemHeight
                        });
                    }
                });
            }

            worksgrid.imagesLoaded(function () {
                worksgrid.isotope({
                    layoutMode: 'packery',
                    itemSelector: '.work-item',
                    transitionDuration: '0.3s',
                    packery: {
                        columnWidth: '.grid-sizer',
                    },
                });
            });

        }).resize();
    });

})(jQuery);
