window.browserResize = {

    registerResizeCallback: function () {
        window.addEventListener("resize", browserResize.resized);
    },

    resized: function () {
        DotNet.invokeMethodAsync("Personal Website", 'OnBrowserResize').then(data => data);
    }

}