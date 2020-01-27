function solve(input) {
    const inputArr = input;
    let uniqueWords = new Set();

    for (let index = 0; index < inputArr.length; index++) {
        let currString = input[index].split(/\W+/).filter(x => x != '');

        for (let f = 0; f < currString.length; f++) {
            uniqueWords.add(currString[f].toLowerCase());
        }
    }

    let array = Array.from(uniqueWords);
   
    return array.join(', ');
}

console.log(solve(['Interdum et malesuada fames ac ante ipsum primis in faucibus.',
    'Vestibulum volutpat lacinia blandit.',
    'Pellentesque dignissim odio in hendrerit lacinia.',
    'Vivamus placerat porttitor purus nec hendrerit.',
    'Aliquam erat volutpat. Donec ac augue ligula.',
    'Praesent venenatis sapien vitae libero ornare, nec pulvinar velit finibus.',
    'Proin dui neque, rutrum vel dolor ut, placerat blandit sapien.',
    'Pellentesque at est arcu.',
    'Nullam eget orci laoreet, feugiat nisi vitae, egestas libero.',
    'Pellentesque pulvinar aliquet felis.',
    'Interdum et malesuada fames ac ante ipsum primis in faucibus.',
    'Etiam sit amet nisl ex.',
    'Sed lacinia pretium metus quis fermentum.',
    'Praesent a ante suscipit, efficitur risus cursus, scelerisque risus.']
));