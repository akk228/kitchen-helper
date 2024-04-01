import React from "react";
import { IRecipe, Recipe} from "./Recipe";

import { GetRecipes } from "./RecipesApi/GetRecipes";

interface IRecipes {
    recipes: IRecipe[]
}
export class Recipes extends React.Component<any, IRecipes>{
    constructor(props: any){
        super(props)
        this.state = { recipes: []}
    }

    getAllRecipes(): void {
        GetRecipes.getAllRecipes((content: IRecipe[]) => this.setState({recipes: content}))
    }

    render(): React.ReactNode {
        return (
        <div className="centered-div">
            <h1>List of recipes</h1>
            <div>
                {this.state.recipes
                .map((recipe: IRecipe) => {
                    return (
                        <Recipe
                            recipe={recipe}
                            onChange={this.getAllRecipes.bind(this)}/>
                        )})}
            </div>
        </div>)
    }

    componentDidMount(): void {
       this.getAllRecipes();
    }
}