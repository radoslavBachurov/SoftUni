export default {
    success: function (message) {
        const successBox = document.getElementById("successNotification");
        successBox.style.display = "block";
        successBox.textContent = message;
        setTimeout(() => {
            successBox.style.display = "none";
        }, 2000);
    },
    error: function (message) {
        const errorBox = document.getElementById("errorNotification");
        errorBox.style.display = "block";
        errorBox.textContent = message;
        setTimeout(() => {
            errorBox.style.display = "none";
        }, 2000);
    }
}