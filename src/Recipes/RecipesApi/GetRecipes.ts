import { IRecipe } from "../Recipe";

export class GetRecipes {
    static getAllRecipes(getRecipes: any): void{
        const url = "/Recipes";
        fetch(
            url,
            {
                method: "GET",
                mode: "cors"
            }
        ).then( result => {
            return result.json()})
        .then(result => {
            getRecipes( result as IRecipe[])
        });
    }
}