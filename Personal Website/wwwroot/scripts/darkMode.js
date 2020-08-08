
const enableDarkMode = () => {
    document.getElementById("primaryStyleSheet").setAttribute("href", "css/dark.css");
    localStorage.setItem("darkMode", "enabled");
}

const disableDarkMode = () => {
    document.getElementById("primaryStyleSheet").setAttribute("href", "css/light.css");
    localStorage.setItem("darkMode", "disabled");
}

//initializes dark mode settings
if (localStorage.getItem("darkMode") === "disabled") {
    disableDarkMode();
} else {
    enableDarkMode();
}

window.darkMode = {

    toggle: function () {
        darkMode = localStorage.getItem("darkMode");

        if (localStorage.getItem("darkMode") === "enabled") {
            disableDarkMode();
        } else {
            enableDarkMode();
        }
    },

    status: function () {
        return localStorage.getItem("darkMode");
    }

}