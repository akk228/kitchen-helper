import { callbackify } from "util";
import { IRecipe } from "../Recipe";

export default class UpdateRecipes 
{

    static add(recipe: IRecipe, callBack: () => void): void
    {
        const url = "/Recipes";
        const body =  JSON.stringify(recipe);
        fetch(
            url,
            {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                mode: "cors",
                body: body,
            
            }
        ).then( result => {
            if(result.status === 200) {
                callBack();
            }else{
                alert("Such recipe exists already.")
            }
            },
            failure => alert("failed"));
    }
    
    static put(callback: () => void): void
    {
        const url = "/Recipes";
        fetch(
            url,
            {
                method: "PUT",
                mode: "cors"
            }
        ).then( result => {
            return result.json()})
        .then(
            result => {
                if(result.status === 200) {
                    callback()
                }else{
                    alert("Couldn't change anything")
                }
            },
            failure => {
                alert("Failed to modify");
            }
        );
    }

    
    static delete(recipeName: string, callback: () => void): void
    {
        const url = "/Recipes/" + recipeName;
        fetch(
            url,
            {
                method: "DELETE",
                mode: "cors"
            }
        )
        .then(
            result => {
                if(result.status === 200) {
                    return result.json();
                }else{
                    alert("Couldn't delete recipe")
                }
            },
            failure => {
                alert("Failed to delete");
            }
        )
        .then(result => {
            if(result == true){
                callback();
            }
        });
    }
}