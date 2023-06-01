// Only some of these will work with JSON.parse() followed by JSON.stringify()
const sampleObject = {
    string: 'string',
    number: 123,
    boolean: false,
    null: null,
    notANumber: NaN, // NaN values will be lost (the value will be forced to 'null')
    date: new Date('1999-12-31T23:59:59'),  // Date will get stringified
    undefined: undefined,  // Undefined values will be completely lost, including the key containing the undefined value
    infinity: Infinity,  // Infinity will be lost (the value will be forced to 'null')
    regExp: /.*/, // RegExp will be lost (the value will be forced to an empty object {})
  }
  
  console.log(sampleObject) // Object { string: "string", number: 123, boolean: false, null: null, notANumber: NaN, date: Date Fri Dec 31 1999 23:59:59 GMT-0500 (Eastern Standard Time), undefined: undefined, infinity: Infinity, regExp: /.*/ }
  console.log(typeof sampleObject.date) // object
  
  const faultyClone = JSON.parse(JSON.stringify(sampleObject))
  
  console.log(faultyClone) // Object { string: "string", number: 123, boolean: false, null: null, notANumber: null, date: "2000-01-01T04:59:59.000Z", infinity: null, regExp: {} }
  
  // The date object has been stringified, the result of .toISOString()
  console.log(typeof faultyClone.date) // string