   const obj = {
    name: 'fatfish',
    age: 100
  }
  
  obj.name &&= 'medium' // medium
  obj.age &&= 1000 // 1000
  console.log(obj.name, obj.age) // medium 1000   