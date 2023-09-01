const
  propValue = document.getElementById("propValue"),
  propDefault = document.getElementById("propDefault"),
  getValue = document.getElementById("getValue"),
  getDefault = document.getElementById("getDefault"),
  input = document.getElementById("test"),
  
  update = (e) => {
    propValue.textContent = input.value;
    propDefault.textContent = input.defaultValue;
    getValue.textContent = input.getAttribute("value");
    let value = input.getAttribute("defaultValue");
    getDefault.textContent = value === null ? "NULL" : value;
  }; // update

input.value = 50;
input.defaultValue = 150;
update();
input.addEventListener("input", update);