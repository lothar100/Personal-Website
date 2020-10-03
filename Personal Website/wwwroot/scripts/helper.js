
window.helper = {

    getHeight: function (elementId) {
        return document.getElementById(elementId).offsetHeight;
    },

    getWidth: function (elementId) {
        return document.getElementById(elementId).offsetWidth;
    },

    getScrollPosition: function (elementId) {
        var elem = document.getElementById(elementId);
        
        var scrollPosition = 0;
        while (elem && !isNaN(elem.offsetTop)) {
            scrollPosition += elem.offsetTop - elem.scrollTop;
            elem = elem.offsetParent;
        }

        return scrollPosition;
    },

    scrollIntoView: function (elementId) {
        var elem = document.getElementById(elementId);
        if (elem) {
            $('html, body').animate({
                scrollTop: helper.getScrollPosition(elementId) - 78 //-- offset to account for top bar and padding between cards
            }, 1000);
        }
    },

    displayQRCode: function (elementId, path) {
        var qrcode = new QRCode(elementId, {
            text: path,
            width: 128,
            height: 128,
            colorDark: "#000000",
            colorLight: "#ffffff"
        });
    }
}