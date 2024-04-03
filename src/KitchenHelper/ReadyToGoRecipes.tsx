import React from "react";
import { IRecipe } from "../Recipes/Recipe";
import { Ready2GoRecipes } from "./CookingApi/Ready2GoRecipes";
import { Recipe } from "../Recipes/Recipe";
interface IReadyToGoRecipesProps{

}

interface IReadyToGoRecipesState{
    recipes: IRecipe[]
}

export default class ReadyToGoRecipes extends React.Component<any,IReadyToGoRecipesState>{
    constructor(props: any){
        super(props)
        this.state = {
            recipes: []
        }

    }
    handleCHange(): void {
        Ready2GoRecipes.getRecipes( (result) => this.setState({ recipes: result}))  
    }

    render(): React.ReactNode {
        return (
            <div className="centered-div">
            <h1>List of recipes ready for cooking</h1>
            <div>
                {this.state.recipes?.map((recipe: IRecipe) => {
                    return (
                        <Recipe
                            recipe={recipe}
                            onChange={this.handleCHange.bind(this)}/>
                        )})}
            </div>
        </div>);
    }

    componentDidMount(): void {
        Ready2GoRecipes.getRecipes( (result) => this.setState({ recipes: result}))
    }
}