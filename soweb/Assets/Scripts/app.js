(function ($) {

    "use strict";

    $(window).load(function () {
        $('.page-loader').fadeOut('slow');
    });

    $(document).ready(function () {

        $(window).scroll(function () {
            if ($(window).scrollTop() > 100)
                $('.scroll-up').fadeIn();
            else
                $('.scroll-up').fadeOut();
        }).scroll();

        $(window).resize(function () {
            $('#hello').height($(window).height());
        }).resize();

        $('a[href="#totop"]').click(function () {
            $('html, body').animate({ scrollTop: $(window).height() }, 'fast');
            return false;
        });

        $('.portfolio-grid').imagesLoaded(function (obj) {
            $(obj.elements).each(function () {
                var $grd = $(this);
                $grd.masonry({
                    itemSelector: '.portfolio-item',
                    columnWidth: '.grid-sizer',
                    percentPosition: true
                });
            });
        });

    });
})(jQuery);