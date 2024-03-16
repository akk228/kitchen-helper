import React from "react";
import { IRecipe } from "./Recipe";
import { Cook } from "./RecipesApi/Cook";

interface ICooking{
    recipe: IRecipe
}

export class Cooking extends React.Component<IRecipe, ICooking>{

    static getDerivedStateFromProps(props: IRecipe, state: ICooking){
        return { recipe: props};
    }

    handleTakeIngredients(){
        Cook.takeProducts(this.state.recipe.ingredients, ()=>{}, undefined)
    }

    render(): React.ReactNode {
        return  <button onClick={this.handleTakeIngredients.bind(this)}>Take ingredients from fridge</button>;
    }
}