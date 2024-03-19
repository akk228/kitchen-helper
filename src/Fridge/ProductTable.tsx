import React from "react";
import { IProduct, Product } from "./Product";
import '../App.css';

interface IProductTableProps{
    products: IProduct[],
    onProductsChange: (product: IProduct) => void
    edit: boolean
}

export default class ProductTable extends React.Component<IProductTableProps, IProduct[]>{
    static getDerivedStateFromProps(props: IProduct[], state: IProduct[]){
        return  props;
    }

    handleProductChange(product: IProduct){
        this.props.onProductsChange(product)
    }

    render(): React.ReactNode {
        return(
            <table className="table">
                <tr>
                    <th scope="col">Name</th>
                    <th scope="col">Amount</th>
                    <th scope="col">Units</th>
                </tr>
                {
                this.props.products?.map( product => 
                    {return <Product 
                        product={product} 
                        onProductChange={this.handleProductChange.bind(this, product)}
                        edit={this.props.edit}
                    />})
                }
            </table>
        );
    }
}