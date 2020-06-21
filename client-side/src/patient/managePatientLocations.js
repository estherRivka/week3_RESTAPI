// export async function addLocation(currentPatient, columnKeys) {

//     const startDateInp = document.getElementById("startDateInp");
//     const endDateInp = document.getElementById("endDateInp");
//     const cityInp = document.getElementById("cityInp");
//     const locationInp = document.getElementById("locationInp");


//     if (isValidDetails() === false) {
//         return;
//     }
//     else {
//         const newLocation = {
//             startDate: (((startDateInp.valueAsDate.getMonth() > 8) ? (startDateInp.valueAsDate.getMonth() + 1) : ('0' + (startDateInp.valueAsDate.getMonth() + 1))) + '/' + ((startDateInp.valueAsDate.getDate() > 9) ? startDateInp.valueAsDate.getDate() : ('0' + startDateInp.valueAsDate.getDate())) + '/' + startDateInp.valueAsDate.getFullYear()),
//             endDate: (((endDateInp.valueAsDate.getMonth() > 8) ? (endDateInp.valueAsDate.getMonth() + 1) : ('0' + (endDateInp.valueAsDate.getMonth() + 1))) + '/' + ((endDateInp.valueAsDate.getDate() > 9) ? endDateInp.valueAsDate.getDate() : ('0' + endDateInp.valueAsDate.getDate())) + '/' + endDateInp.valueAsDate.getFullYear()),
//             city: cityInp.value,
//             location: locationInp.value
//         };

//         const locationsTable = document.getElementById("locationsTable");
//         addRowToTable(locationsTable, newLocation, currentPatient, columnKeys);

//         currentPatient.paths.push(newLocation);
//         const response = await updatePatient(currentPatient,patientControllerURL);
//         console.log(response);


//     }

// }



// export function deleteLocation(currentPatient, rowToDelete) {

//     //Get all rows from table as array.
//     const tableBody = rowToDelete.parentNode;
//     const allRows = Array.prototype.slice.call(tableBody.children);

//     deleteRowFromTable(tableBody, rowToDelete);

//     const index = allRows.indexOf(rowToDelete);
//     currentPatient.paths.splice(index - 1, 1);

//     updatePatient(currentPatient,patientControllerURL);

// }