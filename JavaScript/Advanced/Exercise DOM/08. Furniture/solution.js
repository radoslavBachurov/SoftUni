function solve() {

  let input = document.getElementsByTagName('textarea')[0];
  let generateButton = document.getElementsByTagName('button')[0];
  let furniture = document.getElementsByTagName('tbody')[0];
  let buyButton = document.getElementsByTagName('button')[1];
  let output = document.getElementsByTagName('textarea')[1];

  generateButton.addEventListener('click', generate)
  buyButton.addEventListener('click', buy);

  function buy() {
    let allFurniture = Array.from(document.getElementsByTagName('input'));
    let boughtNames = [];
    let totalPrice = 0;
    let totalFactor = 0;

    for (const element of allFurniture) {
      if (element.checked === true) {
        let parentDiv = (element.parentNode).parentNode;
        boughtNames.push(parentDiv.getElementsByTagName('p')[0].innerHTML);
        totalPrice += Number(parentDiv.getElementsByTagName('p')[1].innerHTML);
        totalFactor += Number(parentDiv.getElementsByTagName('p')[2].innerHTML);
      }
    }
    output.value = ''
    output.value += `Bought furniture: ${boughtNames.join(', ')}\n`;
    output.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    output.value += `Average decoration factor: ${totalFactor/boughtNames.length}`;

  }
  function generate() {
    let inputInfo = Array.from(JSON.parse(input.value));

    for (const singleFurniture of inputInfo) {

      let node = document.createElement("tr");

      for (const parametr in singleFurniture) {

        node.appendChild(createSingleFurniture(parametr, singleFurniture));

      }
      node.appendChild(addCheckBox());
      furniture.appendChild(node);
    }

    input.value = '';
  }

  function addCheckBox() {
    var elNode = document.createElement("td");
    var checkBox = document.createElement('input');
    checkBox.type = "checkbox";
    checkBox.value = "disabled";

    elNode.appendChild(checkBox);
    return elNode;
  }

  function createSingleFurniture(parametr, singleFurniture) {
    var elNode = document.createElement("td");
    if (parametr == 'img') {
      var paraNode = document.createElement("img");
      paraNode.src = singleFurniture['img'];
    } else {
      var paraNode = document.createElement("p");
      let textnode = document.createTextNode(singleFurniture[parametr]);
      paraNode.appendChild(textnode);
    }
    elNode.appendChild(paraNode);

    return elNode;
  }


}