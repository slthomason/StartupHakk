
const nestedArray = [["😉"], ["😊"], ["😇"]]
const nestedCopyWithSpread = [...nestedArray]

console.log(nestedArray[0] === nestedCopyWithSpread[0]) // true -- Shallow copy (same reference)

// This is a hack to make a deep copy that is not recommended because it will often fail:
const nestedCopyWithHack = JSON.parse(JSON.stringify(nestedArray))

console.log(nestedArray[0] === nestedCopyWithHack[0]) // false -- Deep copy (different references)

// A better solution would be using a library like lodash or Ramda's clone() method