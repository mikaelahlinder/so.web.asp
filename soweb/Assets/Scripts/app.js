(function ($) {

    "use strict";

    $(window).load(function () {
        $('.page-loader').fadeOut('slow');
    });

    $(document).ready(function () {
        var navbar = $('.navbar-custom');
        var isNavbarTransparent = navbar.length > 0 && navbar.hasClass('navbar-transparent');
        $(window).scroll(function () {
            if (navbar.length > 0 && isNavbarTransparent !== false) {
                navbar.toggleClass('navbar-transparent', $(window).scrollTop() < 5);
            }
        }).scroll();

        var $grid = $('.portfolio-grid').imagesLoaded(function () {

            $('.portfolio-item').each(function () {
                var $this = $(this);
                if ($this.hasClass('portfolio-group-separator'))
                    return;
                var img = $this.find('img');
                var isPortrait = img.width() < img.height();
                var thisWidth = Math.round($this.width() * 0.95);
                $this.css({
                    height: isPortrait ? thisWidth * 1.4 : thisWidth * 0.74
                });
            });

            $grid.masonry({
                itemSelector: '.portfolio-item',
                columnWidth: '.grid-sizer',
                percentPosition: true,
                transitionDuration: '0.2s'
            });
        });
    });
})(jQuery);