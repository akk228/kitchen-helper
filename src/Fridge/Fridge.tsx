import React, { Component } from "react";
import { IProduct, Product } from "./Product";
import { AddProductForm } from "./AddProduct";
import { FridgeContent } from "./FridgeApi/GetProducts";
import ProductTable from "./ProductTable";
import { UpdateFridgeContent } from "./FridgeApi/UpdateProducts";
import '../App.css';

interface IFridgeState {
    addEnabled: boolean;
    products: IProduct[];
}

class Fridge extends Component<any, IFridgeState> {
    constructor(props: any){
        super(props);
        this.state = {
            addEnabled: false,
            products: []
        }
    }

    handleAddItemMenu() {
        this.setState({ addEnabled: !this.state.addEnabled })
    }

    handleAddProduct(product: IProduct): void {
        UpdateFridgeContent.addProduct(
            product,
            this.handleStateChange.bind(this),
            undefined);
    }

    handleStateChange(): void {
        FridgeContent.getFridgecontent((content: any) => this.setState({ products: content, addEnabled: false }));
    }

    handleDeleteProduct(product: IProduct){
        UpdateFridgeContent.deleteProduct(
            product, 
            () => this.setState({
                products: this.state.products.filter(x => 
                    x.name.toLowerCase() !== product.name.toLowerCase())
            }),
            undefined);
    }

    public render(): React.ReactNode {
        return (
            <div className="centered-div">
                <button
                    onClick={this.handleAddItemMenu.bind(this)}>
                    {!this.state.addEnabled ? 'Add Item' : 'Cancel'}
                </button>
                {this.state.addEnabled && 
                <AddProductForm 
                    onAdd={this.handleAddProduct.bind(this)} 
                />}
                <ProductTable 
                    products={this.state.products} 
                    onProductsChange={this.handleDeleteProduct.bind(this)}
                    edit={true}
                />
            </div>
        );
    }

    componentDidMount(): void {
        this.handleStateChange();
    }
}

export default Fridge;