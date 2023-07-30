function buildNewUser(){
    var pas = document.getElementById("password").value;
    
    var imstudent = document.getElementById("student");
    var imteacher = document.getElementById("teacher");
    


    var pas1 = document.getElementById("confirm-password").value;
    var username = document.getElementById("name").value;
    if(pas !== pas1 ||pas === "" || pas1 === "" ){
        document.getElementById("passlabel").style.color="red";
        
    }
    else{
        document.getElementById("passlabel").style.color="black";
        
    }
    
    if(username === ""){
        document.getElementById("namelabel").style.color="red";
        
    }
    else{document.getElementById("namelabel").style.color="black";
      }
    if(!imstudent.checked && !imteacher.checked){
        document.getElementById("imlabel").style.color="red";
        return;
        
    }
    else{document.getElementById("imlabel").style.color="black";
    }

    if(imteacher.checked){
        var user = {id: 0,
            name: username,
            password: pas,
            tests: []}
            fetch("https://localhost:7218/api/User_teacher",
            {method:"POST",
             headers:{'Accept':'application/json',
                      'Content-Type':'application/json'},
                body:JSON.stringify(user)}
            );
            
            window.location.href = "mainWindowSignIn.html";
    }
    if(imstudent.checked){
        var user = {
            id: 0,
            name: username,
            password: pas,
            grades: [
               
            ]
          }
            fetch("https://localhost:7218/api/User_student",
            {method:"POST",
             headers:{'Accept':'application/json',
                      'Content-Type':'application/json'},
                body:JSON.stringify(user)}
            );
            window.location.href = "mainWindowSignIn.html";
    }
    

    
}

function goSignUp(){
  // navigate to another HTML page
  window.location.href = "signUpPage.html";
 
   

}
async function goSignIn(){
  var pas = document.getElementById("password_").value;
  var imstudent = document.getElementById("student");
  var imteacher = document.getElementById("teacher");
    
  var user = document.getElementById("username_").value;

  if(pas === "" ){
    document.getElementById("labelpass_").style.color="red";
    return;
  }
  else{
    document.getElementById("labelpass_").style.color="black";
    
  }
  if(user === "" ){
    document.getElementById("labeluser_").style.color="red";
    return;
  }
  else{
    document.getElementById("labeluser_").style.color="black";
    
  }
  if(!imstudent.checked && !imteacher.checked){
    document.getElementById("imwhat").style.color="red";
    return;
  }
  else{
    document.getElementById("imwhat").style.color="black";
  }


  if(imteacher.checked){
    fetch(`https://localhost:7218/api/User_teacher/${user}`, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json'
    }
  })
    .then(response => {
      if (!response.ok) {
        throw new Error("User not found");
      }
      return response.json();
    })
    .then(data => {
      var user_ = data;
      var pasUser = user_.password;
      if (pasUser === pas) {
        // get in 
        const jsonString = JSON.stringify(user_);

        // Save the string in sessionStorage
        sessionStorage.setItem('myUser', jsonString);
        window.location.href = "teacherPage.html";
      } else {
        // error
        document.getElementById("errorPart").innerHTML = "error password";
      }
    })
    .catch(error => {
      console.error(error); // Log the error to the console for debugging purposes
      // Handle the error gracefully without further actions
    });

    
        
  }
  if(imstudent.checked){
       
    fetch(`https://localhost:7218/api/User_student/${user}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      }
    })
    .then(response => {
      if (!response.ok) {
        throw new Error("User not found");
      }
      return response.json();
    })
      .then(data => {
        var user_ = data;
        var pasUser = user_.password;
        if(pasUser === pas){
          // get in 
          const jsonString = JSON.stringify(user_);

          // Save the string in sessionStorage
          sessionStorage.setItem('myUser', jsonString);
          window.location.href = "STUDENT/studentPage.html";
        }
        else{
          //error
          document.getElementById("errorPart").innerHTML = "error password";

        }
         
      })
      .catch(error => {
        console.error(error); // Log the error to the console for debugging purposes
        // Handle the error gracefully without further actions
      });
  


  }
    

}