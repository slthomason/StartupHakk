const array = ['😉','😊','😇']

const copyWithEquals = array // Changes to array will change copyWithEquals
const copyWithAssign = [] // Changes to array will not change copyWithAssign
Object.assign(copyWithAssign, array) // Object.assign(target, source)

array[0] = '😡' // Whoops, a bug

console.log(...array) // 😡 😊 😇
console.log(...copyWithEquals) // 😡 😊 😇
console.log(...copyWithAssign) // 😉 😊 😇