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

        $('a[href="#totop"]').click(function () {
            $('html, body').animate({ scrollTop: $(window).height() }, 'fast');
            return false;
        });

        $('.portfolio-grid').imagesLoaded(function (obj) {

            $(window).resize(function () {
                //$(obj.elements).each(function () {
                //    var $this = $(this);
                //    var img = $this.find('img');
                //    var isPortrait = img.width() < img.height();
                //    var thisWidth = Math.round($this.width());
                //    console.log(isPortrait);
                //    $this.css({
                //        height: isPortrait ? thisWidth * 2.8 : thisWidth * 0.67
                //    });
                //});

                $('#hello').height($(window).height());

            }).resize();

            $(obj.elements).each(function () {
                var $grd = $(this);
                $grd.masonry({
                    itemSelector: '.portfolio-item',
                    columnWidth: '.grid-sizer',
                    percentPosition: true,
                    isOriginLeft: !$grd.hasClass('cluster-right')
                });
            });
        });
    });
})(jQuery);