import extend from "../utilus/context.js";
import models from "../models/index.js";
import docModified from "../utilus/doc-modified.js";
export default {
    get: {
        dashboard(context) {
            models.cause.getAll().then((responce) => {

                const causes = responce.docs.map(docModified);
                context.causes = causes;
                extend(context).then(function () {
                    this.partial("../view/cause/dashboard.hbs");
                })
            })
        },
        create(context) {
            extend(context).then(function () {
                this.partial("../view/cause/create.hbs");
            })
        },
        details(context) {
            const { causeId } = context.params;
            models.cause.get(causeId).then((responce) => {
                const cause = docModified(responce);
                Object.keys(cause).forEach((key) => {
                    context[key] = cause[key];
                })

                context.canDonate = cause.uId !== localStorage.getItem("userId");
                extend(context).then(function () {
                    this.partial("../view/cause/details.hbs")
                })
            }).catch((e) => console.error(e));
        }
    },
    post: {
        create(context) {

            const data = {
                ...context.params,
                uId: localStorage.getItem("userId"),
                collectedFunds: 0,
                donors: []
            }
            models.cause.create(data).then((responce) => {
                console.log(responce);
                context.redirect("#/cause/dashboard")
            }).catch((e) => console.error(e));
        }
    },
    del: {
        close(context) {
            const { causeId } = context.params;
            models.cause.close(causeId).then((responce) => {
                context.redirect("#/cause/dashboard");
            })
        }
    },
    put: {
        donate(context) {
            const { causeId, donatedAmount } = context.params;
            models.cause.get(causeId).then((responce) => {
                const cause = docModified(responce);
                cause.collectedFunds += Number(donatedAmount);
                cause.donors.push(localStorage.getItem("userEmail"))
                return models.cause.donate(causeId, cause);
            })
                .then((responce) => {
                    context.redirect("#/cause/dashboard")
                })
        }
    }
}