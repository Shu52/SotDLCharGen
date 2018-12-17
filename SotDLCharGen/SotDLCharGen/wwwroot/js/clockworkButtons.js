//test javascript load
console.log("Hello World");
//declare variables
const strBtn = document.getElementById("strength");
const aglBtn = document.getElementById("agility");
const intBtn = document.getElementById("intellect");
const willBtn = document.getElementById("will");
let attributeSelected = "";
//assign dom element to variable for testing
let changedText = document.getElementById('changed');
//prime changed on load
changedText.textContent = "1";
//options for primed value on load
if (changedText.textContent === "1") {
    strBtn.classList.remove("hidden");
    aglBtn.classList.remove("hidden");
    intBtn.classList.add("hidden");
    willBtn.classList.add("hidden");
    console.log(changedText, "option 1")
}

//function to assign value to changed and change buttons on change
function listQ() {
    changedText.textContent = this.value;
    if (changedText.textContent === "1") {
        strBtn.classList.remove("hidden");
        aglBtn.classList.remove("hidden");
        intBtn.classList.add("hidden");
        willBtn.classList.add("hidden");
    }
    if (changedText.textContent === "2") {
        strBtn.classList.remove("hidden");
        aglBtn.classList.add("hidden");
        intBtn.classList.add("hidden");
        willBtn.classList.add("hidden");
    }
    if (changedText.textContent === "3") {
        strBtn.classList.add("hidden");
        aglBtn.classList.add("hidden");
        intBtn.classList.remove("hidden");
        willBtn.classList.remove("hidden");
    }
    if (changedText.textContent === "4") {
        strBtn.classList.add("hidden");
        aglBtn.classList.remove("hidden");
        intBtn.classList.remove("hidden");
        willBtn.classList.add("hidden");
    }

    if (changedText.textContent === "5") {
        strBtn.classList.remove("hidden");
        aglBtn.classList.remove("hidden");
        intBtn.classList.remove("hidden");
        willBtn.classList.remove("hidden");
    }
}
//get value on change to call function
document.getElementById("ClockworkPurposeId").onchange = listQ;

function focusedAttribute(attributeElement) {
    if (attributeElement.classList.contains("hidden")) {
        console.log("Not allowed")
    }
    else {
        attributeSelected = attributeElement.id;
        console.log(attributeSelected, attributeElement.id);
    }
}
document.getElementById("savePurpose").addEventListener("click", e => {
    console.log(changedText.textContent,attributeSelected)
}
    )
console.log("class name", document.getElementById('will').classList.contains("hidden"))