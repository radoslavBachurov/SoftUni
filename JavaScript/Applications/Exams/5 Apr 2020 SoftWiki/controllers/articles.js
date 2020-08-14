import extend from "../utilus/context.js";
import models from "../models/index.js";
import docModified from "../utilus/doc-modified.js";

export default {
    get: {
        dashboard(context) {
            models.articles.getAll().then((responce) => {

                const articles = responce.docs.map(docModified);
                let articlesList = { "CSharp": [], "JS": [], "Java": [], "Python": [] };

                articles.forEach(element => {
                    if (element.category == "C#") {
                        articlesList["CSharp"].push(element)
                    }
                    else if (element.category == "JavaScript") {
                        articlesList["JS"].push(element)
                    }
                    else if (element.category == "Java") {
                        articlesList["Java"].push(element)
                    }
                    else if (element.category == "Python") {
                        articlesList["Python"].push(element)
                    }
                });

                Object.keys(articlesList).forEach((key) => {
                    articlesList[key].sort((a, b) => a.title.localeCompare(b.title));
                    context[key] = articlesList[key];
                })

                extend(context).then(function () {
                    this.partial("../view/home/home.hbs");
                })
            })
        },

        create(context) {
            extend(context).then(function () {
                this.partial("../view/articles/create.hbs");
            })
        },

        details(context) {
            const { articleId } = context.params;
            models.articles.get(articleId).then((responce) => {
                const article = docModified(responce);

                Object.keys(article).forEach((key) => {
                    context[key] = article[key];
                })

                context.canEdit = article.uId === localStorage.getItem("userId");

                extend(context).then(function () {
                    this.partial("../view/articles/details.hbs")
                })
            }).catch((e) => console.error(e));
        },

        edit(context) {
            const { articleId } = context.params;
            models.articles.get(articleId).then((responce) => {
                const article = docModified(responce);

                Object.keys(article).forEach((key) => {
                    context[key] = article[key];
                })

                extend(context).then(function () {
                    this.partial("../view/articles/edit.hbs")
                })
            }).catch((e) => console.error(e));
        }
    },

    post: {
        create(context) {
            const data = {
                ...context.params,
                uId: localStorage.getItem("userId"),
            }

            models.articles.create(data).then((responce) => {
                context.redirect("#/articles/dashboard")
            }).catch((e) => console.error(e));
        }
    },

    del: {
        remove(context) {
            const { articleId } = context.params;
            models.articles.remove(articleId).then((responce) => {
                context.redirect("#/articles/dashboard");
            })
        }
    },

    put: {
        edit(context) {

            const { articleId, title, content } = context.params;
            models.articles.get(articleId).then((responce) => {
                const article = docModified(responce);
                article.title = title;
                article.content = content;
                return models.articles.edit(articleId, article);
            })
                .then((responce) => {
                    context.redirect("#/articles/dashboard")
                })
        }
    }
}