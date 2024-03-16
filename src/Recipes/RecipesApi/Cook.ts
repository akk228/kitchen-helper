import { IProduct } from "../../Fridge/Product";

export class Cook {
    static takeProducts(products: IProduct[], callbackOnSuccess: any, callbackOnFailure: any): void {
        const url: string = "/Fridge/takeProducts";

        fetch(
            url,
            {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "PUT",
                mode: "cors",
                body: JSON.stringify(products)
            })
        .then(result => {
                if(result.status === 200){
                    alert("Ingredients taken, get to cooking!");
                    return result;
                }else{
                    alert("Not enought products");
                }
            })
    }
}
