import { IRecipe } from "../../Recipes/Recipe";

export class Ready2GoRecipes {
    static getRecipes(getRecipes: (recipes: IRecipe[]) => void): void
    {
        const url = "Cooking/ReadyToGo";
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