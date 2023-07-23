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



{
  fetch("https://localhost:7218/api/Grades" , {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
    }
  })
    .then(response => response.json())
    .then(data => {
      // The data variable contains the response from the server
      var grade_ = data;
      const jsonString = JSON.stringify(grade_);
      sessionStorage.setItem('allGrades', jsonString);
       
       
    })
    .catch(error => {
      console.log("Error:", error);
    });

}




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
                  <button type="button" class="btn btn-success" onclick="editExamFunc(${exam.id})">Edit</button>
                  <button type="button" class="btn btn-danger" onclick="deleExamFunc(${exam.id})">Dele</button>
                  <button type="button" class="btn btn-warning" id="statbutn${exam._id+""}" onclick="staticExamFunc(${exam._id+""})">static</button>
                  <button type="button" class="btn btn-success" id="checkbutn${exam._id+""}" onclick="giveGrade(${exam._id+""})">check</button>
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


  fetch("https://localhost:7218/api/Tests/" + id, {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
    }
  })
    .then(response => response.json())
    .then(data => {
      // The data variable contains the response from the server
      var exam = data;
      const jsonString = JSON.stringify(exam);
      sessionStorage.setItem('examEdit', jsonString);
      window.location.href = "editExam.html";
       
    })
    .catch(error => {
      console.log("Error:", error);
    });


  // at the end 
  showTable();
}
//done
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
  var allGrades_ = sessionStorage.getItem('allGrades');
  // Parse the JSON string back into an object
  allGrades_ = JSON.parse(allGrades_);
  var gradeSpicifc = allGrades_.filter(function(grade) {
    
    return grade.idTest === id+"";
  });
  var butt = document.getElementById('statbutn'+id);
  console.log(gradeSpicifc);
  if(gradeSpicifc.length===0){
   
    butt.style.background='red';
    setTimeout(() => {
      butt.style.background='';
    }, 1000);
     
     
  }
  else{
    var listGrade=[];
    for(var a=0;a< gradeSpicifc.length;a++){
      listGrade.push(gradeSpicifc[a].gradeStudent);
    }
    
    console.log(listGrade);
    drawGraph(listGrade);
  }
  

  // at the end 
 
}
 //done
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
    nameOfTeacher: _theTeacher.name,
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
function giveGrade(id){
 
  var allGrades_ = sessionStorage.getItem('allGrades');
  // Parse the JSON string back into an object
  allGrades_ = JSON.parse(allGrades_);
  var gradeSpicifc = allGrades_.filter(function(grade) {
    
    return grade.idTest === id+"";
  });
  var butt = document.getElementById('checkbutn'+id);
   
  if(gradeSpicifc.length===0){
   
    butt.style.background='red';
    setTimeout(() => {
      butt.style.background='';
    }, 1000);
     
     
  }
  else{
    window.location.href = 'checkExam.html';
  const jsonString = JSON.stringify(gradeSpicifc);
  sessionStorage.setItem('gradeSToCheck', jsonString);

  }
  
}


function drawGraph(numbers) {
  const errorMessageElement = document.getElementById('graphX');
  errorMessageElement.innerHTML = `<canvas id="numberGraph"  ></canvas>
  <br>
  <button type="button" onclick="closeGraph()" class="btn btn-danger">X</button>`;



  var ctx = document.getElementById('numberGraph').getContext('2d');
  var data = {
      labels: Array.from({length: 101}, (_, i) => i), // Array from 0 to 100
      datasets: [{
          label: 'grade',
          data: numbers,
          borderColor: 'red',
          backgroundColor: 'rgba(0, 0, 255, 0.2)',
          fill: true
      }]
  };
  var options = {
      scales: {
          x: {
              display: true,
              title: {
                  display: true,
                  text: 'Value'
              }
          },
          y: {
              display: true,
              title: {
                  display: true,
                  text: 'Number'
              }
          }
      }
  };
  var myLineChart = new Chart(ctx, {
      type: 'line',
      data: data,
      options: options
  });

  

    // Show the error message
    errorMessageElement.style.display = 'block';
//errorMessageElement.style.display = 'none';
    
}
function closeGraph(){
  const errorMessageElement = document.getElementById('graphX');

    // Show the error message
    //errorMessageElement.style.display = 'block';
errorMessageElement.style.display = 'none';
}