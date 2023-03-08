const adventurer = {
    name: 'Alice',
    cat: {
      name: 'Dinah'
    }
  }
  
  const dogName = adventurer?.dog?.name
  
  console.log("DogName: "+dogName)
  // expected output: undefined
  console.log("Adventurer: "+adventurer.someNonExistentMethod?.())
  // expected output: undefined       

      //  const showName = (name) => {
    //     name ??= 'fatfish'
    //     console.log(name)
    //   }
      
    //   showName('medium') // medium
    //   showName() // fatfish

    //   const showName = (name = 'fatfish') => {
    //     console.log(name)
    //   }
      
    //   showName('medium') // medium
    //   showName() // fatfish


    // const obj = {
    //     name: '',
    //     age: 0
    //   }
      
    //   obj.name ||= 'fatfish'
    //   obj.age ||= 100
      
    //   console.log(obj.name, obj.age) // fatfish 100


   // document.getElementById("lyrics").textContent ||= "No lyrics."


//    const obj = {
//     name: 'fatfish',
//     age: 100
//   }
  
//   obj.name &&= 'medium' // medium
//   obj.age &&= 1000 // 1000
//   console.log(obj.name, obj.age) // medium 1000