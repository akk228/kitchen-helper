import React from "react";
import { IRecipe, Recipe} from "./Recipe";

import { GetRecipes } from "./RecipesApi/GetRecipes";

interface IRecipes {
    recipes: IRecipe[]
}
export class Recipes extends React.Component<{}, IRecipes>{

    render(): React.ReactNode {
        return (
        <div className="centered-div">
            <h1>
                List of recipes
            </h1>
            <div>
                {this.state?.recipes?.map(recipe => {
                    return (
                        <Recipe {...recipe}/>
                        );
                })}
            </div>
        </div>)
    }

    componentDidMount(): void {
        GetRecipes.getAllRecipes((content: IRecipe[]) => {
            this.setState({ recipes: content })
        })
    }
}