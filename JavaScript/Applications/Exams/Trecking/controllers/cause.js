
import extend from "../utilus/context.js";
import models from "../models/index.js";
import docModified from "../utilus/doc-modified.js";
export default {
    get: {
        dashboard(context) {
            models.cause.getAll().then((responce) => {

                const treks = responce.docs.map(docModified);
                //console.log(treks)
                treks.sort(function (a, b) {
                    return b.Likes - a.Likes
                });
                context.treks = treks;

                extend(context).then(function () {

                    this.partial("../view/home/home.hbs");
                })
            })
        },
        create(context) {
            extend(context).then(function () {
                this.partial("../view/cause/create.hbs");
            })
        },
        details(context) {
            // console.log(context);
            const { trekId } = context.params;
            models.cause.get(trekId).then((responce) => {
                const cause = docModified(responce);
                Object.keys(cause).forEach((key) => {
                    context[key] = cause[key];
                })
                //console.log(context)
                context.canEdit = cause.uId === localStorage.getItem("userId");
                extend(context).then(function () {
                    this.partial("../view/cause/details.hbs")
                })
            }).catch((e) => console.error(e));
        },
        edit(context) {

            const { trekId } = context.params;
            models.cause.get(trekId).then((responce) => {
                const cause = docModified(responce);
                Object.keys(cause).forEach((key) => {
                    context[key] = cause[key];
                })

                extend(context).then(function () {
                    this.partial("../view/cause/edit.hbs")
                })
            }).catch((e) => console.error(e));
        },
        show(context) {

            models.cause.getAll().then((responce) => {

                const treks = responce.docs.map(docModified);
                context.treks = [];

                for (let index = 0; index < treks.length; index++) {
                    if (localStorage.getItem("userId") === treks[index].uId) {

                        context.treks.push(treks[index]);
                    }
                }
                extend(context).then(function () {

                    this.partial("../view/user/userProfile.hbs")
                })
            })
        }

    },
    post: {
        create(context) {

            const data = {
                ...context.params,
                uId: localStorage.getItem("userId"),
                Organizer: localStorage.getItem("userEmail"),
                Likes: 0
            }

            if (data.location.length > 5 && data.description.length > 9) {

                models.cause.create(data).then((responce) => {
                    context.redirect("#/cause/dashboard");
                    //context.redirect("#/home")
                }).catch((e) => console.error(e));
            }
            else {
                console.log("Invalid Parameters: The trek name should be at least 6 characters long\nThe description should be at least 10 characters long.")
            }

        },
        edit(context) {
            const data = {
                ...context.params,
            }

            if (data.location.length > 5 && data.description.length > 9) {
                //console.log(data)
                models.cause.edit(data.trekId, data).then((responce) => {
                    context.redirect("#/cause/dashboard");
                    //context.redirect("#/home")
                }).catch((e) => console.error(e));
            }
            else {
                console.log("Invalid Parameters: The trek name should be at least 6 characters long\nThe description should be at least 10 characters long.")
            }

        }
    },
    del: {
        close(context) {

            const { trekId } = context.params;
            models.cause.close(trekId).then((responce) => {
                context.redirect("#/cause/dashboard");
            })
        }
    },
    put: {
        donate(context) {

            const { trekId } = context.params;
            models.cause.get(trekId).then((responce) => {
                const trek = docModified(responce);

                trek.Likes++;
                return models.cause.donate(trekId, trek);
            })
                .then((responce) => {
                    context.redirect(`#/cause/details/${trekId}`)
                })
        }
    }
}