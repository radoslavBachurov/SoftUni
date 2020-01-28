function solve(input) {
    const data = input.map(x => JSON.parse(x));

    let table = (content) => `<table>${content}\n</table>`;
    let trow = (content) => `\n\t<tr>${content}\n\t</tr>`;
    let tdin = (content) => `\n\t\t<td>${content}</td>`;

    let result = data.reduce((acc, currRow) => {
        let rowResult = Object.values(currRow).reduce((acctwo, el) => {
            return acctwo + tdin(el)
        }, '')
        return acc + trow(rowResult);
    }, '');

    return table(result);
}


console.log(solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']
));

{/* <table>
	<tr>
		<td>Pesho</td>
		<td>Promenliva</td>
		<td>100000</td>
	</tr>
	<tr>
		<td>Teo</td>
		<td>Lecturer</td>
		<td>1000</td>
	</tr>
	<tr>
		<td>Georgi</td>
		<td>Lecturer</td>
		<td>1000</td>
	</tr>
</table> */}
