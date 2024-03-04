import React, { Component, useState } from "react";
import { IProduct, Product } from "./Product";
import { AddProductForm } from "./AddProduct";
import { FridgeContent } from "./FridgeApi/GetProducts";

interface IFridgeState {
    addEnabled: boolean;
    products: IProduct[];
}

class Fridge extends Component<any, IFridgeState> {
    constructor(props: IFridgeState) {
        super(props);
        this.state = {
            addEnabled: false,
            products: []
        }

    }

    addProduct(): void {
        FridgeContent.getFridgecontent((content: any) => this.setState({ products: content, addEnabled: false }));
    }

    onDelete() {
        FridgeContent.getFridgecontent((content: any) => this.setState({ products: content }));
    }

    handleAddItemMenu() {
        this.setState({ addEnabled: !this.state.addEnabled })
    }

    public render(): React.ReactNode {
        return (
            <>
                <button
                    onClick={this.handleAddItemMenu.bind(this)}>
                    {!this.state.addEnabled ? 'Add Item' : 'Cancel'}
                </button>
                {this.state.addEnabled && 
                <AddProductForm onAdd={this.addProduct.bind(this)} />}
                <div>
                    {this.state.products?.map((product) => 
                        <Product 
                            callback={this.onDelete.bind(this)} 
                            product={product}
                        />)}
                </div>
            </>
        );
    }

    componentDidMount(): void {
        FridgeContent.getFridgecontent((content: any) => this.setState({ products: content }));
    }
}

export default Fridge;