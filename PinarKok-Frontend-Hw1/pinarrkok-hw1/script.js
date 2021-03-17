const todoForm = document.querySelector('.todo-form');
const todoInput = document.querySelector('.todo-input');
const todoItemsList = document.querySelector('.todo-items');

let todoArray = [];

todoForm.addEventListener('submit', function(event) {
  event.preventDefault();
  addTodo(todoInput.value);
});

function addTodo(item) {
  if (item !== '') {
    const todo = {
      id: Date.now(),
      name: item,
      completed: false
    };

    todoArray.push(todo);
    addToLocalStorage(todoArray);

    todoInput.value = '';
  }
}

function renderTodos(todoArray) {
  todoItemsList.innerHTML = '';

  todoArray.forEach(function(item) {
    const checked = item.completed ? 'checked': null;
    const li = document.createElement('li');

    li.setAttribute('class', 'item');
    li.setAttribute('data-key', item.id);
    if (item.completed === true) {
      li.classList.add('checked');
    }

    li.innerHTML = `
      <input type="checkbox" class="checkbox" ${checked}>
      ${item.name}
      <button class="delete-button">X</button>
    `;
    todoItemsList.append(li);
  });

}

function addToLocalStorage(todoArray) {
  localStorage.setItem('todos', JSON.stringify(todoArray));
  renderTodos(todoArray);
}

function getFromLocalStorage() {
  const reference = localStorage.getItem('todos');
  if (reference) {
    todoArray = JSON.parse(reference);
    renderTodos(todoArray);
  }
}

function toggle(id) {
  todoArray.forEach(function(item) {
    if (item.id == id) {
      item.completed = !item.completed;
    }
  });

  addToLocalStorage(todoArray);
}

function deleteTodo(id) {
  todoArray = todoArray.filter(function(item) {
    return item.id != id;
  });

  addToLocalStorage(todoArray);
}

getFromLocalStorage();

todoItemsList.addEventListener('click', function(event) {
  if (event.target.type === 'checkbox') {
    toggle(event.target.parentElement.getAttribute('data-key'));
  }

  if (event.target.classList.contains('delete-button')) {
    deleteTodo(event.target.parentElement.getAttribute('data-key'));
  }
});