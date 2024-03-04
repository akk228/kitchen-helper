import React from "react";
import { IRecipe, Recipe } from "./Recipe";

interface ICooking{
    recipe: IRecipe
}

export class Cooking extends React.Component<IRecipe, ICooking>{

    static getDerivedStateFromProps(props: IRecipe, state: ICooking){
        return { recipe: props};
    }

    handleTakeIngredients(){
        alert("Confirm taking")
    }

    render(): React.ReactNode {
        return (
            <>
                <button onClick={this.handleTakeIngredients}>Take ingredients from fridge</button>
            </>
            );
    }
}