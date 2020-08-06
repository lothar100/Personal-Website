
window.onscroll = function () {
    if (document.documentElement.scrollTop > 5) {
        $(".unshrunk-lg").addClass("shrunk-lg");
        $(".unshrunk-md").addClass("shrunk-md");
        $(".unshrunk-sm").addClass("shrunk-sm");
        $(".shrunk-lg").removeClass("unshrunk-lg");
        $(".shrunk-md").removeClass("unshrunk-md");
        $(".shrunk-sm").removeClass("unshrunk-sm");
    } else {
        $(".shrunk-lg").addClass("unshrunk-lg");
        $(".shrunk-md").addClass("unshrunk-md");
        $(".shrunk-sm").addClass("unshrunk-sm");
        $(".unshrunk-lg").removeClass("shrunk-lg");
        $(".unshrunk-md").removeClass("shrunk-md");
        $(".unshrunk-sm").removeClass("shrunk-sm");
    }
};
