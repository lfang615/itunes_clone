$(document).ready(function () {
    //dropdown menus
    $('.dropdown').hover(
    function () {
        $(this).children('.submenu').slideDown(200, stop());
    },
    function () {
        $(this).children('.submenu').slideUp(200, stop());
    }
    )
    function stop() {
        $('.submenu').stop(true, true);
    };

    //For sticky navigation
    $(window).scroll(function () {

        if ($(this).scrollTop() > $("header").height()) {

            $(".nav").css({ 'position': 'fixed', 'top': '0', 'left': '0' });
            $("#cartMenu").css({"position": "fixed", "top": "57px", "left":"1119px"});

        }
        else {

            $(".nav").css({ 'position': 'relative' });
            $("#cartMenu").css({"position": "fixed", "top": "205px", "left": "1119px"});

        }
    });

    $(".itemContainer").mouseover(function () {

        $(this).find(".qv").show();
        $(".btnClassQV").show();
      
    });

    $(".itemContainer").mouseout(function () {

        $(this).find(".qv").hide();
        $("#btnClassQV").hide();

    });

    $(".trendContainer").mouseover(function () {

        $(this).find(".qvHome").show();
        
    });

    $(".trendContainer").mouseout(function () {

        $(this).find(".qvHome").hide();
        
    });

    $(".overlay-bg").click(function () {
        $(".overlay-bg").hide();
        $(".popupMain").hide();

    });

    //slideshow
    $(".slideshow").slick({
        autoplay: true,

        centerMode: true,
        dots: true,
        fade: true,
        pauseOnHover: false,
        lazyLoad: "progressive",
        arrows: false
    });

    $(".lblCart").mouseover(function () {

        $("#cartMenu").fadeIn(700);
    });

    $(".lblCart").click(function () {
      
            $("#cartMenu").fadeOut(700);
       
    });




});