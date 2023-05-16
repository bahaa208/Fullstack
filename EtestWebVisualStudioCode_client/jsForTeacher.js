window.addEventListener('load', function() {
  // Your function code here
  var theTeacher = sessionStorage.getItem('myUser');

  // Parse the JSON string back into an object
  var _theTeacher = JSON.parse(theTeacher);
  var nameTeacher = _theTeacher.name;
  console.log("theTeacher:");
  document.getElementById("welcomPart").innerHTML = `Welcome ${nameTeacher}`;
  console.log(_theTeacher);
  showTable();
});

function showTable(){
  var table = document.getElementById("TabelOfExams");
  
  var theTeacher = sessionStorage.getItem('myUser');
  // Parse the JSON string back into an object
  theTeacher = JSON.parse(theTeacher);
  
  var exams = theTeacher.tests;
  // Display the exams in the table
  var stringT=``;
  for (var i = 0; i < exams.length; i++) {
    var exam = exams[i];
    stringT+=`<tr class="table-light">
              <th scope="row">${exam.name}</th>
              <td>${exam.date}</td>
              <td>${exam._id}</td>
              <td>
                  <span class="badge rounded-pill bg-success" onclick="editExamFunc(${exam.id})">Edit</span>
                  <span class="badge rounded-pill bg-danger" onclick="deleExamFunc(${exam.id})">Dele</span>
                  <span class="badge rounded-pill bg-warning" onclick="staticExamFunc(${exam.id})">static</span>
              </td>
            </tr>`;
  }
  table.innerHTML= stringT;
  /*
  <tr class="table-light">
    <th scope="row">nameExam</th>
    <td>DAte</td>
    <td>Id</td>
    <td>
        <span class="badge rounded-pill bg-success" onclick="editExamFunc(id)">Edit</span>
        <span class="badge rounded-pill bg-danger" onclick="deleExamFunc()">Dele</span>
        <span class="badge rounded-pill bg-warning" onclick="staticExamFunc()">static</span>
    </td>
  </tr>
  */


}


function editExamFunc(id){
  console.log(id);





  // at the end 
  showTable();
}
function deleExamFunc(id){
   
  fetch(`https://localhost:7218/api/Tests/${id}`, {
  method: "DELETE"
  }
);

  var theTeacher = sessionStorage.getItem('myUser');

  // Parse the JSON string back into an object
  var _theTeacher = JSON.parse(theTeacher);
  _theTeacher.tests = _theTeacher.tests.filter(function(test) {
    return test.id !== id;
  });
   
  const jsonString = JSON.stringify(_theTeacher);
  sessionStorage.setItem('myUser', jsonString);
  

  // at the end 
  showTable();
  
}
function staticExamFunc(id){
  console.log(id);


  // at the end 
  showTable();
}
 
function addExam(){

  var theTeacher = sessionStorage.getItem('myUser');

  // Parse the JSON string back into an object
  var _theTeacher = JSON.parse(theTeacher);
  var idTeacher = _theTeacher.id;


  var exam={
    id: 0,
    name: "newExam",
    _id: "---",
    date: "2023-05-16T11:19:19.692Z",
    nameOfTeacher: "---",
    time: 0,
    random: true,
    allQuestionInTest: [
      {
        id: 0,
        questionText: "string",
        correctAnswer: 0,
        questionURLImageText: "string",
        listAnswer: [
          {
            id: 0,
            text: "string",
            questionId: 0
          }
        ],
        count: 0,
        testId: 0,
        studentChoose: 0,
        valueOfQuestion: 0,
        isOpen: 0
      }
    ],
    user_teacherId: idTeacher
  }
  fetch("https://localhost:7218/api/Tests",
            {method:"POST",
             headers:{'Accept':'application/json',
                      'Content-Type':'application/json'},
                body:JSON.stringify(exam)}
            ).then(response => response.json())
            .then(data => {
              // The data variable contains the response from the server
              exam.id = data.id;
              _theTeacher.tests.push(exam);
              const jsonString = JSON.stringify(_theTeacher);
              sessionStorage.setItem('myUser', jsonString);
              showTable();
            })
            .catch(error => {
              console.log('Error:', error);
            });
  // at the end 
  

}