//test javascript load
console.log("Hello World");
//declare variables
const strBtn = document.getElementById("strength");
const aglBtn = document.getElementById("agility");
const intBtn = document.getElementById("intellect");
const willBtn = document.getElementById("will");
//assign dom element to variable for testing
let changedText = document.getElementById('changed');
//prime changed on load
changedText.textContent = "1";
//options for primed value on load
if (changedText.textContent === "1") {
    strBtn.classList.remove("disabled");
    aglBtn.classList.remove("disabled");
    intBtn.classList.add("disabled");
    willBtn.classList.add("disabled");
    console.log(changedText, "option 1")
}

//function to assign value to changed and change buttons on change
function listQ() {
    changedText.textContent = this.value;
    if (changedText.textContent === "1") {
        strBtn.classList.remove("disabled");
        aglBtn.classList.remove("disabled");
        intBtn.classList.add("disabled");
        willBtn.classList.add("disabled");
    }
    if (changedText.textContent === "2") {
        strBtn.classList.remove("disabled");
        aglBtn.classList.add("disabled");
        intBtn.classList.add("disabled");
        willBtn.classList.add("disabled");
    }
    if (changedText.textContent === "3") {
        strBtn.classList.add("disabled");
        aglBtn.classList.add("disabled");
        intBtn.classList.remove("disabled");
        willBtn.classList.remove("disabled");
    }
    if (changedText.textContent === "4") {
        strBtn.classList.add("disabled");
        aglBtn.classList.remove("disabled");
        intBtn.classList.remove("disabled");
        willBtn.classList.add("disabled");
    }

    if (changedText.textContent === "5") {
        strBtn.classList.remove("disabled");
        aglBtn.classList.remove("disabled");
        intBtn.classList.remove("disabled");
        willBtn.classList.remove("disabled");
    }
}
//get value on change to call function
document.getElementById("ClockworkPurposeId").onchange = listQ;
