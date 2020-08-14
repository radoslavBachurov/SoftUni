import extend from "../utilus/context.js";

export default {
    get: {
        homeLogin(context) {
            extend(context).then(function () {
                this.partial("../view/user/login.hbs");
            })
        },
    }
}