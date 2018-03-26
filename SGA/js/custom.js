function AddFormElement(eleName, eleType, eleValue, eleParent) {
    var ele = document.createElement(eleType);
    ele.setAttribute("type", "hidden");
    ele.name = eleName;
    ele.value = eleValue;
    if (eleParent)
        eleParent.appendChild(ele);

    return ele;
}
// Removes leading whitespaces
function LTrim(value) {
    var re = /\s*((\S+\s*)*)/;
    return value.replace(re, "$1");

}

// Removes ending whitespaces
function RTrim(value) {
    var re = /((\s*\S+)*)\s*/;
    return value.replace(re, "$1");

}

// Removes leading and ending whitespaces
function trim(value) {
    return LTrim(RTrim(value));
}
$(document).ready(function () {
    $("input[type=text]").focus(function () {
		if(this.value == this.defaultValue) {
			this.value = "";
		}
	}).blur(function(){
		if(this.value.length == 0) {
			this.value = this.defaultValue;
		}
	});
})

// hide address bar
if (!window.addEventListener) {
    window.attachEvent("load", function () {
        // Set a timeout...
        setTimeout(function () {
            // Hide the address bar!
            window.scrollTo(0, 1);
        }, 0);
    });
} else {
    window.addEventListener("load", function () {
        // Set a timeout...
        setTimeout(function () {
            // Hide the address bar!
            window.scrollTo(0, 1);
        }, 0);
    });
}
