
///////NOT FINISHED
function solve() {
    let obj = (() => {
        let idCounter = 0;
        let nest = undefined;

        function addToHTML(element) {
            let holder = document.getElementById(nest);

            let mainDiv = document.createElement('div');
            mainDiv.setAttribute("id", `report_${element.ID}`);
            mainDiv.setAttribute("class", "report");

            let bodyDiv = document.createElement('div');
            bodyDiv.setAttribute("class", "body");
            let bodyPara = document.createElement('p');
            bodyPara.appendChild(document.createTextNode(element.description));
            bodyDiv.appendChild(bodyPara);

            let titleDiv = document.createElement('div');
            titleDiv.setAttribute('class', 'title');
            let titleSpan = document.createElement('span');
            titleSpan.setAttribute('class', 'author');
            titleSpan.appendChild(document.createTextNode(`Submitted by: ${element.author}`));

            let titleSpan2 = document.createElement('span');
            titleSpan.setAttribute('class', 'status');
            titleSpan.appendChild(document.createTextNode(`${element.status} | ${element.severity}`));

            titleDiv.appendChild(titleSpan);
            titleDiv.appendChild(titleSpan2);

            mainDiv.appendChild(bodyDiv);
            mainDiv.appendChild(titleDiv);

            holder.appendChild(mainDiv);
        }

        let bugReportList = []

        let report = function (author, description, reproducible, severity) {
            let newBug = {
                'ID': idCounter,
                'author': author,
                'description': description,
                'reproducible': reproducible,
                'severity': severity,
                'status': 'Open',
            }
            if (nest) {
                addToHTML(newBug);
                bugReportList.push(newBug);
                idCounter++;
            }
           
        }


        let setStatus = function (id, newStatus) {
            let bug = bugReportList.find(x => x.ID == id);
            bug.status = newStatus;
        }

        let remove = function (id) {
            bugReportList = bugReportList.filter(x => x.ID !== id);
        }

        let sort = function (method) {

        }

        let output = function (selector) {
            nest = selector;
        }

        return { sort, output, remove, setStatus, report }
    })();
    return obj;
}


