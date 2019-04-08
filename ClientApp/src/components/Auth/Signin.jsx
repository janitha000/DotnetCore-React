import React, { Component } from 'react';

export default class Signin extends Component{
    constructor(props){
        super(props);

        this.initialState = {
            username : '',
            password : ''
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
        fetch('http://localhost:5000/api/auth/signin', {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              username: this.state.username,
              password: this.state.password,
            })
          })
    }

    render() {
        const { username, password } = this.state;
        return ([
            <form>
                <label>UserName</label>
                <input
                    type="text"
                    name="name"
                    value={username} 
                    />
                <label>Password</label>
                <input
                    type="text"
                    name="password"
                    value={password} 
                    />
            </form>,
            <input type="button" value="Submit" onClick={this.submitForm} />

        ])
    }
}