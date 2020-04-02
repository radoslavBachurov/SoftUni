import models from "../models/index.js";
import extend from "../utilus/context.js";
export default {
    get: {
        login(context) {
            extend(context).then(function () {
                this.partial("../view/user/login.hbs")
            })

        },
        register(context) {
            extend(context).then(function () {
                this.partial("../view/user/register.hbs")
            })

        },
        logout(context) {
            models.user.logout().then((responce) => {
                context.redirect("#/home");
            })
        }
    },
    post: {
        login(context) {
            const { username, password } = context.params;

            models.user.login(username, password)
                .then((responce) => {
                    context.user = responce;
                    context.username = responce.email;
                    context.isLoggedIn = true;
                    context.redirect("#/home");
                })
                .catch((e) => console.error(e));
        },
        register(context) {
            const { username, password, rePassword } = context.params;

            if (password === rePassword) {
                models.user.register(username, password)
                    .then((responce) => {
                        context.redirect("#/user/login");
                    })
                    .catch((e) => console.error(e))
            }
        }
    }
}