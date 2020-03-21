function attachEvents() {
    let btnLoad = document.getElementById('btnLoadPosts');
    let postsBox = document.getElementById('posts');
    let btnView = document.getElementById('btnViewPost');

    let postComments = document.getElementById('post-comments');
    let postBody = document.getElementById('post-body');
    let postTitle = document.getElementById('post-title');


    btnLoad.addEventListener('click', loadPosts);

    async function loadPosts() {
        let url = `https://blog-apps-c12bf.firebaseio.com/posts.json`;

        let responce = await fetch(url);
        let data = await responce.json();
        let objPosts = Object.values(data)[0];

        for (const key in objPosts) {
            let newEl = document.createElement('option');
            newEl.value = key;
            newEl.textContent = objPosts[key].title;

            postsBox.appendChild(newEl);
        }
    }

    btnView.addEventListener('click', viewPost);

    async function viewPost() {
        var selected = postsBox.options[postsBox.selectedIndex].value;
        let url = `https://blog-apps-c12bf.firebaseio.com/posts/-M2Tz_NtAu9db4j_ZFqT/${selected}.json`;

        let responce = await fetch(url);
        let data = await responce.json();

        let comURL = `https://blog-apps-c12bf.firebaseio.com/comments.json`;

        let comResponce = await fetch(comURL);
        let comData = await comResponce.json();

        postTitle.textContent = data.title;
        postBody.textContent = data.body;
        postComments.innerHTML = '';

        for (const iterator of Object.values(comData)) {
            if (data.id === iterator.postId) {
                let newEl = document.createElement('li');
                newEl.id = iterator.id;
                newEl.textContent = iterator.text;

                postComments.appendChild(newEl);
            }
        }
    }
}

attachEvents();