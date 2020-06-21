"use strict";
import { configureAddLocationBtn, configurePatientIdInp, configureViewLocationsBtn } from "configurePage.js";
import { addRowToTable, deleteRowFromTable } from "table.js";
import { isValidDetails } from "validation.js";
import { updatePatient, getPatientById } from "httpRequests.js";
import { enableViewTableBtn, resetNewLocationInputs, showAddLocationDiv } from "styleConfiguration.js";
import { buildLocationsTable } from "table.js";


//const patientControllerURL = "https://localhost:44377/api/patient";

const columnNames = ["Start Date", "End Date", "City", "Location"];
const columnKeys = ["startDate", "endDate", "city", "location"];


window.onload = ()=> {

    let currentPatient;

    configureViewLocationsBtn(async() => {

        const patientIdInp = document.getElementById("patientIdInp");
        currentPatient = await getPatientById(patientIdInp.value);

        buildLocationsTable(currentPatient, columnNames, columnKeys);

        resetNewLocationInputs(columnNames);

        enableViewTableBtn();

        showAddLocationDiv();
    });

    configureAddLocationBtn(() => addLocation(currentPatient, columnKeys));
    
};




async function addLocation(currentPatient, columnKeys) {

    const LocationInputs = {
        startDateInp: document.getElementById("startDateInp"),
        endDateInp: document.getElementById("endDateInp"),
        cityInp: document.getElementById("cityInp"),
        locationInp: document.getElementById("locationInp")
    };


    if (isValidDetails(LocationInputs) === false) {
        return;
    }
    else {
        const newLocation = {
            startDate: (((LocationInputs.startDateInp.valueAsDate.getMonth() > 8) ? (LocationInputs.startDateInp.valueAsDate.getMonth() + 1) : ('0' + (LocationInputs.startDateInp.valueAsDate.getMonth() + 1))) + '/' + ((LocationInputs.startDateInp.valueAsDate.getDate() > 9) ? LocationInputs.startDateInp.valueAsDate.getDate() : ('0' + LocationInputs.startDateInp.valueAsDate.getDate())) + '/' + LocationInputs.startDateInp.valueAsDate.getFullYear()),
            endDate: (((LocationInputs.endDateInp.valueAsDate.getMonth() > 8) ? (LocationInputs.endDateInp.valueAsDate.getMonth() + 1) : ('0' + (LocationInputs.endDateInp.valueAsDate.getMonth() + 1))) + '/' + ((LocationInputs.endDateInp.valueAsDate.getDate() > 9) ? LocationInputs.endDateInp.valueAsDate.getDate() : ('0' + LocationInputs.endDateInp.valueAsDate.getDate())) + '/' + LocationInputs.endDateInp.valueAsDate.getFullYear()),
            city: LocationInputs.cityInp.value,
            location: LocationInputs.locationInp.value
        };

        const locationsTable = document.getElementById("locationsTable");
        addRowToTable(locationsTable, newLocation, currentPatient, columnKeys);

        currentPatient.paths.push(newLocation);

        const response = await updatePatient(currentPatient);
        console.log(response);


    }

}


export function deleteLocation(currentPatient, rowToDelete) {

    //Get all rows from table as array.
    const tableBody = rowToDelete.parentNode;
    const allRows = Array.prototype.slice.call(tableBody.children);

    deleteRowFromTable(tableBody, rowToDelete);

    const index = allRows.indexOf(rowToDelete);
    currentPatient.paths.splice(index - 1, 1);

      const response =updatePatient(currentPatient);
      console.log(response);
}
















