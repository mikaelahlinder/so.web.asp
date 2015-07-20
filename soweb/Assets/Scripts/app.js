(function ($) {

    "use strict";

    $(window).load(function () {
        $('.page-loader').fadeOut('slow');
    });

    $(document).ready(function () {

        var navbar = $('.navbar-custom');
        var isNavbarTransparent = navbar.hasClass('navbar-transparent');
        $(window).scroll(function () {

            if (isNavbarTransparent !== false) 
                navbar.toggleClass('navbar-transparent', $(window).scrollTop() < 5);

            if ($(this).scrollTop() > 100) 
                $('.scroll-up').fadeIn();
             else 
                $('.scroll-up').fadeOut();

        }).scroll();

        $('a[href="#totop"]').click(function () {
            $('html, body').animate({ scrollTop: 0 }, 'fast');
            return false;
        });

        var $grid = $('.portfolio-grid').imagesLoaded(function () {

            $(window).resize(function() {
                $('.portfolio-item').each(function() {
                    var $this = $(this);
                    if ($this.hasClass('portfolio-group-separator'))
                        return;

                    var img = $this.find('img');
                    var isPortrait = img.width() < img.height();
                    var thisWidth = Math.round($this.width());
                    $this.css({
                        height: isPortrait ? thisWidth * 1.5 : thisWidth * 0.67
                    });
                });
            }).resize();

            $grid.masonry({
                itemSelector: '.portfolio-item',
                columnWidth: '.grid-sizer',
                percentPosition: true,
                transitionDuration: '0'
            });
        });
    });
})(jQuery);