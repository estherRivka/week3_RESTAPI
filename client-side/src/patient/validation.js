
"use strict";

 export function isValidPatientId(patientId) {

        if (Number.isInteger(patientId)) {
            return true;
        }
        else {
            alert("please enter valid patient Id");
            return false;
        }
}

 export function isValidDetails(LocationInputs) {
        if (LocationInputs.startDateInp === null || LocationInputs.endDateInp === null || LocationInputs.cityInp === null || LocationInputs.locationInp === null) {
            return false;
        }
        if (LocationInputs.startDateInp.value === "" || LocationInputs.endDateInp.value === "" || LocationInputs.cityInp.value === "" || LocationInputs.locationInp.value === "") {
            alert("invalid details");
            return false;
        }
        if ((Date.parse(LocationInputs.startDateInp.value) >= Date.parse(LocationInputs.endDateInp.value))) {
            alert("End date should be greater than Start date");
            LocationInputs.endDateInp.value = "";
            return false;
        }
        else {
            return true;
        }
    
    }