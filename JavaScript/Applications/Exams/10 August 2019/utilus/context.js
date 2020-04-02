export default function (context) {
    firebase.auth().onAuthStateChanged(function (user) {
        if (user) {
            // User is signed in.
            context.isLoggedIn = true;
            context.userId = user.uid;
            context.username = user.email;
            localStorage.setItem("userId", user.uid)
            localStorage.setItem("userEmail", user.email)

            // ...
        } else {
            // User is signed out.
            context.isLoggedIn = false;
            context.userId = null;
            context.username = null;

            localStorage.removeItem("userId")
            localStorage.removeItem("userEmail")

            // ...
        }
    });

    return context.loadPartials({
        notifications: "../view/common/nitofications.hbs",
        header: "../view/common/header.hbs",
        footer: "../view/common/footer.hbs"
    })
}
