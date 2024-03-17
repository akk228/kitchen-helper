import { IRecipe } from "../Recipe";

export default class UpdateRecipes 
{

    static add(recipe: IRecipe, getNewRecipeCollection: () => void): void
    {
        const url = "/Recipes";
        fetch(
            url,
            {
                method: "POST",
                mode: "cors",
                body: JSON.stringify(recipe),
            }
        ).then( result => {
            return result.json()})
        .then(
            result => {
                if(result.status === 200) {
                    getNewRecipeCollection()
                }else{
                    alert("Such recipe exists already.")
                }
            },
            failure => {
                alert("Failed to add recipe")
            }
        );
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