class Article {
    _likes;
    _comments;
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this.comments = [];
        this.likes = [];
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        }
        if (this._likes.length == 1) {
            return `${this._likes[0]} likes this article!`;
        }
        else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`;
        }
    }

    set likes(value) {
        this._likes = [];
    }

    set comments(value) {
        this._comments = [];
    }

    like(username) {
        if (this._likes.some(x => x == username)) {
            throw new Error("You can't like the same article twice!");
        }
        else if (this.creator == username) {
            throw new Error("You can't like your own articles!");
        }
        else {
            this._likes.push(username);
            return `${username} liked ${this.title}!`

        }
    }

    dislike(username) {
        if (!this._likes.some(x => x == username)) {
            throw new Error("You can't dislike this article!");
        }
        else {
            let index = this._likes.indexOf(username);
            this._likes.splice(index, 1);
            return `${username} disliked ${this.title}`;
        }
    }

    comment(username, content, id) {
        if (id === undefined || !this._comments.some(x => x.id === id)) {
            let number = this._comments.length + 1;
            let newComment = {
                'id': number,
                'username': username,
                'content': content,
                'replies': []
            };
            this._comments.push(newComment);
            return `${username} commented on ${this.title}`
        }
        else {
            let number = Number(`${id}.${this._comments[id - 1].replies.length + 1}`);
            let newreply = {
                'id': number,
                'username': username,
                'content': content,
            }
            this._comments[id - 1].replies.push(newreply);
            return "You replied successfully";
        }
    }

    toString(sortingType) {
        let toReturn = '';
        toReturn += `Title: ${this.title}\n`;
        toReturn += `Creator: ${this.creator}\n`;
        toReturn += `Likes: ${this._likes.length}\n`;
        toReturn += 'Comments:\n';
        this._comments = this._comments.sort(mySort);

        for (const comment of this._comments) {
            toReturn += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`
            if (comment.replies.length > 0) {
                comment.replies.sort(mySort);
                comment.replies.forEach(element => {
                    toReturn += `--- ${element.id}. ${element.username}: ${element.content}\n`;
                });
            }
        }

        return toReturn.trim();

        function mySort(a, b) {
            if (sortingType == 'asc') {
                return a.id - b.id;
            }
            else if (sortingType == 'desc') {
                return b.id - a.id;
            }
            else {
               return a.username.localeCompare(b.username);
            }
        }

    }
}









