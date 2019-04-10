import React, { Component } from 'react';

export default class From extends Component {
    constructor(props) {
        super(props)

        this.initialState = {
            name: '',
            age: '',
        }

        this.state = this.initialState;
    }

    handleChange = event => {
        const { name, value } = event.target;
        this.setState({
            [name]: value,
        })
    }

    submitForm = () => {
        this.props.handleSubmit(this.state);
        this.setState(this.initialState);
    }

    render() {
        const { name, age } = this.state;
        return ([
            <form>
                <label>Name</label>
                <input
                    type="text"
                    name="name"
                    value={name}
                    onChange={this.handleChange} />
                <label>Age</label>
                <input
                    type="text"
                    name="age"
                    value={age}
                    onChange={this.handleChange} />
            </form>,
            <input type="button" value="Submit" onClick={this.submitForm} />

        ])
    }
}