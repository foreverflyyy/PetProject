import React from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import { getPosts } from './blogActions.jsx'

//  ласс Blog, с простой разметкой, который при инициализации запрашивает посты и отображает их
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

// маппит состо€ние приложени€ на переменные-параметры
let mapProps = (state) => {
    return {
        posts: state.data,
        error: state.error
    }
}

// котора€ маппит action на переменные-методы
let mapDispatch = (dispatch) => {
    return {
        getPosts: (index, tags) => dispatch(getPosts(index, tags))
    }
}

// котора€ оборачивает класс-компонент Blog в redux-инфраструктуру и передает ему 
// замапленные параметры в Ц this.props, с которыми мы уже и работает в самом компоненте
export default connect(mapProps, mapDispatch)(Blog) 