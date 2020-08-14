import controllers from '../controllers/index.js';

const app = Sammy('#root', function () {
    this.use('Handlebars', 'hbs');

    //Home when logout
    this.get('#/login', controllers.home.get.homeLogin);

    //User
    this.get("#/user/register", controllers.user.get.register);
    this.get("#/user/logout", controllers.user.get.logout);

    this.post("#/user/login", controllers.user.post.login);
    this.post("#/user/register", controllers.user.post.register);

    //articles
    //Home when loggedIn
    this.get("#/articles/dashboard", controllers.articles.get.dashboard);

    this.get("#/articles/create", controllers.articles.get.create);
    this.get("#/articles/edit/:articleId", controllers.articles.get.edit);
    this.get("#/articles/details/:articleId", controllers.articles.get.details);

    this.post("#/articles/create", controllers.articles.post.create);
    this.post("#/articles/edit/:articleId", controllers.articles.put.edit);
    this.get("#/articles/delete/:articleId", controllers.articles.del.remove);
});

(() => {
    app.run("#/login");
})()