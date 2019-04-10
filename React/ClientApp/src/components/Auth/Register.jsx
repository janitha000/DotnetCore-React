import React, { Component } from 'react';

export default class Register extends Component {
    constructor(props) {
        super(props)

        this.initialState = {
            name: '',
            email: '',
            password : '',
        }

        this.state = this.initialState;
    }

    submitForm = () => {
        fetch('http://localhost:5000/api/auth/register', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: this.state.name,
                email: this.state.email,
                password: this.state.password,
            })
        })
    }

    handleChange = event => {
        const { name, value } = event.target;
        this.setState({
            [name]: value,
        })
    }

    render() {
        const { name, email, password } = this.state;
        return ([
            <form>
                <label>Name</label>
                <input
                    type="text"
                    name="name"
                    value={name}
                    onChange={this.handleChange}
                />
                <label>Email</label>
                <input
                    type="text"
                    name="email"
                    value={email}
                    onChange={this.handleChange}
                />
                <label>Password</label>
                <input
                    type="text"
                    name="password"
                    value={password}
                    onChange={this.handleChange}
                />
            </form>,
            <input type="button" value="Submit" onClick={this.submitForm} />

        ])
    }

}