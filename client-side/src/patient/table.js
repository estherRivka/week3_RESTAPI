"use strict";
import { deleteLocation }  from "index.js";
import { resetNewLocationInputs } from "styleConfigurration.js";

const columnNames = ["Start Date", "End Date", "City", "Location"];
const columnKeys = ["startDate", "endDate", "city", "location"];

export function buildLocationTable(currentPatient, columnNames, columnKeys) {

    const columnCount = columnNames.length;

    //Get 'add new location' inputs.
    // const newLocationInputs = document.getElementsByClassName("addLocationInp");

    const table = document.createElement("TABLE");
    table.setAttribute("id", "locationsTable");
    table.border = "1";

    // Add the header row.
    const row = table.insertRow(-1);

    for (let i = 0; i < columnCount; i++) {
        const headerCell = document.createElement("TH");
        headerCell.dataset.id = i;
        headerCell.setAttribute("type", "text");
        headerCell.addEventListener("click", function () {
            sortLocationTableByColumn(currentPatient, columnNames, columnKeys, i);
        });
        headerCell.innerHTML = columnNames[i];
        row.appendChild(headerCell);

    }

    //  Add the data rows.
    for (let i = 0; i < currentPatient.paths.length; i++) {
        addRowToTable(table, currentPatient.paths[i], currentPatient, columnKeys);
    }

    const tableDv = document.getElementById("tableDv");
    tableDv.innerHTML = "";
    tableDv.appendChild(table);


}





export function addRowToTable(table, newLocation, currentPatient, columnKeys) {

    const row = table.insertRow(-1);

    for (let key of columnKeys) {
        let cell = row.insertCell(-1);
        cell.innerHTML = newLocation[key];
    }

    const deleteCell = row.insertCell(-1);
    const deleteBtn = document.createElement("BUTTON");
    deleteBtn.innerHTML = "Delete";
    deleteBtn.addEventListener("click", function () {
        deleteLocation(currentPatient, row);
    });
    deleteCell.appendChild(deleteBtn);

}

export function deleteRowFromTable(table, rowToDelete){

    table.removeChild(rowToDelete);
    
}

export function sortLocationTableByColumn(currentPatient, columnNames, columnKeys, columnIndex) {

    const sortByKey = columnKeys[columnIndex];
    currentPatient.paths.sort((a, b) => a[sortByKey].localeCompare(b[sortByKey]));
    
    resetNewLocationInputs();
    buildLocationTable(currentPatient, columnNames, columnKeys);
}
