import extend from "../utilus/context.js";

export default {
    get: {
        home(context) {
            extend(context).then(function () {
                this.partial("../view/home/home.hbs");
            })
        }
    }
}