import React from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import { getPosts } from './blogActions.jsx'

// ����� Blog, � ������� ���������, ������� ��� ������������� ����������� ����� � ���������� ��
class Blog extends React.Component {

    componentDidMount() {
        this.props.getPosts(0);
    }

    render() {
        let posts = this.props.posts.records.map(item => {
            return (
                <div key={item.postId} className="post">
                    <div className="header">{item.header}</div>
                    <div className="content">{item.body}</div>
                    <hr />
                </div>
            );
        });

        return (
            <div id="blog">
                {posts}
            </div>
        );
    }
};

// ������ ��������� ���������� �� ����������-���������
let mapProps = (state) => {
    return {
        posts: state.data,
        error: state.error
    }
}

// ������� ������ action �� ����������-������
let mapDispatch = (dispatch) => {
    return {
        getPosts: (index, tags) => dispatch(getPosts(index, tags))
    }
}

// ������� ����������� �����-��������� Blog � redux-�������������� � �������� ��� 
// ����������� ��������� � � this.props, � �������� �� ��� � �������� � ����� ����������
export default connect(mapProps, mapDispatch)(Blog) 