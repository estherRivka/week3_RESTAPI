"use strict";

import {httpManager} from "httpManager.js";

export class PatientHttpRequestManager{

  constructer(){
    this.patientControllerURL = "https://localhost:44377/api/patient";
  }

   static getPatientById(currentPatientId) {

    return  httpManager.get(`${this.patientControllerURL}/GetById/${currentPatientId}`);
  
  }
  
static updatePatient(updatedPatient) {
  
      return httpManager.put(this.patientControllerURL,JSON.stringify(updatedPatient));
  
  }

}

