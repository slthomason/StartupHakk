import _ from "lodash" // Import the entire lodash library
// import { clone, cloneDeep } from "lodash" // Alternatively: Import just the clone methods from lodash

const nestedArray = [["😉"], ["😊"], ["😇"]]
// This array is nested 1 level, though the behavior is the same with any degree of nesting

const notACopyWithEquals = nestedArray
console.log(nestedArray[0] === notACopyWithEquals[0]) // true -- Not a copy (same reference)

const shallowCopyWithSpread = [...nestedArray]
console.log(nestedArray[0] === shallowCopyWithSpread[0]) // true -- Shallow copy (same reference)

const shallowCopyWithLodashClone = _.clone(nestedArray)
console.log(nestedArray[0] === shallowCopyWithLodashClone[0]) // true -- Shallow copy (same reference)

const deepCopyWithLodashCloneDeep = _.cloneDeep(nestedArray)
console.log(nestedArray[0] === deepCopyWithLodashCloneDeep[0]) // false -- Deep copy (different reference)

// Try to change the reference for the 1st element, won't work for any copy
nestedArray[0] = "🧐"

// Try to change the nested reference for the 3rd element:
nestedArray[2][0] = "😈"

console.log(...nestedArray) // 🧐 ["😊"] ["😈"]
console.log(...notACopyWithEquals) // 🧐 ["😊"] ["😈"]
console.log(...shallowCopyWithSpread) // ["😉"] ["😊"] ["😈"]
console.log(...shallowCopyWithLodashClone) // ["😉"] ["😊"] ["😈"]
console.log(...deepCopyWithLodashCloneDeep) // ["😉"] ["😊"] ["😇"]