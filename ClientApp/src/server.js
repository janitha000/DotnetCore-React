import React from 'react';
import ReactDom from 'react-dom';

import Table from './components/Table';

export default class Server extends React.Component {

    render() {
        return (
            [
                <div className="container"><h1> Sample application</h1></div>,
                <div className="container">
                    <Table />
                </div>

            ]

        )
    }
}

