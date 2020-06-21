"use strict";

export function resetNewLocationInputs(inputPlaceholders){

    //Get 'add new location' inputs.
    const newLocationInputs = document.getElementsByClassName("addLocationInp");

    const inputCount = newLocationInputs.length;

        for (let i = 0; i < inputCount; i++) {

           newLocationInputs[i].value = '';
           newLocationInputs[i].setAttribute("placeholder", inputPlaceholders[i]);
        }


}

export function enableViewLocationsBtn(){

    const viewLocationsBtn = document.getElementById("viewLocationTableBtn");
 
    viewLocationsBtn.disabled = false;
}

export function disableViewLocationsBtn(){

    const viewLocationsBtn = document.getElementById("viewLocationTableBtn");
 
    viewLocationsBtn.disabled = true;
}

export function showAddLocationDiv(){

    document.getElementById("addLocationDv").style.display = "block";
}