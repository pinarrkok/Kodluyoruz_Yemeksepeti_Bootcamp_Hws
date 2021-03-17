import './App.css';
import React from 'react';
import SubmitForm from './SubmitForm';
import Header from './Header';
import TodoList from './TodoList';

class App extends React.Component {
  state = {
    tasks: ['task 1', 'task 2', 'task 3']
  };

  handleSubmit = task => {
    this.setState({tasks: [...this.state.tasks, task]});
  }
  
  handleDelete = (index) => {
    const newArr = [...this.state.tasks];
    newArr.splice(index, 1);
    this.setState({tasks: newArr});
  }

  render() {
    return(
      <div className='wrapper'>
        <div className='card frame'>
          <Header numTodos={this.state.tasks.length} />
          <TodoList tasks={this.state.tasks} onDelete={this.handleDelete} />
          <SubmitForm onFormSubmit={this.handleSubmit} />
        </div>
      </div>
    );
  } 
}

export default App;