$(function () {
    $('.modal').on('click', function () {
        $('.modal.fade.in').css('display','flex');
    });
});

$(document).ready(function () {
    $(".menuimage").hover(
        function () {
            //$("img", this).fadeTo('fast', 0.5);
            $(".captiontext", this).fadeTo('medium', 1)
        },
        function () {
            //$("img", this).fadeTo('fast', 1);
            $(".captiontext", this).fadeTo(100, 0);
        }
    );
});
