import React from "react";
import { IRecipe } from "./Recipe";
import ProductTable from "../Fridge/ProductTable";
import { AddProductForm } from "../Fridge/AddProduct";
import { IProduct } from "../Fridge/Product";

interface IAddRecipeFormState {
    recipe: IRecipe,
    addProductEnabled: boolean
}

export default class AddRecipeForm extends React.Component<any, IAddRecipeFormState> {
    constructor(props: any){
        super(props)
        this.state = {
            recipe:{
                name: "",
                description: "",
                ingredients: []
            },
            addProductEnabled: false
        }
    }

    handleAddEnabled(event: any): void{
        event.preventDefault();
        this.setState({ addProductEnabled: !this.state.addProductEnabled})
    }

    handleAddProduct(product: IProduct): void {
        this.setState({ 
            recipe: { 
                ...this.state.recipe, 
                ingredients: [...this.state.recipe.ingredients, product]
            },
            addProductEnabled: false
            });
    }

    handleDeleteProduct(): void {

    }

    render(): React.ReactNode {
        return (
            <div className="centered-div">
            <form>
                <label>Name</label>
                <br />
                <input
                    type="text"
                    value={this.state.recipe.name}
                    onChange={(e) => {
                        e.preventDefault();
                        this.setState({ recipe: {...this.state.recipe, name: e.target.value} });
                    }}
                />
                <br />
                 <label>Description</label>
                <br />
                <textarea
                    value={this.state.recipe.description?.toString()}
                    onChange={(e) => {
                        e.preventDefault();
                        this.setState({ recipe: {...this.state.recipe, description: e.target.value} });
                    }}
                    rows={5}
                    cols={50}
                />
                
            </form>
            <button
                onClick={this.handleAddEnabled.bind(this)}>
                {!this.state.addProductEnabled ? 'Add Item' : 'Cancel'}
            </button>
            {this.state.addProductEnabled && 
            <AddProductForm 
                onAdd={this.handleAddProduct.bind(this)} 
            />}
            {this.state.recipe.ingredients.length !== 0 &&
                <ProductTable
                    products={this.state.recipe.ingredients}
                    onProductsChange={this.handleDeleteProduct.bind(this)}
                    edit={true}
                />
            }    
            </div>        
        );
    }
}