import React from 'react';
import ReactDom from 'react-dom';

import Table from './components/Table';

export default class Server extends React.Component {
    state = {
        users : [
            {
              name: 'Charlie',
              job: 'Janitor',
            },
            {
              name: 'Mac',
              job: 'Bouncer',
            },
            {
              name: 'Dee',
              job: 'Aspring actress',
            },
            {
              name: 'Dennis',
              job: 'Bartender',
            },
          ],
    };

    removeUser = index => {
        const { users } = this.state;

        this.setState({
            users : users.filter((user, i) => {
                return i !== index
            })
        })
    }

    render() {
        return (
            [
                <div className="container"><h1> Sample application</h1></div>,
                <div className="container">
                    <Table userData = {this.state.users} removeUser = {this.removeUser} />
                </div>

            ]

        )
    }
}

