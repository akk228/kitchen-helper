import React from "react";
import { IProduct, Product } from "./Product";
import '../App.css';

interface IProductTableProps{
    products: IProduct[],
    onProductsChange: () => void
    edit: boolean
}

export default class ProductTable extends React.Component<IProductTableProps, IProduct[]>{
    static getDerivedStateFromProps(props: IProduct[], state: IProduct[]){
        return  props;
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
                        callback={this.props.onProductsChange}
                        edit={this.props.edit}
                    />})
                }
            </table>
        );
    }
}