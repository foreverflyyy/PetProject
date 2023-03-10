import React from 'react';
import { Link } from 'react-router-dom';

export default class Header extends React.Component {
    render() {
        return (
            <header>
                <menu>
                    <ul>
                        <li>
                            <Link to="/">����</Link>
                        </li>
                        <li>
                            <Link to="/about">��� ���</Link>
                        </li>
                    </ul>
                </menu>
            </header>
        );
    }
};