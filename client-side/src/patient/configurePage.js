"use strict";
import { isValidPatientId } from "validation.js";
import { enableViewLocationsBtn, disableViewLocationsBtn } from "./styleConfiguration";


export function configureViewLocationsBtn(onClickCallBack) {

    const viewLocationsBtn = document.getElementById("viewLocationsBtn");
    const patientIdInp = document.getElementById("patientIdInp");
    let patientId;

    patientIdInp.addEventListener("input", function () {

        patientId = parseInt(patientIdInp.value);

        if (isValidPatientId(patientId)) {
            enableViewLocationsBtn();
        }
        else {
            disableViewLocationsBtn();
        }
    });

    viewLocationsBtn.addEventListener("click", onClickCallBack);

}

export function configureAddLocationBtn(onClickCallback) {

    const addLocationBtn = document.getElementById("addLocationBtn");
    addLocationBtn.addEventListener("click", onClickCallback);
}