(function ($) {

    "use strict";

    function imageSizer(worksgrid) {
        $('.work-item', worksgrid).each(function () {
            var $this = $(this);
            var img = $this.find('img');
            var isPortrait = img.width() < img.height();
            var thisWidth = $this.width() * 0.95;

            $this.css({
                height: isPortrait ? thisWidth * 1.4 : thisWidth * 0.7
            });
        });

        worksgrid.imagesLoaded(function () {
            worksgrid.isotope({
                layoutMode: 'packery',
                itemSelector: '.work-item',
                transitionDuration: '0.3s',
                packery: {
                },
            });
        });
    }

    $(window).load(function () {
        $('.page-loader').fadeOut('slow');
        imageSizer($('.works-grid'));
    });

    $(document).ready(function () {
        var navbar = $('.navbar-custom');
        var isNavbarTransparent = navbar.length > 0 && navbar.hasClass('navbar-transparent');
        $(window).scroll(function () {
            if (navbar.length > 0 && isNavbarTransparent !== false) {
                navbar.toggleClass('navbar-transparent', $(window).scrollTop() < 5);
            }
        }).scroll();
        $(window).on('resize', imageSizer($('.works-grid')));
    });
})(jQuery);