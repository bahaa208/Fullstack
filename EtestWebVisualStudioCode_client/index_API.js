function sendToServer(){
    var cat = document.getElementById("category").value;
    var dif = document.getElementById("difficulty").value;

    var num = document.getElementById("numQuestions").value;
    console.log(num);
    if(num===""){showErrorMessage();return;}
    var url = `https://quizapi.io/api/v1/questions?apiKey=KcS6BsZEZ3zZHbeIi7CdYH4A3FzOkAMKVMeTiCII&category=${cat}&difficulty=${dif}&limit=${num}`;


    fetch(url)
    .then(response => response.json())
    .then(data => {
        console.log(data); // replace with actual code to handle response data
                // Assuming you have the following data
         
        // Get the table element from the HTML
        var table = document.querySelector('#quiz-table');

        // Create a table header row
        var headerRow = document.createElement('tr');
        headerRow.innerHTML = '<th><strong>Question<strong/></th><th>Answers</th><th> correct Answers</th>';
        table.appendChild(headerRow);
        var rowind=0;
        // Loop through the data and create a row for each item
        data.forEach(function(item) {
            
        var row = document.createElement('tr');
        var lisanswer = item.answers;
        var answersString = "";
         
        for (var key in lisanswer) {
        if (lisanswer[key] != null) {
            answersString += lisanswer[key] + " / ";
             
        }
        }
        var correctIndex = -1;
        var i = 0;
        for (var key in item.correct_answers) {
        if (item.correct_answers[key] === 'true') {
            correctIndex = i;
            break;
        }
        i++;
        }

        var corranswersString = "";
        
        var c=0;
        for (var key in lisanswer) {
            
        if (c===correctIndex) {
            corranswersString += lisanswer[key] ;
            
            break;
        }
         
        c++;}

        row.innerHTML = '<td >' + item.question + '</td>' + '<td>' + answersString + '</td><td>' +corranswersString  + '</td>' +'<td>' + `<button type="button" id="takeButtom${rowind}" onclick="addQuestionApi(0, '${item.question}', '*${answersString}*', ${c},${rowind})" class="btn btn-success">take</button>` + '</td>' ;
        table.appendChild(row);



        rowind++;
        });

    })
    .catch(error => {
        console.error(error); // replace with actual error handling code
    });

    

}

function addQuestionApi(i,txt,lisTA,p,j){
    var button = document.getElementById('takeButtom'+j);
    button.style.background='orange';

    save_Q(i,txt,lisTA,p);
}




function showErrorMessage() {
    const errorMessageElement = document.getElementById('errorMessage1');

    // Show the error message
    errorMessageElement.style.display = 'block';

    // Hide the error message after 3 seconds
    setTimeout(() => {
      errorMessageElement.style.display = 'none';
    }, 3000); // 3000 milliseconds = 3 seconds
}








function  save_Q(i,txt,lisTA_,p){
    var exam__ = sessionStorage.getItem('examEdit');
    let modifiedString = lisTA_.substring(1, lisTA_.length - 1);

    var listB = modifiedString.split('/');
    var lisTA=[]
    for(y=1;y<listB.length+1;y++){
        var t = listB[y-1];
        if(t!="" && t!="/" && t!=" "){
          var ele = {
        id: 0,
        text: t,
        questionId: 0
      }
          lisTA.push(ele);
        }
      }
     
    // Parse the JSON string back into an object
    var _exam = JSON.parse(exam__);
    var idex = _exam.id;
    if(i){
       
      


  var qus={
    
  id: 0,
  questionText: txt,
  correctAnswer: p,
  questionURLImageText: "string",
  listAnswer: lisTA,
  count: 0,
  testId: idex,
  studentChoose: 0,
  valueOfQuestion: 0,
  isOpen: 1

  }
  fetch("https://localhost:7218/api/Questions",
            {method:"POST",
             headers:{'Accept':'application/json',
                      'Content-Type':'application/json'},
                body:JSON.stringify(qus)}
            ).then(response => response.json())
            .then(data => {
              // The data variable contains the response from the server
              qus.id = data.id;
              _exam.allQuestionInTest.push(qus);
              const jsonString = JSON.stringify(_exam);
              sessionStorage.setItem('examEdit', jsonString);
             
            })
            .catch(error => {
              console.log('Error:', error);
            });
            // at the end 
  

    }
    else{
      


  var qus={
    
    id: 0,
    questionText: txt,
    correctAnswer: p,
    questionURLImageText: "string",
    listAnswer: lisTA,
    count: 0,
    testId: idex,
    studentChoose: 0,
    valueOfQuestion: 0,
    isOpen: 0
  
    }
    fetch("https://localhost:7218/api/Questions",
              {method:"POST",
               headers:{'Accept':'application/json',
                        'Content-Type':'application/json'},
                  body:JSON.stringify(qus)}
              ).then(response => response.json())
              .then(data => {
                // The data variable contains the response from the server
                qus.id = data.id;
                _exam.allQuestionInTest.push(qus);
                const jsonString = JSON.stringify(_exam);
                sessionStorage.setItem('examEdit', jsonString);
                  
              })
              .catch(error => {
                console.log('Error:', error);
              });
              // at the end 
    
  
  
    }
     
}
  
function backToPage(){
    window.location.href = 'editExam.html';
}  