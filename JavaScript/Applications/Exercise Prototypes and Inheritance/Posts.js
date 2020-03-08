function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`

        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let toReturn = `${super.toString()}\n` +
                `Rating: ${this.likes - this.dislikes}`;

            if (this.comments.length > 0) {
                toReturn += `\nComments:\n`;
                this.comments.forEach(element => {
                    toReturn += ` * ${element}\n`
                });
            }
            return toReturn.trim();
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            let toReturn = `${super.toString()}\n` +
                `Views: ${this.views}`;
            return toReturn;
        }
    }

    return {
        BlogPost, Post, SocialMediaPost
    }
}


