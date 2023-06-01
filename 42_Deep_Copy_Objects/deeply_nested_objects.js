const nestedArray = [['😉'],['😊'],['😇']]
const nestedCopyWithSpread = [...nestedArray]

nestedArray[0][0] = '😡' // Whoops, a bug

console.log(...nestedArray) // ["😡"] ["😊"] ["😇"]
console.log(...nestedCopyWithSpread) // ["😡"] ["😊"] ["😇"]

// This is a hack to make a deep copy that is not recommended because it will often fail:
const nestedCopyWithHack = JSON.parse(JSON.stringify(nestedArray)) // Make a deep copy
nestedCopyWithHack[0][0] = '😉' // Only this copied array will be changed

console.log(...nestedArray) // ["😡"] ["😊"] ["😇"]
console.log(...nestedCopyWithSpread) // ["😡"] ["😊"] ["😇"]
console.log(...nestedCopyWithHack) // ["😉"] ["😊"] ["😇"]

// A better solution would be using a library like lodash or Ramda's clone() methodA