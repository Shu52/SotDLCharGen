//test javascript load
console.log("Hello World");
//assign dom element to variable for testing
let changedText = document.getElementById('changed');
//prime changed on load
changedText.textContent = 1;
//function to assign value to changed
function listQ() {
    changedText.textContent = this.value;
}
//get value on change to call function
document.getElementById("ClockworkPurposeId").onchange = listQ;

if (changedText.textContent === 1) {
    const intBtn = document.getElementById("intellect");
    intBtn.classList.add("disabled");
    console.log ("option 1")
}
