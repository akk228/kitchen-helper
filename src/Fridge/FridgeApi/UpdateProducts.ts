import { get } from "http";
import { IProduct, Product } from "../Product";

export class UpdateFridgeContent {
    static addProduct(product: IProduct, callbackOnSuccess: any, callbackOnFailure: any): void {
        const url: string = "/Fridge/addProduct";

        fetch(
            url,
            {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                mode: "cors",
                body: JSON.stringify(product)
            })
            .then(result => {
                return result;
            })
            .finally(() => callbackOnSuccess());

    }

    static deleteProduct(product: IProduct, callbackOnSuccess: any, callbackOnFailure: any): void {
        const url: string = "/Fridge/deleteProduct";

        fetch(
            url,
            {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "DELETE",
                mode: "cors",
                body: JSON.stringify(product)
            }).finally(() => callbackOnSuccess());

    }
}
