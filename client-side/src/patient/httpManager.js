export class httpManager {

    static get(url) {

        var xhttp = new XMLHttpRequest();
        xhttp.withCredentials = true;
    
        return new Promise((resolve, reject) => {
    
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    resolve(JSON.parse(this.responseText));
                }
                if (this.readyState == 4 && this.status !== 200) {                     
                    reject({ statusCode:this.status, response: JSON.parse(this.responseText)});
                }
            };
            xhttp.open("GET",url);
            xhttp.send();
        });
        
    }

    static post(url, data) {

        var xhttp = new XMLHttpRequest();
        xhttp.withCredentials = true;
    
        return new Promise((resolve, reject) => {
    
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && (this.status == 201 || this.status == 200)) {
            //        resolve(JSON.parse(this.responseText));

                    resolve();
                }
                if (this.readyState == 4 && this.status != 201 && this.status !=200) {
                    const errorMessage = JSON.parse(this.responseText).errorMessage;
                    alert(errorMessage);
                    reject(errorMessage);
                }
            };
            xhttp.open("POST", url);
            xhttp.setRequestHeader('Content-Type', 'application/json');
            xhttp.setRequestHeader('Accept', 'application/json');
            xhttp.send(data);
        });
    
    
    }

    static put(url, data) {

        
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
        xhttp.open("PUT", url);
        xhttp.setRequestHeader('Content-Type', 'application/json');
        xhttp.setRequestHeader('Accept', 'application/json');
        xhttp.send(data);
    });
    }
}
