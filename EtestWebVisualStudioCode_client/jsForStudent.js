window.addEventListener('load', function() {
    // Your function code here
var theStudent = sessionStorage.getItem('myUser');

// Parse the JSON string back into an object
var _theStudent = JSON.parse(theStudent);
console.log("theStudent:");

console.log(_theStudent);

});