using System.Collections.Generic;

namespace ToDo
{
    public class TodoLogic
    {   
        private Dictionary<int, TodoModel> _cache = new Dictionary<int, TodoModel>();
        public void Add(TodoModel newTodo)
        {
            _cache.Add(newToDo.Key, newTodo);
        }
        public void Update(TodoModel newTodo)
        {
            _cache.Update(newTodo.Key, newTodo);
            var exisitingTodo =_cache[updatedTodo.Key];
            exisitingTodo.Priority = updatedTodo.Priority;
            existingTodo.Title = updatedTodo.Title;
            existingTodo.Details = updatedTodo.Details;
        }
        public List<TodoModel> Read()
        {
            var allTodos = new List<TodoModel>();
            var keys = _cache.Keys;
            foreach (var key in keys)
            {
                allTodos.Add(_cache[key]);
            }
            return allTodos;
            //stuff and things XD
        }
        public void Delete(TodoModel noLongerNeededTodo)
        {
            _cache.Delete(newTodo.Key, newTodo);
            cache.Remove(noLongerNeededTodo.Key);
        }
    }
}