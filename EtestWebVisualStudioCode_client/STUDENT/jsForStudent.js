window.addEventListener('load', function() {
    // Your function code here
var theStudent = sessionStorage.getItem('myUser');

// Parse the JSON string back into an object
var _theStudent = JSON.parse(theStudent);
console.log("theStudent:");

console.log(_theStudent);
var name = document.getElementById("welcomName");
name.innerHTML = `     <div>Welcome ${_theStudent.name}</div>`;
showTable();
});
 

function seeExam(id){
    var theStudent = sessionStorage.getItem('myUser');
    // Parse the JSON string back into an object
    theStudent = JSON.parse(theStudent);
    
    var grades = theStudent.grades;
    // Display the grades in the table
    
    for (var i = 0; i < grades.length; i++) {
      var grade = grades[i];
      if(grade.id===id){
        const jsonString = JSON.stringify(grade);

          // Save the string in sessionStorage
          sessionStorage.setItem('examToSee', jsonString);
          window.location.href = "theExam.html";
      }
 
      
    }

}
function showTable(){
    var table = document.getElementById("TabelOfGrade");
    
    var theStudent = sessionStorage.getItem('myUser');
    // Parse the JSON string back into an object
    theStudent = JSON.parse(theStudent);
    
    var grades = theStudent.grades;
    // Display the grades in the table
    var stringT=``;
    for (var i = 0; i < grades.length; i++) {
      var grade = grades[i];
      if(grade.gradeStudent>0){
        stringT+=`<tr class="table-light">
        <th scope="row">${grade.nameOfExam}</th>
        <td>${grade.idTest}</td>
        <td>${grade.gradeStudent}</td>
        <td>
            <button type="button" class="btn btn-success" onclick="seeExam(${grade.id})">Check</button>
            
        </td>
      </tr>`;
      }
      
    }
    table.innerHTML= stringT;
    
  
  }
  
  