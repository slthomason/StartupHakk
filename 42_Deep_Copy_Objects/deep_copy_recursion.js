const deepCopyFunction = (inObject) => {
    let outObject, value, key
  
    if (typeof inObject !== "object" || inObject === null) {
      return inObject // Return the value if inObject is not an object
    }
  
    // Create an array or object to hold the values
    outObject = Array.isArray(inObject) ? [] : {}
  
    for (key in inObject) {
      value = inObject[key]
  
      // Recursively (deep) copy for nested objects, including arrays
      outObject[key] = deepCopyFunction(value)
    }
  
    return outObject
  }
  
  let originalArray = [37, 3700, { hello: "world" }]
  console.log("Original array:", ...originalArray) // 37 3700 Object { hello: "world" }
  
  let shallowCopiedArray = originalArray.slice()
  let deepCopiedArray = deepCopyFunction(originalArray)
  
  originalArray[1] = 0 // Will affect the original only
  console.log(`originalArray[1] = 0 // Will affect the original only`)
  originalArray[2].hello = "moon" // Will affect the original and the shallow copy
  console.log(`originalArray[2].hello = "moon" // Will affect the original array and the shallow copy`)
  
  console.log("Original array:", ...originalArray) // 37 0 Object { hello: "moon" }
  console.log("Shallow copy:", ...shallowCopiedArray) // 37 3700 Object { hello: "moon" }
  console.log("Deep copy:", ...deepCopiedArray) // 37 3700 Object { hello: "world" }