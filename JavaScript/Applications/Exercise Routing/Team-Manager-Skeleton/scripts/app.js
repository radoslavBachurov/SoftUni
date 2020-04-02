// initialize the application
async function homeViewHandler() {

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/home/home.hbs')
}

async function aboutViewHandler() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/about/about.hbs')
}

var app = Sammy('#main', function () {
    // include a plugin
    this.use('HandleBars', 'hbs');

    // define a 'route'
    this.get('#/', homeViewHandler);
    this.get('#/Home', homeViewHandler);
    this.get('#/about , aboutViewHandler')
});

$(function () {
    app.run('#/');
})

// start the application


//NOT FINISHED

