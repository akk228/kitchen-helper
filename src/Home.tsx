import React,{Component} from "react";
import { BrowserRouter as Router, Route, Link, Routes } from 'react-router-dom';

export default class Home extends Component {
    render(): React.ReactNode {
        return (
            <div className="App">
                <h1>Hi! I'm your kitchen helper!</h1>
                <h3>
                    <Link to="/fridge">Take me to fridge</Link>
                </h3>                
            </div>
        )
    }
}