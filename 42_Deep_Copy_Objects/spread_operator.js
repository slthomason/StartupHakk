const array = ['😉','😊','😇']

const copyWithEquals = array // Changes to array will change copyWithEquals
console.log(copyWithEquals === array) // true (The assignment operator did not make a copy)

const copyWithSpread = [...array] // Changes to array will not change copyWithSpread
console.log(copyWithSpread === array) // false (The spread operator made a shallow copy)

array[0] = '😡' // Whoops, a bug

console.log(...array) // 😡 😊 😇
console.log(...copyWithEquals) // 😡 😊 😇
console.log(...copyWithSpread) // 😉 😊 😇