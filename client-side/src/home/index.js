
"use strict";

let token= null;
const script = document.createElement('script');
script.src = '//code.jquery.com/jquery-1.11.0.min.js';
document.getElementsByTagName('head')[0].appendChild(script);

const patientControllerURL = "https://localhost:44377/api/patient";
const loginBtn = document.getElementById("loginBtn");
if (loginBtn !== null) {
    loginBtn.addEventListener("click", async function () {

        const userNameInp= document.getElementsByName("username")[0];
        const passwordInp= document.getElementsByName("pass")[0];
        let check = true;
            // if(validate(userNameInp) == false){
            //          showValidate(userNameInp);
            //              check=false;
            // }
            // if(validate(passwordInp) == false){
            //         showValidate(passwordInp);
            //             check=false;
            // }

        if (check === true){
         //   window.location.href = "src/menu/index.html";
               authenticateUser()
               .then((response)=>{
                   alert(response);
                   token = response;
                   //document.cookie='access_token=[response]';
              window.location.href = "src/menu/index.html";

                   
          
        });
    }
});
}

const registerBtn = document.getElementById("registerBtn");
if (registerBtn !== null) {
    registerBtn.addEventListener("click", async function () {

        const userNameInp= document.getElementById("usernameNew");
        const passwordInp= document.getElementById("passNew");
        const ageInp= document.getElementById("ageNew");
 
        let check = true;
        //validate
        if (check===true){
            createNewPatient({UserName: userNameInp.value, Password: passwordInp.value, Age: parseInt(ageInp.value)});
        }
    });
}


    
    


// // (function ($) {
// //     

// //     var input = $('.validate-input .input100');

// //     $('.validate-form').on('submit',function(){
// //         var check = true;

// //         for(var i=0; i<input.length; i++) {
// //             if(validate(input[i]) == false){
// //                 showValidate(input[i]);
// //                 check=false;
// //             }
// //         }
// //         if (check === true){
// //             authenticateUser()
// //             .then((response)=>{
// //                 alert(response);
// //                 window.location.href = "src/menu/index.html";
                
// //             })
// //             .catch((response)=>{
// //                 alert(response);
// //             });
// //         }

// //         return check;
// //     });


// //     $('.validate-form .input100').each(function(){
// //         $(this).focus(function(){
// //            hideValidate(this);
// //         });
// //     });

//     function validate (input) {
//         if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
//             if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
//                 return false;
//             }
//         }
//         else {
//             if($(input).val().trim() == ''){
//                 return false;
//             }
//         }
//     }

//     // function showValidate(input) {
//     //     var thisAlert = $(input).parent();

//     //     $(thisAlert).addClass('alert-validate');
//     // }

//     // function hideValidate(input) {
//     //     var thisAlert = $(input).parent();

//     //     $(thisAlert).removeClass('alert-validate');
//     // }
    
    

// // })(jQuery);

function authenticateUser(){


    // var validateModel = {
    //     userName: document.getElementsByName("username")[0].value,
    //     password: document.getElementsByName("pass")[0].value
    // };
    
        var validateModel = {
        userName: document.getElementById("username").value,
        password: document.getElementById("pass").value
    };

        var xhttp = new XMLHttpRequest();
        xhttp.withCredentials = true;
    
        return new Promise((resolve, reject) => {
    
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    resolve(JSON.parse(this.responseText));
                }
                if (this.readyState == 4 && this.status !== 200) {
                    const errorMessage = JSON.parse(this.responseText).errorMessage;
                    alert(errorMessage);
                    reject(errorMessage);
                }
            };
            xhttp.open("POST", patientControllerURL+"/authenticate");
            xhttp.setRequestHeader('Content-Type', 'application/json');
            xhttp.setRequestHeader('Accept', 'application/json');
            xhttp.send(JSON.stringify(validateModel));
    
    });
}

$('.message a').click(function(){
    $('form').animate({height: "toggle", opacity: "toggle"}, "slow");
 });


 function createNewPatient(newPatient, url) {

    var xhttp = new XMLHttpRequest();
    xhttp.withCredentials = true;

    return new Promise((resolve, reject) => {

        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 201) {
                resolve(JSON.parse(this.responseText));
            }
            if (this.readyState == 4 && this.status !== 201) {
                const errorMessage = JSON.parse(this.responseText).errorMessage;
                alert(errorMessage);
                reject(errorMessage);
            }
        };
        xhttp.open("POST", "https://localhost:44377/api/patient");
        xhttp.setRequestHeader('Content-Type', 'application/json');
        xhttp.setRequestHeader('Accept', 'application/json');
        var x = JSON.stringify(newPatient);
        xhttp.send(x);
    });

}
    