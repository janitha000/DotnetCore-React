import React, { Component } from 'react';

export default class ApiData extends Component {
    state = { data: [] };

    componentDidMount() {
        const url = 'http://localhost:5000/api/test'

        fetch(url)
        .then(result => result.json())
            .then(result => {
                this.setState({ data: result });
            });
    }

    render() {
        const { data } = this.state;

        // const result = data.map((entry, index) => {
        //     return <li key={index}>{entry}</li>
        // })

        // return <ul>{result}</ul>
        return <ul>{data}</ul>
    }
}

