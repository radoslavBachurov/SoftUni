import models from "../models/index.js";
import extend from "../utilus/context.js";
import notification from "../utilus/notifications.js";

export default {
    get: {
        // login(context) {
        //     extend(context).then(function () {
        //         this.partial("../view/home/home.hbs")
        //     })

        // },
        register(context) {
            extend(context).then(function () {
                this.partial("../view/user/register.hbs")
            })

        },
        logout(context) {
            models.user.logout().then((responce) => {
                context.redirect("#/login");
            })
        }
    },

    post: {
        login(context) {
            const { email, password } = context.params;

            models.user.login(email, password)
                .then((responce) => {
                    context.user = responce.user;
                    context.username = responce.user.email;
                    context.isLoggedIn = true;
                    context.redirect("#/articles/dashboard");
                })
                .catch((e) => notification.error("Invalid username or password"));
        },
        register(context) {
            const { email, password, rePassword } = context.params;

            if (password === rePassword) {
                models.user.register(email, password)
                    .then((responce) => {
                        context.redirect("#/login");
                    })
                    .catch((e) => console.error(e))
            }
            else {
                notification.error("Passwords not match")
            }
        }
    }
}