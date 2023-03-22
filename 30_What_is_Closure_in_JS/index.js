function outerFunction(x) {
    let y = x;
    function innerFunction() {
      console.log(y);
    }
    return innerFunction;
  }
  let myClosure = outerFunction(5);
  myClosure(); // Outputs: 5  