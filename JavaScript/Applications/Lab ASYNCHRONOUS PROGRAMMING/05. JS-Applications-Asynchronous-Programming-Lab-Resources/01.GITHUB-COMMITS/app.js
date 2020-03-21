async function loadCommits() {
    let name = document.getElementById('username');
    let repo = document.getElementById('repo');
    let list = document.getElementById('commits');
    list.innerHTML = '';

    let url = `https://api.github.com/repos/${name.value}/${repo.value}/commits`;

    try {

        const response = await fetch(url);
        if (response.status < 400) {
            const data = await response.json();

            for (const element of data) {
                let el = document.createElement('li');
                el.textContent = `${element.commit.author.name}: ${element.commit.message}`;
                list.appendChild(el);
            }
        }
        else {
            throw ({
                'status': response.status,
                'statusText': response.statusText
            })
        }
    } catch (error) {
        let el = document.createElement('li');
        el.textContent = `Error: ${error.status} (${error.statusText})`;
        list.appendChild(el);
    }
}