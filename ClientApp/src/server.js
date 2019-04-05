import React from 'react';
import ReactDom from 'react-dom';

import Table from './components/Table';
import Form from './components/Form';

export default class Server extends React.Component {
    state = {
        users: [],
    };

    removeUser = index => {
        const { users } = this.state;

        this.setState({
            users: users.filter((user, i) => {
                return i !== index
            })
        })
    }

    handleSubmit = user => {
        this.setState({ users : [...this.state.users, user]});
    }

    render() {
        return (
            [
                <div className="container"><h1> Sample application</h1></div>,
                <div className="container">
                    <Table userData={this.state.users} removeUser={this.removeUser} />
                </div>,
                <div className="container">
                    <Form handleSubmit ={this.handleSubmit} />
                </div>

            ]

        )
    }
}

