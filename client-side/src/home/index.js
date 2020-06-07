
const patientControllerURL = "http://localhost:6060/api/patient";

(function ($) {
    "use strict";

    var input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                check=false;
            }
        }
        if (check === true){
            authenticateUser()
            .then((response)=>{
                alert(response);
            })
            .catch((response)=>{
                alert(response);
            });
        }

        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    

})(jQuery);

function authenticateUser(){

    var validateModel = {
        userName: document.getElementsByName("username")[0].value,
        password: document.getElementsByName("pass")[0].value
    };
   

        var xhttp = new XMLHttpRequest();
    
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