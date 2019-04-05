import React, { Component } from 'react'

export default class Table extends Component {
    render() {
        const { userData , removeUser } = this.props;

        return (
            <table>
                <TableHeader />
                <TableBody userData={userData} removeUser = {removeUser}/>
            </table>
        )
    }
}

const TableBody = props => {
    const rows = props.userData.map((row, index) => {
        return (
            <tr key={index}>
                <td>{row.name}</td>
                <td>{row.age}</td>
                <td><button onClick={() => props.removeUser(index)}>Delete</button></td>
            </tr>
        )
    })

    return <tbody>{rows}</tbody>

}

const TableHeader = () => {
    return (
        <thead>
            <tr>
                <th>Name</th>
                <th>Age</th>
                <th>Delete</th>
            </tr>
        </thead>
    )
}
