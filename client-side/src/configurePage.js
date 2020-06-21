function configurePage(columnNames, columnKeys, patientURL) {

    let currentPatient;
    let patientId;
    
    const patientIdInp = document.getElementById("patientIdInp");
    
    if (patientIdInp !== null) {
        patientIdInp.addEventListener("input", function () {
            patientId = parseInt(patientIdInp.value);
            if (isValidPatientId(patientId)) {
                SetViewLocationBtnAvailability(true);
            }
            else {
                SetViewLocationBtnAvailability(false);
            }
        });
    }

    const viewLocationTableBtn = document.getElementById("viewLocationTableBtn");

    if (viewLocationTableBtn !== null) {
        viewLocationTableBtn.addEventListener("click", async function () {
            getPatientById(patientId, patientURL)
            .then((currentPatientFromDbs)=>{
                   currentPatient= currentPatientFromDbs;
                    buildLocationTable(currentPatient, columnNames, columnKeys);
                    SetViewLocationBtnAvailability(false);
               
            })
            .catch(({statusCode, response})=>{
                debugger;
                //returned with no value, patient doesnt exist
                if (statusCode === 204){
                    debugger;
                    createNewPatient(patientId, patientURL)
                    .then((currentPatientFromDbs)=>{
                        currentPatient=currentPatientFromDbs;
                        buildLocationTable(currentPatient, columnNames, columnKeys);
                        SetViewLocationBtnAvailability(false);
                    })
                    .catch(console.log);
                }
                else{
                    alert(`error occured retieving patient: ${response.errorMessage}`);
                }
                
            });

        });
    }

    const addLocationBtn = document.getElementById("addLocationBtn");

    if (addLocationBtn !== null) {
        addLocationBtn.addEventListener("click", function () {
            addLocation(currentPatient, columnKeys);
        });
    }

    function SetViewLocationBtnAvailability(isValidPatientId) {

        if (isValidPatientId === false) {
            viewLocationTableBtn.disabled = true;
        }
        else {
            viewLocationTableBtn.disabled = false;
        }
    }

    function isValidPatientId(patientId) {

        if (Number.isInteger(patientId)) {
            return true;
        }
        else {
            alert("please enter valid patient Id");
            return false;
        }
    }
}

