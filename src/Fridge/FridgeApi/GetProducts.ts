import {IProduct, Product} from "../Product";

export class FridgeContent {
    static getFridgecontent(callback:any): void {
        const callToFridge = new Promise<IProduct[]>(function (resolve, reject){
            const getProductsCall: XMLHttpRequest = new XMLHttpRequest();
            const url: string = "http://localhost:5149/Fridge/Content";
    
            getProductsCall.onreadystatechange = function() {
                if (this.readyState == 4 && this.status == 200) {
                    let listOfProducts: IProduct[] = JSON.parse(this.responseText);
                    resolve(listOfProducts);
                }else if(this.readyState == 4 && this.status != 200){
                    reject(null);
                }                
            };
    
            getProductsCall.open("GET", url, true);
            getProductsCall.send();
        });
        
        callToFridge.then(
            result => callback(result),
            failure =>{}
        )
    }
}
